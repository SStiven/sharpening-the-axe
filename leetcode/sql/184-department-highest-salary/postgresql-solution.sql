-- Write your PostgreSQL query statement below
WITH max_salary_per_department AS (
    SELECT
        MAX(e.salary) AS max_salary,
        e.departmentId
    FROM
        Employee e
    GROUP BY e.departmentId
)
SELECT d.name AS Department, e.name AS Employee, e.salary AS Salary
FROM Department d
INNER JOIN max_salary_per_department m ON m.departmentId = d.id
INNER JOIN Employee e ON e.departmentId = m.departmentId AND e.salary = m.max_salary


