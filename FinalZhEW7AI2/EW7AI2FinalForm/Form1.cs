namespace EW7AI2FinalForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControlAdd userControl = new UserControlAdd();
            panel1.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControlLoad userControl = new UserControlLoad();
            panel1.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControlDelete userControl = new UserControlDelete();
            panel1.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Biztosan ki akar lepni?", "Kilepes megerositese", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
