INSERT INTO [Category] ([name]) VALUES 
	('Comedie'), ('Animation'), ('Science Fiction');

INSERT INTO [Movie] ([title], [synopsis], [release_year], [category_id]) VALUES 
	('Le monde de Nemo', 'Un petit poisson est perdu', 2003, 2), 
	('Star Wars IV - Un nouvel espoir', 'Luke et Han veulent se taper Leila', 1977, 3), 
	('Star Wars V - L''Empire contre-attaque', 'Luke s''entraine avec un petit homme vert', 1980, 3);

INSERT INTO [Actor]([last_name], [first_name], [birth_date]) VALUES
	('Hamil', 'Mark', CONVERT(DATE, '25/09/1951', 103)),
	('Ford', 'Harisson', CONVERT(DATE, '13/07/1942', 103)),
	('Guiness', 'Alec', CONVERT(DATE, '02/04/1914', 103)),
	('Brooks', 'Albert', CONVERT(DATE, '22/07/1947', 103));

INSERT INTO [Cast]([movie_id], [actor_id], [character_name]) VALUES
	(1,4,'Marin'),
	(2,1,'Luke Skywalker'),
	(2,2,'Han Solo'),
	(2,3,'Obiwan Kenobi'),
	(3,1,'Luke Skywalker'),
	(3,2,'Han Solo');

INSERT INTO [User]([login], [email], [encoded_password], [salt], [last_name], [first_name], [role]) VALUES
	('sa', 'khun.ly@bstorm.be', dbo.SF_HashPassword('admin','sel1'), 'sel1', 'Admin', 'Admin', 'ADMIN'),
	('khun', 'lykhun@gmail.com', dbo.SF_HashPassword('khun', 'sel2'), 'sel2', 'Ly', 'Khun', 'SIMPLE_USER'),
	('Sam', 'samuel.legrain@bstorm.be', dbo.SF_HashPassword('test1234=','toto'), 'toto', 'Legrain', 'Samuel', 'ADMIN');
GO