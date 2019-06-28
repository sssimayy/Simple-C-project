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
using System.Windows.Shapes;

namespace _312Proje
{
    
    public partial class UpdateBookWindow : Window
    {
        SqlConnection sqlConn;
        public UpdateBookWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["_312Proje.Properties.Settings.PublisherDBConnectionString"].ConnectionString;
            
            sqlConn = new SqlConnection(connectionString);
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update Book set book_stock=@stock, book_price=@price where book_Id=@id";
               
                var sqlCommand = new SqlCommand(query, sqlConn);
                sqlConn.Open();
                
                sqlCommand.Parameters.AddWithValue("@id", kitapAdi_txt.Text);
                sqlCommand.Parameters.AddWithValue("@price", Fiyattextbox.Text);
                sqlCommand.Parameters.AddWithValue("@stock", Stoktextbox.Text);
               
                sqlCommand.ExecuteScalar();
                MessageBox.Show("Kitap Güncellenmiştir");
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
