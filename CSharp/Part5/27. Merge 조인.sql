USE BaseballData;

SET STATISTICS TIME ON;
SET STATISTICS IO ON;
SET STATISTICS PROFILE ON;

-- Merge (병합) 조인 = Sort Merge(정렬 병합) 조인

-- NonClustered
--		1
-- 2 3 4 5 6

-- Clustered
--		1
-- 2 3 4 5 6

SELECT *
FROM players AS p
	INNER JOIN salaries AS s
	ON p.playerID = s.playerID;


-- One-To-Many (outer가 unique해야 한다. > PK, Unique)
-- Merge 조인도 조건이 붙게 된다.
-- 일일히 Random Access > Clustered Scan 후 정렬하게 된다.

SELECT *
FROM schools AS s
	INNER JOIN schoolsplayers AS p
	ON p.schoolID = s.schoolID;

-- 오늘의 결론 --
-- Merge > Sort Merge 조인
-- 1) 양족 집합을 Sort(정렬)하고 Merge(병합)한다
	-- 이미 정렬된 상태의 데이터라면 Sort(정렬)은 생략된다.
	-- 정렬할 데이터가 너무 많으면 GG - Hash 조인을 이용한다
-- 2) Random Access 위주로 수행되지는 않는다. 
-- 3) Many-To-Many(다대다)보다는 One-To-Many(일대다) 조인에 효과적이다.
		-- PK, UNIQUE
