namespace FinalZHForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControlLoad userControl = new UserControlLoad();
            panel1.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControlAdd userControl = new UserControlAdd();
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
    }
}
