USE Northwind;

-- 북마크 룩업

-- 인덱스 접근 방식(Access)
-- Index Scan vs Index Seek
-- Index Scan 항상 나쁜 것은 아니고
-- Index Seek 항상 좋은 것은 아니다.
-- 왜 인덱스를 활용하는데 어떻게 느리고 어떻게 빠른가?
-- 그건 바로 북마크 룩업으로 인해 그렇다

-- NonClustered
--		1
-- 2 3 4 5 6
-- Leap에 데이터가 있는게 아니라 데이터의 키(참조)를 가지고 있다.
-- 만약 Clustered INDEX가 따로 없으면 힙 테이블이 생긴다.
-- Heap Table은 [ {Page} {Page} {Page} {Page} {Page} ]로 구조되어 있다.
-- RID를 이용해 힙테이블 찾아간다.

-- Clustered
--		1
-- 2 3 4 5 6
-- 물리적으로 데이터를 가지고 있다.

-- Clustered의 경우 INDEX SEEK가 느릴 수가 없다.
-- 왜? 데이터를 물리적으로 가지고 있으므로

-- NonClustered는 데이터가 Leaf PAGE에 없으므로 한번 더 타고 들어간다
-- 1) RID > HEAP TABLE (BOOKMARK LOOKUP)
-- 2) KEY > Clustered

SELECT * 
INTO TestOrders
FROM Orders;

SELECT * 
FROM TestOrders;

CREATE NonClustered INDEX Orders_Index01
ON TestOrders(CustomerID);

-- 인덱스 번호 
SELECT index_id, name
FROM sys.indexes
WHERE object_id = object_id('TestOrders');

-- 조회
DBCC IND('Northwind', 'TestOrders', 2);

-- 1112
-- 1072 1080 1081 
-- 현재 Clustered Heap를 만들어 주지 않았으니
-- HEAP Table이 생성되고 옆과 같은 [ {Page} {Page} {Page} {Page} {Page} ]로 구조되어 있다.

SET STATISTICS TIME ON;
SET STATISTICS IO ON;
SET STATISTICS PROFILE ON;

-- 기본 탐색을 해보자
SELECT * 
FROM TestOrders
WHERE CustomerID = 'QUICK';

-- 강제로 인덱스를 이용하게 해보자
SELECT * 
FROM TestOrders WITH (INDEX(Orders_Index01))
WHERE CustomerID = 'QUICK';
-- 논리적 읽기가 20에서 30으로 오름
-- 인덱스가 능사가 아니다.

-- 룩업을 줄이기 위한 몸부림
SELECT * 
FROM TestOrders WITH (INDEX(Orders_Index01))
WHERE CustomerID = 'QUICK' AND ShipVia = 3;

DROP INDEX TestOrders.Orders_Index01;

-- 검색을 하려는 모든 컬럼들을 꽉꽉 채워서 넣는 것을 
-- Covered Index라고 한다.
CREATE NonClustered INDEX Orders_Index01
ON TestOrders(CustomerID, ShipVia);

-- 8번 룩업을 시도해서 8번 다 꽝없이 찾게 된것이다.
SELECT * 
FROM TestOrders WITH (INDEX(Orders_Index01))
WHERE CustomerID = 'QUICK' AND ShipVia = 3;

-- Q) 그럼 조건 1 AND 조건 2 필요하면 무조건 INDEX (조건 1, 조건 2)를 추가해주면 되는가?
-- A) NO! 꼭 그렇지만은 않다. 검색할떄에는 빠르지만 DML 작업(INSERT, DELETE) 할 떄 작업의 부하가 증가하게 된다.
-- 서칭하는 작업만 필요하다면 좋겠지만 DML 작업을 수행하면 좋지 않게 된다.

DROP INDEX TestOrders.Orders_Index01;

CREATE NonClustered INDEX Orders_Index01
ON TestOrders(CustomerID) INCLUDE (ShipVia);
-- NonClustered
--		1
-- 2(DATA(SHIPVIA = 3), 3 4 5 6
-- 데이터 옆에 SHIPVIA에 값을 힌트를 줘서
-- NonClustered 단계에서 꽝과 진값을 찾아 데이터를 찾을 수 있게 된다.

-- 8번 룩업을 시도해서 8번 다 꽝없이 찾게 된것이다.
SELECT * 
FROM TestOrders WITH (INDEX(Orders_Index01))
WHERE CustomerID = 'QUICK' AND ShipVia = 3;
-- 동일한 결과가 나오게 된다.

-- 위와 같은 눈물겨운 노력에도 답이 없다면?
-- Clustered INDEX의 활용을 고려할 수 있다.
-- Clustered INDEX는 테이블당 한개만 사용할 수 있기 때문에 정말 중요한 애한테만 걸어줘야 한다는 것이다.

-- 결론
-- NONClustered INDEX가 악영황을 주는 경우?
	-- 북마크 룩업이 심각한 부하를 야기할 때에
-- 대안은?
	-- 옵션 1) COVERED INDEX (검색할 모든 컬럼을 포함시킨다)
	-- 옵션 2) INDEX에다가 INCLUDE로 힌트를 남겨준다.
	-- 옵션 3) Clustered를 고려한다 (한번만 사용할 수 있는 애다) > NONClustered에도 악영향을 끼칠 수 있으므로 주의가 요한다.
-- 인덱스를 무조건 건다고 해서 무조건 빨라진다는 것은 아니다.

