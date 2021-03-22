USE BaseballData;

----------- 변수 -----------
DECLARE @i AS INT = 10;

DECLARE @j AS INT;
SET @j = 10;

-- 예제) 역대 최고 연봉을 받은 선수의 이름은?
DECLARE @firstName AS NVARCHAR(15);
DECLARE @lastName AS NVARCHAR(15);

SET @firstName = (SELECT TOP 1 nameFirst
					FROM players AS p
						INNER JOIN salaries AS s
						ON p.playerID = s.playerID
					ORDER BY s.salary DESC);
--SQL SERVER
SELECT TOP 1 @firstName = p.nameFirst, @lastName = p.nameLast
FROM players AS p
	INNER JOIN salaries AS s
	ON p.playerID = s.playerID
ORDER BY s.salary DESC;

SELECT @firstName, @lastName;

----------- 배치(BATCH) -----------

GO

-- 배치를 이용해 변수의 유효범위를 설정 가능하다 예) C# { }
DECLARE @i AS INT = 10;

-- 배치는 하나의 묶음으로 분석되고 실행되는 명령어 집합
SELECT *
ROM players;

GO

SELECT *
FROM salaries;


----------- 흐름 제어 -----------

-- IF
GO
DECLARE @i AS INT = 10;

IF @i = 10
	PRINT('BINGO!');
ELSE
	PRINT('NO');

IF @i = 10
BEGIN
	PRINT('BINGO!');
	PRINT('BINGO!');
END
ELSE
BEGIN
	PRINT('NO');
END

-- WHILE
GO

DECLARE @i AS INT = 0;
WHILE @i <= 10
BEGIN
	SET @i = @i + 1;
	IF @i = 6 CONTINUE;
	PRINT @i;
END

----------- 테이블 변수 -----------
-- 임시로 사용할 테이블을 변수로 만들 수 있다.
-- testA, testB 만들고 삭제 -> 할 필요 없음
-- DECLARE를 사용한다. > 그 내용은? > tempdb 데이터베이스에 임시 저장

GO

DECLARE @test TABLE
(
	name VARCHAR(50) NOT NULL,
	salary INT NOT NULL
);

INSERT INTO @test
SELECT p.nameFirst + ' ' + p.nameLast, s.salary
FROM players AS p
	INNER JOIN salaries AS s
	ON p.playerID = s.playerID;

SELECT *
FROM @test;