using FinalZHForm.F1Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalZHForm
{
    public partial class UserControlDelete : UserControl
    {
        Forma1Context context = new Forma1Context();
        public UserControlDelete()
        {
            InitializeComponent();
        }

        private void UserControlDelete_Load(object sender, EventArgs e)
        {
            Listazas();
        }

        private void Listazas()
        {
            bindingSource1.DataSource = (from x in context.Pilota
                                         where x.Nev.Contains(textBox1.Text)
                                         select x).ToList();
            listBox1.DataSource = bindingSource1;
            listBox1.DisplayMember = "Nev";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Listazas();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var törlendõ = (Pilotum)bindingSource1.Current;

            if (törlendõ == null)
            {
                MessageBox.Show("Nincs kiválasztott elem a törléshez.", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Biztosan törölni szeretnéd a(z) {törlendõ.Nev} nevű pilótát?",
                "Törlés megerősítése",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                var törlend = (from x in context.Pilota
                               where x.PilotaId == törlendõ.PilotaId
                               select x).FirstOrDefault();

                if (törlend != null)
                {
                    context.Pilota.Remove(törlend);
                    context.SaveChanges();
                    Listazas();
                    MessageBox.Show("A pilóta sikeresen törölve lett.", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nem található a törlendő pilóta az adatbázisban.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
