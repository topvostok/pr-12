using System.Collections.Generic;
using System.Linq;

namespace Book_Пешин.Classes
{
    public class Author
    {
        private static List<Author> _authors = new List<Author>();

        public int Id { get; set; }
        public string FIO { get; set; }

        public Author(int id, string fio)
        {
            this.Id = id;
            this.FIO = fio;
        }

        /// <summary> Загрузка авторов из внешнего источника </summary>
        public static void LoadAuthors(List<Author> authors)
        {
            _authors = authors;
        }

        /// <summary> Репозиторий авторов </summary>
        public static List<Author> AllAuthors()
        {
            if (!_authors.Any())
            {
                _authors = new List<Author>
                {
                    new Author(1, "Виктор Пелевин"),
                    new Author(2, "Александра Маринина"),
                    new Author(3, "Ольга Герр")
                };
            }
            return _authors;
        }
    }
}