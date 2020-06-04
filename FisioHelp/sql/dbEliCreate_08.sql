ALTER TABLE visits ADD COLUMN IF NOT EXISTS future boolean not null DEFAULT 'f';
