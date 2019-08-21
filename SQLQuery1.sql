       
CREATE DATABASE T_Peoples;

USE T_Peoples

Create table Funcionarios
(
	IdFuncionarios int primary key identity
	,Nome Varchar(200) not null 
	,Sobrenome Varchar (200) not null 
);
 insert into Funcionarios(Nome, Sobrenome) Values('Catarina' , 'Strada')
												,('Taddeu' , 'Vitelli')
insert into Funcionarios(Nome, Sobrenome) Values('Josefa' , 'Reis');

select * FROM Funcionarios;



select * from Funcionarios where IdFuncionarios = 2

delete from Funcionarios where IdFuncionarios = 3

update Funcionarios set Nome = 'Taddeu' where IdFuncionarios = 2

update Funcionarios set Nome = 'Catarina' where IdFuncionarios = 1
