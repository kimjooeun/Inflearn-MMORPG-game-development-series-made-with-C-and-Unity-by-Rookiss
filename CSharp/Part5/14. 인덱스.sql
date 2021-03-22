/*

영상으로 공부.

INDEX(색인)는 데이터를 빨리 찾을 수 있게 보조해준다.
인덱스의 종류

-- PRIMARY KEY (CLUSTERED INDEX)
물리적인 데이터 저장 순서의 기준
예) 영한 사전을 떠올리면 된다

-- 일반 INDEX (NON-CLUSTERED INDEX)
다로 관리하는 일종의 LOOKUP 테이블
예) 책 후반에 나오는 색인

*/

-- 인덱스 CREATE INDEX / DROP INDEX

CREATE UNIQUE INDEX i1 ON accounts(accountName);
-- 인덱스 생성

DROP INDEX accounts.i1;
-- 인덱스 삭제

CREATE CLUSTERED INDEX i1 ON accounts(accountName);
-- 테이블 'accounts'에 클러스터형 인덱스를 둘 이상 만들 수 없습니다. 다른 클러스터형 인덱스를 만들려면 기존 클러스터형 인덱스 'PK_Account'을(를) 삭제하십시오.
-- CLUSTERED 인덱스인 PK_Account가 있으므로 i1 인덱스는 생성되지 않는다.

CREATE UNIQUE INDEX i1 ON accounts(accountName, coins);
-- 다른 테이블과 함께 인덱스를 생성해서 키로 사용할 수 있다.
-- 그럴 일은 잘 없지만.