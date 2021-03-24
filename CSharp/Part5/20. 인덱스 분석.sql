USE Northwind;

-- DB 정보 살펴보기
EXEC sp_helpdb 'Northwind';

-- 임시 테이블 만들자 (인덱스 테스트용)
CREATE TABLE Test
(
	EmployeeID	INT NOT NULL,
	LastName	NVARCHAR(20) NULL,
	FirstName	NVARCHAR(20) NULL,
	HireDate	DATETIME NULL
);
GO

INSERT INTO Test
SELECT EmployeeID, LastName, FirstName, HireDate
FROM Employees;

SELECT *
FROM Test;

-- FILLFACTOR (리프 페이지 공간 1%만 사용) 
-- PAD_INDEX (FILLFACTOR 중간 페이지 적용)
-- 리프페이지와 중간 페이지는 나중에 나온다.
CREATE INDEX Test_Index ON Test(LastName)
WITH (FILLFACTOR = 1, PAD_INDEX = ON)
GO

-- 인덱스 번호 찾기
SELECT INDEX_ID, NAME
FROM SYS.INDEXES -- 인덱스 정보를 가지고 있는 놈
WHERE OBJECT_ID = OBJECT_ID('TEST');

-- 2번 인덱스 정보 살펴보기
DBCC IND('Northwind', 'Test', 2);

-- 인덱스 레벨을 살펴봅시다
-- 0번이 가장 하위 1이 가운데 2가 꼭대기
-- Root(2) > Branch(1) > Leaf(0)

--						849(Leverling)
--			872(Dodsworth)			848(Leverling)
--		832(Buchana..)	840(Dodsworth..)	841(Leverling..)

-- Table[ {Page} {Page} {Page} {Page} {Page} ]
-- callahan
-- HEAP RID([페이지 주소(4)][파일ID(2)][슬롯번호(2)] 조합한 ROW 식별자, 테이블에서 정보 추출
DBCC PAGE('Northwind', 1/*파일번호*/, 832/*페이지번호*/, 3/*출력옵션*/);
DBCC PAGE('Northwind', 1/*파일번호*/, 840/*페이지번호*/, 3/*출력옵션*/);
DBCC PAGE('Northwind', 1/*파일번호*/, 841/*페이지번호*/, 3/*출력옵션*/);

DBCC PAGE('Northwind', 1/*파일번호*/, 872/*페이지번호*/, 3/*출력옵션*/);
DBCC PAGE('Northwind', 1/*파일번호*/, 848/*페이지번호*/, 3/*출력옵션*/);
DBCC PAGE('Northwind', 1/*파일번호*/, 849/*페이지번호*/, 3/*출력옵션*/);

-- Random Access (한 건 읽기 위해 한 페이지씩 접근)
-- Bookmark Lookup (RID를 통해 행을 찾는다)