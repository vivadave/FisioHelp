ALTER TABLE invoices ADD COLUMN IF NOT EXISTS contanti boolean not null DEFAULT 'f';
ALTER TABLE proforma_invoices ADD COLUMN IF NOT EXISTS contanti boolean not null DEFAULT 'f';