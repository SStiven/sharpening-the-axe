/* https://leetcode.com/problems/queries-quality-and-percentage */
SELECT
    q.query_name,
    ROUND(
        AVG(CAST(q.rating AS FLOAT)/q.position),
        2
    ) as quality,
    ROUND(
        100.0 * SUM(CASE WHEN rating < 3 THEN 1 ELSE 0 END) / COUNT(*),
        2
    ) as poor_query_percentage
FROM
    Queries AS q
GROUP BY
    q.query_name
