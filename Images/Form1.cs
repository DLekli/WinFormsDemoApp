using System.Windows.Forms;

namespace Images
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Check if pictureBox1 is null before accessing its properties
                if (Image1 != null)
                {   
                    textBox1.Text = dialog.FileName;
                    // Display the selected image in the PictureBox
                    Image1.Image = new Bitmap(dialog.FileName);
                }
                else
                {
                    // Handle the case where pictureBox1 is unexpectedly null
                    MessageBox.Show("Error: PictureBox not initialized.");
                }
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            File.Copy(textBox1.Text, Path.Combine(@"C:\\Users\\Denis\\source\\repos\\WinFormsDemoApp\\Images\\Images", Path.GetFileName(textBox1.Text)), true);
            label1.Text = "Image File saved successfully";
        }
    }
}