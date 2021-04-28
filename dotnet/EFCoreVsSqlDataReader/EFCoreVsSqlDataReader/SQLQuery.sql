-- These are the SQL queries used for reporting purposes

SELECT a.[Context], a.[Query], AVG([Milliseconds]) AS AvgMs
FROM (SELECT TOP(300) *
	FROM [TimingLogs]
	ORDER BY [CreatedOn] DESC) AS a
GROUP BY a.[Query], a.[Context]

SELECT a.[Context], a.[Query], MAX([Milliseconds]) AS MaxMs
FROM (SELECT TOP(300) *
	FROM [TimingLogs]
	ORDER BY [CreatedOn] DESC) AS a
GROUP BY a.[Query], a.[Context]

SELECT a.[Context], a.[Query], MIN([Milliseconds]) AS MinMs
FROM (SELECT TOP(300) *
	FROM [TimingLogs]
	ORDER BY [CreatedOn] DESC) AS a
GROUP BY a.[Query], a.[Context]