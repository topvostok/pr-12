using System.Collections.Generic;

namespace Book_Пешин.Classes
{
    public class Author  // Добавлен public
    {
        public int Id { get; set; }
        public string FIO { get; set; }

        public Author(int id, string fio)
        {
            this.Id = id;
            this.FIO = fio;
        }

        public static List<Author> AllAuthors()
        {
            List<Author> allAuthors = new List<Author>();
            allAuthors.Add(new Author(1, "Виктор Пелевин"));
            allAuthors.Add(new Author(2, "Александра Маринина"));
            allAuthors.Add(new Author(3, "Ольга Герр"));
            return allAuthors;
        }
    }
}