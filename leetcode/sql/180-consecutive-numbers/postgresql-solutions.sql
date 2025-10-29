
-- Write your PostgreSQL query statement below
SELECT DISTINCT l1.num as ConsecutiveNums
FROM Logs l1
INNER JOIN Logs l2 ON l1.id + 1 = l2.id AND l1.num = l2.num
INNER JOIN Logs l3 ON l2.id + 1 = l3.id AND l2.num = l3.num


-- Write your PostgreSQL query statement below
SELECT DISTINCT num AS ConsecutiveNums
FROM (
    SELECT
    num,
    LAG(num, 1) OVER (ORDER BY id) AS prev_num1,
    LAG(num, 2) OVER (ORDER BY id) AS prev_num2
FROM
    Logs
) AS sub
WHERE num = prev_num1 AND num = prev_num2
