ALTER TABLE therapists ADD COLUMN IF NOT EXISTS postit text;
ALTER TABLE customers ADD COLUMN IF NOT EXISTS creation_date date;
