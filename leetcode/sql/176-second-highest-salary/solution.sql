/* Write your T-SQL query statement below */
SELECT 
    COALESCE((
        SELECT DISTINCT 
            e.salary AS SecondHighestSalary
        FROM Employee e
        ORDER BY e.salary DESC
        OFFSET 1 ROWS FETCH NEXT 1 ROW ONLY
    ), NULL) AS SecondHighestSalary;


/* Write your T-SQL query statement below */

-- This query returns the second highest distinct salary, or NULL if none exists
SELECT
    -- 1) MAX over the filtered set picks the highest remaining salary
    MAX(e.salary) AS SecondHighestSalary  
FROM 
    Employee AS e
WHERE
    e.salary < (
        -- 2) Subquery finds the absolute highest salary in the table
        SELECT MAX(salary) 
        FROM Employee
    );
    /* 
       3) The WHERE clause filters out the highest salary itself, leaving only salaries strictly less.
          • If there are at least two distinct salaries, this leaves one or more rows 
            and MAX(e.salary) picks the second highest.
          • If there is only one (or zero) distinct salary, the WHERE yields an empty set.
       
       4) In SQL Server (and standard SQL), any aggregate function (like MAX) applied
          over an empty set returns NULL rather than an error or 0.
          Hence, when no “second” salary exists, SecondHighestSalary is NULL by definition.
    */



ou can force the query to return no rows when there is no “second” salary by adding a HAVING clause that requires at least one candidate in the filtered set:

sql
Copy
Edit
-- Return exactly one row only if a second‐highest salary exists;
-- otherwise return zero rows.
SELECT
    MAX(e.salary) AS SecondHighestSalary
FROM 
    Employee AS e
WHERE 
    -- filter out the absolute highest salary
    e.salary < (
        SELECT MAX(salary)
        FROM Employee
    )
-- only return when there is at least one salary < max(salary)
HAVING
    COUNT(*) > 0;
How it works
WHERE e.salary < (SELECT MAX(salary)…)

Builds the set of all salaries strictly less than the maximum (i.e. potential “second highest” candidates).

MAX(e.salary)

Picks the highest value within that set—i.e. the second highest overall.

HAVING COUNT(*) > 0

If the WHERE filter leaves no rows, then COUNT(*) = 0 and the HAVING fails → no rows returned.

If there is at least one candidate, COUNT(*) ≥ 1 and you get the single row with SecondHighestSalary.

This satisfies your requirement to omit any output entirely when a second‐highest salary does not exist.