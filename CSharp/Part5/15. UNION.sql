USE BaseballData;

-- 복수의 테이블을 다루는 방법에 대해 설명한다.

-- RDMBS (Relational 관계형)
-- 데이터를 집합으로 간주하는것이 RDBMS의 핵심

-- 커리어 평균 연봉이 3000000 이상인 선수들의 playerID
SELECT playerID, AVG(salary)
FROM salaries
GROUP BY playerID
HAVING AVG(salary) >= 3000000;

-- 12월에 태어난 선수들의 playerID
SELECT playerID, birthMonth
FROM players
WHERE birthMonth = 12;

-- [커리어 평균 연봉이 3000000 이상] 이거나(||) [12월에 태어난] 선수
-- UNION (중복 제거)
SELECT playerID
FROM salaries
GROUP BY playerID
HAVING AVG(salary) >= 3000000

UNION

SELECT playerID
FROM players
WHERE birthMonth = 12;

-- UNION ALL (중복 혀용)
SELECT playerID
FROM salaries
GROUP BY playerID
HAVING AVG(salary) >= 3000000

UNION ALL

SELECT playerID
FROM players
WHERE birthMonth = 12
ORDER BY playerID;

-- [커리어 평균 연봉이 3000000 이상] 이거나(&&) [12월에 태어난] 선수 (교집합)
SELECT playerID
FROM salaries
GROUP BY playerID
HAVING AVG(salary) >= 3000000

INTERSECT

SELECT playerID
FROM players
WHERE birthMonth = 12
ORDER BY playerID;

-- [커리어 평균 연봉이 3000000 이상] - [12월에 태어난] 선수 (차집합)
SELECT playerID
FROM salaries
GROUP BY playerID
HAVING AVG(salary) >= 3000000

EXCEPT

SELECT playerID
FROM players
WHERE birthMonth = 12
ORDER BY playerID;