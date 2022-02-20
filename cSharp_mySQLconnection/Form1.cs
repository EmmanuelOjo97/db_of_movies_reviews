namespace cSharp_mySQLconnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            readData readData = new readData();
            readData.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertData insertData = new InsertData();
            insertData.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete DeleteData = new Delete();
            DeleteData.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update UpdateData = new Update();
            UpdateData.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LeaveReview leaveReview = new LeaveReview();
            leaveReview.Show();
        }
    }
}