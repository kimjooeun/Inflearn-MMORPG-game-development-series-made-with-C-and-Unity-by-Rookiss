USE BaseballData;

SELECT *, 
	CASE birthMonth
		WHEN 1 THEN N'겨울'
		WHEN 2 THEN N'겨울'
		WHEN 3 THEN N'봄'
		WHEN 4 THEN N'봄'
		WHEN 5 THEN N'봄'
		WHEN 6 THEN N'여름'
		WHEN 7 THEN N'여름'
		WHEN 8 THEN N'여름'
		WHEN 9 THEN N'가을'
		WHEN 10 THEN N'가을'
		WHEN 11 THEN N'가을'
		WHEN 12 THEN N'겨울'
		ELSE N'몰라요'
	END AS birthSeason
FROM players;

-- CASE 문은 궂이 SELECT 문 안의 있을 필요는 없다.

SELECT *, 
	CASE 
		WHEN birthMonth <= 2 THEN N'겨울'
		WHEN birthMonth <= 5 THEN N'봄'
		WHEN birthMonth <= 8 THEN N'여름'
		WHEN birthMonth <= 11 THEN N'가을'
		ELSE N'겨울'
	END AS birthSeason
FROM players;

-- C언어 IF-ELSE와 동일한 문법이다.

-- 공통 주의사항 
-- ELSE 문을 작성하지 않으면 birthSeason은 NULL이 된다.

SELECT *, 
	CASE 
		WHEN birthMonth <= 2 THEN N'겨울'
		WHEN birthMonth <= 5 THEN N'봄'
		WHEN birthMonth <= 8 THEN N'여름'
		WHEN birthMonth <= 11 THEN N'가을'
		WHEN birthMonth IS NULL THEN N'몰라요' -- NULL 체크
		ELSE N'겨울'
	END AS birthSeason
FROM players;