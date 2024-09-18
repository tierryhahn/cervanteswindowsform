-- Tabela cadastro
CREATE TABLE IF NOT EXISTS public.cadastro
(
    id integer NOT NULL DEFAULT nextval('cadastro_id_seq'::regclass),
    campo_texto character varying(100) NOT NULL,
    campo_numerico integer NOT NULL,
    CONSTRAINT cadastro_pkey PRIMARY KEY (id),
    CONSTRAINT cadastro_campo_numerico_key UNIQUE (campo_numerico),
    CONSTRAINT cadastro_campo_numerico_check CHECK (campo_numerico > 0)
);

ALTER TABLE IF EXISTS public.cadastro
    OWNER to postgres;

REVOKE ALL ON TABLE public.cadastro FROM tierry;

GRANT ALL ON TABLE public.cadastro TO postgres;
GRANT DELETE, UPDATE, INSERT, SELECT ON TABLE public.cadastro TO tierry;

-- Tabela log_operacoes
CREATE TABLE IF NOT EXISTS public.log_operacoes
(
    id integer NOT NULL DEFAULT nextval('log_operacoes_id_seq'::regclass),
    data_hora timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
    tipo_operacao character varying(10) NOT NULL,
    cadastro_id integer,
    CONSTRAINT log_operacoes_pkey PRIMARY KEY (id),
    CONSTRAINT log_operacoes_cadastro_id_fkey FOREIGN KEY (cadastro_id)
        REFERENCES public.cadastro (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

ALTER TABLE IF EXISTS public.log_operacoes
    OWNER to postgres;

REVOKE ALL ON TABLE public.log_operacoes FROM tierry;

GRANT ALL ON TABLE public.log_operacoes TO postgres;
GRANT DELETE, UPDATE, INSERT, SELECT ON TABLE public.log_operacoes TO tierry;