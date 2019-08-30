CREATE TYPE language AS ENUM ('italian', 'german');

CREATE TABLE IF NOT EXISTS price_lists (
  id serial NOT NULL, 
  name varchar(256) not null,  
  price float not null, 
  PRIMARY KEY (id)  
);

CREATE TABLE IF NOT EXISTS addresses (
  id serial NOT NULL, 
  address varchar(256),  
  cap varchar(45) NOT NULL, 
  city varchar(45),
  PRIMARY KEY (id)  
);

CREATE TABLE IF NOT EXISTS customers (
  id serial NOT NULL, 
  name varchar(45),  
  surname varchar(45) NOT NULL, 
  email varchar(45), 
  vat varchar(45), 
  fiscalCode varchar(45), 
  tel1 varchar(45), 
  tel2 varchar(45), 
  address_id INTEGER REFERENCES addresses(id),
  priceList_id INTEGER REFERENCES priceLists(id),
  note text, 
  language language default 'german',
  PRIMARY KEY (id)  
);

CREATE TABLE IF NOT EXISTS invoices (
  id serial NOT NULL, 
  date date not null, 
  discount float, 
  payed boolean DEFAULT 'f', 
  text text,  
  PRIMARY KEY (id)  
);

CREATE TABLE IF NOT EXISTS visits (
  id serial NOT NULL, 
  date date not null, 
  customer_id INTEGER not null REFERENCES customers(id),
  invoice_id INTEGER REFERENCES invoices(id),
  price float, 
  duration INTEGER, 
  invoiced boolean DEFAULT 'f', 
  payed boolean DEFAULT 'f', 
  note text,  
  PRIMARY KEY (id)  
);