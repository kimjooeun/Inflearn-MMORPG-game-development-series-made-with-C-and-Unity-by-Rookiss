USE GameDB;

SELECT *
FROM accounts;

DELETE accounts;

-- BEGIN TRAN;으로 시작한다
-- COMMIT;
-- ROLLBACK; 둘 중 하나를 선택하여 실행한다.

-- ALL OR NOTGING(원자성)
-- 거래를 한다고 가정해보자
-- A의 인벤토리에서 아이템 제거
-- B의 인벤토리에다가 아이템 추가
-- 수수료로 인한 A의 골드 감소

INSERT INTO accounts VALUES (1, 'SHUNG', 100, GETUTCDATE());
-- TRAN을 명시하지 않으면 자동으로 COMMIT 하게 된다.

-- COMMIT과 ROLLBACK에 대해 알아보자
-- 예) 메일을 보낸다고 가정해보자 (BEGIN TRAN)
-- 보낼 것인가? (COMMIT)
-- 취소할 것인가? (ROLLBACK)

-- 성공/실패 여부에 따라 COMMIT (= COMMIT을 수동으로 하겠다)
BEGIN TRAN;
	INSERT INTO accounts VALUES (2, 'SHUNG2', 100, GETUTCDATE());
ROLLBACK;

BEGIN TRAN;
	INSERT INTO accounts VALUES (2, 'SHUNG2', 100, GETUTCDATE());
COMMIT;

-- 응용편
BEGIN TRY
	BEGIN TRAN;
		INSERT INTO accounts VALUES (1, 'SHUNG2', 100, GETUTCDATE());
		INSERT INTO accounts VALUES (3, 'SHUNG3', 100, GETUTCDATE());
	COMMIT;
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0 -- 현재 활성화된 트랜잭션 수를 반환한다.
		ROLLBACK
	PRINT('ROOLBACK했음')
END CATCH

-- TRAN 사용할 때 주의할 점
-- TRAN 안에는 꼭 원자적으로 실행될 애들만 넣을 것.
-- C# List<Player> List<Salary> 원자적으로 수정 -> Lock을 잡고 실행했다. -> WrItelock (상호배타적인 락) Readlock (공유 락)

BEGIN TRAN;
	INSERT INTO accounts VALUES (1, 'SHUNG', 100, GETUTCDATE());
ROLLBACK;