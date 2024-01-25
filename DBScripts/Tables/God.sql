-- Table: public.god

-- DROP TABLE IF EXISTS public.god;

CREATE TABLE IF NOT EXISTS public.god
(
    id integer NOT NULL,
    name character varying(56) COLLATE pg_catalog."default" NOT NULL,
    description text COLLATE pg_catalog."default" NOT NULL,
    mythology integer NOT NULL,
    CONSTRAINT god_pkey PRIMARY KEY (id),
    CONSTRAINT "fk_Mythology" FOREIGN KEY (mythology)
        REFERENCES public.mythology (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.god
    OWNER to odel;