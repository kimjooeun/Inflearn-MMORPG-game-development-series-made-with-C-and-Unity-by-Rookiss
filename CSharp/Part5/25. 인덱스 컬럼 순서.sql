USE Northwind;

-- 복합 인덱스 컬럼 순서
-- Index(A, B, C)

-- NonClustered
--		1
-- 2 3 4 5 6

-- Clustered
--		1
-- 2 3 4 5 6

-- Heap Table은 [ {Page} {Page} {Page} {Page} {Page} ]로 구조되어 있다.

-- 북마크 룩업
-- Leaf Page 탐색은 여전히 존재하기 때문
-- [레벨, 종족] 인덱스 예) (56, 휴먼)

-- (56, 휴먼)이란 데이터가 하나란 보장이 없음.
-- Clustered
--		1
-- 2 3 4[(56, 휴먼),(56, 휴먼),(56, 휴먼),(56, 휴먼)] 그러므로 조건이 맞지 않을 때 까지 스캔을 계속한다.
-- 결국 리프 페이지에 가서는 스캔의 필요성이 생긴다.

-- 그러면 (56~60 휴먼)은 어떻게 되는가?
-- 이 부분이 학습 내용이 된다.

SELECT * 
INTO TestOrders
FROM Orders;

DECLARE @i INT = 1;
DECLARE @emp INT;
SELECT @emp = MAX(EmployeeID) FROM Orders;

-- 더미 데이터를 엄청 늘리는 작업 (830 * 1000)이라는 작업을 한다.
WHILE (@i < 1000)
BEGIN
	INSERT INTO TestOrders(CustomerID, EmployeeID, OrderDate)
	SELECT CustomerID, @emp + @i, OrderDate
	FROM Orders;
	SET @i = @i + 1;
END

CREATE NONCLUSTERED INDEX idx_emp_ord
ON TestOrders(EmployeeID, OrderDate);

CREATE NONCLUSTERED INDEX idx_ord_emp
ON TestOrders(OrderDate, EmployeeID);

-- 어느쪽이 더 빠른지 테스트를 한다.

-- 분석을 위한 도구 준비
SET STATISTICS TIME ON;
SET STATISTICS IO ON;

-- 두 개 비교
SELECT *
FROM TestOrders WITH(INDEX(idx_emp_ord))
WHERE EmployeeID = 1 AND OrderDate = CONVERT(DATETIME, '19970101');

SELECT *
FROM TestOrders WITH(INDEX(idx_ord_emp))
WHERE EmployeeID = 1 AND OrderDate = CONVERT(DATETIME, '19970101');

-- 두 개의 결과 값이 왜 같은가?
-- 직접 살펴보자
SELECT * 
FROM TestOrders
ORDER BY EmployeeID, OrderDate;

SELECT * 
FROM TestOrders
ORDER BY OrderDate, EmployeeID;

-- 범위로 찾는다면?
SELECT *
FROM TestOrders WITH(INDEX(idx_emp_ord))
WHERE EmployeeID = 1 AND OrderDate BETWEEN '19970101' AND '19970103';
-- >= '19970101' AND OrderDate <= '19970103'

SELECT *
FROM TestOrders WITH(INDEX(idx_ord_emp))
WHERE EmployeeID = 1 AND OrderDate BETWEEN '19970101' AND '19970103';

-- 왜 논리적 읽기에서 차이가 나는가?
-- 직접 살펴보자
SELECT * 
FROM TestOrders
ORDER BY EmployeeID, OrderDate;

SELECT * 
FROM TestOrders
ORDER BY OrderDate, EmployeeID;

-- 결론
-- INDEX(A, B, C)로 구성되어진 복합인덱스는 선행에 BETWEEN 사용을 할 경우 후행은 인덱스 기능을 거의 사용할 수 없다
-- 예, A에서 BETWEEN을 사용하면 B와 C는 인덱스 기능을 거의 상실한다.
-- 따라서 BEWTEEN을 사용할거면 후행에 걸어야 한다.

-- 그럼 BETWWEN 같은 비교가 등장하면은 인덱스 순서만 무조건 바꿔주면 되는것인가? > 아니다.
-- BETWEEN 범위가 작을 때에는 > IN-LIST로 대체하는 것을 고려해야 한다.
SET STATISTICS PROFILE ON;

SELECT *
FROM TestOrders WITH(INDEX(idx_ord_emp))
WHERE EmployeeID = 1 AND OrderDate IN('19970101', '19970102', '19970103');
-- 논리적 읽기가 줄어든다.

-- 살펴보자
-- 19970101로 살펴보고 19970102로 살펴보고 19970103로 살펴본다.
-- 범위를 이용하는 것이 아니라 == 이라는 비교연산을 이용하는 것.
-- 사실상 여러번 =을 사용하는 것이다.

-- 그렇다고해서 BETWEEN을 무조건 IN-LIST로 바꾸는 것이 항상 옳은 것이 아니다. 
SELECT *
FROM TestOrders WITH(INDEX(idx_emp_ord))
WHERE EmployeeID = 1 AND OrderDate IN('19970101', '19970102', '19970103');
-- 성능 저하 5에서 11로.
-- 결국, 무작정 BETWEEN을 IN으로 바꾸는 것이 항상 옳은 것이 아니다.

-- 오늘의 결론
-- 복합 컬럼 인덱스를 (선행, 후행)을 만들 경우 순서가 영향을 줄 수 있다.
-- BETWEEN, 부등호(>, <) 선행에 들어가면, 후행은 인덱스의 기능을 상실한다.
-- 만약 BETWEEN의 범위가 적으면 IN-LIST로 대체하면 좋은 경우가 있다. 다만  항상 그런 것은 아니며 선행에 BETWEEN이 들어갈 경우에만 그렇다.
-- 만약 선행이 =,이고 후행이 BETWWEN이면 아무런 문제가 없기 때문에 IN-LIST가 항상 좋지많은 않다.