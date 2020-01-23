USE MachineProject;
# TCL
Commit;
Rollback;
# Select문
SELECT * FROM EMPLOYEES;
SELECT * FROM EMAILDOMAINS;
SELECT * FROM MACHINE;
SELECT * FROM PLISTBYMACHINE;
SELECT * FROM PRODUCTION;
SELECT * FROM PRODUCTIONLIST;
SELECT * FROM PRODUCTIONPLAN;
SELECT * FROM TODO;

COMMIT;

SELECT  EmployeeID, Email, Password, Name, Phone, ZipCode, Addr1, Addr2, Authority FROM EMPLOYEES;
SELECT  EmployeeID, Email, Password, Name, Phone, ZipCode, Addr1, Addr2, Authority FROM EMPLOYEES WHERE EmployeeID='10001';
SELECT EmployeeID, Email, Password, Name, Phone, ZipCode, Addr1, Addr2, Authority FROM EMPLOYEES WHERE Email='bhb0047@naver.co.kr'; 
SELECT DomainCode, Domain FROM EMAILDOMAINS ORDER BY DomainCode;
SELECT M.MachineID, M.isRunning, PL.ProductionID,PL.AmountPerDay FROM MACHINE M
	INNER JOIN PLISTBYMACHINE PL ON M.MachineID = PL.MachineID;
SELECT MachineID, isRunning FROM MACHINE;
SELECT MachineID, ProductionID, AmountPerDay FROM PLISTBYMACHINE;
SELECT TodoCode, MachineID, ProductionID, EmployeeID, TotalAmount FROM TODO;
SELECT ProductionPlanCode, ProductionID, TotalAmount FROM PRODUCTIONPLAN;
SELECT MachineID, ProductionID, AmountPerDay FROM PLISTBYMACHINE WHERE MachineID='20001' AND ProductionID = '30001'; 
SELECT ProductionPlanCode, ProductionID, TotalAmount, (TotalAmount - PlanedAmount) as LeftAmount, PlanedAmount FROM PRODUCTIONPLAN; 

SELECT  EmployeeID, Email, Password, Name, Phone, ZipCode, Addr1, Addr2, Authority FROM EMPLOYEES;

SELECT ProductionID, ProductionName FROM PRODUCTION;
SELECT MachineID, ProductionID, IFNULL(AmountPerDay, 0) as AmountPerDay FROM PLISTBYMACHINE; 
SELECT * FROM TODO;
SELECT ProductionPlanCode, ProductionID, TotalAmount, PlanedAmount FROM PRODUCTIONPLAN;
SELECT (TotalAmount - PlanedAmount) as LeftAmount FROM PRODUCTIONPLAN; 
SELECT isRunning FROM MACHINE WHERE MachineID = 20001;
SELECT isRunning FROM MACHINE;
SELECT MachineID, isRunning FROM MACHINE WHERE isRunning =1;

SELECT * FROM PRODUCTIONLIST;
SELECT * FROM PRODUCTIONLIST;
SELECT * FROM TODO;

SELECT MachineID, TodoCode, SUM(NormalAmount), SUM(DefectAmount) FROM PRODUCTIONLIST WHERE 1=0 
OR (MachineID = '20003' AND TodoCode = 6)
OR (MachineID = '20001' AND TodoCode = 3)
GROUP BY MachineID, TodoCode;

SELECT ProductionCode, MachineID, ProductionID, TodoCode, EmployeeID, NormalAmount, DefectAmount, ProductionDate FROM PRODUCTIONLIST WHERE 1=0 OR ( MachineID = '20001' AND TodoCode = 3)  GROUP BY MachineID, TodoCode ; 
SELECT MachineID, TodoCode, SUM(NormalAmount), SUM(DefectAmount) FROM PRODUCTIONLIST WHERE 1=0 OR ( MachineID = '20001' AND TodoCode = 3)  GROUP BY MachineID, TodoCode ; 
SELECT MachineID, TodoCode, SUM(NormalAmount), SUM(DefectAmount) FROM PRODUCTIONLIST WHERE 1=0 OR ( MachineID = '20001' AND TodoCode = 3)  GROUP BY MachineID, TodoCode ; 


SELECT MachineID, TodoCode, SUM(NormalAmount) TotalNomalAmount, SUM(DefectAmount) TotalDefectAmount, SUM(NormalAmount)+ SUM(DefectAmount) TotalAmount, SUM(DefectAmount)/(SUM(NormalAmount)+ SUM(DefectAmount)) AS DefectRate
FROM PRODUCTIONLIST WHERE 1=0 OR ( MachineID = '20001' AND TodoCode = 3) OR ( MachineID = '20003' AND TodoCode = 6)  GROUP BY MachineID, TodoCode;

