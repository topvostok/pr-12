
using Book_Пешин.Classes;
using System.Collections.Generic;

namespace Book_Пешин
{

    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Genre> Genres { get; set; }

        public List<Author> Authors { get; set; }

        /// <summary> Год издания </summary>
        public int Year { get; set; }

        /// <summary> Конструктор </summary>
        public Book(int id, string name, List<Genre> genres, List<Author> authors, int year)
        {
            this.Id = id;
            this.Name = name;
            this.Genres = genres;
            this.Authors = authors;
            this.Year = year;
        }

        /// <summary> Репозиторий книг </summary>
        public static List<Book> AllBooks()
        {
            // Создаём список
            List<Book> allBooks = new List<Book>();

            // Добавляем в список книги
            allBooks.Add(new Book(
                1, "Путешествие в Элевсии",
                Genre.AllGenres().FindAll(x => x.Id == 1),
                Author.AllAuthors().FindAll(x => x.Id == 1), 2023));

            allBooks.Add(new Book(
                2, "Чапаев и Пустота",
                Genre.AllGenres().FindAll(x => x.Id == 1),
                Author.AllAuthors().FindAll(x => x.Id == 1), 2008));

            allBooks.Add(new Book(
                3, "Дебютная постановка. Том 1",
                Genre.AllGenres().FindAll(x => x.Id == 2),
                Author.AllAuthors().FindAll(x => x.Id == 2), 2023));

            allBooks.Add(new Book(
                4, "Дебютная постановка. Том 2",
                Genre.AllGenres().FindAll(x => x.Id == 2),
                Author.AllAuthors().FindAll(x => x.Id == 2), 2023));

            allBooks.Add(new Book(
                5, "Охота на попаданку. Брахованная жена",
                Genre.AllGenres().FindAll(x => x.Id == 2 || x.Id == 3 || x.Id == 4),
                Author.AllAuthors().FindAll(x => x.Id == 3), 2022));

            // Возвращаем список
            return allBooks;
        }

        /// <summary> Список жанров через запятую </summary>
        public string ToGenres()
        {
            // Выходная строка
            string toGenres = "";

            // Перебираем жанры
            for (int iGenre = 0; iGenre < this.Genres.Count; iGenre++)
            {
                // Добавляем жанры в строку
                toGenres += this.Genres[iGenre].Name;

                // Добавляем запятую
                if (iGenre < this.Genres.Count - 1)
                    toGenres += ", ";
            }

            // Возвращаем результат
            return toGenres;
        }

        /// <summary> Список авторов через запятую </summary>
        public string ToAuthors()
        {
            // Выходная строка
            string toAuthors = "";

            // Перебираем авторов
            for (int iAuthor = 0; iAuthor < this.Authors.Count; iAuthor++)
            {
                // Добавляем авторов в строку
                toAuthors += this.Authors[iAuthor].FIO;

                // Добавляем запятую
                if (iAuthor < this.Authors.Count - 1)
                    toAuthors += ", ";
            }

            // Возвращаем авторов
            return toAuthors;
        }
    }
}