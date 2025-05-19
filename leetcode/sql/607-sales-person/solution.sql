SELECT DISTINCT sp.name
FROM SalesPerson sp
LEFT JOIN (
    SELECT DISTINCT o.sales_id 
    FROM Orders AS o
    JOIN Company AS c ON o.com_id = c.com_id AND c.name = 'RED'
) AS ro ON sp.sales_id = ro.sales_id
WHERE ro.sales_id IS NULL;


SELECT name
FROM SalesPerson AS sp
WHERE NOT EXISTS(
    SELECT 1
    FROM Orders AS o
    JOIN COMPANY c ON o.com_id = c.com_id
    WHERE c.name = 'RED' AND o.sales_id = sp.sales_id
)