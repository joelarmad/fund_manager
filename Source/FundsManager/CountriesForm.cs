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
    public partial class CountriesForm : Form
    {
        private MyFundsManager manager;
        public CountriesForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Country _country = new Country();
            _country.name = nameTextBox.Text;
            _country.FK_Countries_Funds = manager.Selected;
            manager.My_db.Countries.Add(_country);
            manager.My_db.SaveChanges();
            nameTextBox.Clear();
            this.countriesTableAdapter.Fill(this.fundsDBDataSet.Countries);
        }

        private void CountriesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Countries' table. You can move, or remove it, as needed.
            this.countriesTableAdapter.Fill(this.fundsDBDataSet.Countries);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {

                manager.DeleteCountry(Convert.ToInt32(listBox1.SelectedValue));
                this.countriesTableAdapter.Fill(this.fundsDBDataSet.Countries);

            }

        }
    }
}
