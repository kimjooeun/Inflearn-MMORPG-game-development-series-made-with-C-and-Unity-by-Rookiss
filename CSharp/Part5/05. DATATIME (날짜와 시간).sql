-- 5장 DATATIME (날짜와 시간)

-- DATE 연/월/일
-- TIME 시/분/초
-- DATETIME 연/월/일/시/분/초


USE [BaseballData]
GO

  --SELECT CAST('20210311 21:04:05' AS DATETIME)
  ---- CAST 권장사항
  ---- YYYYMMDD
  ---- YYYYMMDD hh:mm:ss.nnn
  ---- YYYY-MM-DDThh:mm

  ---- 현재시간 추출
  --SELECT GETDATE() -- T SQL 전용
  --SELECT CURRENT_TIMESTAMP -- 표준

INSERT INTO [dbo].[DateTimeTest]
           ([time])
     VALUES
           ('20070909')
GO
-- 위는 시간 데이터를 넣는 방법

-- 아래는 넣은 시간을 확인하는 방법
SELECT *
FROM DATETIMETEST
-- 시간을 비교하는 법 (WHERE절을 사용한다)
WHERE time >= '20100101'

-- UTC 데이터를 사용해서 비교하는법
-- GMT(Greenwich Mean Time)
-- 주로 서버 내 시간을 다룰때 아래 표준을 사용한다
SELECT GETUTCDATE();

-- 시간과 관련된 연산(시간을 더하고 빼는 함수)
SELECT DATEADD (YEAR, 1, '20200426')
SELECT DATEADD (DAY, 5, '20200426')
SELECT DATEADD (SECOND, 123123, '20200426')
SELECT DATEADD (SECOND, -123123, '20200426')

-- 두 시간사이의 차이를 구하는 함수
SELECT DATEDIFF(SECOND, '20200426', '20200503')
SELECT DATEDIFF(DAY, '20200426', '20200503')

-- 어떤 특정 날짜에서 연,월,달을 뽑아올떄 사용하는 함수)
SELECT DATEPART(DAY, '20200826')
SELECT YEAR ('20200826')
SELECT MONTH ('20200826')
SELECT DAY ('20200826')