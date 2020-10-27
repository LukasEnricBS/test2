create database casino_db;
use casino_db;

CREATE TABLE Player(
	usrName varchar(30) PRIMARY KEY,
	pwd varchar(30) NOT NULL,
	currentMoney int,
	cardBack int,
	gameBg int
);

CREATE TABLE MoneyRequest(
	id int IDENTITY(1,1) PRIMARY KEY,
	playerName varchar(30),
	amount int,
	pending bit,
	accepted bit,
	FOREIGN KEY (playerName)
		references Player(usrName)
);

CREATE TABLE GameTable (
    id int IDENTITY(1,1) PRIMARY KEY,
    name varchar(25),
    maxPlayers varchar(10),
    pwd varchar(25)
);

CREATE TABLE PlayerTable(
	tableId int,
	playerName varchar(30),
	totalBet int,
	isActivePlayer bit,
	isSmallBlind bit,
	isBigBlind bit,
	hasFolded bit,
	PRIMARY KEY(tableId, playerName),
	FOREIGN KEY (tableId)
		references GameTable(id),
	FOREIGN KEY (playerName)
		references Player(usrName)
);

CREATE TABLE GameCard(
	num int,
	suit varchar(1),
	PRIMARY KEY (num, suit)
);

CREATE TABLE Deck(
	tableId int,
	cardNum int,
	cardSuit varchar(1),
	playerName varchar(30),
	played bit,
	PRIMARY KEY(tableId, cardNum, cardSuit),
	FOREIGN KEY (tableId)
		references GameTable(id),
	FOREIGN KEY (cardNum, cardSuit)
		references GameCard(num, suit),
	FOREIGN KEY (playerName)
		references Player(usrName)
);


insert into GameCard values (1,'S'),(2,'S'),(3,'S'),(4,'S'),(5,'S'),(6,'S'),(7,'S'),(8,'S'),(9,'S'),(10,'S'),(11,'S'),(12,'S'),(13,'S');
insert into GameCard values (1,'H'),(2,'H'),(3,'H'),(4,'H'),(5,'H'),(6,'H'),(7,'H'),(8,'H'),(9,'H'),(10,'H'),(11,'H'),(12,'H'),(13,'H');
insert into GameCard values (1,'D'),(2,'D'),(3,'D'),(4,'D'),(5,'D'),(6,'D'),(7,'D'),(8,'D'),(9,'D'),(10,'D'),(11,'D'),(12,'D'),(13,'D');
insert into GameCard values (1,'C'),(2,'C'),(3,'C'),(4,'C'),(5,'C'),(6,'C'),(7,'C'),(8,'C'),(9,'C'),(10,'C'),(11,'C'),(12,'C'),(13,'C');

insert into Player values('Admin','Admin',-1,0,0);

DROP TRIGGER IF EXISTS AccpetedRequest_trAU;
GO
CREATE TRIGGER AccpetedRequest_trAU ON  dbo.MoneyRequest
FOR UPDATE
AS  
begin
	SET NOCOUNT ON;
    UPDATE dbo.Player
	SET    dbo.Player.currentMoney = dbo.Player.currentMoney + inserted.amount
	FROM   dbo.Player
       JOIN inserted
         ON dbo.Player.usrName = inserted.playerName  
		 WHERE inserted.accepted = 1
	
end;

