Drop Schema If Exists santos;
Create Schema santos;
Use santos;

Create Table usuario
(
	nm_login varchar(200),
	nm_usuario varchar(200),
	nm_senha varchar(64),
	constraint pk_usuario primary key (nm_login)
);

Insert into usuario values ('proffreddy@etec.com', 'Frederico Arco e Flexa Machado Justo', md5('123'));
Insert into usuario values ('tavares@etec.com', 'Luiz Tavares', md5('123'));
Insert into usuario values ('andrereis@etec.com', 'Andre Reis', md5('123'));
Insert into usuario values ('maristela@etec.com', 'Maristela Gamba', md5('123'));