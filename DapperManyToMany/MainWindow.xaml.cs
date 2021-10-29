using Dapper;
using DapperManyToMany.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace DapperManyToMany
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var conn=new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                var sql = @"select A.AuthorId,A.Firstname,A.Lastname,B.BookId,
                          B.Title,B.Price
                          from Authors as A
                          inner join AuthorAndBooks as AB on AB.AuthorId=A.AuthorId
                          inner join Books as B on B.BookId=AB.BookId";

                var authors = conn.Query<Author, Book, Author>(sql,
                    (a, b) =>
                    {
                        a.Books.Add(b);
                        b.Authors.Add(a);
                        return a;
                    },splitOn:"BookId").ToList();
                myGrid.ItemsSource = authors;
            }
        }
    }
}
