/* Criar Banco de Dados */
CREATE DATABASE myfinance
GO

USE myfinance
GO

/* Estrutura do Banco de dados */
CREATE TABLE planoconta(
	id int IDENTITY(1,1) NOT NULL,
	descricao VARCHAR(50) NOT NULL,
	tipo CHAR(1),
	PRIMARY KEY (id)
	
)
GO

/* Inserir primeira carga de dados */
INSERT INTO planoconta(descricao, tipo) VALUES('Combustível', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Salário', 'R')
INSERT INTO planoconta(descricao, tipo) VALUES('Alimentação', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Impostos', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Água', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Luz', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Internet', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Cartão de Crédito', 'D')


/* Estrutura do Banco de dados */
CREATE TABLE transacao(
    id int IDENTITY(1,1) NOT NULL,
    data datetime NOT NULL,
    valor decimal(9,2) NOT NULL,
    historico varchar(100) NULL,
    planoconta_id int NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (planoconta_id) REFERENCES planoconta(id)
)
GO

/* Inserir primeira carga de dados */
INSERT INTO transacao(data, valor, historico, planoconta_id) VALUES(GETDATE(), 25, 'Café da Manhã', 3)
INSERT INTO transacao(data, valor, historico, planoconta_id) VALUES(GETDATE(), 38, 'Gasolina Moto', 1)
INSERT INTO transacao(data, valor, historico, planoconta_id) VALUES(GETDATE(), 100, 'Salario Empresa 1', 2)
INSERT INTO transacao(data, valor, historico, planoconta_id) VALUES('20230610', 350, 'IPTU', 4)
INSERT INTO transacao(data, valor, historico, planoconta_id) VALUES('20230608', 250, 'Copasa', 5)
INSERT INTO transacao(data, valor, historico, planoconta_id) VALUES('20230608', 350, 'CEMIG', 6)
INSERT INTO transacao(data, valor, historico, planoconta_id) VALUES('20230605', 125, 'Internet Casa', 7)
INSERT INTO transacao(data, valor, historico, planoconta_id) VALUES('20230612', 600, 'Cartão Santander', 8)