-- STS (Sistema Tessera Sanitaria) integration
ALTER TABLE public.customers ADD COLUMN IF NOT EXISTS sts_opponent BOOLEAN NOT NULL DEFAULT FALSE;

ALTER TABLE public.invoices ADD COLUMN IF NOT EXISTS sts_sent BOOLEAN NOT NULL DEFAULT FALSE;
ALTER TABLE public.invoices ADD COLUMN IF NOT EXISTS sts_sent_date DATE NULL;

ALTER TABLE public.therapists ADD COLUMN IF NOT EXISTS sts_password VARCHAR(100) NULL;
ALTER TABLE public.therapists ADD COLUMN IF NOT EXISTS sts_pincode VARCHAR(20) NULL;
