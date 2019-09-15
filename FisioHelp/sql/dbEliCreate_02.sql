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

ALTER TABLE visits RENAME duration TO start_time;
ALTER TABLE visits RENAME note TO initial_evaluetion;
ALTER TABLE visits ADD COLUMN final_evaluetion text;

ALTER TABLE invoices ADD title VARCHAR(25) UNIQUE NOT NULL;
ALTER TABLE invoices ADD deleted boolean DEFAULT 'f';

CREATE TABLE IF NOT EXISTS therapists (
  id serial NOT NULL, 
  address varchar(256),  
  fullName varchar(45) NOT NULL, 
  taxNumber varchar(45),
  fiscalCode varchar(45),
  iban varchar(45),
  PRIMARY KEY (id)  
);