using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Book_Пешин.Classes;
using Book_Пешин.Elements;

namespace Book_Пешин
{
    public partial class MainWindow : Window
    {
        /// <summary> Все авторы </summary>
        List<Author> AllAuthors = Author.AllAuthors();

        /// <summary> Все жанры </summary>
        List<Genre> AllGenres = Genre.AllGenres();

        /// <summary> Все книги </summary>
        List<Book> AllBooks = Book.AllBooks();

        public MainWindow()
        {
            InitializeComponent();
            AddAuthors();
            AddGenres();
            AddYears();
            CreateUI(AllBooks);
        }

        /// <summary> Метод добавления авторов в выпадающий список </summary>
        public void AddAuthors()
        {
            cbAuthors.Items.Clear();
            cbAuthors.Items.Add("Выберите ...");
            foreach (Author author in AllAuthors)
                cbAuthors.Items.Add(author.FIO);
            cbAuthors.SelectedIndex = 0;
        }

        /// <summary> Метод добавления жанров в выпадающий список </summary>
        public void AddGenres()
        {
            cbGenres.Items.Clear();
            cbGenres.Items.Add("Выберите ...");
            foreach (Genre genre in AllGenres)
                cbGenres.Items.Add(genre.Name);
            cbGenres.SelectedIndex = 0;
        }

        /// <summary> Метод добавления годов </summary>
        public void AddYears()
        {
            cbYear.Items.Clear();
            cbYear.Items.Add("Выберите ...");
            List<int> AllYears = new List<int>();
            foreach (Book book in AllBooks)
                if (!AllYears.Contains(book.Year))
                {
                    AllYears.Add(book.Year);
                    cbYear.Items.Add(book.Year);
                }
            cbYear.SelectedIndex = 0;
        }

        /// <summary> Метод создания книг </summary>
        public void CreateUI(List<Book> books)
        {
            spBooks.Children.Clear();
            foreach (Book book in books)
                spBooks.Children.Add(new Element(book));
        }

        private void Search_Book(object sender, KeyEventArgs e) => Search();

        private void SelectionChanged(object sender, SelectionChangedEventArgs e) => Search();

        /// <summary> Метод поиска и сортировки </summary>
        public void Search()
        {
            List<Book> FindBook = AllBooks.FindAll(x =>
                x.Name.ToLower().Contains(tbSearch.Text.ToLower()));

            if (cbAuthors.SelectedIndex > 0)
            {
                Author SelectAuthor = AllAuthors.Find(x =>
                    x.FIO == cbAuthors.SelectedItem.ToString());
                FindBook = FindBook.FindAll(x =>
                    x.Authors.Find(y => y.Id == SelectAuthor.Id) != null);
            }

            if (cbGenres.SelectedIndex > 0)
            {
                Genre SelectGenre = AllGenres.Find(x =>
                    x.Name == cbGenres.SelectedItem.ToString());
                FindBook = FindBook.FindAll(x =>
                    x.Genres.Find(y => y.Id == SelectGenre.Id) != null);
            }

            if (cbYear.SelectedIndex > 0)
            {
                FindBook = FindBook.FindAll(x =>
                    x.Year == Convert.ToInt32(cbYear.SelectedItem.ToString()));
            }

            CreateUI(FindBook);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DataService dataService = new DataService();
            dataService.SaveToFile();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            DataService dataService = new DataService();
            dataService.LoadFromFile();

            // Обновление данных после загрузки
            AllAuthors = Author.AllAuthors();
            AllGenres = Genre.AllGenres();
            AllBooks = Book.AllBooks();

            // Обновление интерфейса
            AddAuthors();
            AddGenres();
            AddYears();
            CreateUI(AllBooks);
        }
    }
}