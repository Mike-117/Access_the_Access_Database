using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml;


namespace Access_the_Access_Database
{
    /// <summary>
    /// Interaction logic for ChooseDatabase.xaml
    /// </summary>
    public partial class ChooseDatabase : Page
    {
        public ChooseDatabase ()
        {
            InitializeComponent();
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.Filter = "Access Database Files (*.mdb)|*.mdb";
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {

                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
                builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                builder.DataSource = openFileDlg.FileName;
                builder["User Id"] = "admin";
                builder["Password"] = "";
                string conStr = builder.ToString();

                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = builder.ToString();
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select ML_Name from [ML]";
                cmd.Connection = con;
                OleDbDataReader rd = cmd.ExecuteReader();
                listBox.ItemsSource = rd;


            }
        }
    }
}