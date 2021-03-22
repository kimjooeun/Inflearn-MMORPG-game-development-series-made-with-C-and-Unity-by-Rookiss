USE BaseballData;

-- 윈도우 함수
-- 행들의 서브 집합을 대상으로, 각 행렬로 계산을 해서 스칼라(단일 고정)값을 출력하는 함수

-- 느낌상 GROUPING이랑 비슷한가?
-- SUM, COUNT, AVG 집계 함수

SELECT *
FROM salaries
ORDER BY salary DESC;

SELECT playerID, MAX(salary)
FROM salaries
GROUP BY playerID
ORDER BY MAX(salary) DESC;

-- 헤딩하면서 배우는 윈도우 함수
-- ~OVER 문법이 들어간다
-- ~OVER ([PARTITION] [ORDER BY] [ROWS])
-- PARTITION은 서브셋을 어떻게 그룹핑 할것인지?
-- ORDER BY는 정렬을 어떻게 할 것인지?
-- ROWS는 범위를 어떻게 사용할 것인지?

-- 전체 데이터를 연봉 순서로 나열하고, 순위 표기
SELECT *,
	ROW_NUMBER() OVER (ORDER BY salary DESC), -- 행#번호
	RANK() OVER (ORDER BY salary DESC), -- 랭킹
	DENSE_RANK() OVER (ORDER BY salary DESC), -- 랭킹 
	NTILE(100) OVER (ORDER BY salary DESC) -- 상위 몇 %? (백분율)
FROM salaries;

-- playerID 별 순위를 따로 하고 싶다면
SELECT *,
	RANK () OVER (PARTITION BY playerID ORDER BY salary DESC)
FROM salaries
ORDER BY playerID;

-- LAG(바로 이전), LEAD(바로 다음)
SELECT *,
	RANK () OVER (PARTITION BY playerID ORDER BY salary DESC),
	LAG(salary) OVER (PARTITION BY playerID ORDER BY salary DESC) AS prevSalary, 
	LEAD(salary) OVER (PARTITION BY playerID ORDER BY salary DESC) AS prevSalary
FROM salaries
ORDER BY playerID;

-- FIRST_VALUE, LAST_VALUE
-- BRAME : FIRST ~ CURRENT
SELECT *,
	RANK () OVER (PARTITION BY playerID ORDER BY salary DESC),
	FIRST_VALUE(salary) OVER (PARTITION BY playerID ORDER BY salary DESC ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS best,
	LAST_VALUE(salary) OVER (PARTITION BY playerID ORDER BY salary DESC ROWS BETWEEN CURRENT ROW AND UNBOUNDED FOLLOWING) AS worst
FROM salaries
ORDER BY playerID;
-- 범위가 처음부터 끝가지이므로 1번 내용은 1행만, 2번 내용은 2행만 삽입되는 것이다.