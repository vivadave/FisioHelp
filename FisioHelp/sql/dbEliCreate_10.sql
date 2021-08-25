ALTER TABLE proforma_invoices ADD COLUMN IF NOT EXISTS custom_text TEXT;
ALTER TABLE invoices ADD COLUMN IF NOT EXISTS custom_text TEXT;
