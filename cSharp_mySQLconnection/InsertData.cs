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
    public partial class InsertData : Form
    {
        public InsertData()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userTitle, userRating;
            int inputLength, inputReleaseDate;
            double inputMoviePrice;
            userTitle = textBox1.Text;
            userRating = textBox2.Text;
            inputLength = Convert.ToInt32(textBox3.Text);
            inputReleaseDate = Convert.ToInt32(textBox4.Text);
            inputMoviePrice = Convert.ToDouble(textBox5.Text);
            string connectionString;
            MySqlConnection cnn;
            connectionString = @"Data Source=localhost; Initial Catalog=mydb ;User ID=root;Password=root";
            cnn = new MySqlConnection(connectionString);
            cnn.Open();
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string sql = "";
            sql = $"insert into mydb.movie (title,length,release_date,rating,movie_price) VALUES (\"" + userTitle + "\", " + inputLength + ", " + inputReleaseDate + ",\"" + userRating + "\"," + inputMoviePrice + " )";
            command = new MySqlCommand(sql, cnn);
            adapter.InsertCommand = new MySqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            MessageBox.Show("Your query has been added " + sql);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 backToForm1 = new Form1();
            backToForm1.Close();
            this.Hide();
        }

        private void InsertData_Load(object sender, EventArgs e)
        {

        }
    }
}
