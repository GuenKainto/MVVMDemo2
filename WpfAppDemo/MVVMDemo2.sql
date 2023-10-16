DROP DATABASE MVVMDemo2
CREATE DATABASE MVVMDemo2

use MVVMDemo2

CREATE TABLE MANGA(
	M_ID CHAR(4) NOT NULL PRIMARY KEY,
	M_NAME NVARCHAR(80) NOT NULL,
	M_EPISODE INT NOT NULL,
	M_DESCRIPTION NVARCHAR(255),
	M_AGE NVARCHAR(4)
);


CREATE TABLE BOOK(
	B_ID CHAR(4) NOT NULL PRIMARY KEY,
	B_NAME NVARCHAR(80) NOT NULL,
	B_DateRelease Date NOT NULL,
	B_Publisher NVARCHAR(30) NOT NULL,
);

SELECT * FROM BOOK;
SELECT * FROM MANGA;