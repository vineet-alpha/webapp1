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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace demoADO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string connectionString;

        SqlConnection con;

        SqlCommand cmd;

        DataTable table = new DataTable();
        public void Load()
        {
            DataTable table = new DataTable();
            connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            con = new SqlConnection(connectionString);

            cmd = new SqlCommand("Select * from ado", con);

            con.Open();
            SqlDataReader res = cmd.ExecuteReader();

            table.Load(res);//do this close res

            //Reading the data one by one
            //if (res.HasRows)
            //{
            //    res.Read();//gets first row
            //    MessageBox.Show("Total Rows:" + res[1]);//column index in the []
            //    res.Read();//gets second row
            //    res.Read();//Third row
            //    res.Read();//4th row
            //    res.Read();//5th row
            //    MessageBox.Show("Total Rows:" + res[1]);
            //    res.Close();
            //}

            //For not one by one:::Put Data in variable which works even after the connection has closed

            con.Close();

            MyGridTable.DataContext = table;



        }
        private void Window_Loaded(object sender, RoutedEventArgs e)//new even handler created
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            con = new SqlConnection(connectionString);

            cmd = new SqlCommand("Select * from ado", con);

            con.Open();
            SqlDataReader res = cmd.ExecuteReader();

             table.Load(res);//do this close res

            //Reading the data one by one
            //if (res.HasRows)
            //{
            //    res.Read();//gets first row
            //    MessageBox.Show("Total Rows:" + res[1]);//column index in the []
            //    res.Read();//gets second row
            //    res.Read();//Third row
            //    res.Read();//4th row
            //    res.Read();//5th row
            //    MessageBox.Show("Total Rows:" + res[1]);
            //    res.Close();
            //}

            //For not one by one:::Put Data in variable which works even after the connection has closed

            con.Close();

            MyGridTable.DataContext = table;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
           
            string ID;
            string NAME;

            
            ID = Txt2.Text;
            NAME = Txt3.Text;
            cmd = new SqlCommand("Insert into ado(id,name) values (@ID,@name)", con);
            
            cmd.Parameters.Add("@ID", ID);
            cmd.Parameters.Add("@name", NAME);
            cmd.ExecuteNonQuery();

            con.Close();
            
          Load();
        }

        private void Txt1_TextChanged(object sender, TextChangedEventArgs e)
        {
            int r = 4;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            con.Open();
            string id;
            id = Txt2.Text;

            cmd = new SqlCommand("Delete from ado where id=@id", con);
            cmd.Parameters.Add("@id", id);

            cmd.ExecuteNonQuery();
            con.Close();

            Load();


        }

        private void Txt2_TextChanged(object sender, TextChangedEventArgs e)
        {
            int x = 8;
        }
    }
}
