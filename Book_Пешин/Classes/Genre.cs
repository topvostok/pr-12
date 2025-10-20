using System.Collections.Generic;

namespace Book_Пешин.Classes
{
    public partial class Genre 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Genre(int Id, string name)
        {
            this.Id = Id;
            this.Name = name;
        }

        public static List<Genre> AllGenres()  
        {
            List<Genre> allGenres = new List<Genre>();
            allGenres.Add(new Genre(1, "Современная Русская Литература"));
            allGenres.Add(new Genre(2, "Современные Детективы"));  
            allGenres.Add(new Genre(3, "Любовное фэнтази")); 
            allGenres.Add(new Genre(4, "Попаданцы"));
            allGenres.Add(new Genre(5, "Юмористическое Фэнтази"));  

            return allGenres; 
        }
    }
}