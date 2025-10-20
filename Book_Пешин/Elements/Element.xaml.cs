using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Book_Пешин.Classes;

namespace Book_Пешин.Elements
{
    /// <summary>
    /// Логика взаимодействия для Element.xaml
    /// </summary>
    public partial class Element : UserControl
    {
        public Element(Book book)
        {
            InitializeComponent();
            // В поле наименование прописываем данные
            tbName.Text = $"Наименование: {book.Name} ({book.Year} г.)";
            // В поле жанры прописываем данные
            tbGenre.Text = $"Жанр: {book.ToGenres()}";
            // В поле авторы прописываем данные
            tbAuthor.Text = $"Автор: {book.ToAuthors()}";
        }
    }
}