USE BaseballData;

-- SubQuery (서브쿼리/하위쿼리)
-- SQL 명령문 안에 지정하는 하부 SELECT

-- 연봉이 역대급으로 높은 선수의 정보를 추출
SELECT TOP 1 *
FROM salaries
ORDER BY salary DESC;

-- 해당 선수는 rodrial01
-- 그럼 해당 선수의 정보를 찾으려면?
SELECT *
FROM players
WHERE playerID = 'rodrial01';

-- 위와 같이 해야한다. 그렇지만 이걸 매번 할 수 없으니 이걸 한번에 하려면?
-- 서브쿼리를 사용하면 된다.
-- 단일 행 서브쿼리
SELECT *
FROM players
WHERE playerID = (SELECT TOP 1 playerID FROM salaries ORDER BY salary DESC);

-- 다중 행 서브쿼리 = (IN을 사용해주면 된다)
SELECT *
FROM players
WHERE playerID IN (SELECT TOP 20 playerID FROM salaries ORDER BY salary DESC);

-- 하위 쿼리에서 값을 둘 이상 반환했습니다. 하위 쿼리 앞에 =, !=, <, <=, >, >= 등이 오거나 하위 쿼리가 하나의 식으로 사용된 경우에는 여러 값을 반환할 수 없습니다.
-- =이 어떤애랑 같아야하는지 알 수 없으므로 문제가 생긴다.
-- 이때 =를 IN으로 바꿔주면 된다.

-- 서브쿼리는 WHERE에서 가장 많이 사용된다. 그렇지만 나머지 구문에서도 사용 가능하다.
SELECT (SELECT COUNT(*) FROM players) AS playerCount, (SELECT COUNT(*) FROM batting) AS battingCount;

-- INSERT에서도 사용 가능
SELECT *
FROM salaries
ORDER BY yearID DESC;

-- INSERT INTO와 서브쿼리를 이용해 데이터를 넣는 법
INSERT INTO salaries
VALUES (2020, 'KOR', 'NL', 'SHUNG', (SELECT MAX(SALARY) FROM salaries))

-- INSERT SELECT
INSERT INTO salaries
SELECT 2020, 'KOR', 'NL', 'SHUNG2', (SELECT MAX(SALARY) FROM salaries);

-- 그럼 INSERT INTO와 INSERT SELECT의 차이점은 무엇인가?
-- 테이블의 내용을 모두 복사해서 다른 테이블에 넣어줄 수 있는 것
/* 
INSERT INTO salaries_temp
SELECT yearID, playerID, salary FROM salaries;

SELECT *
FROM salaries_temp;
*/ 

-- 상관 관계 서브쿼리
-- EXISTS, NOT EXISTS
-- 당장 자유자재로 사용을 못해도 되니 기억만 해도 된다.

-- 포스트 시즌 타격에 참여한 선수들 목록
SELECT *
FROM players
WHERE playerID IN (SELECT playerID FROM battingpost);

-- 상관관계를 이용한 포스트 시즌 타격에 참여한 선수들 목록
SELECT *
FROM players
WHERE EXISTS (SELECT playerID FROM battingpost WHERE battingpost.playerID = players.playerID);
-- SELECT playerID FROM battingpost WHERE players.playerID = battingpost.playerID 는 독립적이지 못하다.
-- EXISTS는 있으면 SELECT하고 없으면 SKIP해라.
-- WHERE이 사용범위가 조금 더 넓다.