PGDMP                  
    |            opd    16.4    16.4 3    !           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            "           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            #           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            $           1262    16497    opd    DATABASE     w   CREATE DATABASE opd WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE opd;
                postgres    false            �            1259    16593    break_history    TABLE     �   CREATE TABLE public.break_history (
    id integer NOT NULL,
    time_ timestamp without time zone,
    seria character varying,
    machine_type character varying
);
 !   DROP TABLE public.break_history;
       public         heap    postgres    false            �            1259    16592    break_history_id_seq    SEQUENCE     �   CREATE SEQUENCE public.break_history_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.break_history_id_seq;
       public          postgres    false    226            %           0    0    break_history_id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.break_history_id_seq OWNED BY public.break_history.id;
          public          postgres    false    225            �            1259    16579    equimpet    TABLE     �   CREATE TABLE public.equimpet (
    id integer NOT NULL,
    fk_line_id integer,
    machine_type character varying,
    seria character varying,
    weight_untill_break integer,
    probeg integer
);
    DROP TABLE public.equimpet;
       public         heap    postgres    false            �            1259    16578    equimpet_id_seq    SEQUENCE     �   CREATE SEQUENCE public.equimpet_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.equimpet_id_seq;
       public          postgres    false    224            &           0    0    equimpet_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.equimpet_id_seq OWNED BY public.equimpet.id;
          public          postgres    false    223            �            1259    16559    factory_line    TABLE     >   CREATE TABLE public.factory_line (
    id integer NOT NULL
);
     DROP TABLE public.factory_line;
       public         heap    postgres    false            �            1259    16558    factory_line_id_seq    SEQUENCE     �   CREATE SEQUENCE public.factory_line_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.factory_line_id_seq;
       public          postgres    false    220            '           0    0    factory_line_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.factory_line_id_seq OWNED BY public.factory_line.id;
          public          postgres    false    219            �            1259    16545    for_employers    TABLE     �   CREATE TABLE public.for_employers (
    id integer NOT NULL,
    weight_defect_product integer,
    what_date timestamp without time zone
);
 !   DROP TABLE public.for_employers;
       public         heap    postgres    false            �            1259    16544    for_employers_id_seq    SEQUENCE     �   CREATE SEQUENCE public.for_employers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.for_employers_id_seq;
       public          postgres    false    216            (           0    0    for_employers_id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.for_employers_id_seq OWNED BY public.for_employers.id;
          public          postgres    false    215            �            1259    16552    plan    TABLE     �   CREATE TABLE public.plan (
    id integer NOT NULL,
    what_date timestamp without time zone,
    product_plan integer,
    product_real_quantity integer
);
    DROP TABLE public.plan;
       public         heap    postgres    false            �            1259    16551    plan_id_seq    SEQUENCE     �   CREATE SEQUENCE public.plan_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 "   DROP SEQUENCE public.plan_id_seq;
       public          postgres    false    218            )           0    0    plan_id_seq    SEQUENCE OWNED BY     ;   ALTER SEQUENCE public.plan_id_seq OWNED BY public.plan.id;
          public          postgres    false    217            �            1259    16566    scales    TABLE     �   CREATE TABLE public.scales (
    id integer NOT NULL,
    fk_line_id integer,
    time_ timestamp without time zone,
    weight_out integer
);
    DROP TABLE public.scales;
       public         heap    postgres    false            �            1259    16565    scales_id_seq    SEQUENCE     �   CREATE SEQUENCE public.scales_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.scales_id_seq;
       public          postgres    false    222            *           0    0    scales_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.scales_id_seq OWNED BY public.scales.id;
          public          postgres    false    221            �            1259    16601    users    TABLE     �   CREATE TABLE public.users (
    id integer NOT NULL,
    name_ character varying,
    sec_name character varying,
    post character varying
);
    DROP TABLE public.users;
       public         heap    postgres    false            r           2604    16596    break_history id    DEFAULT     t   ALTER TABLE ONLY public.break_history ALTER COLUMN id SET DEFAULT nextval('public.break_history_id_seq'::regclass);
 ?   ALTER TABLE public.break_history ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    225    226    226            q           2604    16582    equimpet id    DEFAULT     j   ALTER TABLE ONLY public.equimpet ALTER COLUMN id SET DEFAULT nextval('public.equimpet_id_seq'::regclass);
 :   ALTER TABLE public.equimpet ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    223    224    224            o           2604    16562    factory_line id    DEFAULT     r   ALTER TABLE ONLY public.factory_line ALTER COLUMN id SET DEFAULT nextval('public.factory_line_id_seq'::regclass);
 >   ALTER TABLE public.factory_line ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    220    219    220            m           2604    16548    for_employers id    DEFAULT     t   ALTER TABLE ONLY public.for_employers ALTER COLUMN id SET DEFAULT nextval('public.for_employers_id_seq'::regclass);
 ?   ALTER TABLE public.for_employers ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    215    216    216            n           2604    16555    plan id    DEFAULT     b   ALTER TABLE ONLY public.plan ALTER COLUMN id SET DEFAULT nextval('public.plan_id_seq'::regclass);
 6   ALTER TABLE public.plan ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    217    218    218            p           2604    16569 	   scales id    DEFAULT     f   ALTER TABLE ONLY public.scales ALTER COLUMN id SET DEFAULT nextval('public.scales_id_seq'::regclass);
 8   ALTER TABLE public.scales ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    221    222    222                      0    16593    break_history 
   TABLE DATA           G   COPY public.break_history (id, time_, seria, machine_type) FROM stdin;
    public          postgres    false    226   R6                 0    16579    equimpet 
   TABLE DATA           d   COPY public.equimpet (id, fk_line_id, machine_type, seria, weight_untill_break, probeg) FROM stdin;
    public          postgres    false    224   �6                 0    16559    factory_line 
   TABLE DATA           *   COPY public.factory_line (id) FROM stdin;
    public          postgres    false    220   i7                 0    16545    for_employers 
   TABLE DATA           M   COPY public.for_employers (id, weight_defect_product, what_date) FROM stdin;
    public          postgres    false    216   �7                 0    16552    plan 
   TABLE DATA           R   COPY public.plan (id, what_date, product_plan, product_real_quantity) FROM stdin;
    public          postgres    false    218   �7                 0    16566    scales 
   TABLE DATA           C   COPY public.scales (id, fk_line_id, time_, weight_out) FROM stdin;
    public          postgres    false    222   �7                 0    16601    users 
   TABLE DATA           :   COPY public.users (id, name_, sec_name, post) FROM stdin;
    public          postgres    false    227   W8       +           0    0    break_history_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.break_history_id_seq', 3, true);
          public          postgres    false    225            ,           0    0    equimpet_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.equimpet_id_seq', 1, true);
          public          postgres    false    223            -           0    0    factory_line_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.factory_line_id_seq', 1, false);
          public          postgres    false    219            .           0    0    for_employers_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.for_employers_id_seq', 1, false);
          public          postgres    false    215            /           0    0    plan_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.plan_id_seq', 1, false);
          public          postgres    false    217            0           0    0    scales_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.scales_id_seq', 1, false);
          public          postgres    false    221            ~           2606    16600     break_history break_history_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.break_history
    ADD CONSTRAINT break_history_pkey PRIMARY KEY (id);
 J   ALTER TABLE ONLY public.break_history DROP CONSTRAINT break_history_pkey;
       public            postgres    false    226            |           2606    16586    equimpet equimpet_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.equimpet
    ADD CONSTRAINT equimpet_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.equimpet DROP CONSTRAINT equimpet_pkey;
       public            postgres    false    224            x           2606    16564    factory_line factory_line_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.factory_line
    ADD CONSTRAINT factory_line_pkey PRIMARY KEY (id);
 H   ALTER TABLE ONLY public.factory_line DROP CONSTRAINT factory_line_pkey;
       public            postgres    false    220            t           2606    16550     for_employers for_employers_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.for_employers
    ADD CONSTRAINT for_employers_pkey PRIMARY KEY (id);
 J   ALTER TABLE ONLY public.for_employers DROP CONSTRAINT for_employers_pkey;
       public            postgres    false    216            v           2606    16557    plan plan_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY public.plan
    ADD CONSTRAINT plan_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.plan DROP CONSTRAINT plan_pkey;
       public            postgres    false    218            z           2606    16571    scales scales_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.scales
    ADD CONSTRAINT scales_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.scales DROP CONSTRAINT scales_pkey;
       public            postgres    false    222            �           2606    16607    users users_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    227            �           2606    16587 !   equimpet equimpet_fk_line_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.equimpet
    ADD CONSTRAINT equimpet_fk_line_id_fkey FOREIGN KEY (fk_line_id) REFERENCES public.factory_line(id);
 K   ALTER TABLE ONLY public.equimpet DROP CONSTRAINT equimpet_fk_line_id_fkey;
       public          postgres    false    4728    220    224            �           2606    16572    scales scales_fk_line_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.scales
    ADD CONSTRAINT scales_fk_line_id_fkey FOREIGN KEY (fk_line_id) REFERENCES public.factory_line(id);
 G   ALTER TABLE ONLY public.scales DROP CONSTRAINT scales_fk_line_id_fkey;
       public          postgres    false    222    4728    220               E   x�3�4202�54�52S00�2��20�36��01�	q���04估��֋��.컰Ċ������ �~         �   x���A
�0@���0�I�d�쪥��=�g�n�x��'� (=��FN�����<�0�� _y��?�¯����*�<Ҁ&Q6��y�#���;߄���hۮC܉�Q��Z�= ���U�ڳL��ie����w��6d4d����p�V][���R&?�,K"L��~!�$��(+��n�            x�3�2����� n             x������ � �            x������ � �         �   x�u��B1�s�
0���>���;�!��=yca1�*�b�P}e�;��W�B
mS�� �˪�H�h����Z�R��Y5zM2�z�X�E�X?f�c��S2���O�e�s��l�Kҿ�l�u���m���	��8#         �   x�]�[
�0E�'��|��Ŵ�����G%���;;�Nꗄ@frr�d"8�E�\S|A	�����/v;�	=��hPi���ׂ�Ls<��T�G����2�To��3qC��f�Y1p�f|˲J-W���(���'��wps�%z>mFG��x��g�µ[�E����]ǰh*8�x�����/����c����μ     