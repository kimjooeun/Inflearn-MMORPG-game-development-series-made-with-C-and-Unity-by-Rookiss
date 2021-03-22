
-- 우선 데이터베이스를 만들어야 한다.
-- baseballdata를 만드는 것처럼.
-- 이를 스키마(schema)라고 한다.

CREATE DATABASE GameDB;

USE GameDB;

-- 테이블 생성(CREATE)/삭제(DROP)/변경(ALTER)
-- CREATE TABLE 테이블명(열이름 자료형 [DEFAULT 기본값] [NULL | NOT NULL](제약) ,,,)

CREATE TABLE accounts(
	accountId INTEGER NOT NULL,
	accountName VARCHAR(10) NOT NULL,
	coins INTEGER DEFAULT 0,
	createdTime DATETIME
	-- PRIMARY KEY(accountID)와 같이 해줄 수 있다.
);

-- C#으로 치면 int accountID, string accountName, int coins, datetime createTime을 만든거와 똑같다.

SELECT * 
FROM accounts;
-- 테이블만 만들어 준 상태 아무런 값도 없다.

-- 테이블 삭제 (사용시 주의할 것.)
DROP TABLE accounts;

-- 테이블 변경 (ALTER)
-- 열 추가(ADD)/삭제(DROP)/변경(ALTER)
ALTER TABLE accounts
ADD lastEnterTime DATETIME;

ALTER TABLE accounts
DROP COLUMN lastEnterTime;

ALTER TABLE accounts
ALTER COLUMN accountName VARCHAR(20) NOT NULL;

-- 제약(CONSTRAINT) 추가/삭제
-- NOT NULL, UNIQUE, PRIMARY KEY(매우 X 100 중요), FOREIGN KEY

-- C# class Player() { }
-- List<Player> 장점 : 데이터가 적을때 관리하기 용이하다. 단점 : 데이터가 많아질 때 속도측면에서 떨어진다. (모두 순회해야하므로)
-- Dictionary<int, Player> : int를 Key값으로 사용한다.

ALTER TABLE accounts
ADD PRIMARY KEY (accountID);

ALTER TABLE accounts
ADD CONSTRAINT PK_Account PRIMARY KEY (accountId);
-- CONSTRAINT를 이용해 PRIMARY KEY의 별명을 만들어 줄 수 있다.

ALTER TABLE accounts
DROP CONSTRAINT PK_Account;
-- DROP과 CONSTRAINT를 이용해 PRIMARY KEY를 삭제한다.

SELECT *
FROM accounts
WHERE accountId = 1111;

-- List<Account>			// 프라이머리 키를 없애면 List 방식으로 실행계획이 생기며
-- Dictionary<int, Account> // 프라이머리 키를 생성하면 Dictinary 방식으로 실행계획이 생긴다. (이게 더 빠름)