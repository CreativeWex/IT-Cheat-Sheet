# Типы данных
## I. Целочисленные
- smallint
- integer
- bigint
### C фиксированной точностью знаков
- numeric
- decimal.

Используются для точных вычислений, имеют общий синтаксис
```
numeric(кол-во цифр в числе, кол-во цифр после запятой)

decimal(кол-во цифр в числе, кол-во цифр после запятой)
```
### С плавающей точкой
- real
- double
- float

<br>

---
## II. Символьные

- character(n) - `char` - дополняет до n пробелами
- character varying(n) - `varchar` - не дополняет
- `text` - не имеет ограничений

Параметр n отвечает за макс. количество символов в поле

<br>

---

## III. Типы "дата/время"
- date(yyyy-mm-dd)
```
SELECT 'Sep 12, 2016'::date;
```
```
SELECT '21:15:(опционально секунды)'::time;
```

---

<br>

## IV. Логический тип boolean
- Истина: TRUE, 't','true', 'y', 'yes', 'on', '1'.
- Ложь: FALSE, 'f', 'false', 'n', 'no', 'off', '0'.

---

<br>

## V. Массивы

Для объявления массива к имени типа нужно добавить квадртные скобки, указывать число элементов не обязательно.

`schedule integer[]` - пример объявления

`{1, 2, 3, 4, 5, 6}` - присвоение значения

<br>

### Основные операции

Добавление значения с помощью `конкатенации`
```
UPDATE pilots
SET schedule = schedule || 7
WHERE pilot_name = 'Boris';
```

<br>

Добавление значения в конец списка с помощью ф-ии `array_append`

```
UPDATE pilots
SET schedule = array_prepend( 1, schedule )
WHERE pilot_name = 'Pavel';
```

<br>

Добавление значения в конец списка с помощью ф-ии `array_prepend`

```
UPDATE pilots
SET schedule = array_prepend( 1, schedule )
WHERE pilot_name = 'Pavel';
```

<br>

Удаление элемента массива с помощью ф-ии `array_remove`

```
UPDATE pilots
SET schedule = array_remove( schedule, 5 )
WHERE pilot_name = 'Ivan';
```

<br>

Обащение к элементам массива `по индексам`

```
UPDATE pilots
SET schedule[ 1 ] = 2, schedule[ 2 ] = 3
WHERE pilot_name = 'Petr';
```