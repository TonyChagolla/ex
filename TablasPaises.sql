USE Prueba;
DROP TABLE IF EXISTS ciudad;
DROP TABLE IF EXISTS estado;
DROP TABLE IF EXISTS pais;

CREATE TABLE pais
(
	pais_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
)

CREATE TABLE estado
(
	estado_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	pais_id INT NOT NULL FOREIGN KEY REFERENCES pais(pais_id)
)

CREATE TABLE ciudad
(
	ciudad_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	estado_id INT NOT NULL FOREIGN KEY REFERENCES estado(estado_id),
	estatus BIT NOT NULL
)

INSERT INTO pais(nombre) 
VALUES
('Mexico'),
('Estados Unidos'), 
('Brasil');

INSERT INTO estado(nombre, pais_id)
VALUES
('Guanajuato', 1),
('Nuevo León', 1),
('California', 2),
('Texas', 2),
('Sao Paulo', 3),
('Amazonas', 3)

INSERT INTO ciudad(nombre, estado_id, estatus)
VALUES
('Irapuato', 1, 1),
('Salamanca', 1,1),
('Monterey', 2,1),
('Santa Catarina', 2, 1),
('Los Angeles', 3, 1),
('San Fransisco',3, 1),
('Houston',4, 1),
('Sao Paulo', 5, 1),
('Limeria', 5, 1),
('Manaos',6, 1)