-- Table: public.mythology

-- DROP TABLE IF EXISTS public.mythology;

CREATE TABLE IF NOT EXISTS public.mythology
(
    id integer NOT NULL,
    name character varying(56) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT mythology_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.mythology
    OWNER to odel;