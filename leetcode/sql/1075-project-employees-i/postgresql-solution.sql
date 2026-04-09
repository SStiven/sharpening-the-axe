-- Write your PostgreSQL query statement below
select p.project_id, ROUND(AVG(e.experience_years), 2) as average_years
from  Project p
join Employee e on p.employee_id = e.employee_id
group by p.project_id
order by p.project_id asc


-- Improved version
select
    p.project_id
    ,round(AVG(experience_years),2) as average_years 
from project p
left join employee e using(employee_id)
group by p.project_id


CREATE TABLE Employee (
    employee_id INTEGER PRIMARY KEY,
    name VARCHAR(255),
    experience_years INTEGER NOT NULL
);

CREATE TABLE Project (
    project_id INTEGER,
    employee_id INTEGER,
    PRIMARY KEY (project_id, employee_id),
    FOREIGN KEY (employee_id) REFERENCES Employee (employee_id)
);

INSERT INTO Employee (employee_id, name, experience_years) VALUES
(1, 'Khaled', 3),
(2, 'Ali', 2),
(3, 'John', 1),
(4, 'Doe', 2);