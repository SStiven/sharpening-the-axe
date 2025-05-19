-- Selects only valid email addresses per the four rules, ordered by user_id
SELECT
    user_id,
    email
FROM
    Users
WHERE
    -- 0) Must contain at least one "@"
    email LIKE '%@%'        

    -- 1) Exactly one "@": disallow any string containing two or more "@"
    AND email NOT LIKE '%@%@%'  

    -- 2) Must end with ".com"
    AND email LIKE '%.com'  

    -- 3) Local part (before "@") only letters, digits, underscores
    AND LEFT(
            email,
            CHARINDEX('@', email) - 1
        ) NOT LIKE '%[^A-Za-z0-9_]%'  

    -- 4) Domain part (between "@" and ".com") only letters
    AND SUBSTRING(
            email,
            CHARINDEX('@', email) + 1,
            LEN(email)
              - CHARINDEX('@', email)    -- drop everything up to and including "@"
              - 4                        -- drop the ".com" suffix
        ) NOT LIKE '%[^A-Za-z]%' 
ORDER BY
    user_id;
