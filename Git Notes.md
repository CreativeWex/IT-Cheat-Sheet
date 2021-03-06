***Git*** — система управления версиями с распределенной архитектурой. Применяется для управления версиями в рамках колоссального количества проектов по разработке ПО, как коммерческих, так и с открытым исходным кодом. Позволяет всем разработчикам хранить историю изменений в полном объеме.

Имеет древовидную структуру, где каждая ветка соответствует версии (много версий = много веток). Ветки можно совмещать, изменять и тд, подробнее в соответствующем разделе.

<br>

## 0. Инициализация
`git init` - инициализация git, создает скрытую папку .git, которая будет хранить техническую информацию

<br>

## 1. Внесение изменений 
`git status` - информация по гиту: текущая ветка, прикрепленные файлы, тут отображаются все изменения

`git add название_файла` - добавить новую версию файла

`git add .` - обновить версии всех файлов в директории

`git rm --cashed название_файла` - перестать отслеживать файл 

<br>

## 2. Коммит
***Коммит*** - фиксирование версии для дальнейшей работы/отправки.

С помощью коммитов можно откатывать изменения/возвращаться к определенным этапам разработки.


`git commit -m "название_коммита"` - создание коммита с заданным названием

Для того, чтобы некоторые файлы не попадали в коммит, используется специальный файл ***.gitignore***, в который записываются файлы и директории, которые будут гитом игнорироваться.

`git log` - лог коммитов
<br>

Классная статья про .gitignore https://tyapk.ru/blog/post/gitignore

<br>

## Ветки
`git branch` - просмотреть текущую ветку.

`git branch название_ветки` - создать ветку

`git branch -D название_ветки` - удалить ветку

`git checkout название_ветки` - переключиться на ветку

`git checkout -b название_ветки` - создать новую ветку и сразу же на нее переключаться.

<br>

Чтобы совместить ветки, нужно переключиться на ту ветку, которую будем совмещать
`git merge ветка_с_которой_будем_совмещать` - совместить ветки

<br>

## GitHub

`--global user.name` - просмотр имени автора коммитов

`--global user.email` - почта

`git remote add origin адресс` -  привязка удаленного репозитория к локальному

`git push -u origin master` - залить ветку

`git clone адрес` - скачать ветку
 
`` - 
`` - 
`` - 
`` - 
`` - 
`` - 
`` - 

## Полезные ссылки

Git и GitHub Курс Для Новичков https://www.youtube.com/watch?v=zZBiln_2FhM&t=1688s

О файле .gitignore https://tyapk.ru/blog/post/gitignore

https://coderoad.ru/13040958/Слияние-двух-репозиториев-Git-без-нарушения-истории-файлов