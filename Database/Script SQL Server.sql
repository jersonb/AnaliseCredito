-- Modele uma estrutura de dados do seguinte caso:
-- - Um cliente tem os seguintes campos : Nome, Id Cliente, UF, Celular
-- - Um cliente tem N financiamentos.
-- - Um financiamento tem os seguintes campos : Id Cliente, Tipo Financiamento, Valor Total, Data  Vencimento
-- - Cada financiamento tem N parcelas, cujas tem os seguintes campos : Id Financiamento, Número  da Parcela, Valor Parcela, Data Vencimento, Data Pagamento;

-- Crie as tabelas que julgue necessárias e insira alguns registros de testes na mesma.

-- Elabore as seguintes querys:
-- - Listar todos os clientes do estado de SP que tenham mais de 60% das parcelas pagas.
-- - Listar os primeiros 4 clientes que tenham alguma parcela com mais de 05 dias atrasadas (Data Vencimento maior que data atual E data pagamento nula)
-- - Listar todos os clientes que já atrasaram em algum momento duas ou mais parcelas em mais de 10 dias, e que o valor do financiamento seja maior que R$ 10.000,00.
USE master
CREATE DATABASE TESTE_JERSON
GO
USE TESTE_JERSON

CREATE TABLE TB_CLIENTE
(
    ClienteId INT IDENTITY PRIMARY KEY,
    Nome NVARCHAR(150) NOT NULL,
    UF VARCHAR(2) NOT NULL,
    Celular NVARCHAR(15)
)

INSERT INTO TB_CLIENTE
VALUES('Jerson Brito', 'PE', '81981900785')
SELECT *
FROM TB_CLIENTE

CREATE TABLE TB_FINANCIAMENTO
(
    FinanciamentoId INT IDENTITY PRIMARY KEY,
    Tipo NVARCHAR(100) NOT NULL,
    ValorTotal DECIMAL(10,4),
    Vencimento DATE,
    ClienteId INT NOT NULL

        CONSTRAINT FK_TB_FINANCIAMENTO FOREIGN KEY(ClienteId) 
    REFERENCES TB_CLIENTE(ClienteId)
)

INSERT INTO TB_FINANCIAMENTO
VALUES('IMOBILIÁRIO', 10000, '2021-12-31', 1)
SELECT *
FROM TB_FINANCIAMENTO

CREATE TABLE TB_PARCELA
(
    ParcelaId INT IDENTITY PRIMARY KEY,
    Ordem INT NOT NULL,
    Valor DECIMAL(10,4) NOT NULL,
    Vencimento DATE NOT NULL,
    Pagamento DATE,
    FinanciamentoId INT NOT NULL

        CONSTRAINT FK_TB_PARCELA FOREIGN KEY(FinanciamentoId) 
    REFERENCES TB_FINANCIAMENTO(FinanciamentoId)
)

INSERT INTO TB_PARCELA
VALUES(1, 1000, '2020-09-10', NULL, 1)
SELECT *
FROM TB_PARCELA

SELECT C.ClienteId, SUM(P.Valor)
FROM TB_CLIENTE C
    INNER JOIN TB_FINANCIAMENTO F ON C.ClienteId = C.ClienteId
        AND C.UF = 'SP'
    INNER JOIN TB_PARCELA P ON F.FinanciamentoId = P.FinanciamentoId
GROUP BY C.ClienteId, F.ValorTotal
HAVING SUM(P.Valor)/F.ValorTotal > 60

SELECT TOP 4
     C.ClienteId, SUM(P.Valor) 'VALOR EM ABERTO'
FROM TB_CLIENTE C
    INNER JOIN TB_FINANCIAMENTO F ON C.ClienteId = C.ClienteId
    INNER JOIN TB_PARCELA P ON F.FinanciamentoId = P.FinanciamentoId
    AND P.Pagamento = NULL AND P.Vencimento > GETDATE()
GROUP BY C.ClienteId

-- USE master
-- GO
-- DROP DATABASE TESTE_JERSON
