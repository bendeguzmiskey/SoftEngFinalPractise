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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalZHForm
{
    public partial class UserControlLoad : UserControl
    {
        Forma1Context context = new Forma1Context();
        public UserControlLoad()
        {
            InitializeComponent();
        }

        private void UserControlLoad_Load(object sender, EventArgs e)
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

        private void VersenyListazas()
        {
            if (bindingSource1.Current != null)
            {
                var id = ((Pilotum)bindingSource1.Current).PilotaId;

                var versenyek = from x in context.Eredmenies
                                where x.PilotaId == id
                                select new Verseny
                                {
                                    PilotaId = x.PilotaId,
                                    CsapatId = x.CsapatId,
                                    Szponzor = x.Csapat.Szponzor,
                                    Nemzetiseg = x.Pilota.Nemzetiseg
                                };
                versenyBindingSource.DataSource = versenyek.ToList();
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            VersenyListazas();
        }
    }

    public class Verseny
    {
        public int PilotaId { get; set; }
        public int? CsapatId { get; set; }

        public string Szponzor { get; set; }

        public string Nemzetiseg { get; set; }

    }
}
