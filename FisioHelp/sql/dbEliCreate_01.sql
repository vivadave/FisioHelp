CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE IF NOT EXISTS therapists (
  id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
  address varchar(256),  
  full_name varchar(45) NOT NULL, 
  tax_number varchar(45),
  fiscal_code varchar(45),
  iban varchar(45)
);

CREATE TABLE IF NOT EXISTS price_lists (
  id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
  name varchar(256) not null,  
  price float not null, 
  therapist_id uuid not null REFERENCES therapists(id)
);

CREATE TABLE IF NOT EXISTS addresses (
  id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
  address varchar(256),  
  cap varchar(45) NOT NULL, 
  city varchar(45)
);

CREATE TABLE IF NOT EXISTS customers (
  id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
  name varchar(45),  
  surname varchar(45) NOT NULL, 
  email varchar(45), 
  vat varchar(45), 
  fiscalCode varchar(45), 
  tel1 varchar(45), 
  tel2 varchar(45), 
  address_id uuid REFERENCES addresses(id),
  priceList_id uuid REFERENCES price_lists(id),
  therapist_id uuid not null REFERENCES therapists(id),
  note text, 
  language  varchar(45)
);

CREATE TABLE IF NOT EXISTS invoices (
  id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
  date date not null, 
  discount float, 
  payed boolean not null DEFAULT 'f', 
  therapist_id uuid not null REFERENCES therapists(id),
  text text
);

CREATE TABLE IF NOT EXISTS visits (
  id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
  date date not null, 
  customer_id uuid not null REFERENCES customers(id),
  invoice_id uuid REFERENCES invoices(id),
  therapist_id uuid not null REFERENCES therapists(id),
  price float, 
  duration varchar(45), 
  invoiced boolean not null DEFAULT 'f', 
  payed boolean not null DEFAULT 'f', 
  initial_evaluetion text
);