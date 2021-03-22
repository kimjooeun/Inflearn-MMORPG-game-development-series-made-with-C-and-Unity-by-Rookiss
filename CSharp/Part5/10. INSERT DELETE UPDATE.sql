USE BaseballData;

-- INSERT, DELETE, UPDATE, 

SELECT *
FROM salaries
ORDER BY yearID DESC

-- INSERT
-- 예) INSERT INTO [테이블명] VALUE (값, ...)
INSERT INTO salaries
VALUES (2020, 'KOR', 'NL', 'SHUNG', 9000000);

-- 데이터를 하나 빼먹으면? -> ERROR가 발생한다.
INSERT INTO salaries
VALUES (2020, 'KOR', 'NL', 'SHUNG2');

-- INSERT INTO [테이블명] (열, ...) VALUE (값, ...)
INSERT INTO salaries(yearID, teamID, playerID, lgID, salary)
VALUES (2020, 'KOR', 'SHUNG2', 'NL', 123456789);

-- 연봉을 제거한 SQL문
-- INSERT INTO [테이블명] (열, ...) VALUE (값, ...)
INSERT INTO salaries(yearID, teamID, playerID, lgID)
VALUES (2020, 'KOR', 'SHUNG3', 'NL');

-- DELETE
-- DELETE FROM [테이블명] WHERE [조건]
DELETE FROM salaries
WHERE playerID = 'SHUNG3'

-- UPDATE
-- UPDATE [테이블명] SET [열 = 값, ] WHERE [조건]
UPDATE salaries
SET salary = salary * 2, yearID = yearID + 1
WHERE teamID = 'KOR'

-- 추가한 데이터 삭제!
DELETE FROM salaries
WHERE yearID >= 2020

-- DELETE vs UPDATE
-- 물리삭제 vs 논리삭제

