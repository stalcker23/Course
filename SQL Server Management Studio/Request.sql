USE [Hotel]
GO
SELECT * INTO T1 FROM Client;
SELECT * INTO T2 FROM Reserve;
INSERT INTO T1(id_client,FIO,pasport) 
VALUES

(1,'Акимов Андрей Николаевич',4365575765),
(8,'Мартьянов Артур Викторович',2343345425),
(9,'Мартьянова Татьяна Алексндровна',4656323535)

SELECT * FROM 
T1 INNER JOIN Client
ON T1.id_client=Client.id_client 

SELECT * FROM
T1 LEFT JOIN CLIENT
ON T1.id_client=Client.id_client 

SELECT * FROM
T1 RIGHT JOIN CLIENT
ON T1.id_client=Client.id_client 

SELECT * FROM
T1 FULL OUTER JOIN CLIENT
ON T1.id_client=Client.id_client

/*EXISTS Возвращает значение TRUE, если вложенный запрос содержит хотя бы одну строку.*/

SELECT A.id_client
FROM T1 AS A
WHERE EXISTS
(SELECT * FROM
 Category AS B
 WHERE A.id_client = B.id_category
 AND A.id_client = '1');

 /*IN Определяет, совпадает ли указанное значение с одним из значений, содержащихся во вложенном запросе или списке.*/
SELECT A.FIO
FROM T1 AS A
WHERE A.id_client IN
(SELECT A.id_client FROM
 Category AS B
 WHERE A.id_client = B.id_category
 AND A.id_client = '1');

 /*ANY/SOME Сравнивает скалярное значение с набором значений, состоящим из одного столбца. Ключевые слова SOME и ANY эквивалентны.*/
IF 0 < ANY (SELECT pasport FROM T1)
PRINT 'TRUE' 
ELSE
PRINT 'FALSE';

/*ALL Сравнивает скалярное значение с набором значений, состоящим из одного столбца.*/
IF 0 < ALL (SELECT id_client FROM T1)
PRINT 'TRUE' 
ELSE
PRINT 'FALSE';

/*BETWEEN Определяет диапазон для проверки*/
SELECT A.FIO
FROM T1 AS A
WHERE A.id_client BETWEEN 0 AND 4;

/*LIKE Определяет, совпадает ли указанная символьная строка с заданным шаблоном*/
SELECT A.FIO
FROM T1 AS A
WHERE A.FIO LIKE 'Акимов Артемий Андреевич';

/*Инструкция CASE последовательно оценивает свои условия и останавливается, когда находит первое условие, удовлетворяющее ей.*/

SELECT FIO, pasport, "id_client" =
      CASE id_client
         WHEN  1 THEN '1'
         WHEN 2 THEN '2'
         WHEN 3 THEN '3'
         WHEN 4 THEN '4'
		 WHEN 5 THEN '5'
         ELSE 'Неизвестный клиент'
      END
FROM T1;

/*CAST/CONVERT Преобразует выражение одного типа данных в другой*/
SELECT
GETDATE() AS UnconvertedDateTime,
CAST(GETDATE() AS nvarchar(30)) AS UsingCast,
CONVERT(nvarchar(30), GETDATE(), 126) AS UsingConvertTo_ISO8601;
/*IS NULL IS NOT NULL Определяет, может ли указанное выражение быть NULL.*/

SELECT FIO
FROM T1
WHERE FIO IS NULL;

SELECT FIO
FROM T1
WHERE FIO IS NOT NULL;

/*COALESCE Вычисляет аргументы в указанном порядке и возвращает текущее значение первого из выражений, которое изначально не дает значение NULL.*/
SELECT FIO, pasport, id_client,
COALESCE(FIO, passport) AS FirstNotNull
FROM T1;

/*IIF возвращает одно из двух значений в зависимости от того, принимает логическое выражение значение true или false.*/
DECLARE @a int = 45, @b int = 40;
SELECT IIF ( @a > @b, 'TRUE', 'FALSE' ) AS Result;

/*REPLACE Заменяет все вхождения указанного строкового значения другим строковым значением.*/
SELECT REPLACE('Василий', 'а', '1');

/*SUBSTRING Возвращает часть символьного, двоичного, текстового или графического выражения*/
SELECT FIO, SUBSTRING(FIO, 1, 4) AS Prefix
FROM T1;

/*STR Возвращает символьные данные, преобразованные из числовых данных.*/
SELECT STR(123.45, 6, 1);

/*Функция STUFF вставляет одну строку в другую. Она удаляет указанное количество символов первой строки в начальной позиции и вставляет на их место вторую строку.*/
SELECT STUFF('abcdef', 2, 3, 'ijklmn');

/*UPPER*/
SELECT UPPER(RTRIM(FIO)) + ', ' + FIO AS Name
FROM T1;

/*DATEPART Возвращает целое число, представляющее указанный компонент datepart указанной даты date.*/
 SELECT A.date_begin, DATEPART(year, A.date_begin) AS YearStop
FROM T2 AS A;

/*datetimeoffset Определяет дату, объединенную со временем дня, с учетом часового пояса в 24-часовом формате.*/
SELECT 
CAST('2007-05-08 12:35:29. 1234567 +12:15' AS time(7)) AS 'time', 
CAST('2007-05-08 12:35:29. 1234567 +12:15' AS date) AS 'date',
CAST('2007-05-08 12:35:29.123' AS smalldatetime) AS 'smalldatetime', 
CAST('2007-05-08 12:35:29.123' AS datetime) AS 'datetime', 
CAST('2007-05-08 12:35:29.1234567+12:15' AS datetime2(7)) AS 'datetime2',
CAST('2007-05-08 12:35:29.1234567 +12:15' AS datetimeoffset(7)) AS 'datetimeoffset',
CAST('2007-05-08 12:35:29.1234567+12:15' AS datetimeoffset(7)) AS'datetimeoffset IS08601';


INSERT INTO T2(id_reserve, id_client, id_category, date_begin, date_end)
VALUES ('2','2','1', GETDATE(), '20/09/2016');
SELECT id_reserve, id_category
FROM T2 
GROUP BY id_reserve, id_category;

SELECT id_room AS tax_room,id_category,status
FROM HotelRoom
HAVING tax_room > 50;