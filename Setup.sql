-- CREATE TABLE cars(
--   id int NOT NULL AUTO_INCREMENT ,
--   make VARCHAR (255),
--   model VARCHAR (255),
--   year INT   ,
--   price INT ,
--   description VARCHAR (255),
--   imgUrl VARCHAR (255),
--   PRIMARY KEY (id)
-- );

-- Create(Post)
INSERT INTO cars(make,model,year,price,descriptions,imgUrl) VALUES("Subaru","SB-007",2018,25000,"A red color car!","https://placeholder");
INSERT INTO cars(make,model,year,price,descriptions,imgUrl) VALUES("Tesla","TS-007",2020,50000,"New tec car!","https://placeholder");
INSERT INTO cars(make,model,year,price,descriptions,imgUrl) VALUES("Ferrari","FR-007",2016,60000,"A red ferrari car!","https://placeholder");

-- GetAll
SELECT * FROM cars;

--Edit(put)
UPDATE cars SET make="Mercedes", model= "MC-7992" WHERE id=2;

-- GetOne
SELECT * from cars WHERE id=3;

-- DELETE 
DELETE FROM cars WHERE make="Ferrari";



