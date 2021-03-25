USE BaseballData;

-- 조인 원리
	-- 1) Nested Loop (NL) 조인
	-- 2) Merge (병합) 조인
	-- 3) Hash (해시) 조인

-- NonClustered
--		1
-- 2 3 4 5 6

-- Clustered
--		1
-- 2 3 4 5 6

-- Merge
SELECT *
FROM players AS p
	INNER JOIN salaries AS s
	ON p.playerID = s.playerID;

-- NL
SELECT TOP 5 *
FROM players AS p
	INNER JOIN salaries AS s
	ON p.playerID = s.playerID;

-- Hash
SELECT *
FROM salaries AS s
	INNER JOIN teams AS t
	ON s.teamID = t.teamID;

-- NL
SELECT *
FROM players AS p
	INNER JOIN salaries AS s
	ON p.playerID = s.playerID
	OPTION(LOOP JOIN);

-- NL
SELECT *
FROM players AS p
	INNER JOIN salaries AS s
	ON p.playerID = s.playerID
	OPTION(FORCE ORDER, LOOP JOIN);

-- 오늘의 결론
-- NL의 특징
-- 먼저 접근한(액세스)한 OUTER 테이블의 로우를 차례 차례 스캔을 하며 걔(OUTER TALBE)를 들어 (INNER)테이블에 랜덤 엑세스 하게 된다.
-- 두번재 조건은 (INNER)테이블에 인덱스가 없으면 답이 없다. (노답) (매우 느림)
-- 부분 범위 처리에 좋다 (EX, TOP 5)