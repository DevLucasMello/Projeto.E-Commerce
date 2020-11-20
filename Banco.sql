CREATE DATABASE `pcsantosdb`;

USE `pcsantosdb`;

CREATE TABLE `cliente` (
  `Id` varchar(50) PRIMARY KEY NOT NULL,
  `Nome` varchar(100) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Senha` varchar(100) DEFAULT NULL,
  `CPF`varchar(20) DEFAULT NULL,
  `DataNasc`date DEFAULT NULL,
  `Sexo`varchar (15) DEFAULT NULL,
  `Telefone`varchar(50) DEFAULT NULL,
  `CEP`varchar (15) DEFAULT NULL,
  `Endereco`varchar (100) DEFAULT NULL,
  `Numero` varchar (8) DEFAULT NULL,
  `Bairro`varchar (100) DEFAULT NULL,
  `Cidade`varchar (50) DEFAULT NULL,
  `Estado`varchar (50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `produto` (
  `Id` varchar(50) PRIMARY KEY NOT NULL,
  `Categoria` varchar(100) DEFAULT NULL,
  `Descricao` varchar(100) DEFAULT NULL,
  `Valor` decimal(10,2) DEFAULT NULL,
  `FichaTecnica` text DEFAULT NULL  
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `pedido` (  
  `Id` varchar(50) NOT NULL,
  `Numero` int PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `PedidoStatus` int DEFAULT NULL,
  `ClienteId` varchar(50) DEFAULT NULL,
  `ClienteNome` varchar(100) DEFAULT NULL,
  `ClienteEmail` varchar(100) DEFAULT NULL,
  `ClienteSenha` varchar(50) DEFAULT NULL,
  `ClienteCPF` varchar(30) DEFAULT NULL,
  `ClienteDataNasc` datetime DEFAULT NULL,
  `ClienteSexo` varchar(15) DEFAULT NULL,
  `ClienteTelefone` varchar(50) DEFAULT NULL,
  `ClienteCEP` varchar(50) DEFAULT NULL,
  `ClienteEndereco` varchar(100) DEFAULT NULL,
  `ClienteNumero` varchar(10) DEFAULT NULL,
  `ClienteBairro` varchar(100) DEFAULT NULL,
  `ClienteCidade` varchar(50) DEFAULT NULL,
  `ClienteEstado` varchar(30) DEFAULT NULL,
  `ValorTotal` decimal (10,2) DEFAULT NULL,
   CONSTRAINT fk_PedCliente Foreign key (ClienteId) references cliente(Id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `pedidoItem` (
  `Id` varchar(50) PRIMARY KEY NOT NULL,  
  `NumeroPedido` int DEFAULT NULL,
  `ProdutoId` varchar(50) DEFAULT NULL,
  `ProdutoCategoria` varchar(50) DEFAULT NULL,
  `ProdutoDescricao` varchar(50) DEFAULT NULL,
  `ProdutoValor` decimal (10,2) DEFAULT NULL,
  `ProdutoFichaTecnica` text DEFAULT NULL,
  `Quantidade` int DEFAULT NULL,
  `Total` decimal (10,2) DEFAULT NULL,
   CONSTRAINT fk_ItemPedido Foreign key (NumeroPedido) references pedido(Numero),
   CONSTRAINT fk_ItemProduto Foreign key (ProdutoId) references produto(Id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PedidoIncluir`(
  Id varchar(50),
  Numero int,  
  PedidoStatus int,
  ClienteId varchar(50),
  ClienteNome varchar(100),
  ClienteEmail varchar(100),
  ClienteSenha varchar(50),
  ClienteCPF varchar(30),
  ClienteDataNasc datetime,
  ClienteSexo varchar(15),
  ClienteTelefone varchar(50),
  ClienteCEP varchar(50),
  ClienteEndereco varchar(100),
  ClienteNumero varchar(10),
  ClienteBairro varchar(100),
  ClienteCidade varchar(50),
  ClienteEstado varchar(30),
  ValorTotal decimal (10,2)
)
BEGIN

Insert into pedido(Id,Numero,PedidoStatus,ClienteId,ClienteNome,ClienteEmail,ClienteSenha,ClienteCPF,ClienteDataNasc,ClienteSexo,ClienteTelefone,ClienteCEP,ClienteEndereco,ClienteNumero,ClienteBairro,ClienteCidade,ClienteEstado,ValorTotal)
values(Id,Numero,PedidoStatus,ClienteId,ClienteNome,ClienteEmail,ClienteSenha,ClienteCPF,ClienteDataNasc,ClienteSexo,ClienteTelefone,ClienteCEP,ClienteEndereco,ClienteNumero,ClienteBairro,ClienteCidade,ClienteEstado,ValorTotal);

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PedidoItemIncluir`(
  Id varchar(50),  
  NumeroPedido int,
  ProdutoId varchar(50),
  ProdutoCategoria varchar(50),
  ProdutoDescricao varchar(50),
  ProdutoValor decimal (10,2),
  ProdutoFichaTecnica text,
  Quantidade int,
  Total decimal (10,2)
)
BEGIN

Insert into pedidoitem(Id,NumeroPedido,ProdutoId,ProdutoCategoria,ProdutoDescricao,ProdutoValor,ProdutoFichaTecnica,Quantidade,Total)
values(Id,NumeroPedido,ProdutoId,ProdutoCategoria,ProdutoDescricao,ProdutoValor,ProdutoFichaTecnica,Quantidade,Total);

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PedidoObterPorNumero`(Numero int)

BEGIN

SELECT Id,Numero,PedidoStatus,ClienteId,ClienteNome,ClienteEmail,ClienteSenha,ClienteCPF,ClienteDataNasc,ClienteSexo,ClienteTelefone,ClienteCEP,ClienteEndereco,ClienteNumero,ClienteBairro,ClienteCidade,ClienteEstado,ValorTotal
FROM pedido p 
WHERE p.Numero=Numero;

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PedidoItemObterPorNumeroPedido`(NumeroPedido int)

BEGIN

SELECT Id,NumeroPedido,ProdutoId,ProdutoCategoria,ProdutoDescricao,ProdutoValor,ProdutoFichaTecnica,Quantidade,Total
FROM pedidoItem p 
WHERE p.NumeroPedido=NumeroPedido;

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PedidoObterPorClienteId`(ClienteId varchar(50))

BEGIN

SELECT Id,Numero,PedidoStatus,ClienteId,ClienteNome,ClienteEmail,ClienteSenha,ClienteCPF,ClienteDataNasc,ClienteSexo,ClienteTelefone,ClienteCEP,ClienteEndereco,ClienteNumero,ClienteBairro,ClienteCidade,ClienteEstado,ValorTotal
FROM pedido p 
WHERE p.ClienteId=ClienteId;

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PedidoObterPorId`(Id varchar(50))
BEGIN

SELECT Id,Numero,PedidoStatus,ClienteId,ClienteNome,ClienteEmail,ClienteSenha,ClienteCPF,ClienteDataNasc,ClienteSexo,ClienteTelefone,ClienteCEP,ClienteEndereco,ClienteNumero,ClienteBairro,ClienteCidade,ClienteEstado,ValorTotal
FROM pedido p 
WHERE p.Id=Id;

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ClienteIncluir`(
  Id varchar(50),
  Nome varchar(100),
  Email varchar(100),
  Senha varchar(100),
  CPF varchar(20),
  DataNasc date,
  Sexo varchar (15),
  Telefone varchar(50),
  CEP varchar (15),
  Endereco varchar (100),
  Numero varchar (8),
  Bairro varchar (100),
  Cidade varchar (50),
  Estado varchar (50)
)
BEGIN

Insert into cliente(Id,Nome,Email,Senha,CPF,DataNasc,Sexo,Telefone,CEP,Endereco,Numero,Bairro,Cidade,Estado)
values(Id,Nome,Email,Senha,CPF,DataNasc,Sexo,Telefone,CEP,Endereco,Numero,Bairro,Cidade,Estado);

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ClienteAlterar`(
	Id varchar(50),
  Nome varchar(100),
  Email varchar(100),
  Senha varchar(100),
  CPF varchar(20),
  DataNasc date,
  Sexo varchar (15),
  Telefone varchar(50),
  CEP varchar (15),
  Endereco varchar (100),
  Numero varchar (8),
  Bairro varchar (100),
  Cidade varchar (50),
  Estado varchar (50)
)
BEGIN

update cliente c
set c.Nome=Nome,
c.Email=Email, 
c.Senha=Senha, 
c.CPF=CPF, 
c.DataNasc=DataNasc, 
c.Sexo=Sexo, 
c.Telefone=Telefone, 
c.CEP=CEP, 
c.Endereco=Endereco, 
c.Numero=Numero, 
c.Bairro=Bairro,
c.Cidade=Cidade,
c.Estado=Estado
where c.Id=Id;

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ClienteObterPorEmailSenha`(
Email varchar(100),
Senha varchar(100)
)
BEGIN

select c.Id, c.Nome, c.Email, c.Senha, c.CPF, c.DataNasc, c.Sexo, c.Telefone, c.CEP, c.Endereco, c.Numero, c.Bairro, c.Cidade, c.Estado
from cliente c
where c.Email=Email and c.Senha=Senha;

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ClienteObterPorId`(Id varchar(50))
BEGIN

select c.Id, c.Nome, c.Email, c.Senha, c.CPF, c.DataNasc, c.Sexo, c.Telefone, c.CEP, c.Endereco, c.Numero, c.Bairro, c.Cidade, c.Estado
from cliente c
where c.Id=Id;

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ProdutoObterPorCategoria`(Categoria varchar(100))
BEGIN

select  p.Id, p.Categoria, p.Descricao, p.Valor, p.FichaTecnica
from produto p
where p.Categoria=Categoria;

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ProdutoObterPorId`(Id varchar(50))
BEGIN

select  p.Id,  p.Categoria, p.Descricao, p.Valor, p.FichaTecnica
from produto p
where p.Id=Id;

END;;
DELIMITER ;;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ProdutoObterTodos`()
BEGIN

select  p.Id, p.Categoria, p.Descricao, p.Valor, p.FichaTecnica
from produto p;

END;;
DELIMITER ;;



