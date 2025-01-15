insert into Student values ('22330034','Jinhai','Hu','hujh53','00000000',null,'COMP','2022');

insert into EnrollsIn values ('22330034','COMP3311',97.6);
insert into EnrollsIn values ('22330034','COMP4021',88.3);
insert into EnrollsIn values ('22330034','ELEC3100',95.1);
insert into EnrollsIn values ('22330034','HUMA1020',89.4);
insert into EnrollsIn values ('22330034','MATH2421',92.5);

create unique index EmailNameIndex on Student(email);