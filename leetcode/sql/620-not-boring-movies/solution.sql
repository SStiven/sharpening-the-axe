/* https://leetcode.com/problems/not-boring-movies */
SELECT
    c.id, c.movie, c.description, c.rating
FROM 
    Cinema AS c
WHERE
    c.id % 2 <> 0
    AND c.description <> 'boring'
ORDER BY 
    rating DESC;