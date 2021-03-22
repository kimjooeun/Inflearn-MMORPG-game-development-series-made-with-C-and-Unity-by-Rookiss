-- 4장 수치와 문자열

USE BaseballData;

-- 한국나이 계산법 (2021 - 아무년도)
-- 다른 프로그램과 마찬가지로 사칙연산이 가능함(+, -, *, /, %)

SELECT 2021 - birthYear AS koreanAge
FROM players
WHERE deathYear IS NULL AND birthYear IS NOT NULL AND (2021-birthYear) <= 80
ORDER BY koreanAge

-- 순서(아래와 같이 읽고 이해해야 한다)
-- frem, where - select - orderby
-- 책상에서, 빨간색공을, 갖고오고, 크기 순서로 정렬해라

SELECT 2021 - NULL
-- NULL은 사칙연산 중 무엇을 해도 NULL이다.

-- 나눗셈 연산시 주의점
SELECT 3.0 / 0
-- 정수형 나누기 정수형이므로 소수 이하 값 삭제
-- 앞에 소숫점을 붙여주면 해결 된다.
-- 0으로는 나눌 수 없다

SELECT ROUND(3.141592, 3);
SELECT POWER(2, 3)
SELECT COS(0)

/* 이하 문자열 연산 시간 연산 */
SELECT 'HELLO WORLD'
SELECT N'안녕하세요'
-- 한글은 앞에 N을 붙여줘야한다.

SELECT 'HELLO' + 'WORLD'
-- 두 문자열을 더할때 사용한다

SELECT SUBSTRING ('20210311', 1, 4);
-- 몇번째 인자부터 몇번재 인자까지 출력할것인가?

SELECT TRIM('                        HELLOWORLD');
-- 앞에 스페이스를 날려주는 기능을 가진 함수

SELECT nameFirst + ' ' + nameLast AS fullname
FROM players
WHERE nameFirst IS NOT NULL AND nameLast IS NOT NULL

-- nameFirst와 nameLast를 풀네임으로 읽어들이는 SQL문
-- 대신 nameFirst와 nameLast이 널이 아니여야 한다.