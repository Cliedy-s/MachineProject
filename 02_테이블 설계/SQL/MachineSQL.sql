USE MACHINEPROJECTDB;

select * from employees;
select * from machine;
select * from  plistbymachine;
select * from  production;
select * from productionlist;
select * from productionplan;
select * from todo;

ALTER TABLE employees DROP COLUMN Addr;
ALTER TABLE employees ADD COLUMN ( Addr2 varchar(50));

ALTER TABLE TODO DROP FOREIGN KEY  `fk_employees_todo_employeeid`;			

ALTER TABLE PRODUCTIONLIST DROP FOREIGN KEY  `fk_employees_productionlist_employeeid`;					
ALTER TABLE PRODUCTIONLIST DROP FOREIGN KEY  `fk_todo_productionlist_todocode`;						

ALTER TABLE PLISTBYMACHINE DROP FOREIGN KEY  `fk_machine_plistbymachine_machineid`;					
ALTER TABLE PLISTBYMACHINE DROP FOREIGN KEY  `fk_production_plistbymachine_productionid`;					

ALTER TABLE PRODUCTIONPLAN DROP FOREIGN KEY  `fk_production_productionplan_productionid`;					












