using System.Collections.Generic;
using System.Linq;

namespace Book_Пешин.Classes
{
    public partial class Genre
    {
        private static List<Genre> _genres = new List<Genre>();

        public int Id { get; set; }
        public string Name { get; set; }

        public Genre(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary> Загрузка жанров из внешнего источника </summary>
        public static void LoadGenres(List<Genre> genres)
        {
            _genres = genres;
        }

        /// <summary> Получение всех жанров </summary>
        public static List<Genre> AllGenres()
        {
            if (!_genres.Any())
            {
                _genres = new List<Genre>
                {
                    new Genre(1, "Современная Русская Литература"),
                    new Genre(2, "Современные Детективы"),
                    new Genre(3, "Любовное фэнтази"),
                    new Genre(4, "Попаданцы"),
                    new Genre(5, "Юмористическое Фэнтази")
                };
            }
            return _genres;
        }
    }
}