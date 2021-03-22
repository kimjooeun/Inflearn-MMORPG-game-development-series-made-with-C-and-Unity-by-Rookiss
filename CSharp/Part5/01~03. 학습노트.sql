  -- 학습노드
  
  /* 
  1장 SSMS 입문
  주석 다는법 : /* */ 전체, -- 한줄

  -- SQL이란? 관계형 데이터 베이스(RRDBMS)를 조작하기 위한 명령어
  -- +@ T-SQL 최대한 표준에 맞춰서 작성한데
  -- CRUD (Create-Read-JUpdate-Delete) : 가장 기본적인 행위이다 
  */ 

  /* 
  2장 SELECT FROM WHERE

  SELECT *
  FROM players
  -- 책상에서 ~을 갖고와주세요는 책상이 1, ~를 갖고와주세요는 2번 순서이다.
  -- 그렇지만 이는 한국어에서 통용되는 것이며 'FROM : 책상에서 SELECT : ~를 갖고와주세요'가 된다.
  -- 하지만 영어는 정 반대이다.

  -- 순서 from, where, select!
  -- where 절은 IF문과 동일하다

  -- NULL은 IS NULL, IS NOT NULL로 비교한다.

  -- 문자열 비교는 패턴(LIKE)문을 사용한다. 이는 크게 %와 _로 나눌 수 있다
  -- % 임의의 문자열
  -- _ 임의의 문자 1개
  */

  /* 3장 ORDER BY (정렬과 연산)

  ASC 작은 숫자에서 큰 숫자
  DESE 큰 숫자에서 작은 숫자

  -- TOP은 T SQL에서만 사용된다는 단점이 있다.
  -- 단점 : 100부터 200등을 확인할 수 없다
 
  SELECT TOP 1 PERCENT(생략가능) *
  FROM players
  WHERE birthYear IS NOT NULL
  ORDER BY birthYear DESC, birthMonth DESC, birthDay DESC;
  
  -- 100~200등 검색하는 법
  SELECT *
  FROM players
  WHERE birthYear IS NOT NULL
  ORDER BY birthYear DESC, birthMonth DESC, birthDay DESC
  (추가) OFFSET 100 ROWS FETCH NEXT 100 ROWS ONLY;
  */ 