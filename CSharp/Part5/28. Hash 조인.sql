USE Northwind;

-- Hash(해시) 조인

SELECT * INTO TestOrders FROM Orders;
SELECT * INTO TestCustomers FROM Customers;

SELECT * FROM TestOrders; --830
SELECT * FROM TestCustomers; --91

-- HASH
SELECT *
FROM TestOrders AS o
	INNER JOIN TestCustomers AS c
	ON o.CustomerID = c.CustomerID;

-- NL (Inner 테이블에 인덱스가 없다)
SELECT *
FROM TestOrders AS o
	INNER JOIN TestCustomers AS c
	ON o.CustomerID = c.CustomerID
	OPTION (FORCE ORDER, LOOP JOIN);

-- Merge (Outer, Inner 모두 Sort 해야 한다. 즉 (Many-To-Many))
SELECT *
FROM TestOrders AS o
	INNER JOIN TestCustomers AS c
	ON o.CustomerID = c.CustomerID
	OPTION (FORCE ORDER, MERGE JOIN);

-- HASH
SELECT *
FROM TestOrders AS o
	INNER JOIN TestCustomers AS c
	ON o.CustomerID = c.CustomerID;

-- 오늘의 결론 --
-- Hash 조인
-- 1) 정렬이 필요하지 않다. > 데이터가 너무 많아서 Merge가 부담스러울 때에 Hash가 대안이 될 수 있다.
-- 2) 인덱스 유무에 영향을 받지 않는다. (별 다섯개 중요)
	-- NL/Merge에 비해 확실한 장점이다.
	-- 그렇지만 인덱스를 잊고 살면 안된다.
	-- HashTable을 만드는 비용을 무시하면 안된다. (수행 빈도가 많은 쿼리를 만든다고 가정하면 > 결국 인덱스를 추가해 관리가 필요하다)
	-- 가끔 사용하면 해쉬조인을 이용해 인덱스 없이 사용하게 될 경우 NL, 머지에 비해 효율적이다
-- 3) 랜덤 엑서스 위주로 수행되지 않는다.
-- 4) 데이터가 적은 쪽을 HashTable로 만드는 것이 유리하다.
