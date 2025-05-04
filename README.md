# Склад годноты

## Что такое годнота
 - это абсолютно любая строка
 - и два параметра: время создания годноты и количество запросов к годноте

## со скслад годготы можно производить действия:
 - добавить новый элемент
 - получить элемент по id
 - обновить элемент
 - удалить элемент

 - получить список элементов в проядке убывания "годности" (годность считается в CompareTo класса Element)
 - получить список элементов в проядке убывания близости к входной строке (основан на полнотекстовом поиске)

## простой способ запуска приложения (docker)

 - `git clone https://github.com/lehakurshev/AwesomeStorage.git`
 - `cd AwesomeStorage`
 - `docker-compose up --build`
 ![alt text](https://github.com/lehakurshev/AwesomeStorage/blob/main/png/1.png)

## можно и без docker
 - достаточно создать базу данных postgres с названием `awesomestorage` и запустить .net приложение в удобной для вас форме

## Резюме
 - комерческого опыта нет но мало ли)
 - https://docs.google.com/document/d/1zN3wrZQejVrxrYIYFrmMQY14hlwht86dAWhCRcQG_Vw/edit?usp=sharing

## TODO
- поизучать полнотекстовый поиск
- сделать операцию GetElementsWithContext производительнее и безопаснее