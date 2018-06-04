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
    public partial class ItemsForm : Form
    {
        private MyFundsManager manager;
        public ItemsForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item _item = new Item();
            _item.name = textBox1.Text;
            _item.FK_Items_Funds = manager.Selected;
            manager.My_db.Items.Add(_item);
            manager.My_db.SaveChanges();
            textBox1.Clear();
            this.itemsTableAdapter.Fill(this.fundsDBDataSet.Items);
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.fundsDBDataSet.Items);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {

                manager.DeleteItem(Convert.ToInt32(listBox1.SelectedValue));
                this.itemsTableAdapter.Fill(this.fundsDBDataSet.Items);

            }
        }
    }
}
