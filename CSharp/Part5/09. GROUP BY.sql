USE BaseballData;

-- 복습
-- 2004년도 보스턴 소속으로 출전한 선수들의 타격 정보
SELECT *
FROM BATTING
WHERE YEARID = 2004 AND TEAMID = 'BOS';

-- 2004년도 보스턴 소속으로 출전해서 날린 홈런 개수
SELECT SUM (HR)
FROM BATTING
WHERE YEARID = 2004 AND TEAMID = 'BOS';

-- 2004년도에 가장 많은 홈런을 날린 팀은?
SELECT *
FROM BATTING
WHERE YEARID = 2004
ORDER BY TEAMID;

-- 팀별로 묶어서 무엇인가를 분석하고 싶다 -> grouping
SELECT TEAMID, COUNT(TEAMID) AS playerCount, SUM(HR) AS homeRuns
FROM BATTING
WHERE YEARID = 2004
GROUP BY TEAMID;

-- 2004년도에 가장 많은 홈런을 날린 팀은?
SELECT TEAMID, SUM(HR) AS homeRuns
FROM BATTING
WHERE YEARID = 2004
GROUP BY TEAMID
ORDER BY homeRuns DESC;

-- 2004년도에 200홈런 이상을 날린 팀의 목록
SELECT TEAMID, SUM(HR) AS homeRuns
FROM BATTING
WHERE YEARID = 2004
GROUP BY TEAMID
HAVING SUM(HR) >= 200
ORDER BY homeRuns DESC;

-- 실제로 실행되는 동작의 순서(영문법)
-- FROM			책상에서
-- WHERE		공을
-- GROUP BY		색상별로 분류해서
-- HAVING		분류한 다음에 빨간색은 제외하고
-- SELECT		갖고 와주세요
-- ORDER BY		크기 별로 나열해주세요

-- 당일 년도에 가장 많은 홈런을 날린 팀은?
SELECT TEAMID, YEARID, SUM(HR) AS homeRuns
FROM BATTING
GROUP BY TEAMID, yearID
ORDER BY homeRuns DESC;