SELECT stable.MachineID, stable.TodoCode, stable.TotalNomalAmount, stable.TotalDefectAmount, stable.TotalAmount, stable.TotalDefectAmount/  stable.TotalAmount as DefectRate
FROM (
SELECT MachineID, TodoCode, SUM(NormalAmount) TotalNomalAmount, SUM(DefectAmount) TotalDefectAmount, SUM(NormalAmount)+ SUM(DefectAmount) TotalAmount
FROM PRODUCTIONLIST WHERE 1=0 OR ( MachineID = '20001' AND TodoCode = 3) OR ( MachineID = '20003' AND TodoCode = 6)  GROUP BY MachineID, TodoCode 
) AS stable;

SELECT MachineID, TodoCode, SUM(NormalAmount), SUM(DefectAmount) FROM PRODUCTIONLIST WHERE 1=0 OR ( MachineID = '20001' AND TodoCode = 3) OR ( MachineID = '20003' AND TodoCode = 6)  GROUP BY MachineID, TodoCode ; 
SELECT MachineID, isRunning FROM MACHINE WHERE 1=1 AND MachineID = '20001' AND MachineID = '20002' AND MachineID = '20003' AND MachineID = '20004' AND MachineID = '20005' ; 
SELECT MachineID, isRunning, ifnull(runningTodo, ' ') runningTodo FROM MACHINE;
SELECT * FROM TODO;
UPDATE TODO SET Complete = 'Y', CompleteDate = now() WHERE TodoCode = 3; ROLLBACK;
# Insert문
# 사용자 : 10000대
# 기계 : 20000대
# 제품 : 30000대
INSERT INTO EMPLOYEES(EmployeeID, Email, Password, Name, Phone, ZipCode, Addr1, Addr2) VALUES('10001', 'bhb0047@gmail.com','tlsth9189', '신소연','01063055237','k0001','세웅빌딩','409호');
INSERT INTO EMPLOYEES(EmployeeID, Email, Password, Name, Phone, Authority) VALUES('00001', 'admin','1234', '관리자','00000000000', b'0010');
INSERT INTO EMPLOYEES(EmployeeID, Email, Password, Name, Phone, Authority) VALUES('00002', 'emp','1234', '사용자','00000000000', b'0001');
INSERT INTO EMPLOYEES(EmployeeID, Email, Password, Name, Phone, Authority) VALUES('00003', 'emp2','1234', '사용자','00000000000', b'0001'); commit;
INSERT INTO EMAILDOMAINS( DomainCode,Domain) VALUES(0, '직접입력');
INSERT INTO EMAILDOMAINS( DomainCode, Domain) VALUES(1, 'naver.com');
INSERT INTO EMAILDOMAINS( Domain) VALUES('gmail.com');
INSERT INTO EMAILDOMAINS( Domain) VALUES('nate.com');
INSERT INTO EMAILDOMAINS( Domain) VALUES('paran.com');
INSERT INTO EMAILDOMAINS( Domain) VALUES('hanmail.net');

INSERT INTO PRODUCTION(ProductionID, ProductionName) VALUES('30001','허니버터칩');
INSERT INTO PRODUCTION(ProductionID, ProductionName) VALUES('30002','다이제');
INSERT INTO PRODUCTION(ProductionID, ProductionName) VALUES('30003','포카칩');
INSERT INTO PRODUCTION(ProductionID, ProductionName) VALUES('30004','새우깡');
INSERT INTO PRODUCTION(ProductionID, ProductionName) VALUES('30005','마가렛트');
INSERT INTO PRODUCTION(ProductionID, ProductionName) VALUES('30006','콘초');
INSERT INTO PRODUCTION(ProductionID, ProductionName) VALUES('30007','초코파이');
INSERT INTO PRODUCTION(ProductionID, ProductionName) VALUES('30008','인디안밥');
INSERT INTO PRODUCTION(ProductionID, ProductionName) VALUES('30009','자갈치');
INSERT INTO PRODUCTION(ProductionID, ProductionName) VALUES('30010','신당동떡볶이');

INSERT INTO MACHINE(MachineID, isRunning) VALUES('20001',0);
INSERT INTO MACHINE(MachineID, isRunning) VALUES('20002',0);
INSERT INTO MACHINE(MachineID, isRunning) VALUES('20003',0);
INSERT INTO MACHINE(MachineID, isRunning) VALUES('20004',0);
INSERT INTO MACHINE(MachineID, isRunning) VALUES('20005',0);

INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20001','30001');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20001','30002');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20001','30003');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20002','30002');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20002','30003');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20002','30004');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20002','30005');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20003','30003');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20003','30006');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20003','30007');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20003','30008');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20004','30009');
INSERT INTO PLISTBYMACHINE(MachineID, ProductionID) VALUES('20005','30010');

INSERT INTO PRODUCTIONPLAN(ProductionID, TotalAmount) VALUES('30001',3000);
INSERT INTO PRODUCTIONPLAN(ProductionID, TotalAmount) VALUES('30002',2000);
INSERT INTO PRODUCTIONPLAN(ProductionID, TotalAmount) VALUES('30003',50000);
INSERT INTO PRODUCTIONPLAN(ProductionID, TotalAmount) VALUES('30002',1000);

INSERT INTO TODO(MachineID, ProductionID, EmployeeID, Amount) VALUES('20001','30001','00002', 3000);
INSERT INTO TODO(MachineID, ProductionID, EmployeeID, Amount) VALUES('20001','30001','00002', 3000);
INSERT INTO PRODUCTIONLIST(TodoCode, MachineID, ProductionID, EmployeeID, NormalAmount, DefectAmount, ProductionDate) 
VALUES
('20001', '30001', 3, '00002', 8, 2, NOW());
INSERT INTO PRODUCTIONLIST(TodoCode, MachineID, ProductionID, EmployeeID, NormalAmount, DefectAmount, ProductionDate) VALUES (3, '20001', '30003', '00002', 8, 2, '2019-11-06 14:37:31'),(3, '20001', '30003', '00002', 9, 1, '2019-11-06 14:37:36'),(3, '20001', '30003', '00002', 7, 3, '2019-11-06 14:37:41'),(3, '20001', '30003', '00002', 7, 3, '2019-11-06 14:37:46'),(3, '20001', '30003', '00002', 9, 1, '2019-11-06 14:37:51'),(3, '20001', '30003', '00002', 6, 4, '2019-11-06 14:37:56'),(3, '20001', '30003', '00002', 9, 1, '2019-11-06 14:38:01'),(6, '20003', '30003', '00002', 8, 2, '2019-11-06 14:37:32'),(6, '20003', '30003', '00002', 8, 2, '2019-11-06 14:37:37'),(6, '20003', '30003', '00002', 8, 2, '2019-11-06 14:37:42'),(6, '20003', '30003', '00002', 7, 3, '2019-11-06 14:37:47'),(6, '20003', '30003', '00002', 8, 2, '2019-11-06 14:37:52'),(6, '20003', '30003', '00002', 8, 2, '2019-11-06 14:37:57'),(6, '20003', '30003', '00002', 8, 2, '2019-11-06 14:38:02');
SELECT * FROM PRODUCTIONLIST;
# Delete문
DELETE FROM EMPLOYEES WHERE EmployeeID = '신소연';
DELETE FROM EMPLOYEES WHERE EmployeeID = '10001';
DELETE FROM EMAILDOMAINS WHERE DomainCode = 1;
DELETE FROM TODO WHERE TodoCode = 1;
# Update문
-- UPDATE EMPLOYEES SET `Password` = , `Name`, Phone = , Addr1 = , Addr2 =  WHERE EmployeeID = 10001;
UPDATE EMPLOYEES SET Authority = b'0010'  WHERE EmployeeID = 10001;
UPDATE PRODUCTIONPLAN SET PlanedAmount = 300 WHERE ProductionPlanCode = 1;
UPDATE TODO SET CompleteDate = now(), Complete = 'Y' WHERE TodoCode = 1;
UPDATE MACHINE SET isRunning = 0; commit; SELECT * FROM MACHINE;

UPDATE PLISTBYMACHINE SET AmountPerDay =330 WHERE ProductionID = 30003;
UPDATE PLISTBYMACHINE SET AmountPerDay =250 WHERE MachineID = '20003';
select * from PLISTBYMACHINE;

-- auto_increment 초기화
ALTER TABLE TODO AUTO_INCREMENT=1;
SET @COUNT = 0;
ALTER TABLE PRODUCTIONLIST AUTO_INCREMENT=1;
SET @COUNT = 0;

UPDATE TODO SET TodoCode = @COUNT:=@COUNT+1; -- 초기화 후 모든 칼럼 정상 설정
--
#TRUNCATE
TRUNCATE TABLE TODO;
TRUNCATE TABLE PRODUCTIONLIST; SELECT * FROM PRODUCTIONLIST;
# TCL
Commit;
Rollback;
