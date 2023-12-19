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
    public partial class DailyUpdate : Form
    {
        public DailyUpdate()
        {
            InitializeComponent();
        }

        private void DailyUpdate_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Visible = false;
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where date_registered = '" + dateTimePicker1.Text + "'", LblTodayg, "Max Customer");
            OperationDB.Todayguest("Select count(room.Availability) as 'Available Room' from  room where room.Availability = 'Available'", LblAvalC, "Available room");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where date_registered = '" + dateTimePicker1.Text + "'AND status = 'Pre-Registered' ", label4, "Max Customer");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where date_registered = '" + dateTimePicker1.Text + "'AND status = 'Checked-in' ", label7, "Max Customer");
            OperationDB.TodayRevenue("Select sum(Overall_Payment) from  Guest where date_registered = '" + dateTimePicker1.Text + "'", label11);
            // label11.Text = DataChecker.totAmount.ToString("N2");

            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where date_registered = '" + dateTimePicker1.Text + "'AND status = 'Cancelled Registration' ", label12, "Max Customer");

        }
    }
}
