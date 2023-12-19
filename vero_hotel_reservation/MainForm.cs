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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SidePanel.Visible = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Visible = false;
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where date_registered = '" + dateTimePicker1.Text + "'", LblTodayg, "Max Customer");
            OperationDB.Todayguest("Select count(cottage.Availability) as 'Available Cottage' from  cottage where cottage.Availability = 'Available'", label1, "Available Cottage");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where date_registered = '" + dateTimePicker1.Text + "'AND status = 'Pre-Registered' ", label4, "Max Customer");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where date_registered = '" + dateTimePicker1.Text + "'AND status = 'Checked-in' ", label7, "Max Customer");

        }
        private void lblLogOut_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirm Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response and return a boolean value
            if (result == DialogResult.Yes)
            {
                this.Hide();
                new LogIn().Show();
            }
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            SidePanel.Visible = true;

            SidePanel.Height = BtnCustomer.Height;
            SidePanel.Top = BtnCustomer.Top;
            OperationDB.AddForm(new CustomerList(), MainPanel);
        }

        private void btnDup_Click(object sender, EventArgs e)
        {
            SidePanel.Visible = true;

            SidePanel.Height = btnDup.Height;
            SidePanel.Top = btnDup.Top;
            OperationDB.AddForm(new DailyUpdate(), MainPanel);
        }

        private void BtnRoom_Click(object sender, EventArgs e)
        {
            SidePanel.Visible = true;
            SidePanel.Height = BtnRoom.Height;
            SidePanel.Top = BtnRoom.Top;
            OperationDB.AddForm(new AddRoom(), MainPanel);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SidePanel.Visible = true;

            SidePanel.Height = btnReport.Height;
            SidePanel.Top = btnReport.Top;
            OperationDB.AddForm(new Report(), MainPanel);
        }
    }
}
