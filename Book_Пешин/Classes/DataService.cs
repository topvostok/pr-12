using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;

namespace Book_Пешин.Classes
{
    public class DataService
    {
        private const string BooksFile = "books.xml";
        private const string AuthorsFile = "authors.xml";
        private const string GenresFile = "genres.xml";

        /// <summary> Сохранение данных в файлы XML </summary>
        public void SaveToFile()
        {
            try
            {
                // Сохранение книг
                var books = Book.AllBooks();
                SaveToXml(books, BooksFile);

                // Сохранение авторов
                var authors = Author.AllAuthors();
                SaveToXml(authors, AuthorsFile);

                // Сохранение жанров
                var genres = Genre.AllGenres();
                SaveToXml(genres, GenresFile);

                MessageBox.Show("Данные успешно сохранены в файлы!", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary> Загрузка данных из файлов XML </summary>
        public void LoadFromFile()
        {
            try
            {
                // Загрузка авторов
                if (File.Exists(AuthorsFile))
                {
                    var loadedAuthors = LoadFromXml<List<Author>>(AuthorsFile);
                    if (loadedAuthors != null && loadedAuthors.Any())
                    {
                        Author.LoadAuthors(loadedAuthors);
                    }
                }

                // Загрузка жанров
                if (File.Exists(GenresFile))
                {
                    var loadedGenres = LoadFromXml<List<Genre>>(GenresFile);
                    if (loadedGenres != null && loadedGenres.Any())
                    {
                        Genre.LoadGenres(loadedGenres);
                    }
                }

                // Загрузка книг
                if (File.Exists(BooksFile))
                {
                    var loadedBooks = LoadFromXml<List<Book>>(BooksFile);
                    if (loadedBooks != null && loadedBooks.Any())
                    {
                        Book.LoadBooks(loadedBooks);
                    }
                }

                MessageBox.Show("Данные успешно загружены из файлов!", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveToXml<T>(T obj, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(stream, obj);
            }
        }

        private T LoadFromXml<T>(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(filename, FileMode.Open))
            {
                return (T)serializer.Deserialize(stream);
            }
        }
    }
}