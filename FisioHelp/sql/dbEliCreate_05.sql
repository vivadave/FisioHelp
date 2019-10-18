ALTER TABLE therapists ADD COLUMN IF NOT EXISTS postit text;
ALTER TABLE therapists ADD COLUMN IF NOT EXISTS invoices_folder text;
ALTER TABLE therapists ADD COLUMN IF NOT EXISTS privacy_folder text;
ALTER TABLE therapists ADD COLUMN IF NOT EXISTS email text;
ALTER TABLE therapists ADD COLUMN IF NOT EXISTS address_de text;

ALTER TABLE customers ADD COLUMN IF NOT EXISTS privacy boolean not null DEFAULT 'f';
ALTER TABLE customers ADD COLUMN IF NOT EXISTS creation_date date not null DEFAULT now();
ALTER TABLE invoices ADD COLUMN IF NOT EXISTS tax_stamp boolean not null DEFAULT 'f';
