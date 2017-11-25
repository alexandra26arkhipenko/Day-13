# Day-13
1. Разработать обобщенный класс-коллекцию Queue, реализующий основные операции для работы с очередью, и предоставляющий возможность итерирования, реализовав итератор «вручную» (без использования блок-итератора yield). Протестировать методы разработанного класса.

2. Создать обобщенные классы для представления квадратной, симметрической и диагональной матриц (симметрическая матрица – это квадратная матрица, которая совпадает с транспонированной к ней; диагональная матрица – это квадратная матрица, у которой элементы вне главной диагонали заведомо имеют значения по умолчанию типа элемента). Описать в созданных классах событие, которое происходит при изменении элемента матрицы с индексами (i, j).  Расширить функциональность существующей иерархии классов, добавив возможность операции сложения двух матриц любого типа. Разработать unit-тесты.
3. Разработать обобщенный класс-коллекцию BinarySearchTree (бинарное дерево поиска). Предусмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): для реализации использовать блок-итератор (yield). Протестировать разработанный класс, используя следующие типы:
- System.Int32 (использовать сравнение по умолчанию и подключаемый компаратор); 
- System.String (использовать сравнение по умолчанию и подключаемый компаратор); 
- пользовательский класс Book, для объектов которого реализовано отношения порядка (использовать сравнение по умолчанию и подключаемый компаратор); 
- пользовательскую структуру Point, для объектов которого не реализовано отношения порядка (использовать подключаемый компаратор).
