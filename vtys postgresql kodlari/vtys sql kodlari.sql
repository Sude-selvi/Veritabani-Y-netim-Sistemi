--
-- PostgreSQL database dump
--

-- Dumped from database version 14.5
-- Dumped by pg_dump version 15rc2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: public; Type: SCHEMA; Schema: -; Owner: postgres
--

-- *not* creating schema, since initdb creates it


ALTER SCHEMA public OWNER TO postgres;

--
-- Name: dusukfiyat(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.dusukfiyat() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
if new.fiyat >80 then 
raise exception '80 tl üstü fiyat girilemez';
end if;
return new;
end;
$$;


ALTER FUNCTION public.dusukfiyat() OWNER TO postgres;

--
-- Name: film_satis_bul(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.film_satis_bul(filmno integer) RETURNS TABLE(izlenmesayisi bigint)
    LANGUAGE plpgsql
    AS $$
begin
return query
select
count(film_no)
from biletler
where film_no=filmno;
end;
$$;


ALTER FUNCTION public.film_satis_bul(filmno integer) OWNER TO postgres;

--
-- Name: kucukharfedonustur(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kucukharfedonustur() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
    new.film_adi=lower(new.film_adi);
    return new;
    end;
$$;


ALTER FUNCTION public.kucukharfedonustur() OWNER TO postgres;

--
-- Name: oyuncu_bul(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.oyuncu_bul(ad text) RETURNS TABLE(fono integer, filmad character varying, oyuncuad character varying, oyuncusoyad character varying)
    LANGUAGE plpgsql
    AS $$
begin
return query select * from filmlerdeki_oyuncular_view where oyuncu_adi= ad;
end;
$$;


ALTER FUNCTION public.oyuncu_bul(ad text) OWNER TO postgres;

--
-- Name: oyuncuisimdonustur(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.oyuncuisimdonustur() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
    new.oyuncu_adi=lower(new.oyuncu_adi);
    new.oyuncu_soyadi=lower(new.oyuncu_soyadi);
    return new;
    end;
$$;


ALTER FUNCTION public.oyuncuisimdonustur() OWNER TO postgres;

--
-- Name: tarihe_gore_ucret_hesapla(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.tarihe_gore_ucret_hesapla(tarih text) RETURNS TABLE(alistarih text, toplamfiyat bigint)
    LANGUAGE plpgsql
    AS $$

begin 
    return query 
    select 
    alis_tarihi,
    sum(fiyat) 
    from 
    biletler group by alis_tarihi having alis_tarihi=tarih;
   
end;
$$;


ALTER FUNCTION public.tarihe_gore_ucret_hesapla(tarih text) OWNER TO postgres;

--
-- Name: toplamsinemasalonu(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.toplamsinemasalonu() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
update "ssalontoplami" set sayi=sayi+1;
return new;
end;
$$;


ALTER FUNCTION public.toplamsinemasalonu() OWNER TO postgres;

--
-- Name: toplamsinemasalonu2(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.toplamsinemasalonu2() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
update "ssalontoplami" set sayi=sayi-1;
return new;
end;
$$;


ALTER FUNCTION public.toplamsinemasalonu2() OWNER TO postgres;

--
-- Name: tumfilmler(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.tumfilmler() RETURNS TABLE(filmadi character varying)
    LANGUAGE plpgsql
    AS $$
begin return query select distinct film_adi from filmler ;
end;
$$;


ALTER FUNCTION public.tumfilmler() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: biletler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.biletler (
    referans_no integer NOT NULL,
    ssalon_id integer NOT NULL,
    salonlar_id integer,
    film_no integer NOT NULL,
    bufe_id integer,
    musteri integer NOT NULL,
    fiyat integer,
    seans_saat integer,
    seans_tarih integer,
    koltuk_no integer,
    alis_tarihi text DEFAULT CURRENT_DATE
);


ALTER TABLE public.biletler OWNER TO postgres;

--
-- Name: biletler_referans_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.biletler_referans_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.biletler_referans_no_seq OWNER TO postgres;

--
-- Name: biletler_referans_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.biletler_referans_no_seq OWNED BY public.biletler.referans_no;


--
-- Name: bufe; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.bufe (
    bufe_id integer NOT NULL,
    ssalon_id integer NOT NULL,
    yiyecek boolean,
    icecek boolean
);


ALTER TABLE public.bufe OWNER TO postgres;

--
-- Name: bufe_bufe_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.bufe_bufe_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.bufe_bufe_id_seq OWNER TO postgres;

--
-- Name: bufe_bufe_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.bufe_bufe_id_seq OWNED BY public.bufe.bufe_id;


--
-- Name: film_seans; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.film_seans (
    film_seans_id integer NOT NULL,
    seans integer,
    film integer,
    seans_tarih text
);


ALTER TABLE public.film_seans OWNER TO postgres;

--
-- Name: film_seans_film_seans_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.film_seans_film_seans_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.film_seans_film_seans_id_seq OWNER TO postgres;

--
-- Name: film_seans_film_seans_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.film_seans_film_seans_id_seq OWNED BY public.film_seans.film_seans_id;


--
-- Name: film_tur; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.film_tur (
    film_tur_id integer NOT NULL,
    turu integer,
    film integer
);


ALTER TABLE public.film_tur OWNER TO postgres;

--
-- Name: film_tur_film_tur_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.film_tur_film_tur_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.film_tur_film_tur_id_seq OWNER TO postgres;

--
-- Name: film_tur_film_tur_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.film_tur_film_tur_id_seq OWNED BY public.film_tur.film_tur_id;


--
-- Name: filmdeki_oyuncular; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.filmdeki_oyuncular (
    fo_no integer NOT NULL,
    oyuncu integer,
    film integer
);


ALTER TABLE public.filmdeki_oyuncular OWNER TO postgres;

--
-- Name: filmdeki_oyuncular_fo_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.filmdeki_oyuncular_fo_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.filmdeki_oyuncular_fo_no_seq OWNER TO postgres;

--
-- Name: filmdeki_oyuncular_fo_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.filmdeki_oyuncular_fo_no_seq OWNED BY public.filmdeki_oyuncular.fo_no;


--
-- Name: filmler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.filmler (
    film_no integer NOT NULL,
    film_adi character varying(50) NOT NULL,
    film_tur character varying(13) NOT NULL,
    film_format character(1),
    film_suresi text
);


ALTER TABLE public.filmler OWNER TO postgres;

--
-- Name: filmler_film_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.filmler_film_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.filmler_film_no_seq OWNER TO postgres;

--
-- Name: filmler_film_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.filmler_film_no_seq OWNED BY public.filmler.film_no;


--
-- Name: oyuncular; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.oyuncular (
    oyuncu_id integer NOT NULL,
    oyuncu_adi character varying(40),
    oyuncu_soyadi character varying(40)
);


ALTER TABLE public.oyuncular OWNER TO postgres;

--
-- Name: filmlerdeki_oyuncular_view; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.filmlerdeki_oyuncular_view AS
 SELECT filmdeki_oyuncular.fo_no,
    filmler.film_adi,
    oyuncular.oyuncu_adi,
    oyuncular.oyuncu_soyadi
   FROM ((public.filmdeki_oyuncular
     JOIN public.oyuncular ON ((oyuncular.oyuncu_id = filmdeki_oyuncular.oyuncu)))
     JOIN public.filmler ON ((filmler.film_no = filmdeki_oyuncular.film)));


ALTER TABLE public.filmlerdeki_oyuncular_view OWNER TO postgres;

--
-- Name: icecekler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.icecekler (
    bufe_id integer NOT NULL,
    icecek_ad character varying(30) NOT NULL,
    fiyat numeric,
    icecek_no integer NOT NULL
);


ALTER TABLE public.icecekler OWNER TO postgres;

--
-- Name: icecekler_icecek_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.icecekler_icecek_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.icecekler_icecek_no_seq OWNER TO postgres;

--
-- Name: icecekler_icecek_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.icecekler_icecek_no_seq OWNED BY public.icecekler.icecek_no;


--
-- Name: icecekler_view; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.icecekler_view AS
 SELECT icecekler.icecek_ad,
    icecekler.fiyat
   FROM (public.bufe
     JOIN public.icecekler ON ((bufe.bufe_id = icecekler.bufe_id)));


ALTER TABLE public.icecekler_view OWNER TO postgres;

--
-- Name: iller; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.iller (
    il_no integer NOT NULL,
    il_adi character varying(14)
);


ALTER TABLE public.iller OWNER TO postgres;

--
-- Name: koltuklar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.koltuklar (
    koltuklar_id integer NOT NULL,
    koltuk_no character varying(3),
    salonlar_id integer NOT NULL
);


ALTER TABLE public.koltuklar OWNER TO postgres;

--
-- Name: koltuklar_koltuklar_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.koltuklar_koltuklar_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.koltuklar_koltuklar_id_seq OWNER TO postgres;

--
-- Name: koltuklar_koltuklar_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.koltuklar_koltuklar_id_seq OWNED BY public.koltuklar.koltuklar_id;


--
-- Name: musteri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.musteri (
    musteri_id integer NOT NULL,
    musteri_ad character varying(40),
    musteri_soyad character varying(40),
    musteri_tel character(11),
    musteri_tur character(1)
);


ALTER TABLE public.musteri OWNER TO postgres;

--
-- Name: musteri_musteri_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.musteri_musteri_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.musteri_musteri_id_seq OWNER TO postgres;

--
-- Name: musteri_musteri_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.musteri_musteri_id_seq OWNED BY public.musteri.musteri_id;


--
-- Name: ogrenci; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ogrenci (
    musteri_id integer NOT NULL,
    bilet_fiyat numeric
);


ALTER TABLE public.ogrenci OWNER TO postgres;

--
-- Name: oyuncular_oyuncu_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.oyuncular_oyuncu_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.oyuncular_oyuncu_id_seq OWNER TO postgres;

--
-- Name: oyuncular_oyuncu_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.oyuncular_oyuncu_id_seq OWNED BY public.oyuncular.oyuncu_id;


--
-- Name: salon_seans; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.salon_seans (
    ssalon_seans_id integer NOT NULL,
    salonlar_id integer,
    seans_id integer
);


ALTER TABLE public.salon_seans OWNER TO postgres;

--
-- Name: salon_seans_ssalon_seans_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.salon_seans_ssalon_seans_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.salon_seans_ssalon_seans_id_seq OWNER TO postgres;

--
-- Name: salon_seans_ssalon_seans_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.salon_seans_ssalon_seans_id_seq OWNED BY public.salon_seans.ssalon_seans_id;


--
-- Name: salonlar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.salonlar (
    salonlar_id integer NOT NULL,
    salon_no character varying(2),
    sinemasalonu_id integer NOT NULL,
    koltuk_adedi character varying(3)
);


ALTER TABLE public.salonlar OWNER TO postgres;

--
-- Name: salonlar_salonlar_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.salonlar_salonlar_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.salonlar_salonlar_id_seq OWNER TO postgres;

--
-- Name: salonlar_salonlar_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.salonlar_salonlar_id_seq OWNED BY public.salonlar.salonlar_id;


--
-- Name: sinemasalonu; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sinemasalonu (
    ssalon_id integer NOT NULL,
    il integer NOT NULL,
    ssalon_ad character varying(40),
    ssalon_adres text,
    ssalon_iletisim character(11)
);


ALTER TABLE public.sinemasalonu OWNER TO postgres;

--
-- Name: salonlar_view; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.salonlar_view AS
 SELECT salonlar.salonlar_id,
    sinemasalonu.ssalon_ad,
    salonlar.salon_no,
    salonlar.koltuk_adedi
   FROM (public.salonlar
     JOIN public.sinemasalonu ON ((salonlar.sinemasalonu_id = sinemasalonu.ssalon_id)));


ALTER TABLE public.salonlar_view OWNER TO postgres;

--
-- Name: seanslar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.seanslar (
    seans_id integer NOT NULL,
    seans_saat text
);


ALTER TABLE public.seanslar OWNER TO postgres;

--
-- Name: seans_islemleri_view; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.seans_islemleri_view AS
 SELECT film_seans.film_seans_id AS id,
    filmler.film_adi,
    filmler.film_format,
    film_seans.seans_tarih,
    seanslar.seans_saat
   FROM ((public.film_seans
     JOIN public.filmler ON ((film_seans.film = filmler.film_no)))
     JOIN public.seanslar ON ((film_seans.seans = seanslar.seans_id)));


ALTER TABLE public.seans_islemleri_view OWNER TO postgres;

--
-- Name: seanslar_seans_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.seanslar_seans_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.seanslar_seans_id_seq OWNER TO postgres;

--
-- Name: seanslar_seans_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.seanslar_seans_id_seq OWNED BY public.seanslar.seans_id;


--
-- Name: sinemasalonu_ssalon_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sinemasalonu_ssalon_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.sinemasalonu_ssalon_id_seq OWNER TO postgres;

--
-- Name: sinemasalonu_ssalon_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sinemasalonu_ssalon_id_seq OWNED BY public.sinemasalonu.ssalon_id;


--
-- Name: sinemasalonu_view; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.sinemasalonu_view AS
 SELECT sinemasalonu.ssalon_id,
    iller.il_adi,
    sinemasalonu.ssalon_ad,
    sinemasalonu.ssalon_adres,
    sinemasalonu.ssalon_iletisim
   FROM (public.sinemasalonu
     JOIN public.iller ON ((sinemasalonu.il = iller.il_no)));


ALTER TABLE public.sinemasalonu_view OWNER TO postgres;

--
-- Name: ssalon_film; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ssalon_film (
    ssalon_film integer NOT NULL,
    ssalon_id integer,
    film_no integer
);


ALTER TABLE public.ssalon_film OWNER TO postgres;

--
-- Name: ssalon_film_ssalon_film_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ssalon_film_ssalon_film_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ssalon_film_ssalon_film_seq OWNER TO postgres;

--
-- Name: ssalon_film_ssalon_film_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ssalon_film_ssalon_film_seq OWNED BY public.ssalon_film.ssalon_film;


--
-- Name: ssalontoplami; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ssalontoplami (
    sayi integer
);


ALTER TABLE public.ssalontoplami OWNER TO postgres;

--
-- Name: tur; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tur (
    tur_id integer NOT NULL,
    tur_adi character varying(13)
);


ALTER TABLE public.tur OWNER TO postgres;

--
-- Name: yetiskin; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.yetiskin (
    musteri_id integer NOT NULL,
    bilet_fiyat numeric
);


ALTER TABLE public.yetiskin OWNER TO postgres;

--
-- Name: yiyecekler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.yiyecekler (
    bufe_id integer NOT NULL,
    yiyecek_ad character varying(18) NOT NULL,
    fiyat numeric,
    yiyecek_no integer NOT NULL
);


ALTER TABLE public.yiyecekler OWNER TO postgres;

--
-- Name: yiyecekler_view; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.yiyecekler_view AS
 SELECT yiyecekler.yiyecek_ad,
    yiyecekler.fiyat
   FROM (public.bufe
     JOIN public.yiyecekler ON ((bufe.bufe_id = yiyecekler.bufe_id)));


ALTER TABLE public.yiyecekler_view OWNER TO postgres;

--
-- Name: yiyecekler_yiyecek_no_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.yiyecekler_yiyecek_no_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.yiyecekler_yiyecek_no_seq OWNER TO postgres;

--
-- Name: yiyecekler_yiyecek_no_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.yiyecekler_yiyecek_no_seq OWNED BY public.yiyecekler.yiyecek_no;


--
-- Name: biletler referans_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler ALTER COLUMN referans_no SET DEFAULT nextval('public.biletler_referans_no_seq'::regclass);


--
-- Name: bufe bufe_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bufe ALTER COLUMN bufe_id SET DEFAULT nextval('public.bufe_bufe_id_seq'::regclass);


--
-- Name: film_seans film_seans_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.film_seans ALTER COLUMN film_seans_id SET DEFAULT nextval('public.film_seans_film_seans_id_seq'::regclass);


--
-- Name: film_tur film_tur_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.film_tur ALTER COLUMN film_tur_id SET DEFAULT nextval('public.film_tur_film_tur_id_seq'::regclass);


--
-- Name: filmdeki_oyuncular fo_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.filmdeki_oyuncular ALTER COLUMN fo_no SET DEFAULT nextval('public.filmdeki_oyuncular_fo_no_seq'::regclass);


--
-- Name: filmler film_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.filmler ALTER COLUMN film_no SET DEFAULT nextval('public.filmler_film_no_seq'::regclass);


--
-- Name: icecekler icecek_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.icecekler ALTER COLUMN icecek_no SET DEFAULT nextval('public.icecekler_icecek_no_seq'::regclass);


--
-- Name: koltuklar koltuklar_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.koltuklar ALTER COLUMN koltuklar_id SET DEFAULT nextval('public.koltuklar_koltuklar_id_seq'::regclass);


--
-- Name: musteri musteri_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.musteri ALTER COLUMN musteri_id SET DEFAULT nextval('public.musteri_musteri_id_seq'::regclass);


--
-- Name: oyuncular oyuncu_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.oyuncular ALTER COLUMN oyuncu_id SET DEFAULT nextval('public.oyuncular_oyuncu_id_seq'::regclass);


--
-- Name: salon_seans ssalon_seans_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salon_seans ALTER COLUMN ssalon_seans_id SET DEFAULT nextval('public.salon_seans_ssalon_seans_id_seq'::regclass);


--
-- Name: salonlar salonlar_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salonlar ALTER COLUMN salonlar_id SET DEFAULT nextval('public.salonlar_salonlar_id_seq'::regclass);


--
-- Name: seanslar seans_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.seanslar ALTER COLUMN seans_id SET DEFAULT nextval('public.seanslar_seans_id_seq'::regclass);


--
-- Name: sinemasalonu ssalon_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinemasalonu ALTER COLUMN ssalon_id SET DEFAULT nextval('public.sinemasalonu_ssalon_id_seq'::regclass);


--
-- Name: ssalon_film ssalon_film; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ssalon_film ALTER COLUMN ssalon_film SET DEFAULT nextval('public.ssalon_film_ssalon_film_seq'::regclass);


--
-- Name: yiyecekler yiyecek_no; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yiyecekler ALTER COLUMN yiyecek_no SET DEFAULT nextval('public.yiyecekler_yiyecek_no_seq'::regclass);


--
-- Data for Name: biletler; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.biletler VALUES
	(6, 2, 6, 3, 1, 17, 110, 5, 25, 7, '2022-12-24'),
	(7, 4, 9, 6, 1, 18, 115, 13, 28, 8, '2022-12-24'),
	(8, 2, 6, 8, 1, 19, 90, 10, 34, 9, '2022-12-25'),
	(9, 4, 9, 6, 1, 2, 110, 11, 29, 10, '2022-12-25'),
	(10, 2, 6, 2, 1, 22, 95, 8, 23, 11, '2022-12-25'),
	(11, 5, 13, 4, 1, 1, 90, 5, 26, 12, '2022-12-25'),
	(12, 6, 14, 8, 1, 24, 95, 10, 34, 13, '2022-12-25'),
	(13, 4, 9, 8, 1, 1, 100, 13, 35, 14, '2022-12-25'),
	(14, 2, 6, 4, 1, 1, 100, 5, 26, 15, '2022-12-25'),
	(15, 10, 17, 6, 1, 1, 90, 13, 28, 16, '2022-12-25'),
	(16, 5, 11, 7, 1, 28, 120, 10, 31, 17, '2022-12-25'),
	(17, 3, 15, 8, 1, 29, 95, 13, 35, 18, '2022-12-25'),
	(18, 10, 19, 7, 1, 30, 115, 8, 30, 19, '2022-12-25'),
	(19, 4, 10, 7, 1, 31, 110, 8, 30, 20, '2022-12-25'),
	(20, 2, 7, 8, 1, 32, 110, 13, 35, 21, '2022-12-25'),
	(21, 4, 9, 3, 1, 33, 105, 7, 27, 22, '2022-12-25'),
	(22, 1, 1, 2, 1, 34, 110, 7, 21, 23, '2022-12-25'),
	(23, 2, 6, 7, 1, 35, 130, 10, 31, 24, '2022-12-25'),
	(24, 2, 6, 8, 1, 36, 110, 9, 32, 25, '2022-12-25'),
	(25, 3, 15, 3, 1, 37, 120, 7, 27, 26, '2022-12-25'),
	(26, 5, 11, 6, 1, 38, 90, 11, 29, 27, '2022-12-25'),
	(31, 2, 7, 4, 1, 44, 105, 5, 26, 34, '2022-12-25'),
	(32, 4, 10, 3, 1, 17, 110, 5, 25, 35, '2022-12-25'),
	(33, 3, 15, 4, 1, 38, 110, 5, 26, 36, '2022-12-25'),
	(34, 4, 9, 3, 1, 1, 105, 7, 27, 37, '2022-12-25'),
	(35, 3, 25, 7, 1, 1, 110, 8, 30, 38, '2022-12-25'),
	(36, 3, 15, 7, 1, 50, 120, 8, 30, 39, '2022-12-25'),
	(37, 3, 25, 7, 1, 1, 95, 10, 31, 40, '2022-12-25'),
	(38, 3, 25, 3, 1, 1, 95, 7, 27, 41, '2022-12-25'),
	(39, 4, 9, 8, 1, 1, 110, 13, 35, 42, '2022-12-25'),
	(40, 4, 10, 8, 1, 54, 115, 13, 35, 43, '2022-12-25'),
	(41, 4, 10, 8, 1, 56, 100, 13, 35, 45, '2022-12-25'),
	(42, 1, 2, 2, 1, 58, 60, 7, 21, 48, '2022-12-25'),
	(43, 1, 1, 2, 1, 60, 75, 6, 20, 51, '2022-12-25'),
	(44, 2, 6, 4, 1, 62, 90, 5, 26, 7, '2022-12-25');


--
-- Data for Name: bufe; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.bufe VALUES
	(1, 1, true, true),
	(2, 2, true, true),
	(3, 3, true, true),
	(4, 4, true, false),
	(5, 5, false, true),
	(6, 6, false, false);


--
-- Data for Name: film_seans; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.film_seans VALUES
	(32, 9, 8, '27.12.2022'),
	(33, 10, 8, '27.12.2022'),
	(34, 10, 8, '28.12.2022'),
	(35, 13, 8, '28.12.2022'),
	(36, 5, 9, '30.12.2022'),
	(37, 6, 9, '30.12.2022'),
	(38, 7, 9, '30.12.2022'),
	(39, 8, 9, '30.12.2022'),
	(40, 9, 9, '30.12.2022'),
	(41, 10, 9, '30.12.2022'),
	(42, 11, 8, '30.12.2022'),
	(43, 12, 8, '30.12.2022'),
	(44, 13, 8, '30.12.2022'),
	(45, 13, 1, '30.12.2022'),
	(46, 6, 1, '30.12.2022'),
	(47, 10, 1, '30.12.2022'),
	(48, 7, 6, '30.12.2022'),
	(49, 6, 6, '30.12.2022'),
	(50, 12, 6, '30.12.2022'),
	(51, 5, 2, '30.12.2022'),
	(52, 6, 2, '30.12.2022'),
	(53, 7, 2, '30.12.2022'),
	(54, 5, 3, '30.12.2022'),
	(55, 6, 3, '30.12.2022'),
	(56, 7, 3, '30.12.2022'),
	(58, 8, 7, '30.12.2022'),
	(59, 9, 7, '30.12.2022'),
	(27, 7, 3, '28.12.2022'),
	(25, 5, 3, '28.12.2022'),
	(26, 5, 4, '28.12.2022'),
	(17, 12, 5, '28.12.2022'),
	(29, 11, 6, '28.12.2022'),
	(28, 13, 6, '28.12.2022'),
	(31, 10, 7, '28.12.2022'),
	(30, 8, 7, '28.12.2022'),
	(24, 12, 2, '28.12.2022'),
	(23, 8, 2, '28.12.2022'),
	(21, 7, 2, '28.12.2022'),
	(20, 6, 2, '28.12.2022');


--
-- Data for Name: film_tur; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.film_tur VALUES
	(2, 1, 1),
	(3, 1, 2),
	(4, 1, 3),
	(5, 3, 4),
	(6, 4, 5),
	(7, 4, 6);


--
-- Data for Name: filmdeki_oyuncular; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.filmdeki_oyuncular VALUES
	(1, 7, 7),
	(2, 1, 3),
	(3, 2, 3),
	(4, 3, 3),
	(5, 1, 4),
	(6, 2, 4),
	(7, 3, 4),
	(8, 4, 6),
	(9, 5, 6),
	(10, 6, 2),
	(13, NULL, 6),
	(14, NULL, 6),
	(15, 9, 7);


--
-- Data for Name: filmler; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.filmler VALUES
	(1, 'Black Panter', 'Aksiyon', 'D', '161 dakika'),
	(3, 'Avatar:Suyun Yolu', 'Aksiyon', 'D', '190 dakika'),
	(4, 'Avatar:Suyun Yolu', 'Aksiyon', 'A', '190 dakika'),
	(5, 'Black Panter', 'Aksiyon', 'A', '161 dakika'),
	(6, 'Bugday Tanesi', 'Dram', 'O', '120 dakika'),
	(7, 'Kurak Günler', 'Dram', 'O', '129 dakika'),
	(2, 'Sil Bastan Kaynanam', 'Komedi', 'O', '120 dakika'),
	(8, 'Ajan Kedi1', 'Animasyon', 'D', '90 dakika'),
	(9, 'tenet', 'Bilim-Kurgu', 'A', '180 dakika');


--
-- Data for Name: icecekler; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.icecekler VALUES
	(1, 'istemiyorum', 0, 6),
	(1, 'Karpuzlu Maden Suyu', 15, 7),
	(1, 'Fanta', 20, 8),
	(1, 'kola', 20, 9),
	(1, 'mangolu ice tea', 25, 10);


--
-- Data for Name: iller; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.iller VALUES
	(1, 'adana'),
	(6, 'ankara'),
	(34, 'istanbul'),
	(35, 'izmir'),
	(26, 'eskisehir'),
	(45, 'manisa'),
	(48, 'mugla'),
	(53, 'rize'),
	(54, 'sakarya'),
	(81, 'duzce'),
	(7, 'antalya');


--
-- Data for Name: koltuklar; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.koltuklar VALUES
	(1, '32', 6),
	(2, '32', 15),
	(3, '50', 6),
	(4, '44', 6),
	(5, '12', 6),
	(6, '10', 6),
	(7, '', 6),
	(8, '33', 9),
	(9, '16', 6),
	(10, '63', 9),
	(11, '19', 6),
	(12, '1', 13),
	(13, '24', 14),
	(14, '11', 9),
	(15, '4', 6),
	(16, '52', 17),
	(17, '45', 11),
	(18, '68', 15),
	(19, '32', 19),
	(20, '50', 10),
	(21, '70', 7),
	(22, '50', 9),
	(23, '35', 1),
	(24, '34', 6),
	(25, '46', 6),
	(26, '38', 15),
	(27, '38', 11),
	(28, '35', 10),
	(29, '15', 6),
	(30, '52', 15),
	(31, '47', 6),
	(34, '29', 7),
	(35, '27', 10),
	(36, '67', 15),
	(37, '38', 9),
	(38, '12', 25),
	(39, '8', 15),
	(40, '59', 25),
	(41, '55', 25),
	(42, '23', 9),
	(43, '14', 10),
	(45, '', 10),
	(48, '', 2),
	(51, '', 1);


--
-- Data for Name: musteri; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.musteri VALUES
	(1, 'Sude', 'Selvi', '05423352632', 'O'),
	(2, 'Nebahat', 'Selvi', '05938563849', 'Y'),
	(3, 'Erol', 'Kilic', '05294719372', 'Y'),
	(4, 'Furkan', 'Aydin', '05249244532', 'Y'),
	(5, 'Zehra Nur', 'Soy', '05974952396', 'O'),
	(6, 'sda', 'asdsa', '05869485940', 'Y'),
	(7, 'asf', 'dfsd', '05839489385', 'O'),
	(8, 'sasafas', 'asdsad', '05849583948', 'Y'),
	(9, 'dvsdv', 'cycyx', '05948267364', 'O'),
	(10, 'asdas', 'asdas', '05849389405', 'Y'),
	(11, 'adsad', 'asdsa', '05948394839', 'Y'),
	(12, 'adsas', 'asd', '05967392849', 'O'),
	(13, 'asd', 'asd', '05938293849', 'Y'),
	(14, 'gh', 'dsg', '05948374928', 'O'),
	(15, 'fgd', 'dfg', '05839273018', 'Y'),
	(16, 'wer', 'wer', '05943829483', 'O'),
	(17, 'sude', 'aydin', '05293840364', 'Y'),
	(18, 'erol', 'ozturk', '05930287394', 'Y'),
	(19, 'oznur', 'savas', '05849382839', 'O'),
	(22, 'adad', 'assada', '05938493849', 'O'),
	(24, 'ssada', 'asdasd', '05493728384', 'O'),
	(28, 'deneme', 'deneme', '05948390202', 'Y'),
	(29, 'sude', 'cetin', '05829301578', 'O'),
	(30, 'furkan', 'yasar', '05291832910', 'Y'),
	(31, 'sevda', 'yildiz', '05292783625', 'Y'),
	(32, 'deniz', 'parlak', '05439871276', 'Y'),
	(33, 'sezgi', 'kurt', '05673402938', 'Y'),
	(34, 'sena', 'güler', '05837489039', 'Y'),
	(35, 'Sude', 'Kaya', '05646564635', 'Y'),
	(36, 'ayse', 'atak', '05382535454', 'Y'),
	(37, 'serra', 'aydin', '05386410490', 'Y'),
	(38, 'cetin', 'yaman', '05849387200', 'O'),
	(43, 'sdfas', 'kgh', '05332343211', 'Y'),
	(44, 'yvyd', 'ydvy', '05969599999', 'Y'),
	(50, 'selin', 'aksu', '05423352633', 'Y'),
	(54, 'ali', 'yasa', '05938492034', 'Y'),
	(56, 'sdfs', 'sdfsd', '09485738573', 'O'),
	(57, 'sdfvd', 'sdvds', '08459385932', 'O'),
	(58, 'asd', 'asd', '09548593049', 'Y'),
	(59, 'wqewq', 'qwe', '02938193821', 'Y'),
	(60, 'asdsa', 'asd', '05938493829', 'Y'),
	(61, 'qada', 'asd', '05928520423', 'Y'),
	(62, 'sda', 'asd', '05284739405', 'Y');


--
-- Data for Name: ogrenci; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.ogrenci VALUES
	(38, 45),
	(56, 45);


--
-- Data for Name: oyuncular; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.oyuncular VALUES
	(1, 'Kate', 'Winslet'),
	(2, 'Sigourney', 'Weaver'),
	(3, 'Zoe', 'Saldana'),
	(4, 'Yeliz', 'Akkaya'),
	(5, 'Deniz', 'Arna'),
	(6, 'Kutsi', '-'),
	(7, 'Selahattin', 'Pasali'),
	(9, 'sude', 'elvi'),
	(10, 'nebahat ', 'selvi'),
	(12, 'erol', 'tas');


--
-- Data for Name: salon_seans; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: salonlar; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.salonlar VALUES
	(1, '1', 1, '72'),
	(2, '2', 1, '72'),
	(3, '3', 1, '72'),
	(4, '4', 1, '72'),
	(5, '5', 1, '72'),
	(6, '1', 2, '72'),
	(7, '2', 2, '72'),
	(8, '3', 2, '72'),
	(9, '1', 4, '72'),
	(10, '2', 4, '72'),
	(11, '1', 5, '72'),
	(12, '2', 5, '72'),
	(13, '3', 5, '72'),
	(14, '1', 6, '72'),
	(15, '1', 3, '72'),
	(17, '1', 10, '72'),
	(18, '2', 10, '72'),
	(19, '3', 10, '72'),
	(20, '4', 10, '72'),
	(21, '2', 3, '72'),
	(22, '3', 3, '72'),
	(25, '4', 3, '72'),
	(26, '5', 3, '72'),
	(27, '2', 6, '72'),
	(32, '1', 9, '72'),
	(35, '2', 9, '72');


--
-- Data for Name: seanslar; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.seanslar VALUES
	(5, '10:00'),
	(6, '11:00'),
	(7, '12:00'),
	(8, '13:00'),
	(9, '14:00'),
	(10, '15:00'),
	(11, '17:00'),
	(12, '19:00'),
	(13, '21:00');


--
-- Data for Name: sinemasalonu; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.sinemasalonu VALUES
	(1, 6, 'armada', 'sogutozu, armada avm 4.kat', '03122344321'),
	(2, 26, 'espark', 'espark avm 3.kat', '02222344321'),
	(3, 7, 'markantalya', 'muratpasa,markantalya avm 2.kat', '03748374932'),
	(4, 35, 'mavibahce', 'Mavişehir, Caher Dudayev Blv, 35590 Karşıyaka/İzmir', '02428394865'),
	(5, 34, 'akasya', 'uskudar, akasya avm 3.kat', '01793782233'),
	(6, 54, 'serdivan', 'serdivan, serdivan avm 3.kat', '07293612384'),
	(7, 26, 'kanatli', 'ismet inönü caddesi, boyner avm 4.kat', '05382394724'),
	(9, 1, 'adana avm', 'adana avm 2.kat', '02222197584'),
	(8, 48, 'fethiye48', 'fethiye, no48 avm 2. kat', '05385241567'),
	(10, 53, 'rize53', 'caykurAvm 2.kat', '02982986767'),
	(12, 45, 'sinemanisa', 'manisa avm 4.kat', '02839389383');


--
-- Data for Name: ssalon_film; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.ssalon_film VALUES
	(1, 1, 2),
	(2, 1, 1),
	(3, 1, 3),
	(4, 1, 4),
	(5, 1, 5),
	(6, 2, 5),
	(7, 2, 6),
	(8, 2, 3),
	(9, 2, 1),
	(10, 3, 1),
	(11, 3, 4),
	(12, 3, 6),
	(13, 3, 6),
	(14, 4, 5),
	(15, 4, 6),
	(16, 4, 7);


--
-- Data for Name: ssalontoplami; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.ssalontoplami VALUES
	(11);


--
-- Data for Name: tur; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.tur VALUES
	(1, 'Aksiyon'),
	(2, 'Animasyon'),
	(3, 'Komedi'),
	(4, 'Dram'),
	(5, 'Bilim-Kurgu');


--
-- Data for Name: yetiskin; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.yetiskin VALUES
	(37, 60),
	(44, 60),
	(50, 60),
	(54, 60),
	(58, 60),
	(60, 60);


--
-- Data for Name: yiyecekler; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.yiyecekler VALUES
	(1, 'istemiyorum', 0, 7),
	(1, 'baharatli cubuk', 30, 8),
	(1, 'kücük boy pop corn', 30, 9),
	(1, 'orta boy pop corn', 40, 10),
	(1, 'buyuk boy pop corn', 50, 11);


--
-- Name: biletler_referans_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.biletler_referans_no_seq', 44, true);


--
-- Name: bufe_bufe_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.bufe_bufe_id_seq', 6, true);


--
-- Name: film_seans_film_seans_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.film_seans_film_seans_id_seq', 59, true);


--
-- Name: film_tur_film_tur_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.film_tur_film_tur_id_seq', 7, true);


--
-- Name: filmdeki_oyuncular_fo_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.filmdeki_oyuncular_fo_no_seq', 15, true);


--
-- Name: filmler_film_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.filmler_film_no_seq', 11, true);


--
-- Name: icecekler_icecek_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.icecekler_icecek_no_seq', 10, true);


--
-- Name: koltuklar_koltuklar_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.koltuklar_koltuklar_id_seq', 51, true);


--
-- Name: musteri_musteri_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.musteri_musteri_id_seq', 62, true);


--
-- Name: oyuncular_oyuncu_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.oyuncular_oyuncu_id_seq', 12, true);


--
-- Name: salon_seans_ssalon_seans_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.salon_seans_ssalon_seans_id_seq', 1, false);


--
-- Name: salonlar_salonlar_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.salonlar_salonlar_id_seq', 35, true);


--
-- Name: seanslar_seans_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.seanslar_seans_id_seq', 13, true);


--
-- Name: sinemasalonu_ssalon_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sinemasalonu_ssalon_id_seq', 12, true);


--
-- Name: ssalon_film_ssalon_film_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ssalon_film_ssalon_film_seq', 16, true);


--
-- Name: yiyecekler_yiyecek_no_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.yiyecekler_yiyecek_no_seq', 12, true);


--
-- Name: filmler FilmlerUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.filmler
    ADD CONSTRAINT "FilmlerUnique" UNIQUE (film_adi, film_format);


--
-- Name: ssalon_film SSalonFilmPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ssalon_film
    ADD CONSTRAINT "SSalonFilmPK" PRIMARY KEY (ssalon_film);


--
-- Name: sinemasalonu SSalonPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinemasalonu
    ADD CONSTRAINT "SSalonPK" PRIMARY KEY (ssalon_id);


--
-- Name: biletler biletlerPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT "biletlerPK" PRIMARY KEY (referans_no);


--
-- Name: bufe bufePK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bufe
    ADD CONSTRAINT "bufePK" PRIMARY KEY (bufe_id);


--
-- Name: bufe bufeUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bufe
    ADD CONSTRAINT "bufeUnique" UNIQUE (bufe_id, ssalon_id);


--
-- Name: filmdeki_oyuncular f_o_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.filmdeki_oyuncular
    ADD CONSTRAINT "f_o_PK" PRIMARY KEY (fo_no);


--
-- Name: film_seans f_s_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.film_seans
    ADD CONSTRAINT "f_s_PK" PRIMARY KEY (film_seans_id);


--
-- Name: film_tur f_t_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.film_tur
    ADD CONSTRAINT "f_t_PK" PRIMARY KEY (film_tur_id);


--
-- Name: filmler filmPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.filmler
    ADD CONSTRAINT "filmPK" PRIMARY KEY (film_no);


--
-- Name: icecekler icecekPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.icecekler
    ADD CONSTRAINT "icecekPK" PRIMARY KEY (bufe_id, icecek_ad);


--
-- Name: iller illerPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.iller
    ADD CONSTRAINT "illerPK" PRIMARY KEY (il_no);


--
-- Name: koltuklar koltuklarPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.koltuklar
    ADD CONSTRAINT "koltuklarPK" PRIMARY KEY (koltuklar_id);


--
-- Name: koltuklar koltuklarUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.koltuklar
    ADD CONSTRAINT "koltuklarUnique" UNIQUE (salonlar_id, koltuk_no);


--
-- Name: musteri musteriPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.musteri
    ADD CONSTRAINT "musteriPK" PRIMARY KEY (musteri_id);


--
-- Name: musteri musteriUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.musteri
    ADD CONSTRAINT "musteriUnique" UNIQUE (musteri_tel);


--
-- Name: ogrenci ogrenciPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ogrenci
    ADD CONSTRAINT "ogrenciPK" PRIMARY KEY (musteri_id);


--
-- Name: oyuncular oyuncularPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.oyuncular
    ADD CONSTRAINT "oyuncularPK" PRIMARY KEY (oyuncu_id);


--
-- Name: oyuncular oyuncularUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.oyuncular
    ADD CONSTRAINT "oyuncularUnique" UNIQUE (oyuncu_adi, oyuncu_soyadi);


--
-- Name: salonlar salonlarPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salonlar
    ADD CONSTRAINT "salonlarPK" PRIMARY KEY (salonlar_id);


--
-- Name: salonlar salonlarUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salonlar
    ADD CONSTRAINT "salonlarUnique" UNIQUE (salon_no, sinemasalonu_id);


--
-- Name: seanslar seanslarPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.seanslar
    ADD CONSTRAINT "seanslarPK" PRIMARY KEY (seans_id);


--
-- Name: salon_seans ssalon_Seans_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salon_seans
    ADD CONSTRAINT "ssalon_Seans_PK" PRIMARY KEY (ssalon_seans_id);


--
-- Name: tur turPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tur
    ADD CONSTRAINT "turPK" PRIMARY KEY (tur_id);


--
-- Name: yetiskin yetiskinPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yetiskin
    ADD CONSTRAINT "yetiskinPK" PRIMARY KEY (musteri_id);


--
-- Name: yiyecekler yiyeceklerPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yiyecekler
    ADD CONSTRAINT "yiyeceklerPK" PRIMARY KEY (bufe_id, yiyecek_ad);


--
-- Name: filmler filmkucukharf; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER filmkucukharf BEFORE INSERT OR UPDATE ON public.filmler FOR EACH ROW EXECUTE FUNCTION public.kucukharfedonustur();


--
-- Name: oyuncular oyuncukucult; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER oyuncukucult BEFORE INSERT OR UPDATE ON public.oyuncular FOR EACH ROW EXECUTE FUNCTION public.oyuncuisimdonustur();


--
-- Name: sinemasalonu sstoplamtrigger; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER sstoplamtrigger AFTER INSERT ON public.sinemasalonu FOR EACH ROW EXECUTE FUNCTION public.toplamsinemasalonu();


--
-- Name: sinemasalonu sstoplamtrigger2; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER sstoplamtrigger2 AFTER DELETE ON public.sinemasalonu FOR EACH ROW EXECUTE FUNCTION public.toplamsinemasalonu2();


--
-- Name: yiyecekler yemek_fiyat; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER yemek_fiyat BEFORE INSERT OR UPDATE ON public.yiyecekler FOR EACH ROW EXECUTE FUNCTION public.dusukfiyat();


--
-- Name: sinemasalonu SSalonFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sinemasalonu
    ADD CONSTRAINT "SSalonFK" FOREIGN KEY (il) REFERENCES public.iller(il_no);


--
-- Name: ssalon_film SSalonFilm_film_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ssalon_film
    ADD CONSTRAINT "SSalonFilm_film_FK" FOREIGN KEY (film_no) REFERENCES public.filmler(film_no);


--
-- Name: ssalon_film SSalonFilm_ssalon_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ssalon_film
    ADD CONSTRAINT "SSalonFilm_ssalon_FK" FOREIGN KEY (ssalon_id) REFERENCES public.sinemasalonu(ssalon_id);


--
-- Name: biletler biletlerBufeIdFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT "biletlerBufeIdFK" FOREIGN KEY (bufe_id) REFERENCES public.bufe(bufe_id);


--
-- Name: biletler biletlerFilmNoFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT "biletlerFilmNoFK" FOREIGN KEY (film_no) REFERENCES public.filmler(film_no);


--
-- Name: biletler biletlerMusteriFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT "biletlerMusteriFK" FOREIGN KEY (musteri) REFERENCES public.musteri(musteri_id) ON DELETE CASCADE;


--
-- Name: biletler biletlerSSalonFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT "biletlerSSalonFK" FOREIGN KEY (ssalon_id) REFERENCES public.sinemasalonu(ssalon_id);


--
-- Name: biletler biletlerSalonNoFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT "biletlerSalonNoFK" FOREIGN KEY (salonlar_id) REFERENCES public.salonlar(salonlar_id);


--
-- Name: icecekler bufeIcecekFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.icecekler
    ADD CONSTRAINT "bufeIcecekFK" FOREIGN KEY (bufe_id) REFERENCES public.bufe(bufe_id) ON DELETE CASCADE;


--
-- Name: bufe bufeSSalonIdFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bufe
    ADD CONSTRAINT "bufeSSalonIdFK" FOREIGN KEY (ssalon_id) REFERENCES public.sinemasalonu(ssalon_id);


--
-- Name: yiyecekler bufeYiyecekFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yiyecekler
    ADD CONSTRAINT "bufeYiyecekFK" FOREIGN KEY (bufe_id) REFERENCES public.bufe(bufe_id) ON DELETE CASCADE;


--
-- Name: filmdeki_oyuncular f_o_filmFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.filmdeki_oyuncular
    ADD CONSTRAINT "f_o_filmFK" FOREIGN KEY (film) REFERENCES public.filmler(film_no) ON DELETE CASCADE;


--
-- Name: filmdeki_oyuncular f_o_oyuncuFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.filmdeki_oyuncular
    ADD CONSTRAINT "f_o_oyuncuFK" FOREIGN KEY (oyuncu) REFERENCES public.oyuncular(oyuncu_id);


--
-- Name: film_seans f_s_filmFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.film_seans
    ADD CONSTRAINT "f_s_filmFK" FOREIGN KEY (film) REFERENCES public.filmler(film_no) ON DELETE CASCADE;


--
-- Name: film_tur f_s_filmFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.film_tur
    ADD CONSTRAINT "f_s_filmFK" FOREIGN KEY (film) REFERENCES public.filmler(film_no) ON DELETE CASCADE;


--
-- Name: film_seans f_s_seansFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.film_seans
    ADD CONSTRAINT "f_s_seansFK" FOREIGN KEY (seans) REFERENCES public.seanslar(seans_id) ON DELETE CASCADE;


--
-- Name: film_tur f_t_turuFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.film_tur
    ADD CONSTRAINT "f_t_turuFK" FOREIGN KEY (turu) REFERENCES public.tur(tur_id) ON DELETE CASCADE;


--
-- Name: biletler koltuk_no_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT "koltuk_no_FK" FOREIGN KEY (koltuk_no) REFERENCES public.koltuklar(koltuklar_id);


--
-- Name: koltuklar koltuklarSalonNoPK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.koltuklar
    ADD CONSTRAINT "koltuklarSalonNoPK" FOREIGN KEY (salonlar_id) REFERENCES public.salonlar(salonlar_id);


--
-- Name: ogrenci ogrenciFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ogrenci
    ADD CONSTRAINT "ogrenciFK" FOREIGN KEY (musteri_id) REFERENCES public.musteri(musteri_id) ON DELETE CASCADE;


--
-- Name: biletler seans_saat_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT "seans_saat_FK" FOREIGN KEY (seans_saat) REFERENCES public.seanslar(seans_id);


--
-- Name: biletler seans_tarih_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT "seans_tarih_FK" FOREIGN KEY (seans_tarih) REFERENCES public.film_seans(film_seans_id);


--
-- Name: salonlar sinemadakiSalonlarFk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salonlar
    ADD CONSTRAINT "sinemadakiSalonlarFk" FOREIGN KEY (sinemasalonu_id) REFERENCES public.sinemasalonu(ssalon_id);


--
-- Name: salon_seans ssalon_Seans_seans_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salon_seans
    ADD CONSTRAINT "ssalon_Seans_seans_FK" FOREIGN KEY (seans_id) REFERENCES public.seanslar(seans_id);


--
-- Name: salon_seans ssalon_seans_salon_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salon_seans
    ADD CONSTRAINT "ssalon_seans_salon_FK" FOREIGN KEY (salonlar_id) REFERENCES public.salonlar(salonlar_id);


--
-- Name: yetiskin yetiskinFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yetiskin
    ADD CONSTRAINT "yetiskinFK" FOREIGN KEY (musteri_id) REFERENCES public.musteri(musteri_id) ON DELETE CASCADE;


--
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE USAGE ON SCHEMA public FROM PUBLIC;
GRANT ALL ON SCHEMA public TO PUBLIC;


--
-- PostgreSQL database dump complete
--

