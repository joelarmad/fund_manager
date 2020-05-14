using FundsManager.Classes.Utilities;
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
    public partial class ShipmentForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        private bool fEditMode = false;

        public ShipmentForm()
        {
            InitializeComponent();
        }

        private void ShipmentForm_Load(object sender, EventArgs e)
        {            
            this.letter_of_creditsTableAdapter.FillByFundWithNoEmpty(this.fundsDBDataSet.letter_of_credits, manager.Selected);

            loadShipmentData();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            addShipment();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            fEditMode = false;
            cmdAdd.Text = "Add";

            txtNumber.Text = "";
            txtValue.Text = "";

            cmdCancel.Visible = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert;
                alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (alert == DialogResult.OK)
                {
                    int _id = int.Parse(listBox1.SelectedValue.ToString());

                    manager.DeleteShipment(_id);

                    loadShipmentData();

                    cmdCancel_Click(null, null);
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void cbLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fEditMode)
            {
                loadShipmentData();

                cmdCancel_Click(null, null);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int shipmentId = 0;

                if (listBox1.SelectedValue != null && int.TryParse(listBox1.SelectedValue.ToString(), out shipmentId))
                {
                    Shipment _selected = manager.My_db.Shipments.FirstOrDefault(x => x.Id == shipmentId);

                    if (_selected != null)
                    {
                        fEditMode = true;
                        cmdAdd.Text = "Save";

                        txtNumber.Text = _selected.Number;
                        txtValue.Text = String.Format("{0:n}", _selected.Value);

                        letter_of_credits letter = manager.My_db.letter_of_credits.FirstOrDefault(x => x.Id == _selected.LetterOfCreditId);

                        foreach (DataRowView _item in cbLetter.Items)
                        {
                            if (_item.Row[0].ToString() == letter.Id.ToString())
                            {
                                cbLetter.SelectedItem = _item;
                                break;
                            }
                        }

                        cmdCancel.Visible = true;
                    }
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show("Error: " + _ex.Message);
            }
        }

        private void loadShipmentData()
        {
            if (fundsDBDataSet != null && cbLetter.SelectedValue != null)
            {
                this.shipmentsTableAdapter.FillByLetterWithNoEmpty(this.fundsDBDataSet.Shipments, int.Parse(cbLetter.SelectedValue.ToString()));
            }

            listBox1.SelectedIndex = -1;
        }

        private void addShipment()
        {
            try
            {
                int letterId = Convert.ToInt32(cbLetter.SelectedValue);

                if (!fEditMode)
                {
                    Shipment _validation = manager.My_db.Shipments.FirstOrDefault(x => x.Number == txtNumber.Text && x.LetterOfCreditId == letterId);

                    if (_validation != null)
                    {
                        MessageBox.Show("Duplicated number.");
                        return;
                    }

                    Shipment _shipment = new Shipment();
                    _shipment.Number = txtNumber.Text;
                    _shipment.LetterOfCreditId = letterId;
                    _shipment.Value = decimal.Parse(txtValue.Text);
                    manager.My_db.Shipments.Add(_shipment);
                    manager.My_db.SaveChanges();
                }
                else
                {
                    int _id = int.Parse(listBox1.SelectedValue.ToString());

                    Shipment _validation = manager.My_db.Shipments.FirstOrDefault(x => x.Id != _id && x.Number == txtNumber.Text);

                    if (_validation != null)
                    {
                        MessageBox.Show("Duplicated number.");
                        return;
                    }

                    Shipment _selected = manager.My_db.Shipments.FirstOrDefault(x => x.Id == _id);

                    if (_selected != null)
                    {
                        _selected.Number = txtNumber.Text;
                        _selected.Value = decimal.Parse(txtValue.Text);
                        _selected.LetterOfCreditId = Convert.ToInt32(cbLetter.SelectedValue);

                        manager.My_db.SaveChanges();
                    }
                }

                loadShipmentData();

                cmdCancel_Click(null, null);
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }
    }
}
