ALTER TABLE treatments ADD COLUMN IF NOT EXISTS disabled boolean not null DEFAULT 'f';
