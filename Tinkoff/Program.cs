using System;
using System.Collections.Generic;

namespace Tinkoff
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkArea workArea = new WorkArea();

            workArea.Run();
        }
    }

    class WorkArea
    {
        private Library _library = new Library();

        public void Run()
        {
            bool isWork = true;
            string enterValue = String.Empty;

            int value;

            while (isWork)
            {
                Console.WriteLine("1 - Вывести колво книг\n2-Добавить книгу\n3-Удалить книгу\n4-Выйти");

                if (int.TryParse(enterValue, out value))
                {
                    switch (value)
                    {
                        case 1:
                            _library.Information();
                            break;
                        case 2:
                            _library.Add();
                            break;
                        case 3:
                            _library.Remove();
                            break;
                        case 4:
                            isWork = false;
                            break;
                        default:
                            Console.WriteLine("Такого значения не существует");
                            break;
                    }
                }
            }
        }
    }

    class Library
    {
        private List<Book> _books = new List<Book>() { new Book("Война и мир", "Толстой", 1900, 300)
        , new Book("Капитанская дочка", "Пушкин", 1800, 100)
        , new Book("Есенин", "Черный человек", 1923, 200) };

        private int GetCorrectValue(string enterInfo)
        {
            bool isCorrectValue = false;
            int value;

            while (isCorrectValue == false)
            {
                enterInfo = Console.ReadLine();

                if (int.TryParse(enterInfo, out value))
                {
                    isCorrectValue = true;
                    return value;
                }
                else
                {
                    Console.WriteLine("Вы ввели неправильное значение. Попробуйте снова!");
                }
            }

            return 0;
        }

        public void Add()
        {
            int releaseDate = 0, pagesAmount = 0;
            string enterInfo = String.Empty;

            string name, author;

            Console.WriteLine("Введите имя автора,название книги, год выпуска и колво страниц");

            name = Console.ReadLine();
            author = Console.ReadLine();

            releaseDate = GetCorrectValue(enterInfo);
            pagesAmount = GetCorrectValue(enterInfo);

            _books.Add(new Book(name, author, releaseDate, pagesAmount));
        }

        public void Remove()
        {
            int value;
            string enterValue = String.Empty;

            Information();

            Console.WriteLine("Введите номер книги по списку,который вы хотите удалить");

            value = GetCorrectValue(enterValue);

            _books.RemoveAt(value - 1);
        }

        public void Information()
        {
            for (int i = 0; i < _books.Count; i++)
            {
                Console.Write($"{i + 1} - ");
                _books[i].Information();
            }
        }
    }

    class Book
    {
        private string _name;
        private string _author;

        private int _releaseDate;
        private int _pagesAmount;

        public Book(string name, string author, int releaseDate, int pagesAmount)
        {
            _name = name;
            _author = author;
            _releaseDate = releaseDate;
            _pagesAmount = pagesAmount;
        }

        public void Information()
        {
            Console.WriteLine($"{_name} - {_author} - {_releaseDate} - {_pagesAmount}");
        }
    }
}
