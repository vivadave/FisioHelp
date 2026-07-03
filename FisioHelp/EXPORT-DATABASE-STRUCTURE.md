# Struttura del database "FisioHelp" — guida per la migrazione dati

Questo documento descrive lo schema del database sorgente di **FisioHelp**, un gestionale
per studi di fisioterapia (mono-terapeuta per installazione), usato per preparare
l'esportazione/migrazione dei dati verso un altro gestionale. L'obiettivo è dare al
sistema di destinazione (o a chi scrive lo script di importazione) il contesto semantico
necessario per mappare correttamente i campi, non solo i loro tipi SQL.

## Contesto generale

- **Motore**: PostgreSQL. Tutte le tabelle hanno chiave primaria `id uuid` generata con
  `uuid_generate_v4()` (estensione `uuid-ossp`).
- **Multi-tenancy**: il database è **mono-terapeuta**. La tabella `therapists` contiene
  tipicamente **una sola riga** (l'applicazione fa sempre `SELECT ... FROM therapists
  LIMIT 1` / `FirstOrDefault()`): rappresenta lo studio/professionista titolare
  dell'installazione, non un elenco di terapisti multipli in uso concorrente. Il campo
  `therapist_id` presente in molte tabelle è quindi quasi un vincolo di integrità storico
  più che un vero discriminante multi-tenant: nella pratica avrà sempre lo stesso valore.
- **Localizzazione**: lo studio opera in un'area bilingue italiano/tedesco (Alto Adige/Südtirol).
  Diversi campi hanno varianti `_it` / `_de` (es. `treatments.description_it/_de`,
  `therapists.address` vs `address_de`). Il campo `customers.language` (stringa libera,
  es. `"german"`) determina quale lingua/indirizzo usare nei documenti stampati per quel
  paziente.
- **Soft delete**: alcune tabelle (`visits`, `invoices` storicamente, `proforma_invoices`)
  usano un flag booleano `deleted` invece di una `DELETE` fisica. **Filtrare `deleted = false`
  in fase di esportazione**, altrimenti si esportano record cancellati logicamente.
- **Fatturazione sanitaria italiana (STS)**: i campi `sts_*` servono per l'invio dei dati
  al "Sistema Tessera Sanitaria" (Agenzia delle Entrate, spese sanitarie precompilate).
  `customers.sts_opponent = true` significa che il paziente **si è opposto** all'invio dei
  suoi dati sanitari al Sistema Tessera Sanitaria (diritto di opt-out per legge italiana),
  non che è "un avversario/nemico".

## Elenco tabelle e semantica dei campi

### `therapists` — dati dello studio/professionista (in pratica: 1 riga)
| Campo | Tipo | Significato |
|---|---|---|
| `id` | uuid | PK |
| `full_name` | varchar(45) | Ragione sociale / nome del fisioterapista |
| `address` | varchar(256) | Indirizzo studio (versione italiana), righe separate da `-` |
| `address_de` | varchar(256) | Indirizzo studio in tedesco, stesso formato |
| `tax_number` | varchar(45) | Partita IVA |
| `fiscal_code` | varchar(45) | Codice fiscale |
| `iban` | varchar(45) | IBAN per pagamenti |
| `email` | text | Email dello studio |
| `aifi` | text | Numero tessera associazione professionale AIFI (Associazione Italiana Fisioterapisti) |
| `postit` | text | Testo libero in RTF, "post-it" nella dashboard interna — **nota interna, non da esportare come dato anagrafico/clinico** |
| `invoices_folder`, `privacy_folder`, `sqlbackup_folder` | text | Percorsi cartelle locali usate dall'app per salvare PDF fatture, moduli privacy, backup — **puramente locali al vecchio gestionale, non hanno senso nel sistema di destinazione** |
| `sts_password`, `sts_pincode` | varchar | Credenziali per il servizio STS — **dati sensibili, da NON esportare/loggare in chiaro** |

### `customers` — anagrafica pazienti
| Campo | Tipo | Significato |
|---|---|---|
| `id` | uuid | PK |
| `name`, `surname` | varchar(45) | Nome e cognome (surname obbligatorio, name può mancare per aziende/enti) |
| `email`, `tel1`, `tel2` | varchar(45) | Contatti |
| `vat` | varchar(45) | Partita IVA (se il paziente è un'azienda/ha fattura con P.IVA) |
| `fiscalcode` | varchar(45) | Codice fiscale |
| `address_id` | uuid → `addresses.id` | Indirizzo di residenza (nullable) |
| `pricelist_id` | uuid → `price_lists.id` | Listino prezzi assegnato al paziente (nullable = usa prezzo libero per visita) |
| `therapist_id` | uuid → `therapists.id` | Riferimento allo studio (vedi nota multi-tenancy sopra) |
| `note` | text | Note libere sul paziente |
| `language` | varchar(45) | Lingua preferita del paziente (es. `"german"`), determina lingua documenti |
| `privacy` | boolean | Consenso privacy firmato (sì/no) |
| `creation_date` | date | Data di inserimento in anagrafica |
| `legal_representative` | text | Nome del rappresentante legale (usato per pazienti minorenni o incapaci) |
| `age` | integer | Età del paziente (valore salvato al momento dell'inserimento, non calcolato dinamicamente da una data di nascita — **non esiste un campo data di nascita nel DB**) |
| `sts_opponent` | boolean | Opt-out dall'invio dati al Sistema Tessera Sanitaria (vedi sopra) |

⚠️ Nota importante: **non esiste una data di nascita**, solo un'età salvata come intero al
momento della creazione del paziente. Se il gestionale di destinazione richiede una data
di nascita, questo dato semplicemente non è disponibile/derivabile con precisione.

### `addresses` — indirizzi
| Campo | Significato |
|---|---|
| `address` | Via e numero civico |
| `cap` | CAP (obbligatorio) |
| `city` | Città |

Tabella normalizzata separatamente da `customers`, riferita da `customers.address_id`.
Non ha collegamento con provincia/nazione (non presenti nello schema).

### `price_lists` — listini prezzi
| Campo | Significato |
|---|---|
| `name` | Nome del listino (es. "Seduta standard", "Prima visita") |
| `price` | Prezzo unitario (float, euro) |
| `therapist_id` | Owner (vedi nota) |

Un paziente può avere un listino di default (`customers.pricelist_id`), ma il prezzo
effettivo applicato è comunque salvato per singola visita (`visits.price`), quindi il
listino è solo un default/comodo, non l'unica fonte di verità sul prezzo.

### `treatments` — tipologie di trattamento/prestazione
| Campo | Significato |
|---|---|
| `description_it`, `description_de` | Descrizione della prestazione nelle due lingue (es. "Terapia manuale" / "Manuelle Therapie") |
| `disabled` | Trattamento non più proposto (soft-disable, non eliminato per non rompere lo storico) |
| `therapist_id` | Owner |

Sono le voci di un catalogo prestazioni, associate alle visite tramite la tabella ponte
`visits_treatments` (relazione N:M — una visita può includere più trattamenti).

### `visits` — sedute/visite erogate (tabella centrale, un record per appuntamento svolto)
| Campo | Significato |
|---|---|
| `date` | Data della visita |
| `start_time` | Ora di inizio (salvata come stringa libera, non `time`) |
| `duration` | Durata (⚠️ tipizzata `varchar`, nonostante concettualmente sia un numero/intervallo — attenzione in fase di parsing) |
| `customer_id` | Paziente |
| `therapist_id` | Owner |
| `price` | Prezzo applicato a QUESTA visita specifica (può differire dal listino) |
| `invoice_id` | Se valorizzato, la visita è stata fatturata con fattura definitiva (`invoices`) |
| `invoiced` | Flag ridondante che rispecchia `invoice_id IS NOT NULL` |
| `proforma_invoice_id` / `proforma_invoiced` | Stesso meccanismo ma per la fattura proforma (vedi sotto) |
| `payed` | Se la singola visita risulta pagata |
| `deleted` | Soft delete — **filtrare `deleted = false`** |
| `future` | Marca visite/appuntamenti pianificati nel futuro (non ancora erogati) distinguendoli dallo storico clinico effettivo |
| `initial_evaluetion` | Valutazione funzionale iniziale (testo libero, dato clinico) — nome del campo con refuso storico ("evaluetion" invece di "evaluation") |
| `final_evaluetion` | Valutazione finale/di dimissione (stesso refuso) |

Relazione N:M con `treatments` tramite `visits_treatments (visit_id, treatment_id)`.

### `invoices` — fatture definitive
| Campo | Significato |
|---|---|
| `title` | Numero/titolo fattura, **univoco** (es. progressivo tipo "1/2026") |
| `date` | Data fattura |
| `discount` | Sconto applicato (importo assoluto, non percentuale, sottratto dal totale) |
| `payed` | Fattura saldata |
| `tax_stamp` | Marca da bollo applicata (rilevante fiscalmente sopra soglia importo esente IVA) |
| `contanti` | Pagamento in contanti (rilevante per normativa STS/tracciabilità) |
| `text` | Testo standard stampato in fattura |
| `custom_text` | Testo alternativo/aggiuntivo, sovrascrive `text` se valorizzato in stampa |
| `proforma_invoice_id` | Fattura proforma da cui questa fattura definitiva è stata generata (se presente) |
| `sts_sent` / `sts_sent_date` | Se e quando i dati sono stati inviati al Sistema Tessera Sanitaria |
| `therapist_id` | Owner |

Una fattura **non ha un campo cliente diretto**: il paziente si ricava indirettamente
dalla prima visita collegata (`visits.invoice_id`). Il totale fattura è calcolato
run-time come somma dei prezzi delle visite collegate meno lo sconto — **non è un campo
salvato nel DB**, va ricalcolato in export: `SUM(visits.price WHERE invoice_id = X) - discount`.

### `proforma_invoices` — fatture proforma (pre-fattura/preventivo)
Stessa struttura concettuale di `invoices`, con in più:
- `payed_date`: data effettivo incasso (per la proforma)
- `group_visits`: se true, le visite multiple vengono raggruppate in un'unica riga di
  stampa invece che elencate singolarmente
- `invoice_id`: collegamento alla fattura definitiva generata da questa proforma (se emessa)

Flusso tipico: si crea prima una **proforma** per un gruppo di visite (usata come
preventivo/pro-forma non fiscale), poi quando il paziente paga si genera la **fattura
definitiva** collegata (`invoices.proforma_invoice_id` / `proforma_invoices.invoice_id`),
e le visite vengono "spostate" concettualmente da proforma a definitiva.

### `recent_anamnesys`, `remote_anamnesys`, `stomatognathic_test` — schede cliniche
Queste tre tabelle contengono **dati clinici specialistici** (anamnesi prossima, anamnesi
remota, test stomatognatico/gnatologico con decine di misurazioni muscolari e articolari
specifiche — es. `lastissimus_dors_1r`, `m_masseter_prof_r`, vertebre cervicali `c0_r`…`t2_d`).

Sono legate 1:N a `customers` (in pratica quasi sempre 0 o 1 record per paziente, ma
modellate come storico ripetibile). **Molto probabilmente il gestionale di destinazione
non ha campi equivalenti**: se non gestisce cartelle cliniche specialistiche di
fisioterapia con questo livello di dettaglio, valutare se:
1. Non sono nello scope della migrazione (dati amministrativi/fatturazione sì, cartella clinica no), oppure
2. Vanno esportati come blob/allegato/testo libero collegato al paziente, non tentando un mapping campo-per-campo.

## Diagramma relazionale (semplificato)

```
therapists (1 riga)
  ├─< customers >─── addresses
  │      │      └─── price_lists
  │      ├─< recent_anamnesys
  │      ├─< remote_anamnesys
  │      ├─< stomatognathic_test
  │      └─< visits >─┬─< visits_treatments >─┤ treatments
  │                    ├── invoices ──── proforma_invoices
  │                    └── proforma_invoices
  ├─< price_lists
  ├─< treatments
  ├─< invoices
  └─< proforma_invoices
```

## Priorità suggerite per l'esportazione

1. **Anagrafica**: `customers` + `addresses` — dato a più alto valore, quasi certamente
   mappabile 1:1 su qualunque gestionale (nome, cognome, indirizzo, contatti, CF/P.IVA).
2. **Fatturazione**: `invoices`, `proforma_invoices`, `visits` (prezzo/data/pagato) —
   fondamentale per continuità amministrativa e fiscale. Attenzione a ricalcolare i
   totali dalle visite collegate come spiegato sopra, e a filtrare `deleted = false`.
3. **Catalogo prestazioni**: `treatments` e `price_lists` — utile se il nuovo gestionale
   ha un concetto analogo di listino/prestazioni codificate.
4. **Dati clinici** (`initial_evaluetion`/`final_evaluetion` su `visits`, e le tre tabelle
   di anamnesi/test): da valutare caso per caso, probabilmente da trattare come
   allegati/note testuali piuttosto che tentare un mapping strutturato.
5. **Da NON migrare**: percorsi cartelle locali (`invoices_folder`, `privacy_folder`,
   `sqlbackup_folder`), credenziali STS (`sts_password`, `sts_pincode`), e il campo
   `postit` (nota interna dashboard).
