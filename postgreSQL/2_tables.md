
# Операции с таблицами

`\dt` - Список таблиц

`\d НАЗВАНИЕ` - информация о таблице

`ALTER TABLE старое_название RENAME TO новое_название;` - переименовывание таблицы

<br>

# Создание таблицы

```
CREATE TABLE название
(
    Имя поля тип(макс кол-во символов для ввода) [ограничения],
    Имя поля тип(макс кол-во символов для ввода) [ограничения],
    ...
    Имя поля тип(макс кол-во символов для ввода) [ограничения],
    [ограничения],
    [первичный ключ],
    [внешний ключ]
);
 ```
**PRIMARY KEY** - обязательное поле

**Пример**

```
CREATE TABLE movies(
    id integer primary key generated always as identity, // счетчик
    name CHARACTER VARYING(30) NOT NULL,
    price numeric(5, 2)
);
```
<br>

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
## Ограничения
Добавление ограничения
```
ALTER TABLE название_таблицы ADD CHECK (name <> '');
ALTER TABLE название_таблицы ADD CONSTRAINT some_name UNIQUE (столбец);
ALTER TABLE название_таблицы ADD FOREIGN KEY (product_group_id)
    REFERENCES product_groups;
```
`CHECK` - проверка условия, например (price > 0)

`CONSTRAINT` - присвоение ограничению отдельного имени, используется для вывода сообщений об ошибках и позволяет ссылаться на это имя при изменении ограничения (Пример: **CONSTRAINT positive_price CHECK (price > 0)**)

`UNIQUE` - уникальный параметр (имена в строках не повторяются)

Чтобы добавить ограничение NOT NULL, которое нельзя записать в виде ограничения таблицы:
```
ALTER TABLE products ALTER COLUMN столбец SET NOT NULL;
```
Удаление ограничения
```
ALTER TABLE таблица DROP CONSTRAINT ограничение;
```
Удаление ограничения NOT NULL
```
ALTER TABLE таблица ALTER COLUMN столбец DROP NOT NULL;
```
Назначить столбцу новое значение по умолчанию
```
ALTER TABLE название_таблицы ALTER COLUMN столбец SET DEFAULT 7.77;
```
Удалить значение по умолчанию
```
ALTER TABLE название_таблицы ALTER COLUMN столбец DROP DEFAULT;
```
<br>

# Данные в таблице
Добавить строку в таблицу 
```
INSERT INTO Название_таблицы
(через_запятую_поля_которые_требуется_изменить)
VALUES (значения_полей),
(значения_полей),
(значения_полей);
```
Текстовые значение вводятся в одинарных ковычках (Пример: \`значение\`)
## Изменить данные
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

# Добавление записей из другой таблицы

С помощью запроса на добавление можно не только добавить в таблицу конкретные значения (список **VALUES**), но и записи из другой таблицы, отобранные с помощью запроса на выборку.  В этом случае вместо раздела **VALUES** записывается запрос на выборку, начинающийся с **SELECT**.  В нем можно использовать **WHERE**, **GROUP** **BY**, **ORDER BY**
```
INSERT INTO book (title, author, price, amount) 
SELECT title, author, price, amount 
FROM supply;

SELECT * FROM book;
```
<br>

# Добавление записей, вложенные запросы
**Пример:** Занести из таблицы supply в таблицу book только те книги, авторов которых нет в  book.

```
INSERT INTO book
(title, author, price, amount)
SELECT title, author, price, amount FROM supply
WHERE author NOT IN (SELECT author FROM book);
```

<br>

# Источники


https://postgrespro.ru/docs/postgresql/9.6/ddl-alter#ddl-alter-removing-a-column

https://postgrespro.ru/docs/postgrespro/9.5/ddl-constraints
