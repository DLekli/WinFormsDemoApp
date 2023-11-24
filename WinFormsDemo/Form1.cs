namespace WinFormsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = "Last Name";
            label3.Text = "Full Name";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"Hello {textBox1.Text} {textBox2.Text}");
            //textBox3.Text = $" {textBox1.Text} {textBox2.Text}";
            //progressBar1.Value += 10;

            //Form1 frm = new Form1();
            //frm.Show();

            Form2 frm2 = new("Hello from Form1");
            frm2.Show();

            //toolStripProgressBar1.Value += 5;
            //toolStripStatusLabel1.Text = "Working...";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created By Denis");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}