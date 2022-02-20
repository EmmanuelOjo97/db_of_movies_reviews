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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int movie_id;
            string connectionString;
            //rating = "PG-13";
            movie_id = Convert.ToInt32(textBox1.Text);
            MySqlConnection cnn;
            connectionString = @"Data Source=localhost; Initial Catalog=mydb ;User ID=root;Password=root";
            cnn = new MySqlConnection(connectionString);
            cnn.Open();
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string Output = "Movie with id of " + movie_id + " has been deleted";
            string sql = "";
            sql = $"DELETE FROM mydb.movie WHERE movie_id= " + movie_id + "";
            command = new MySqlCommand(sql, cnn);
            string selecter = "SELECT movie_id,title,length,release_date,movie_price FROM movie WHERE movie_id = " + movie_id + ";";
            adapter.DeleteCommand = new MySqlCommand(sql, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();
            MessageBox.Show(Output);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 backToForm1 = new Form1();
            this.Hide();
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connetionString;
            MySqlConnection cnn;
            connetionString = @"Data Source=localhost; Initial Catalog=mydb ;User ID=root;Password=root";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string searchForMovie = textBox2.Text;
            MySqlCommand cmd = cnn.CreateCommand();
            MySqlDataAdapter adap = new MySqlDataAdapter();
            string sqlquery = "SELECT * FROM movie WHERE title LIKE \"" + "%" + searchForMovie + "%" + "\"";
            adap.SelectCommand = new MySqlCommand(sqlquery, cnn);
            DataTable table = new DataTable();
            adap.Fill(table);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
            //DataGridViewRow nicer = dataGridView1.SelectedRows[0];
            //DataGridViewSelectedRowCollection row = dataGridView1.SelectedRows;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cell_id = dataGridView1.SelectedCells[0].Value.ToString();
            textBox1.Text = cell_id;
            Console.WriteLine(cell_id);
            string cell_title = dataGridView1.SelectedCells[1].Value.ToString();
            textBox3.Text = cell_title;
        }
    }
}
