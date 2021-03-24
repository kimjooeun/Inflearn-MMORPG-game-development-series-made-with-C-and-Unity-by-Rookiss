USE Northwind;
-- 5340

-- 주문 상세 정보를 살펴보자
SELECT * 
FROM [Order Details]
ORDER BY OrderID;

-- 임시 테스트 테이블을 만들고 데이터를 복사한다
SELECT *
INTO TestOrderdetails
FROM [Order Details];

-- 복사한 데이터 확인
SELECT *
FROM TestOrderdetails;

-- 복합 인덱스 추가
CREATE INDEX Index_TestOrderDetails
ON TestOrderDetails(OrderID, ProductID);

-- 인덱스 정보 살펴보기
EXEC sp_helpindex 'TestOrderDetails';

-- (OrderID, ProductID) 동시 서칭? OrderID? ProductID? 각각 서칭?
-- INDEX SCAN (INDEX FULL SCAN) > 인덱스를 사용 안하고 통채로 찾는 경우. (나쁜 케이스)
-- INDEX SEEK > (좋은 케이스 -- 인덱스가 정상적으로 활용된다고 볼 수 있다.)

-- 인덱스 적용 테스트1 > (두개를 동시에 찾는 경우) > SEEK가 발생하였음
SELECT * 
FROM TestOrderDetails
WHERE OrderID = 10248 AND ProductID = 11;

-- 인덱스 적용 테스트2 > GOOD
SELECT * 
FROM TestOrderDetails
WHERE ProductID = 11 AND OrderID = 10248;

-- 인덱스 적용 테스트3 > GOOD
SELECT * 
FROM TestOrderDetails
WHERE OrderID = 10248;

-- 인덱스 적용 테스트4 > BAD (인덱스 풀 스캔)
SELECT * 
FROM TestOrderDetails
WHERE ProductID = 11 ;

-- 왜 ProductID만 인덱스 풀 스캔을 사용할까?
-- 서칭하는 순서가 아래와 같으므로
-- ON TestOrderDetails(OrderID, ProductID);
-- ProductID

--INDEX 정보
DBCC IND ('Northwind', 'TestOrderDetails', 2);

-- 해당 인덱스의 트리 구조
--				880
-- 824 848 849 850 851 852

DBCC PAGE ('Northwind', 1, 864, 3);
-- DBCC PAGE ('Northwind', 1, 864, 3);를 살펴보면
-- ON TestOrderDetails(OrderID, ProductID);으로 인해
-- OrderID가 먼저 정렬이 되어 (금메달), ProductID(은메달)이 된다.
-- 따라서 데이터가 저장되어 있는 순서는 (OrderID, ProductID);이기 떄문에 ProductID를 이용하여 정렬을 하면 테이블 풀 스캔이 된다.

-- 결론 인덱스 (A,B)를 사용중이라면 인덱스(A)가 없어도 무방하다
-- 하지만 B 순서를 이용해 B로도 검색이 필요하면 인덱스 (B)는 별도로 걸어줘야 한다.
-- 그게 아니면 인덱스 스캔을 받지 못하고 풀 스캔을 하게 된다.

-- 사실 인덱스라는 것은 데이터가 추가 / 삭제 / 갱신 되어도 유지 되어야 한다.
-- 데이터가 50개를 강제로 넣어보자.
-- 1) 10248 / 11
-- 마지막) 10387 / 24

DECLARE @i INT = 0;
WHILE @i < 50
BEGIN
	INSERT INTO TestOrderdetails
	VALUES (10248, 100 + @i, 10, 1, 0);
	SET @i = @i + 1;
END

-- 데이터를 넣고 난  후 인덱스의 정보
DBCC IND ('Northwind', 'TestOrderDetails', 2);

--				880
-- 824 [881] 848 849 850 851 852
DBCC PAGE ('Northwind', 1, 929, 3);
DBCC PAGE ('Northwind', 1, 896, 3);
-- 인덱스 데이터들이 페이지 공간을 넘치면 페이지를 잘라 다른 페이지에 저장한다
-- 결론 : 페이지에 여유 공간이 없다면 > 페이지 분할 (SPLIT) 발생

-- 가공 테스트
SELECT LastName
INTO TestEmployees
FROM Employees;

SELECT * FROM TestEmployees;
-- 9명의 결과가 나오는 것을 알 수 있따.

-- 인덱스 추가
CREATE INDEX Index_TestEmployees
ON TestEmployees(LastName);

-- INDEX SCAN > BAD
SELECT * 
FROM TestEmployees
WHERE SUBSTRING(Lastname, 1, 2) = 'Bu';
-- 인덱스를 걸었다고 해서 100% 확률로 무조건 찾아준다는 보장이 없다.
-- SUBSTRING의 Lastname이 어떻게 가공될지 모르므로 인덱스 스캔으로 진행된다.

-- INDEX SEEK
SELECT * 
FROM TestEmployees
WHERE Lastname LIKE 'Bu%';
-- 실행 계획을 살펴보는 내용이 중요하다

-- 오늘의 결론
-- 복합 인덱스 (A,B)를 사용할때 순서를 주의 해야 한다. 
-- (A에서 B순서로 검색하기 때문에 A,B를 동시에 사용하거나 A만 사용하는건 괜찮지만 A를 건너뛰고 B만 사용하면 복합 인덱스를 사용할 수 없다)
-- 인덱스 사용 시, 데이터 추가로 인해 페이지 여유 공간이 없으면 SPLIT
-- 키 가공할 때 주의하자!
