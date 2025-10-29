CREATE OR REPLACE FUNCTION NthHighestSalary(N INT) RETURNS TABLE (Salary INT) AS $$
BEGIN
  RETURN QUERY (
    -- Write your PostgreSQL query statement below.
    SELECT (
        SELECT e.salary
        FROM employee e
        GROUP BY e.salary
        ORDER BY e.salary DESC
        LIMIT 1
        OFFSET N - 1
    )
  );
END;
$$ LANGUAGE plpgsql;