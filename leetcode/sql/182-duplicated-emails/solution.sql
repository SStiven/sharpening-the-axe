/* Write your T-SQL query statement below */
SELECT
    p.email
FROM
    Person AS p
GROUP BY
    p.email
HAVING
    COUNT(p.email) > 1;