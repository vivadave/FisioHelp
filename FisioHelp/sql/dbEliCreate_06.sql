CREATE TABLE IF NOT EXISTS proforma_invoices (
  id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
  date date not null, 
  discount float, 
  payed boolean not null DEFAULT 'f',
  payed_date date, 
  tax_stamp boolean not null DEFAULT 'f',
  therapist_id uuid not null REFERENCES therapists(id),
  title VARCHAR(25) UNIQUE NOT NULL,
  deleted boolean not null DEFAULT 'f',
  text text
);

ALTER TABLE invoices DROP COLUMN deleted;
ALTER TABLE visits ADD COLUMN IF NOT EXISTS proforma_invoice_id uuid;
DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'visits_proforma_invoice_id_fkey') THEN
        ALTER TABLE visits
            ADD CONSTRAINT visits_proforma_invoice_id_fkey
            FOREIGN KEY (proforma_invoice_id) REFERENCES proforma_invoices(id);
    END IF;
END;
$$;

ALTER TABLE visits ADD COLUMN IF NOT EXISTS proforma_invoiced bool not null DEFAULT 'f';
UPDATE visits set proforma_invoiced = false WHERE proforma_invoiced IS NULL;

ALTER TABLE invoices ADD COLUMN IF NOT EXISTS proforma_invoice_id uuid;
DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'invoices_proforma_invoice_id_fkey') THEN
        ALTER TABLE invoices
            ADD CONSTRAINT invoices_proforma_invoice_id_fkey
            FOREIGN KEY (proforma_invoice_id) REFERENCES proforma_invoices(id);
    END IF;
END;
$$;

ALTER TABLE proforma_invoices ADD COLUMN IF NOT EXISTS invoice_id uuid;
DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'proforma_invoices_invoice_id_fkey') THEN
        ALTER TABLE proforma_invoices
            ADD CONSTRAINT proforma_invoices_invoice_id_fkey
            FOREIGN KEY (invoice_id) REFERENCES invoices(id);
    END IF;
END;
$$;
