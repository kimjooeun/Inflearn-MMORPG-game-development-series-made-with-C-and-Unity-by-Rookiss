USE Northwind;

-- 인덱스 접근 방식(Access)
-- Index Scan vs Index Seek

CREATE TABLE TestAccess
(
	id INT NOT NULL,
	name NCHAR(50) NOT NULL,
	dummy NCHAR(1000) NULL
);
GO

CREATE CLUSTERED INDEX TestAccess_CI
ON TestAccess(id);
GO

CREATE NONCLUSTERED INDEX TestAccess_NCI
ON TestAccess(name);


DECLARE @i INT
SET @i = 1;
WHILE (@i <= 500)
BEGIN
	INSERT INTO TestAccess
	VALUES (@i, 'Name' + CONVERT(VARCHAR, @i), 'HELLO WORLD' + CONVERT(VARCHAR, @i));
	SET @i = @i +1;
END

-- 인덱스 정보
EXEC sp_helpindex 'TestAccess';

-- 인덱스 번호 
SELECT index_id, name
FROM sys.indexes
WHERE object_id = object_id('TestAccess');

-- 조회
DBCC IND('Northwind', 'TestAccess', 1);
DBCC IND('Northwind', 'TestAccess', 2);

-- CLUSTERED(1) : id
--			9121
-- 840 ~ 9120 (167)

-- NONCLUSTERED(2) : name
--		833
-- 837 ~ 832 (13)

-- 논리적 읽기 > 실제 데이터를 찾기 위해 읽은 페이지수
SET STATISTICS TIME ON;
SET STATISTICS IO ON;

-- INDEX SCAN = LEAF PAGE를 순차적으로 검색하는 것
SELECT *
FROM TestAccess;

-- INDEX SEEK 
SELECT *
FROM TestAccess
WHERE id = 104;
-- 왜 논리적 읽기가 2인가? 
-- CLUSTERED(1) : id
--			9121
-- 840 ~ 9120 (167)에서
-- 9121을 먼저 검색하고 없으니 그 밑에 840 ~ 9120사이에 값을 검색한 것이므로 2번

-- INDEX SEEK + KEY LOOKUP
SELECT *
FROM TestAccess
WHERE name = 'name5';
-- 왜 논리적 기반이 4인가?
-- NONCLUSTERED(2) : name
--		833
-- 837 ~ 832 (13) 833페이지에 들어와 NAME 5를 찾고 싶은에 어떤 페이지로 가야하는가?
-- 알맞는 832에 있다 그럼 833 1번, 832 2번이 된다. 그렇지만 NONCLUSTERED 실제 물리적으로 정보가 저장되어 있는게 아니라
-- CLUSTERED의 키값만 가지고 있으므로 키값이 ID이므로 832에 있다고 하더라도 NAME 5번에 해당하는 ID 값만 가지고 있으니
-- CLUSTERED쪽으로 넘어가서 2번을 추가하므로 4가 된다.

-- INDEX SCAN + KEY LOOKUP
-- N * 2 + @
SELECT TOP 10 *
FROM TestAccess
ORDER BY name;
-- INDEX SCAN 이 떳다고 해서 꼭 나쁜건 아니다.
-- 그럼 왜 논리적 읽기가 13인가? > TOP 5와 ORDER BY로 인해 그렇다

-- NONCLUSTERED(2) : name
--		833
-- 837 ~ 832 (13)에서 837 부터 5개만 추출하고 나오면 되므로 인덱스 스캔이지만 빠르게 진행된다.
-- 5개만 추출한 내용을 CLUSTERED가서 진행한다.
-- CLUSTERED(1) : id
--			9121
-- 840 ~ 9120 (167)
-- 이로 인해 대략적으로 13개가 나온것을 알 수 있다.