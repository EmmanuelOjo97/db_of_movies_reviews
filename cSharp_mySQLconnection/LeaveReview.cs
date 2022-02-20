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
    public partial class LeaveReview : Form
    {
        public LeaveReview()
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
            string searchForMovie = textBox5.Text;
            MySqlCommand cmd = cnn.CreateCommand();
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            string sqlquery = "SELECT * FROM movie WHERE title LIKE \"" + "%" + searchForMovie + "%" + "\"";
            myAdapter.SelectCommand = new MySqlCommand(sqlquery, cnn);
            DataTable tableOfData = new DataTable();
            myAdapter.Fill(tableOfData);
            BindingSource bindToSource = new BindingSource();
            bindToSource.DataSource = tableOfData;
            dataGridView1.DataSource = bindToSource;
            // MessageBox.Show(Convert.ToString(dataGridView1.CurrentCell.Value));
            string movie_id = dataGridView1.SelectedCells[0].Value.ToString();
            textBox1.Text = movie_id;
            DataGridViewCell movie_title = dataGridView1.SelectedCells[0];
            //string movie_title = dataGridView1.SelectedCells[0]
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 backToForm1 = new Form1();
            backToForm1.Close();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string movieTitle, review_description;
            int movie_rating, inputReleaseDate;
            int recommendMovie;
            movieTitle = textBox2.Text;
            review_description = textBox4.Text;
            movie_rating = Convert.ToInt32(textBox3.Text);
            //inputReleaseDate = Convert.ToInt32(textBox4.Text);
            // recommendMovie = Convert.ToInt32(textBox6.Text);
            int movie_id = Convert.ToInt32(textBox1.Text);
            string connectionString;
            MySqlConnection cnn;
            connectionString = @"Data Source=localhost; Initial Catalog=mydb ;User ID=root;Password=root";
            cnn = new MySqlConnection(connectionString);
            cnn.Open();
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string sql = "";
            sql = $"insert into mydb.review(movie_title,review_description,movie_movie_id,movie_rating) VALUES (\"" + movieTitle + "\", \"" + review_description + "\"," + movie_id + ", " + movie_rating + ")";
            //sql = $"insert into mydb.movie (title,length,release_date,rating,movie_price) VALUES (\"" + userTitle + "\", " + inputLength + ", " + inputReleaseDate + ",\"" + userRating + "\"," + inputMoviePrice + " )";

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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*string movie_id = dataGridView1.SelectedCells[0].Value.ToString();
            MessageBox.Show(movie_id);*/
            // string movie_id = dataGridView1.SelectedCells[0].Value.ToString();

            //MessageBox.Show(Convert.ToString(dataGridView1.CurrentCell.Value));
            string id = dataGridView1.CurrentCell.Value.ToString();
            textBox1.Text = id;

            string cell_id = dataGridView1.SelectedCells[0].Value.ToString();
            textBox1.Text = cell_id;
            Console.WriteLine(cell_id);
            string cell_title = dataGridView1.SelectedCells[1].Value.ToString();
            textBox2.Text = cell_title;


            //int movie_id = Convert.ToInt32(dataGridView1.CurrentCell.Value);
            //MessageBox.Show(movie_id.ToString());
        }
    }
}
