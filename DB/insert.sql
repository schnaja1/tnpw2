USE [DBS2]
GO

INSERT INTO [dbo].[Staty]
           ([Jmeno])
     VALUES
      ('Česká republika'),
		   ('Velká Británie'),
		   ('Spojené státy americké'),
		   ('Německo'),
		   ('Francie'),
		   ('Španělsko'),
		   ('Japonsko'),
		   ('Čína'),
		   ('Austrálie');
		  
GO


INSERT INTO [dbo].[Destinace]
           ([Nazev]
           ,[StatyID])
     VALUES
		('Praha', '1'),
    ('Pec pod Sněžkou', '1'),
    ('Londýn', '2'),
    ('Manchester', '3'),
    ('New York', '3'),
    ('Miami', '3'),
    ('Berlín', '4'),
    ('Hamburg', '4'),
    ('Paříž', '5'),
    ('Marseille', '5'),
    ('Barcelona', '6'),
    ('Malága', '6'),
    ('Tokyo', '7'),
    ('Shangai', '8'),
    ('Hong Kong', '8'),
    ('Peking', '8'),
    ('Sydney', '9');                                                        
GO

INSERT INTO [dbo].[Zpusobystravovani]
           ([Nazev]
           ,[Popis])
     VALUES
        ('Plná penze', ''),
		   ('Poloviční penze', ''),
		   ('Ultra All Inclusiv', ''),
		   ('All Inclusiv', ''),
		   ('Snídaně', '');/*5*/
GO


INSERT INTO [dbo].[Hotely]
           ([Nazev]
           ,[DestinaceID]
           ,[Hodnoceni]          
           ,[email]
           ,[ZpusobystravovaniID]
           ,[popis])
     VALUES
