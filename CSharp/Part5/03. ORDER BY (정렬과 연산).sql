-- 3장 ORDER BY (정렬과 연산)

USE BaseballData;

-- TOP은 T SQL에서만 사용된다는 단점이 있다.
-- 단점 : 100부터 200등을 확인할 수 없다


SELECT TOP 1 PERCENT *
FROM players
WHERE birthYear IS NOT NULL
ORDER BY birthYear DESC, birthMonth DESC, birthDay DESC;

-- 100~200등 검색
SELECT *
FROM players
WHERE birthYear IS NOT NULL
ORDER BY birthYear DESC, birthMonth DESC, birthDay DESC
OFFSET 100 ROWS FETCH NEXT 100 ROWS ONLY;