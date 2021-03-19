# EN SolutionToKasperskyTask
It`s a solution to Kaspersky test task.

If the console advised you to check this file to work with unsupported extension, here is s tutorial how to add handler for your extension.

1. Add your extension to list "SupportedExtions".
2. Create new class for your extension, like this below:

        class *your extension*Handler : AbstractFileHandler
    {
        protected override string ValidExtensionForMethod() => "*your extension*";
        protected override void DoSomeStuff(string fileName)
        {
            Console.WriteLine("*your extension* file handled");
            /* any needed processes*/
        }
    }
    
3. Add any needed processes where it is shown.
4. Enjoy!


# RU РешениеНаТестовоеЗаданиеКасперски
Это решение тестового задания от Лаборатории Касперского

Если консоль направила вас в этот файл для работы с неподдерживаемыми расширениями, ниже даны указания по добавлению обработчика для вашего расширения.

1. Добавьте ваше расширение в список "SupportedExtions".
2. Создайте новый класс для вашего расширения, следуя примеру из п.2 английской версии мануала.
3. Добавьте любые необходимые функции там где это показано в английской версии мануала.
4. Наслаждайтесь!
