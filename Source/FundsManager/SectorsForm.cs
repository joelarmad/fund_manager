using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager
{
    public partial class SectorsForm : Form
    {
        private MyFundsManager manager;
        public SectorsForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
        }

        private void SectorsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Sectors' table. You can move, or remove it, as needed.
            this.sectorsTableAdapter.Fill(this.fundsDBDataSet.Sectors);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sector _sector = new Sector();
            _sector.name = textBox1.Text;
            _sector.FK_Sectors_Funds = manager.Selected;
            manager.My_db.Sectors.Add(_sector);
            manager.My_db.SaveChanges();
            textBox1.Clear();
            this.sectorsTableAdapter.Fill(this.fundsDBDataSet.Sectors);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {

                manager.DeleteSector(Convert.ToInt32(listBox1.SelectedValue));
                this.sectorsTableAdapter.Fill(this.fundsDBDataSet.Sectors);

            }
        }
    }
}