('Grand Hotel Prague', '1', '5', 'info@praguegrandhotel.cz', '1', 'Krásný hotel Grand Hotel Prague, situovaný v samotném historickém centru Prahy.'),
('Hotel Horizont', '2', '4', 'info@hotelhorizont.cz', '2', 'Vychutnejte si moderní ubytování s výhledem na Pec pod Sněžkou a krásnou krkonošskou přírodu. Jako hosté tohoto hotelu můžete obdivovat krásy Krkonoš a zároveň si užívat komfortního ubytování v našem hotelu. '),
('Royal Hotel London', '3', '5', 'info@hotelryal.uk', '5', 'Royal London Hotel poskytuje nepřetržitě otevřenou recepci. e vzdálen necelých 10 minut chůze od stanice metra Shepherds Bush. Hudební aréna O2 Shepherds Bush Empire je vzdálena necelých 5 minut chůze. V jídelně se denně podává kontinentální snídaně a ve všech prostorách funguje bezplatné Wi-Fi.'),
('The Lowry Hotel', '4', '4', 'info@thelowry.uk', '4' , 'Palace Theatre Hotel je jedním z nejstarších hotelů v Manchestru. Je situován v samotném centru města a s dopravním spojením zde není žádný problémOceněný hotel Lowry upoutá na břehu řeky Irwell svou zakřivenou prosklenou fasádou, která je dominantou zdejší lokality. Nabízí pokoje s nádherným výhledem, restauraci u řeky a wellness centrum. Na místě je bezplatné Wi-Fi..'),
('The Paul Hotel', '5', '5', 'info@paulhotel.us', '3', 'The Paul Hotel se nachází v New Yorku, 400 metrů od Empire State Building. Nabízí sluneční terasu, fitness centrum a vlastní restauraci. Pokoje mají klimatizaci, TV s plochou obrazovkou, kávovar a vlastní koupelnu. Bezplatné Wi-Fi je k dispozici ve všech prostorách.'),
('ME Miami', '6', '5','info@memiami.us', '2', 'Ať jste turista nebo cestujete za obchodem ME Miami je skvělým místem pro ubytování v průběhu vaší návštěvy města Miami (FL). Odtud mohou hosté užívat snadný přístup ke všemu, co může toto živé město nabídnout. Díky své výhodné poloze, nabízí hotel snadný přístup k místům, která musíte vidět.'),
('Titanic Gendarmenmarkt Berlin', '7', '4', 'info@titanic.de', '2', 'Pro cestovatele chtějící vnímat památky a zvuky města Berlín je hotel Titanic Gendarmenmarkt Berlin Hotel perfektní volbou. Pouze 9.7 km daleko, může být tento 5-hvězdičkový hotel dosažitelný z letiště. Díky své výhodné poloze, nabízí hotel snadný přístup k místům, která musíte vidět.'),
('Superbude Hotel Hostel St. Georg', '8', '5', 'info@stgeorg.de', '1', 'Tento hostel se nachází 1 stanici vlakem od hamburského hlavního nádraží a nabízí barevné pokoje s bezplatným internetem a TV s plochou obrazovkou, vlastní kino i hernu s konzolí Nintendo Wii. Superbude Hotel & Hostel St. Georg poskytuje pokoje s TV, koupelnou a trezorem. Pokoje se vyznačují světlými barvami, velkými okny a neobvyklými doplňky. Ložní prádlo i ručníky jsou k dispozici zdarma'),
('Lodge In', '9', '5', 'info@lodge.fr', '2', 'Lodge In se nachází ve 13. okrsku v Paříži, jen 2 km od Národní knihovny a 2,6 km od Accor Arény. Nabízí bezplatné Wi-Fi připojení ve všech prostorách.Moderní pokoje mají interiér v teplých tónech, satelitní TV a sdílenou koupelnu.'),
('Escale Oceania Marseille Vieux Port', '10', '5', 'info@escaleoceania.fr', '2', 'Hotel Escale Oceania Marseille Vieux Port je butikový hotel, který se nachází na slavné ulici Canebière, 1 km od vlakového nádraží St. Charles a pouhých 100 metrů od přístavu Vieux. Nabízí klimatizované pokoje s bezplatným Wi-Fi. Escale Oceania Marseille Vieux Port poskytuje zvukotěsné pokoje s kabelovou a satelitní TV s plochou obrazovkou a vlastní koupelnou s otevřeným sprchovým koutem.'),
('Petit Príncep', '11', '5', 'info@petit.es', '4', 'Hostal Petit Príncep se nachází na třídě Avenida Diagonal v Barceloně, 15 minut chůze od bulváru Passeig de Gracia, a nabízí klimatizované, moderně zařízené pokoje s bezplatným Wi-Fi.Všechny pokoje mají topení a barevný interiér a z některých se otevírá výhled na město. Ve vlastní koupelně najdete fén. K dispozici je také sdílená lednička a mikrovlnná trouba.'),
('Venecia', '12', '4', 'info@venecia.es', '4', 'Toto ubytování se nachází 10 minut chůze od pláže. Tento hotel s centrální polohou jen jeden km od pláže má příjemnou kavárnu a restauraci, která nabízí typické pokrmy španělské kuchyně na snídani, oběd a večeři. Dopřejte si klidný spánek v pěkně zařízených pokojích, které jsou zařízeny dlaždicovou podlahou, nábytkem z borového dřeva a květinovým designem. Všechny pokoje mají vlastní koupelnu a dostatek přirozeného světla. Můžete obdivovat výhledy na město z velkých oken a surfovat zdarma pomocí bezdrátového připojení na internet.'),
('Grand Nikko Tokyo Daiba', '13', '5', 'info@grandnikko', '2', 'Toto ubytování se nachází 7 minut chůze od pláže. Grand Nikko Tokyo Daiba je první hotel Grand Nikko v Japonsku a byl uvedený do provozu 1. července 2016. Jedná se o hotelový rezort nejblíže centru Tokia. Nachází se ve čtvrti Odaiba v Tokijském zálivu. Prostorné elegantní hotelové pokoje jsou zařízené v evropském stylu a vybavené bezplatným kabelovým internetem ve všech prostorách. Z horních pater je panoramatický výhled na Tokijský záliv, Duhový most a Tokijskou věž.'),
('Best Western Harbour View', '14', '4', 'info@harbourview.cn', '2', 'Best Western Hotel Harbour View nabízí střešní bazén a bezplatné Wi-Fi dostupné ve všech prostorách, Tento 4hvězdičkový moderní hotel se nachází jen pár kroků od stanice metra MTR Sai Ying Pun (Exit A1) a 5 minut autem od mezinárodního finančního centra. Všechny pokoje jsou klimatizované a mají TV s plochou obrazovkou, osobní trezor a příslušenství pro přípravu čaje a kávy. Některé pokoje poskytují výhled na hory nebo na přístav Victoria Harbour. Na pokojích je koupelna se sprchou.'),
('Empark Prime', '15', '5',  'info@emparkprime.cn', '2', 'Prime Hotel má ideální polohu 1 km od proslulé 700 let staré ulice Wang-fu-ťing a nabízí 5 možností stravování, krytý bazén a parkování zdarma. Prostorné pokoje s výhledem na město mají bezplatné Wi-Fi připojení. Prime Hotel se nachází přímo na proslulé nákupní ulici Pekingu se snadným spojením k hlavním turistickým atrakcím v okolí. Prime Hotel je vzdálen 5 minut jízdy od Zakázaného města. Náměstí Nebeského klidu a čínské Národní muzeum jsou v okruhu 8 minut jízdy od hotelu. Park Beihai je v dosahu 11 minut chůze a mezinárodní letiště Beijing Capital je vzdáleno 45 minut jízdy od hotelu.'),
('Four Seasons Hotel Sydney', '16', '5', 'info@fourseasonshotel.au', '2', 'Hotel Four Seasons nabízí krásný výhled na historické skály města Sydney. V hotelu je k dispozici wifi zdarma, bar, restaurace, bazén a fitness centrum. ');
GO



