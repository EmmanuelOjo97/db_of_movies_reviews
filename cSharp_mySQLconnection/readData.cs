using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cSharp_mySQLconnection
{
    public partial class readData : Form
    {
        public readData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            MySqlConnection cnn;
            connetionString = @"Data Source=localhost; Initial Catalog=mydb ;User ID=root;Password=root";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            /*
            MySqlCommand command;
            MySqlDataReader dataReader;
            string sql, Output = "", sqlColumns = "";
            sql = "SELECT movie_id,title,length,release_date,movie_price FROM movie";
            command = new MySqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                sqlColumns = "movie_id, Title, movie length, release date, movie_price";
                Output = Output + dataReader.GetString(0) + " " + dataReader.GetString(1) + " " + dataReader.GetString(2) + " " + dataReader.GetString(3) + " " + dataReader.GetString(4) + "\n";
            }
            MessageBox.Show(Output, sqlColumns);
            dataReader.Close();
            command.Dispose();
            cnn.Close();*/


            MySqlCommand cmd = cnn.CreateCommand();
            MySqlDataAdapter adap = new MySqlDataAdapter();
            string sqlquery = "SELECT * FROM movie";
            adap.SelectCommand = new MySqlCommand(sqlquery, cnn);
            DataTable table = new DataTable();
            adap.Fill(table);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 backToForm1 = new Form1();
            backToForm1.Close();
            this.Hide();
        }
    }
}
