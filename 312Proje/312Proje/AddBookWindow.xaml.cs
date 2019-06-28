using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using System.Windows.Shapes;

namespace _312Proje
{
   
    public partial class AddBookWindow : Window
    {
        SqlConnection sqlConn;
        public AddBookWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["_312Proje.Properties.Settings.PublisherDBConnectionString"].ConnectionString;
            
            sqlConn = new SqlConnection(connectionString);
        }

        private void AddBook(object sender, RoutedEventArgs e)
        {
            
            try
            {
                
                string query = "insert into Book values (@bname,@author,@price,@type,@stock,@puid)";

               
                var sqlCommand = new SqlCommand(query, sqlConn);
                sqlConn.Open();
              
                sqlCommand.Parameters.AddWithValue("@bname", kitapAdı_textbox.Text);
                sqlCommand.Parameters.AddWithValue("@author", yazar_textbox.Text);
                sqlCommand.Parameters.AddWithValue("@price", fiyat_textbox.Text);
                sqlCommand.Parameters.AddWithValue("@type", type_txt.Text);
                sqlCommand.Parameters.AddWithValue("@stock", stok_textbox.Text);
                sqlCommand.Parameters.AddWithValue("@puid", yayınevi_txt.Text);
                sqlCommand.ExecuteScalar();
                MessageBox.Show("Kitap Eklenmiştir");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConn.Close();
            }

        }
    }
}
