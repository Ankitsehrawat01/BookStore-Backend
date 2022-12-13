CREATE TABLE TypeTable
(
	TypeId bigint identity(1,1) primary key,
	Type varchar(200)
)

INSERT INTO TypeTable
VALUES ('Home')

INSERT INTO TypeTable
VALUES ('Office')

INSERT INTO TypeTable
VALUES ('Other')

SELECT * FROM TypeTable