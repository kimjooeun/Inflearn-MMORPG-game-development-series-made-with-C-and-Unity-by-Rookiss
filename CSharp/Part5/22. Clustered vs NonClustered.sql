USE Northwind;

-- 인덱스 종류
-- Clustered(영한 사전) vs NonClustered(색인)

-- Clustered
	-- 실제로 데이터가 정렬되는 순서에 연관을 준다
	-- 물리적으로 데이터가 저장되는 순서가 키 값 정렬 순서를 따른다고 했습니다.
	-- Leaf Page가 곧 Data Page가 된다.
	-- Leaf Page는 트리 맨 마지막에 있는 값
	-- 데이터는 Clustered Index 로 걸어준 키 순서로 정렬된다.

-- NonClustered ? (사실 Clustered Index가 테이블 유무에 따라 다르게 동작을 한다.) > 핵심내용
	-- 1) Clustered Index가 없는 경우
		-- Clustered Index가 없으면 데이터는 Heap Table이라는 곳에 저장
		-- HeapTable의 번호인 Heap RID를 가지고 있으며 이를 이용해 Heap Table에 접근하여 데이터 추출한다.

	-- 2) Clustered Index가 있는 경우
		-- Heap Table이 없는 상태. Leaf Table에 실제 데이터가 들어 있다.
		-- Clustered Index의 실제 키 값을 들고 있는다.

-- 임시 테스트 테이블을 만들고 데이터를 복사하는 작업
SELECT * 
INTO TestOrderdetails
FROM [Order Details]; 

SELECT *
FROM TestOrderdetails

-- 인덱스 추가
CREATE INDEX Index_OrderDetails
ON TestOrderdetails(OrderID, ProductID);

-- 인덱스 정보
EXEC sp_helpindex 'TestOrderdetails';

-- 인덱스 번호 찾기
SELECT index_id, NAME
FROM sys.indexes
WHERE object_id = object_id('TestOrderdetails');

-- 조회
-- PageType 1번은(DATA PAGE) 2번은(INDEX PAGE)
DBCC IND('Northwind', 'TestOrderdetails', 2);

--			 952
-- 864 896 897 898 899 900

DBCC PAGE('Northwind', 1, 864, 3);
-- 각각의 Heap RID([페이지 주소(4)][파일ID(2)][슬롯(2)] ROW)
-- Heap Table이 존재하므로 Heap RID가 존재한다.
-- Heap Table은 [ {Page} {Page} {Page} {Page} {Page} ]로 구조되어 있다.

-- Clustered 인덱스 추가
CREATE Clustered INDEX Index_OrderDetails_Clustered
ON TestOrderdetails(OrderID);
-- PAGE ID가 변경된다.

-- Non-Clustered
DBCC PAGE('Northwind', 1, 984, 3);
-- Heap RID가 사라졌다

-- 조회
-- PageType 1번은(DATA PAGE) 2번은(INDEX PAGE)
DBCC IND('Northwind', 'TestOrderdetails', 1);

--					976
-- 928 936 937 938 939 940 941 942 943 944