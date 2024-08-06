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

delimiter $$

Drop procedure if exists listarUsuarios$$
Create procedure listarUsuarios()
begin
	Select nm_login, nm_usuario from usuario order by nm_usuario;
end$$

Drop procedure if exists acessar$$
Create procedure acessar(pLogin varchar(200), pSenha varchar(64))
begin
	Select nm_usuario from usuario where nm_login = pLogin and nm_senha = md5(pSenha);
end$$

delimiter ;