INSERT INTO [dbo].[Moznostidopravy]
           ([Typ]
 		)
     VALUES
       ('Autobus'),
		   ('Letadlo'),
		   ('Loď'),
		   ('Vlak'),
       ('Vlastní')
		 
GO



INSERT INTO [dbo].[Zajezdy]
           ([Cena]
           ,[Od]
           ,[Kapacita]
           ,[Do]
           ,[HotelyID]
           ,[MoznostidopravyID])
     VALUES
      			('8000', '2018-06-26', '30', '2018-07-02', '1', '3'),
			('4000', '2017-12-05', '15', '2017-12-12', '2', '1'),
			('24000', '2018-04-22', '50', '2018-04-25', '3', '3'),
			('15000', '2018-04-04', '60', '2018-04-09', '4', '4'),
			('12000', '2018-01-18', '80', '2018-01-21', '5', '2'),
			('15000', '2018-10-13', '20', '2018-10-16', '6', '1'),
			('11000', '2018-04-22', '20', '2018-05-06', '7', '2'),
			('14000', '2017-08-14', '30', '2017-08-25', '8', '2'),
			('13000', '2018-10-25', '20', '2018-11-05', '9', '2'),
			('12000', '2018-04-19', '20', '2018-04-24', '10', '1'),
			('15000', '2018-06-30', '20', '2018-07-08', '11', '5'),
			('11000', '2018-08-02', '20', '2018-08-06', '12', '4'),
			('13000', '2018-09-16', '40', '2018-09-20', '13', '2'),
			('14000', '2018-01-07', '30', '2018-01-16', '14', '1'),
			('19000', '2018-06-19', '40', '2018-06-25', '15', '2'),
			('20000', '2018-05-06', '20', '2018-05-11', '16', '1'); 
GO



INSERT INTO [dbo].[Psc]
           ([Psc])
     VALUES
            ('38473'),
			('66483'),
			('67532'),
			('67110'),
			('74724'),
			('54401'),
			('38801'),
			('68738'),
			('51264'),
			('34526'),
			('68352'),
			('79201'),
			('54901');
GO



INSERT INTO [dbo].[Adresy]
           ([Cp]
           ,[Mesto]
           ,[Ulice]
           ,[PscID])
     VALUES
			('934', 'Martínkov', 'Pohořelec', '1'),
			('2144', 'Andělská Hora', 'Kamenomlýnský most', '2'),
			('1302', 'Hraběšice', 'Ostrá', '3'),
			('857', 'Sedliště', 'Tyršova', '4'),
			('2194', 'Červené Poříčí', 'V luzích', '5'),
			('829', 'Stračov', 'Wainerovo náměstí', '6'),
			('1473', 'Lhůta', 'Hlaváčkova', '7'),
			('441', 'Podbořany', 'Bayerova', '8'),
			('574', 'Běrunice', 'Svitavské nábřeží', '9'),
			('364', 'Slavětín', 'Kuklenská', '10'),
			('1460', 'Nové Sedlo', 'Úhledná', '11'),
			('1313', 'Zdounky', 'Helceletova', '12'),
			('1684', 'Vysoké Mýto', 'Železničářská', '13');
GO

