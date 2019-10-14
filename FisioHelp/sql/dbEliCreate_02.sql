CREATE TABLE IF NOT EXISTS treatments (
 id  serial PRIMARY KEY,
 description_de text NOT NULL,
 description_it text NOT NULL
);

CREATE TABLE IF NOT EXISTS visits_treatments (
  visit_id    int REFERENCES visits (id) ON UPDATE CASCADE,
  treatment_id int REFERENCES treatments (id) ON UPDATE CASCADE,
  CONSTRAINT bill_product_pkey PRIMARY KEY (visit_id, treatment_id)  
);

ALTER TABLE visits ADD COLUMN IF NOT EXISTS final_evaluetion text;
ALTER TABLE visits ADD COLUMN IF NOT EXISTS start_time varchar(45);

ALTER TABLE invoices ADD COLUMN IF NOT EXISTS title VARCHAR(25) UNIQUE NOT NULL;
ALTER TABLE invoices ADD COLUMN IF NOT EXISTS deleted boolean DEFAULT 'f';

CREATE TABLE IF NOT EXISTS therapists (
  id serial NOT NULL, 
  address varchar(256),  
  fullName varchar(45) NOT NULL, 
  taxNumber varchar(45),
  fiscalCode varchar(45),
  iban varchar(45),
  PRIMARY KEY (id)  
);