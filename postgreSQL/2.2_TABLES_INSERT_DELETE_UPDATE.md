# Столбцы
Добавление нового столбца
```
ALTER TABLE Название_таблицы
ADD Название_столбца Тип(макс кол-во символов для ввода) [ограничения];
```
Удаление столбца
```
ALTER TABLE products DROP COLUMN название;
```
Переименование столбца
```
ALTER TABLE products RENAME COLUMN старое_название TO новое_название;
```
Изменение типа данных столбца
```
ALTER TABLE название_таблицы ALTER COLUMN стобец TYPE тип(макс кол-во символов для ввода);
```


<br>

# Добавить строку
Добавить строку в таблицу 
```
INSERT INTO Название_таблицы
(через_запятую_поля_которые_требуется_изменить)
VALUES (значения_полей),
(значения_полей),
(значения_полей);
```
Текстовые значение вводятся в одинарных ковычках (Пример: \`значение\`)

<br>

## Добавление записей из другой таблицы

С помощью запроса на добавление можно не только добавить в таблицу конкретные значения (список **VALUES**), но и записи из другой таблицы, отобранные с помощью запроса на выборку.  В этом случае вместо раздела **VALUES** записывается запрос на выборку, начинающийся с **SELECT**.  В нем можно использовать **WHERE**, **GROUP** **BY**, **ORDER BY**
```
INSERT INTO book (title, author, price, amount) 
SELECT title, author, price, amount 
FROM supply;

SELECT * FROM book;
```

<br>

## Добавление записей, вложенные запросы
**Пример:** Занести из таблицы supply в таблицу book только те книги, авторов которых нет в  book.

```
INSERT INTO book
(title, author, price, amount)
SELECT title, author, price, amount FROM supply
WHERE author NOT IN (SELECT author FROM book);
```







<br>

# Обновить данные
```
UPDATE Название_таблицы
SET price = 10
WHERE критерий строки;
```
Пример: **UPDATE products SET price = 10 WHERE price = 5;** -  увеличивает цену всех товаров, имевших до этого цену 5, до 10

Запросы на обновление нескольких столбцов
```
UPDATE таблица SET поле1 = выражение1, поле2 = выражение2
```


<br>

# Удаление строк из таблицы
Синтаксис:
```
DELETE FROM таблица
WHERE условие;
```
`DELETE FROM таблица;` - удалить все записи из таблицы









<br>

# Источники


https://postgrespro.ru/docs/postgresql/9.6/ddl-alter#ddl-alter-removing-a-column

https://postgrespro.ru/docs/postgrespro/9.5/ddl-constraints
