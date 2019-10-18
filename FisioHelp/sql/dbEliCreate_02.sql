CREATE TABLE IF NOT EXISTS treatments (
	id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
	therapist_id uuid not null REFERENCES therapists(id),
	description_de text NOT NULL,
	description_it text NOT NULL
);

CREATE TABLE IF NOT EXISTS visits_treatments (
  visit_id    uuid REFERENCES visits (id) ON UPDATE CASCADE,
  treatment_id uuid REFERENCES treatments (id) ON UPDATE CASCADE,
  CONSTRAINT bill_product_pkey PRIMARY KEY (visit_id, treatment_id)  
);

ALTER TABLE visits ADD COLUMN IF NOT EXISTS final_evaluetion text;
ALTER TABLE visits ADD COLUMN IF NOT EXISTS start_time varchar(45);

ALTER TABLE invoices ADD COLUMN IF NOT EXISTS title VARCHAR(25) UNIQUE NOT NULL;
ALTER TABLE invoices ADD COLUMN IF NOT EXISTS deleted boolean not null DEFAULT 'f';
