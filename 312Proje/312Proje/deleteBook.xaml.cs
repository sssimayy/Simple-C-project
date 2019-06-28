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
    
    public partial class deleteBook : Window
    {

        SqlConnection sqlConn;
        public deleteBook()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["_312Proje.Properties.Settings.PublisherDBConnectionString"].ConnectionString;
            
            sqlConn = new SqlConnection(connectionString);
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Book where book_Id=@bid";
               
                var sqlDataAdapter = new SqlDataAdapter(query, sqlConn);
                var sqlCommand = new SqlCommand(query, sqlConn);
                sqlConn.Open();
                
                sqlCommand.Parameters.AddWithValue("@bid", kitapID_txt.Text);
                
                sqlCommand.ExecuteScalar();
                MessageBox.Show("Kitap Silinmiştir");
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
