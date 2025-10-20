using System.Collections.Generic;

namespace Book_Oshchepkov.Classes
{
    public class Author
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
            // Создаём список авторов
            List<Author> allAuthors = new List<Author>();

            // Заполняем список
            allAuthors.Add(new Author(1, "Виктор Пелевин"));
            allAuthors.Add(new Author(2, "Александра Маринина"));
            allAuthors.Add(new Author(3, "Ольга Герр"));

            // Возвращаем список
            return allAuthors;
        }
    }
}