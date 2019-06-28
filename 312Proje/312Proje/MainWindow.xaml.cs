using System.Windows;

namespace _312Proje
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {


            string username = Username.Text.ToString();
            //string pass = Pass.ToString();

            if (Pass.Password.Equals("asd"))
            {
                MessageBox.Show("Login successful");
                SearchWindow win2 = new SearchWindow();
                win2.Show();
                this.Close();
            }
            else
                MessageBox.Show("Wrong Password");
        }
    }
}
