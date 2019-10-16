ALTER TABLE therapists ADD COLUMN IF NOT EXISTS postit text;
ALTER TABLE therapists ADD COLUMN IF NOT EXISTS invoices_folder text;
ALTER TABLE therapists ADD COLUMN IF NOT EXISTS privacy_folder text;

ALTER TABLE customers ADD COLUMN IF NOT EXISTS privacy boolean DEFAULT 'f';
