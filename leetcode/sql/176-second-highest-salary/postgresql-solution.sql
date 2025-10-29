-- Write your PostgreSQL query statement below
SELECT (
    SELECT salary 
    FROM employee
    GROUP BY salary
    ORDER BY salary DESC
    LIMIT 1
    OFFSET 1
) AS SecondHighestSalary;


select (
    select salary
    from (
        select salary, DENSE_RANK() over (order by salary desc) as rank
        from Employee
    )
    where rank=2
    limit 1
)
 as "SecondHighestSalary"