INSERT INTO [dbo].[UzivatelskaPrava]
              ([Nazev]
              ,[UzivatelskaPravaID])
           VALUES
           ('Administrator','1'),
           ('Zamestnanec','2'),
           ('Zakaznik','3')
GO     


INSERT INTO [dbo].[Uzivatele]
           ([Heslo]
           ,[UzivatelskaPravaID]
           ,[Jmeno]
           ,[Login]
           ,[Novinky]
           ,[Prijmeni]
           ,[Telefon]
           ,[AdresyID])
    VALUES
        ('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '1', 'Michal', 'michal.blazek@eurotravel.cz', '0', 'Blažek', '+420722771097', '1'),
  			('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '2', 'Anděla', 'pavlaskova.andela@eurotravel.cz', '0', 'Pavlásková', '+420721455858', '2'),
  			('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '2', 'Albína', 'trojakova.albina@eurotravel.cz', '0', 'Trojáková', '+420731559104', '3'),
  			('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '2', 'Taťána', 'martinkova.tatana@eurotravel.cz', '0', 'Martínková', '+420722946576', '4'),
  			('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '2', 'Radek', 'franek.radek@fakemail.cz', '1', 'Franěk', '+420720222583', '5'),
  			('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '2', 'Robert', 'jano.robert@fakemail.cz', '0', 'Jano', '+420605993266', '6'),
  			('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '3', 'Kristián', 'sosna.kristian@fakemail.cz', '1', 'Sosna', '+420726152770', '7'),
  			('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '3', 'Alexandr', 'klika.alexandr@fakemail.cz', '0', 'Klika', '+420607454300', '8'),
  			('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '3', 'Rudolf', 'antos.rudolf@fakemail.cz', '1', 'Antoš', '+420738451225', '9'),
  			('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '3', 'Bruno', 'riedl.bruno@fakemail.cz', '0', 'Riedl', '+420607426680', '10'),
  			('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '3', 'Dominik', 'srom.dominik@fakemail.cz', '1', 'Šrom', '+420723638006', '11'),
  			('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '3', 'Daniel', 'zabojnik.daniel@fakemail.cz', '0', 'Zábojník', '+420728770012', '12'),
        ('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', '3', 'Prokop', 'tnpw2testemail@seznam.cz', '1', 'Buben', '+420742761072', '13');
  
GO




INSERT INTO [dbo].[Rezervace]
           ([Pocetdospelych]
           ,[Poznámka]
           ,[UzivateleID]
           ,[pocetdeti]
           ,[ZajezdyID]
           ,[Zaplaceno])
     VALUES
 ('1', '-', '5', '3', '8', '1'),
 ('2', '-', '11', '2', '6', '0'),
 ('4', '-', '5', '2', '2', '1'),
 ('2', '-', '8', '1', '3', '0'),
 ('1', '-', '6', '0', '11', '0'),
 ('1', '-', '4', '1', '14', '0'),
 ('2', '-', '12', '3', '1', '1'),
 ('3', '-', '9', '0', '11', '1'),
 ('3', '-', '5', '3', '3', '0'),
 ('2', '-', '4', '0', '10', '0'),
 ('4', '-', '10', '0', '6', '0'),
 ('4', '-', '13', '0', '11', '1'),
 ('1', '-', '7', '3', '7', '1'),
 ('1', '-', '12', '1', '12', '0'),
 ('4', '-', '11', '3', '3', '0'),
 ('3', '-', '10', '3', '1', '0'),
 ('4', '-', '5', '2', '9', '1'),
 ('1', '-', '10', '0', '8', '0'),
 ('2', '-', '12', '3', '5', '0'),
 ('2', '-', '5', '3', '16', '1'),
 ('1', '-', '10', '1', '6', '1'),
 ('1', '-', '11', '2', '5', '1'),
 ('4', '-', '12', '2', '13', '1'),
 ('1', '-', '5', '3', '4', '1'),
 ('4', '-', '6', '0', '14', '1'),
 ('4', '-', '6', '3', '8', '1'),
 ('3', '-', '8', '3', '16', '1'),
 ('2', '-', '8', '2', '9', '1'),
 ('3', '-', '6', '0', '15', '0'),
 ('2', '-', '5', '0', '3', '1'),
 ('4', '-', '6', '1', '1', '1'),
 ('2', '-', '7', '1', '8', '0'),
 ('3', '-', '9', '2', '7', '0'),
 ('4', '-', '10', '1', '15', '1'),
 ('2', '-', '6', '1', '9', '1'),
 ('4', '-', '11', '0', '2', '1'),
 ('1', '-', '11', '1', '8', '0'),
 ('4', '-', '6', '2', '9', '0'),
 ('3', '-', '13', '2', '14', '1'),
 ('1', '-', '8', '3', '5', '1'),
 ('4', '-', '7', '0', '6', '1'),
 ('2', '-', '9', '2', '9', '0'),
 ('3', '-', '3', '2', '1', '0'),
 ('2', '-', '12', '3', '10', '0'),
 ('1', '-', '6', '3', '14', '0'),
 ('2', '-', '7', '1', '14', '0'),
 ('2', '-', '11', '1', '11', '1'),
 ('2', '-', '13', '3', '7', '0'),
 ('2', '-', '13', '2', '4', '0'),
 ('2', '-', '9', '0', '5', '1');
GO



INSERT INTO [dbo].[Fotografie]
    (
           [Fotografie]
           ,[HotelyID] 
           ,[Popisek] 
           ,[Nahled])
     VALUES
	('~\Images\hotely\1.jpg','1','hotel xx','~\Images\hotely\nahled\1.jpg'),
('~\Images\hotely\2.jpg','2','hotel xx','~\Images\hotely\nahled\2.jpg'),
('~\Images\hotely\3.jpg','3','hotel xx','~\Images\hotely\nahled\3.jpg'),
('~\Images\hotely\4.jpg','4','hotel xx','~\Images\hotely\nahled\4.jpg'),
('~\Images\hotely\5.jpg','5','hotel xx','~\Images\hotely\nahled\5.jpg'),
('~\Images\hotely\6.jpg','6','hotel xx','~\Images\hotely\nahled\6.jpg'),
('~\Images\hotely\7.jpg','7','hotel xx','~\Images\hotely\nahled\7.jpg'),
('~\Images\hotely\8.jpg','8','hotel xx','~\Images\hotely\nahled\8.jpg'),
('~\Images\hotely\9.jpg','9','hotel xx','~\Images\hotely\nahled\9.jpg'),
('~\Images\hotely\10.jpg','10','hotel xx','~\Images\hotely\nahled\10.jpg'),
('~\Images\hotely\11.jpg','11','hotel xx','~\Images\hotely\nahled\11.jpg'),
('~\Images\hotely\12.jpg','12','hotel xx','~\Images\hotely\nahled\12.jpg'),
('~\Images\hotely\13.jpg','13','hotel xx','~\Images\hotely\nahled\13.jpg'),
('~\Images\hotely\14.jpg','14','hotel xx','~\Images\hotely\nahled\14.jpg'),
('~\Images\hotely\23.jpg','15','hotel xx','~\Images\hotely\nahled\23.jpg'),
('~\Images\hotely\16.jpg','16','hotel xx','~\Images\hotely\nahled\16.jpg');
GO


CREATE PROCEDURE [dbo].[UzivatelVloz]   
    @heslo varchar(MAX),   
    @jmeno varchar(40),
	@prijmeni varchar(40),
	@login varchar(40),
	@prava int,
	@novinka bit,
	@telefon varchar(15),
	@psc int,
	@cp int,
	@mesto varchar(40),
	@ulice varchar(40)
AS   
	BEGIN
	IF   (SELECT Count(*) FROM Psc WHERE Psc = @psc) = 0
	BEGIN
	INSERT INTO Psc (Psc) VALUES (@psc); 
	END

	DECLARE @p int
	SELECT @p = PscID FROM Psc WHERE Psc = @psc;

	IF   (SELECT Count(*) FROM Adresy WHERE Cp = @cp AND Mesto = @mesto AND Ulice = @ulice) = 0
	BEGIN
	INSERT INTO Adresy (Cp,Mesto,Ulice,PscID) VALUES (@cp,@mesto,@ulice,@p); 
	END

	DECLARE @c int
	SELECT @c = AdresyID FROM Adresy WHERE Cp = @cp AND Mesto = @mesto AND Ulice = @ulice;

	INSERT INTO Uzivatele (Heslo,UzivatelskaPravaID,Jmeno,Login,Novinky,Prijmeni,Telefon, AdresyID) 
	VALUES (@heslo,@prava,@jmeno,@login,@novinka,@prijmeni,@telefon,@c);
	END
GO
