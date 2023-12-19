using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vero_hotel_reservation
{
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
        }

        private void CustomerList_Load(object sender, System.EventArgs e)
        {
            label13.Visible = false;
            tbxCashRcd.Visible = false;
            label14.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            Hidedetails();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            // LblDate.Text = DataChecker.cd.dateregistered.ToString();
            OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` ", DgvCustomer);
        }
        public void refreshPreR()
        {
            OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` where Status = 'Pre-Registered' ", DgvCustomer);

        }
        public void refreshCin()
        {
            OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` where Status = 'Checked-in' ", DgvCustomer);

        }
        public void HidePic()
        {
            pictureBox2.Visible = false;
        }
        public void ShowPic()
        {
            pictureBox2.Visible = true;
        }
        public void showdetails()
        {
            label7.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label3.Visible = true;
            label9.Visible = true;
            label16.Visible = true;
            LblName.Visible = true;
            Lblcot.Visible = true;
            LblDate.Visible = true;
            LblStat.Visible = true;
            LbltotP.Visible = true;
            LblCon.Visible = true;
        }
        public void Hidedetails()
        {
            label13.Visible = false;
            tbxCashRcd.Visible = false;
            label14.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            label7.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label3.Visible = false;
            label9.Visible = false;
            label16.Visible = false;
            LblName.Visible = false;
            Lblcot.Visible = false;
            LblDate.Visible = false;
            LblStat.Visible = false;
            LbltotP.Visible = false;
            LblCon.Visible = false;
        }
        public void Refresh()
        {
            LblName.Text = "Guest Name";
            Lblcot.Text = "Room Reserved";
            LblDate.Text = "Date Registered";
            LblStat.Text = "Payment status";
            LbltotP.Text = "Total Payment";
            LblCon.Text = "Contact Info";
            Hidedetails();
            ShowPic();

            label13.Visible = false;
            tbxCashRcd.Visible = false;
            label14.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
        }

        private void BtnCin_Click(object sender, System.EventArgs e)
        {
            Hidedetails();
            ShowPic();

            Refresh();

            DataChecker.dcheker.opt = "Checked-in";
            OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` where Status = 'Checked-in' ", DgvCustomer);

        }

        private void BtnCout_Click(object sender, System.EventArgs e)
        {
            Hidedetails();
            ShowPic();

            Refresh();

            DataChecker.dcheker.opt = "Checked-out";
            OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` where Status = 'Checked-out' ", DgvCustomer);

        }

        private void BtnPre_Click(object sender, System.EventArgs e)
        {
            Hidedetails();
            ShowPic();
            Refresh();


            DataChecker.dcheker.opt = "Pre-Registered";
            OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` where Status = 'Pre-Registered' ", DgvCustomer);

        }

        private void tbxSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (DataChecker.dcheker.opt == "Pre-Registered")
            {
                OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` where Name LIKE '%" + tbxSearch.Text + "%' AND status = 'Pre-Registered' ORDER BY room_id ASC ", DgvCustomer);
            }
            else if (DataChecker.dcheker.opt == "Checked-in")
            {
                OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` where Name LIKE '%" + tbxSearch.Text + "%' AND status = 'Checked-in' ORDER BY room_id ASC ", DgvCustomer);

            }
            else if (DataChecker.dcheker.opt == "Checked-out")
            {
                OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` where Name LIKE '%" + tbxSearch.Text + "%' AND status = 'Checked-out' ORDER BY room_id ASC ", DgvCustomer);

            }
            else if (DataChecker.dcheker.opt == "All")
            {
                OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` where Name LIKE '%" + tbxSearch.Text + "%' ORDER BY room_id ASC ", DgvCustomer);
            }
            else
            {
                OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` where Name LIKE '%" + tbxSearch.Text + "%' ORDER BY room_id ASC ", DgvCustomer);

            }
        }

        private void btnShowAll_Click(object sender, System.EventArgs e)
        {
            Refresh();
            ShowPic();

            Hidedetails();
            DataChecker.dcheker.opt = "All";
            OperationDB.dgvViewing("SELECT  `Name`, `ContactNo.` as 'Contact Number', `status` as 'Status' FROM `guest` where Name LIKE '%" + tbxSearch.Text + "%' ORDER BY room_id ASC ", DgvCustomer);

        }
        private void tbxCashRcd_TextChanged(object sender, System.EventArgs e)
        {
            double amt = 0;
            double rec = 0;
            double change = 0;

            double.TryParse(LbltotP.Text, out amt);
            double.TryParse(tbxCashRcd.Text, out rec);

            change = Math.Abs(amt - rec);
            textBox3.Text = change.ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (button1.Text == "Check in")
            {
                {
                    if (tbxCashRcd.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Please Input A Cash Received");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Confirm Payment", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // Check the user's response and return a boolean value
                        if (result == DialogResult.Yes)
                        {
                            OperationDB.saveUpdateDelete("INSERT INTO `payment_transaction`(`guest_id`, `Total_Payment`, `Cash`, `Change`, `Transaction_date`) VALUES('" + DataChecker.cd.guestid.ToString() + "','" + LbltotP.Text + "','" + tbxCashRcd.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "')", "Saved");
                            Customerdb.updatecustomerstatus();
                            refreshPreR();
                            Refresh();

                        }
                        else
                        {

                        }
                    }
                }
            }
            else if (button1.Text == "Check out")
            {
                DialogResult result = MessageBox.Show("Confirm Check out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's response and return a boolean value
                if (result == DialogResult.Yes)
                {
                    Customerdb.updatecottavailability();
                    Customerdb.updatecustomerstatus1();
                    MessageBox.Show(LblName.Text + "Succesfully Checked-out");
                    refreshCin();
                    Refresh();

                }

            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Remove this Guest in Reserved List?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response and return a boolean value
            if (result == DialogResult.Yes)
            {
                Customerdb.updatecustomerstatus2();
                Customerdb.updatecottavailability();
                Customerdb.updatecustomerstatcanc();
                MessageBox.Show(LblName.Text + " " + "was Successfully Removed from Reserved List");
                refreshPreR();
                Refresh();
            }
        }

        private void DgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //TxtName.Text = DgvCottage.Rows[e.RowIndex].Cells[0].Value.ToString();
            //TxtCapacity.Text = DgvCottage.Rows[e.RowIndex].Cells[1].Value.ToString();
            //Lblavail.Text = DgvCottage.Rows[e.RowIndex].Cells[2].Value.ToString();
            //TxtPrice.Text = DgvCottage.Rows[e.RowIndex].Cells[3].Value.ToString();

            DataGridViewRow clickedrow = DgvCustomer.Rows[e.RowIndex];
            Customerdb.getcustid(clickedrow);
            LblName.Text = DataChecker.cd.name;
            LblCon.Text = DataChecker.cd.contact_no.ToString();
            LblStat.Text = DataChecker.cd.paystatus;
            LbltotP.Text = DataChecker.cd.totpayment.ToString();
            LblDate.Text = DataChecker.cd.dateregistered.ToString();
            DataGridViewRow clickedrow1 = DgvCustomer.Rows[e.RowIndex];
            Customerdb.getcustroom(clickedrow1);
            Lblcot.Text = DataChecker.cd.room;
            if (DataChecker.cd.paystatus == "Pending")
            {
                button1.Text = "Check in";
                showdetails();
                label13.Visible = true;
                tbxCashRcd.Visible = true;
                label14.Visible = true;
                textBox3.Visible = true;
                button1.Visible = true;
                button3.Visible = true;
                HidePic();
            }
            else if (DataChecker.cd.status == "Checked-in")
            {
                button1.Text = "Check out";
                showdetails();
                button1.Visible = true;
                label13.Visible = false;
                tbxCashRcd.Visible = false;
                label14.Visible = false;
                textBox3.Visible = false;
                HidePic();

            }
            else
            {
                showdetails();
                label13.Visible = false;
                tbxCashRcd.Visible = false;
                label14.Visible = false;
                textBox3.Visible = false;
                button1.Visible = false;
                button3.Visible = false;
                HidePic();
            }
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            new AddCustomer().ShowDialog();
            this.Hide();
        }

    }
}
