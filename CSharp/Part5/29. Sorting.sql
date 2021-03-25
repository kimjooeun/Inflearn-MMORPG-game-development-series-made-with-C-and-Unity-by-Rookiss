USE BaseballData;

-- Sorting (정렬)의 시간을 줄이자.

-- O(NLogN) > DB는 데이터가 어마어마하게 많다
-- 너무 용량이 커서 가용 메모리로 커버가 되지 않는다면 > 디스크까지 찾아가게 된다 (문제 발생)
-- 그렇다면 언제 Sorting이 일어나는지 파악해야 한다

-- Sorting이 일어날 때
-- 1) SORT MERGE JOIN
-- 2) ORDER BY
-- 3) GROUP BY
-- 4) DISTINCT
-- 5) UNION
-- 6) RANKING WINDOES FUNCTION
-- 7) MIX, MAX

-- 1) 은 생략

-- 2) ORDER BY
-- 원인 : ORDER BY 순서로 출력을 해서 정렬해야 하기 때문에 SORT가 일어난다.

SELECT *
FROM players
ORDER BY college;

-- 3) GROUP BY
-- 원인 : 집계를 하기 위해
SELECT College, COUNT(College)
FROM players
WHERE college LIKE '%C'
GROUP BY college;

-- 4) DISTINCT
-- 원인 : 중복을 제거하기 위해 사용된다
SELECT DISTINCT College
FROM players
WHERE college LIKE '%C'

-- 5) UNION
-- 원인 : 마찬가지로 데이터의 중복을 제거하기 위해 사용된다
SELECT College
FROM players
WHERE college LIKE 'B%'
UNION
SELECT College
FROM players
WHERE college LIKE 'C%'

-- 6) 순위 윈도우 함수
-- 원인 : 집계를 하기 위해
SELECT ROW_NUMBER() OVER (ORDER BY College)
FROM players;

-- 오늘의 결론
-- Sorting을 줄이자.

-- O(NLogN) > DB는 데이터가 어마어마하게 많다
-- 너무 용량이 커서 가용 메모리로 커버가 되지 않는다면 > 디스크까지 찾아가게 된다 (문제 발생)
-- 그렇다면 언제 Sorting이 일어나는지 파악해야 한다

-- Sorting이 일어날 때
-- 1) SORT MERGE JOIN
-- 2) ORDER BY
-- 3) GROUP BY
-- 4) DISTINCT
-- 5) UNION
-- 6) RANKING WINDOES FUNCTION
-- 7) MIX, MAX