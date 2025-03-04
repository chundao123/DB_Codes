/* COMP 3311 Lab 4 Exercise: Queries */

clear screen
set feedback off
set pagesize 30

/* Query 1 */
set heading off
select 'Query 1: Find the minimum, maximum, average and total number of computers over all departments.' from dual;
set heading on
-- ***** Construct Query 1 below this line *****
select min(numberComputers) as "MINIMUM", max(numberComputers) as "MAXMUM", avg(numberComputers) as "AVERAGE", sum(numberComputers) as "TOTAL"
from Department natural join Facility;


/* Query 2 */
set heading off
select '--------------------------------------------------------------------------------------------------' from dual;
select 'Query 2: Find the first name, last name, student id and cga of the students from the COMP' || chr(10) ||
       '         department with the highest cga.' from dual;
-- ***** Construct Query 2 below this line *****
select 'Typical Student (student id ' || studentId || ') with cga ' || cga || ' has the highest CGA in the ' || departmentId || ' department'
from Student
where cga = (select max(cga) from Student where departmentId = 'COMP');


/* Query 3 */
select '--------------------------------------------------------------------------------------------------' from dual;
select 'Query 3: Find, for each course, the course id and the average cga of the students enrolled in the' || chr(10) ||
       '         course. Order the result by average cga descending.' from dual;
set heading on
-- ***** Construct Query 3 below this line *****
select courseId, trunc(avg(cga), 2) as "AVG CGA"
from EnrollsIn natural join Student
group by courseId
order by avg(cga) desc;


/* Query 4 */
set heading off
select '--------------------------------------------------------------------------------------------------' from dual;
select 'Query 4: Find, for each course, the course id, student last and first name, department id and cga of' || chr(10) ||
       '         the students who have the highest cga in the course. Order the result by course id ascending.' from dual;
set heading on
-- ***** Construct Query 4 below this line *****
select courseId, lastName, firstName, departmentId as "DEPA", cga
from (select courseId, max(cga) as cga from Student natural join EnrollsIn group by courseId) natural join Student;


/* Query 5 */
set heading off
select '--------------------------------------------------------------------------------------------------' from dual;
select 'Query 5: Find, for each student, the first name, last name, department id and the number of courses' || chr(10) ||
       '         in which the student is enrolled. Order the result first by the number of courses descending' || chr(10) ||
       '         and second by department id ascending.' from dual;
set heading on
-- ***** Construct Query 5 below this line *****
select firstName, lastName, departmentId as "DEAP", count(courseId) as "Number of courses"
from Student left join EnrollsIn on Student.studentId = EnrollsIn.studentId
group by firstName, lastName, departmentId
order by count(courseId) desc, departmentId asc;