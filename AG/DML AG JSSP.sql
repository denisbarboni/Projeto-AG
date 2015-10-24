CREATE TABLE sku(
	id_sku int NOT NULL,
	nome_sku VARCHAR(100), 
	peso_caixa numeric(15,4),
	constraint pk_sku primary key (id_sku)
); -- Cria Tabela com respectivos campos.

CREATE TABLE unidade(
	codigo VARCHAR(4) NOT NULL,
	nome VARCHAR(100),
	constraint pk_codigo primary key (codigo)
); 

CREATE TABLE setor(
	id_setor INT NOT NULL,
	nome VARCHAR(100),
	constraint pk_setor primary key (id_setor)
); 

CREATE TABLE maquina(
	id_maquina INT NOT NULL,
	nome VARCHAR(100),
	constraint pk_maquina primary key (id_maquina)
);

CREATE TABLE velocidade(
	id_velocidade INT NOT NULL,
	id_setor INT,
	id_maquina INT,
	id_sku INT,
	velocidade_hora numeric(5,4),
	constraint pk_velocidade primary key (id_velocidade, id_setor, id_maquina, id_sku),
	constraint fk_velocidade_setor foreign key (id_setor) references setor (id_setor),
	constraint fk_velocidade_maquina foreign key (id_maquina) references maquina (id_maquina),
	constraint fk_velocidade_sku foreign key (id_sku) references sku (id_sku)
); -- tROCAR PARA CHAVE COMPOSTA.

CREATE TABLE job(
	id_job INT NOT NULL,
	id_sku int, 
	quantidade numeric(15,4),
	constraint pk_job primary key (id_job),
	constraint fk_job_sku foreign key (id_sku) references sku (id_sku)
); -- Cria Tabela com respectivos campos.

CREATE TABLE plano (
	IdPlano int not null,
	Nome varchar(50) not null,
	Descricao text not null,
	Valor numeric (5,2) not null,
	constraint Pk_plano primary key (IdPlano)
);

CREATE SEQUENCE nextplano
INCREMENT 1
MINVALUE 1
MAXVALUE 99999999999
START 1
CACHE 1;

INSERT INTO plano VALUES (nextval('nextplano'), 'Principal', 'Plano Principal de 100 reais', 100.00);

CREATE TABLE usuario (
	IdUsuario int not null,
	Login varchar(30) not null,
	Senha varchar(30) not null,
	IdPlano int not null,
	constraint pk_usuario primary key (IdUsuario),
	constraint fk_usuario_plano foreign key (IdPlano) references plano (IdPlano)
);

CREATE SEQUENCE nextuser
INCREMENT 1
MINVALUE 1
MAXVALUE 99999999999
START 1
CACHE 1;

INSERT INTO usuario VALUES (nextval('nextuser'), 'ADMIN', '123', 1);

CREATE TABLE configuracao(
	IdUser int not null,
	SolucaoMax numeric(15,5) not null,
	TaxaCrossover numeric(1,1) not null,
	TaxaMutacao numeric(1,1) not null,
	Eltismo boolean null,
	TotalPopulacao int not null,
	TotalGeracao int not null,
	constraint pk_configuracao primary key (IdUser),
	constraint fk_confgs_user foreign key (idUser) references usuario (IdUsuario)
);

INSERT INTO Configuracao VALUES (1,9999,0.6,0.4,true,10,3000);

CREATE SEQUENCE nextjob
INCREMENT 1
MINVALUE 1
MAXVALUE 99999999999
START 1
CACHE 1;

CREATE SEQUENCE nextmaquina
INCREMENT 1
MINVALUE 1
MAXVALUE 99999999999
START 1
CACHE 1;

CREATE SEQUENCE nextsetor
INCREMENT 1
MINVALUE 1
MAXVALUE 99999999999
START 1
CACHE 1;

CREATE SEQUENCE nextsku
INCREMENT 1
MINVALUE 1
MAXVALUE 99999999999
START 1
CACHE 1;

CREATE SEQUENCE nextvelocidade
INCREMENT 1
MINVALUE 1
MAXVALUE 99999999999
START 1
CACHE 1;

CREATE SEQUENCE nextunidade
INCREMENT 1
MINVALUE 1
MAXVALUE 99999999999
START 1
CACHE 1;

ALTER TABLE maquina ADD COLUMN IdUser int not null;
ALTER TABLE maquina add constraint fk_maquina_user foreign key (idUser) references usuario (IdUsuario);

ALTER TABLE setor ADD COLUMN IdUser int not null;
ALTER TABLE setor add constraint fk_setor_user foreign key (idUser) references usuario (IdUsuario);

ALTER TABLE sku ADD COLUMN IdUser int not null;
ALTER TABLE sku add constraint fk_sku_user foreign key (idUser) references usuario (IdUsuario);

ALTER TABLE unidade ADD COLUMN IdUser int not null;
ALTER TABLE unidade add constraint fk_unidade_user foreign key (idUser) references usuario (IdUsuario);

ALTER TABLE job ADD COLUMN IdUser int not null;
ALTER TABLE job add constraint fk_job_user foreign key (idUser) references usuario (IdUsuario);

ALTER TABLE velocidade ADD COLUMN IdUser int not null;
ALTER TABLE velocidade add constraint fk_velocidade_user foreign key (idUser) references usuario (IdUsuario);

ALTER TABLE velocidade ALTER COLUMN velocidade_hora type numeric(10,4);

select  * from usuario