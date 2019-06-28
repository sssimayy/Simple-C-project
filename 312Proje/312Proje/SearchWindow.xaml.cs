using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace _312Proje
{
    /// <summary>
    /// SearchWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class SearchWindow : Window
    {
        SqlConnection sqlConn;
        public SearchWindow()
        {
            InitializeComponent();
            
          
            string connectionString = ConfigurationManager.ConnectionStrings["_312Proje.Properties.Settings.PublisherDBConnectionString"].ConnectionString;
            //string p;
            sqlConn = new SqlConnection(connectionString);
            showPublisherList();
            // showBookList();
        }
        private void showPublisherList()
        {
            try
            {
                string query = "select * from Publisher";
                //string query = "select publisher_name from Publisher where publisher_id=@pid";
                var sqlDataAdapter = new SqlDataAdapter(query, sqlConn);
                var sqlCommand= new SqlCommand(query, sqlConn);
                using (sqlDataAdapter)
                {
                
                    DataTable publisherTable = new DataTable();
                    sqlDataAdapter.Fill(publisherTable);
                    PublisherList.DisplayMemberPath = "publisher_name";
                    PublisherList.SelectedValuePath = "publisher_Id";
                    PublisherList.ItemsSource = publisherTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

       


        private void Exit_Event(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {

            AddBookWindow addBook = new AddBookWindow();
            addBook.Show();
        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            UpdateBookWindow updateBook= new UpdateBookWindow();
            updateBook.Show();
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            deleteBook deleteBook =new deleteBook();
            deleteBook.Show();
        }

        private void KitapGoster_Click(object sender, RoutedEventArgs e)
        {
            Book kitap= new Book();
           
            //MessageBox.Show(PublisherList.SelectedValue.ToString());


            try
            {
               // int p_id = Convert.ToInt32(PublisherList.SelectedValue.ToString());
                string query = "select * from Book where book_publisher=@pid";
                //string query = "select publisher_name from Publisher where publisher_id=@pid";
                var sqlDataAdapter = new SqlDataAdapter(query, sqlConn);
                var sqlCommand = new SqlCommand(query, sqlConn);
                //sqlCommand.Parameters.AddWithValue("@pid", p_id);
                //*sqlCommand.ExecuteScalar();
                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@pid", PublisherList.SelectedValue);
                    //MessageBox.Show();
                    DataTable bookTable = new DataTable();
                    sqlDataAdapter.Fill(bookTable);
                    BookList.DisplayMemberPath = "book_name";
                    BookList.SelectedValuePath = "book_Id";
                    BookList.ItemsSource = bookTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
