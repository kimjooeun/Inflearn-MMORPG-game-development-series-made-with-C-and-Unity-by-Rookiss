USE BaseballData;

-- COUNT, SUM, AVG, MIN, MAX

SELECT *
FROM players;

-- COUNT
SELECT COUNT(*)
FROM players;
-- *을 붙일 수 있는 애는 COUNT가 유일하다

SELECT COUNT(birthYear)
FROM players;
-- 집계 함수는 집합이 NULL이면 무시한다.
-- 그래서 위 결과 값인 COUNT(*)와 아래 SQL인 COUNT(birthYear)의 결과 값은 차이점이 생긴다

SELECT DISTINCT birthCity
FROM players;
-- DISTINCT는 중복 제거이다

SELECT DISTINCT birthYear, birthMonth, birthDay
FROM players
ORDER BY BIRTHYEAR;
-- DISTINCT를 통해 여러개를 선택할 경우 각각의 인자값이 다 같아야 중복처리를 한다.

SELECT DISTINCT COUNT(birthCity)
FROM players;
-- 위 SQL은 COUNT가 먼저 연산이 되기 떄문에 16108로 처리 된다.
-- 그럼 어떻게 해야하나?

-- 집계함수(DISTINCT 집합)
SELECT COUNT(DISTINCT birthCity)
FROM players;
-- 위와 같이 해야한다.

SELECT *
FROM players;

-- 선수들의 평균 몸무게(WEIGHT)를 구해보자 (단위 : POUND)
SELECT AVG(WEIGHT)
FROM players;

-- 위 아래는 동일한 내용이다.
SELECT SUM(WEIGHT) / COUNT(WEIGHT)
FROM players;

-- 선수들의 평균 몸무게(WEIGHT)를 구해보자 (단위 : POUND)
-- 단, WEIGHT = NULL인 경우라면 WEIGHT = 0으로 친다
-- 실생활에서 이런 경우는 없겠지만 게임에서는 초기 골드 값을 NULL로 설정하고 골드의 평균을 구할때 NULL이 비교되면 안되기 떄문에 0으로 처리한다고 예를 들 수 있다.
SELECT AVG(CASE WHEN weight IS NULL THEN 0 ELSE WEIGHT END)
FROM players;

-- MIN, MAX
SELECT MIN(WEIGHT), MAX(weight)
FROM players;
-- MIN, MAX는 문자열이나 날짜에도 참고할 수 있는 특징이 있다.