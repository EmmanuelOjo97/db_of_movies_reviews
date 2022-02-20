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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string movie_title, rating;
            string connectionString;
            rating = "PG-13";
            movie_title = textBox1.Text;
            int movie_id = Convert.ToInt32(textBox2.Text);
            int length, release_date;
            double movie_price;
            length = 100;
            release_date = 2019;
            movie_price = 10.99;
            MySqlConnection cnn;
            connectionString = @"Data Source=localhost; Initial Catalog=mydb ;User ID=root;Password=root";
            cnn = new MySqlConnection(connectionString);
            cnn.Open();
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string sql = "";
            sql = "Update mydb.movie set title = \"" + movie_title + "\" where movie_id = " + movie_id + "";
            command = new MySqlCommand(sql, cnn);
            adapter.UpdateCommand = new MySqlCommand(sql, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();
            MessageBox.Show("You have updated the title of ID " + movie_id + " With " + movie_title);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 backToForm1 = new Form1();
            backToForm1.Close();
            this.Hide();
        }

        private void Update_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connetionString;
            MySqlConnection cnn;
            connetionString = @"Data Source=localhost; Initial Catalog=mydb ;User ID=root;Password=root";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string searchForMovie = textBox3.Text;
            MySqlCommand cmd = cnn.CreateCommand();
            MySqlDataAdapter adap = new MySqlDataAdapter();
            string selectLike = "%\"" + searchForMovie + "\"%";
            string sqlquery = "SELECT * FROM movie WHERE title LIKE \"" + "%" + searchForMovie + "%" + "\"";
            adap.SelectCommand = new MySqlCommand(sqlquery, cnn);
            DataTable table = new DataTable();
            adap.Fill(table);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
            string cell_id = dataGridView1.SelectedCells[0].Value.ToString();
            textBox1.Text = cell_id;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string cell_id = dataGridView1.SelectedCells[0].Value.ToString();
            textBox2.Text = cell_id;
            Console.WriteLine(cell_id);
            string cell_title = dataGridView1.SelectedCells[1].Value.ToString();
            textBox1.Text = cell_title;

        }
    }
}
