﻿CREATE TABLE tbAluno (
	Id INT NOT NULL,
	Nome NVARCHAR(128) NOT NULL,
	Email NVARCHAR(128) NOT NULL,
	RA NVARCHAR(128) NOT NULL,
	
	PRIMARY KEY (Id)
	
);

CREATE TABLE tbQuestao (
	Id INT NOT NULL,
	Nome NVARCHAR(128) NOT NULL,
	Enunciado NVARCHAR(300) NOT NULL,

	PRIMARY KEY (Id)
	
);

CREATE TABLE tbProva (
	Id INT NOT NULL,
	Nome NVARCHAR(128) NOT NULL,
	DataAplicacao DATETIME NOT NULL,

	PRIMARY KEY (Id)
	
);


CREATE TABLE tbProvaQuestao (
	IdProvaQuestao INT NOT NULL,
	
	Valor FLOAT NOT NULL,

	PRIMARY KEY (IdProvaQuestao),
	IdProva INT FOREIGN KEY REFERENCES tbProva(Id),
	IdQuestao INT FOREIGN KEY REFERENCES tbQuestao(Id),
	
);

CREATE TABLE tbAlunoProvaQuestao (
	IdAlunoProvaQuestao INT NOT NULL,
	IdProvaQuestao INT FOREIGN KEY REFERENCES tbProvaQuestao(IdProvaQuestao),
	IdAluno INT FOREIGN KEY REFERENCES tbAluno(Id),
	Enunciado NVARCHAR(300) NOT NULL,
	Nota FLOAT NOT NULL,

	PRIMARY KEY (IdAlunoProvaQuestao),
	
);





