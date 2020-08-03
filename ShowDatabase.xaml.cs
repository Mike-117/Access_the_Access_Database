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
using System.Data.OleDb;
using System.Configuration;
using System.Xml;

namespace Access_the_Access_Database
{
    /// <summary>
    /// Interaction logic for ShowDatabase.xaml
    /// </summary>
    public partial class ShowDatabase : Page
    {
        public ShowDatabase()
        {
            InitializeComponent();
            loadlist();
        }

        private void loadlist()
        {

            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select ML_Name from [ML]";
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            listBox.ItemsSource = rd;

        }
    }
}

