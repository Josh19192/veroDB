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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Visible = false;
            OperationDB.TodayRevenue("Select sum(Overall_Payment) from  Guest where date_registered = '" + dateTimePicker1.Text + "'", LblTodayg);
            //  LblTodayg.Text = DataChecker.totAmount.ToString("N2");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where date_registered = '" + dateTimePicker1.Text + "'", label2, "Max Customer");
            OperationDB.Todayguest("Select Sum(`no._of_occupants`) as 'Total Reservation' from Guest where date_registered = '" + dateTimePicker1.Text + "'", label5, "Total Reservation");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where date_registered = '" + dateTimePicker1.Text + "'AND status = 'Cancelled Registration' ", label7, "Max Customer");
            sysReport.first("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.cott_id where date_registered = '" + dateTimePicker1.Text + "' GROUP by room.Name Order by 'Total' DESC LIMIT 1", label14, label9, "Total", "Name");
            sysReport.second("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.cott_id where date_registered = '" + dateTimePicker1.Text + "' GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 1", label15, label11, "Total", "Name");
            sysReport.third("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.cott_id where date_registered = '" + dateTimePicker1.Text + "' GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 2", label16, label12, "Total", "Name");

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            OperationDB.TodayRevenue("Select sum(Overall_Payment) from  Guest", LblTodayg);
            //  LblTodayg.Text = DataChecker.totAmount.ToString("N2");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest ", label2, "Max Customer");
            OperationDB.Todayguest("Select Sum(`no._of_occupants`) as 'Total Reservation' from Guest", label5, "Total Reservation");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where status = 'Cancelled Registration' ", label7, "Max Customer");
            sysReport.first("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id GROUP by room.Name Order by 'Total' DESC LIMIT 1", label14, label9, "Total", "Name");
            sysReport.second("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 1", label15, label11, "Total", "Name");
            sysReport.third("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 2", label16, label12, "Total", "Name");

        }

        private void btnShowToday_Click(object sender, EventArgs e)
        {
            OperationDB.TodayRevenue("Select sum(Overall_Payment) from  Guest where date_registered = '" + dateTimePicker1.Text + "'", LblTodayg);
            //  LblTodayg.Text = DataChecker.totAmount.ToString("N2");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where date_registered = '" + dateTimePicker1.Text + "'", label2, "Max Customer");
            OperationDB.Todayguest("Select Sum(`no._of_occupants`) as 'Total Reservation' from Guest where date_registered = '" + dateTimePicker1.Text + "'", label5, "Total Reservation");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where date_registered = '" + dateTimePicker1.Text + "'AND status = 'Cancelled Registration' ", label7, "Max Customer");
            sysReport.first("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where date_registered = '" + dateTimePicker1.Text + "' GROUP by room.Name Order by 'Total' DESC LIMIT 1", label14, label9, "Total", "Name");
            sysReport.second("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where date_registered = '" + dateTimePicker1.Text + "' GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 1", label15, label11, "Total", "Name");
            sysReport.third("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where date_registered = '" + dateTimePicker1.Text + "' GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 2", label16, label12, "Total", "Name");
            //            SELECT COUNT(guest.cott_id), cottage.Name FROM guest
            //INNER JOIN cottage on cottage.cott_id = guest.cott_id GROUP by cottage.Name DESC LIMIT 3;
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            OperationDB.Todayguest("Select Sum(`no._of_occupants`) as 'Total Reservation' from Guest where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 7 DAY) AND '" + dateTimePicker1.Text + "'", label5, "Total Reservation");

            OperationDB.TodayRevenue("Select sum(Overall_Payment) from  Guest where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 7 DAY) AND '" + dateTimePicker1.Text + "'", LblTodayg);
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 7 DAY) AND '" + dateTimePicker1.Text + "'", label2, "Max Customer");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 7 DAY) AND '" + dateTimePicker1.Text + "' AND status = 'Cancelled Registration'", label7, "Max Customer");
            sysReport.first("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 7 DAY) AND '" + dateTimePicker1.Text + "' GROUP by room.Name Order by 'Total' DESC LIMIT 1", label14, label9, "Total", "Name");
            sysReport.second("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 7 DAY) AND '" + dateTimePicker1.Text + "'  GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 1", label15, label11, "Total", "Name");
            sysReport.third("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 7 DAY) AND '" + dateTimePicker1.Text + "' GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 2", label16, label12, "Total", "Name");

        }

        private void BtnCout_Click(object sender, EventArgs e)
        {
            OperationDB.Todayguest("Select Sum(`no._of_occupants`) as 'Total Reservation' from Guest where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 30 DAY) AND '" + dateTimePicker1.Text + "'", label5, "Total Reservation");

            OperationDB.TodayRevenue("Select sum(Overall_Payment) from  Guest where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 30 DAY) AND '" + dateTimePicker1.Text + "'", LblTodayg);
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 30 DAY) AND '" + dateTimePicker1.Text + "'", label2, "Max Customer");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 30 DAY) AND '" + dateTimePicker1.Text + "' AND status = 'Cancelled Registration'", label7, "Max Customer");
            sysReport.first("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 30 DAY) AND '" + dateTimePicker1.Text + "' GROUP by room.Name Order by 'Total' DESC LIMIT 1", label14, label9, "Total", "Name");
            sysReport.second("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 30 DAY) AND '" + dateTimePicker1.Text + "'  GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 1", label15, label11, "Total", "Name");
            sysReport.third("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where  date_registered BETWEEN DATE_SUB('" + dateTimePicker1.Text + "', INTERVAL 30 DAY) AND '" + dateTimePicker1.Text + "' GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 2", label16, label12, "Total", "Name");

        }

        private void btnThisM_Click(object sender, EventArgs e)
        {
            OperationDB.TodayRevenue("Select sum(Overall_Payment) from  Guest where DATE_FORMAT(date_registered, '%Y-%m') = DATE_FORMAT(NOW(), '%Y-%m')", LblTodayg);
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where DATE_FORMAT(date_registered, '%Y-%m') = DATE_FORMAT(NOW(), '%Y-%m')", label2, "Max Customer");
            OperationDB.Todayguest("SELECT SUM(`no._of_occupants`) as 'Total Reservation' FROM Guest WHERE DATE_FORMAT(date_registered, '%Y-%m') = DATE_FORMAT(NOW(), '%Y-%m')", label5, "Total Reservation");
            OperationDB.Todayguest("Select count(Name) as 'Max Customer' from  Guest where DATE_FORMAT(date_registered, '%Y-%m') = DATE_FORMAT(NOW(), '%Y-%m') AND status = 'Cancelled Registration'", label7, "Max Customer");
            sysReport.first("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where DATE_FORMAT(date_registered, '%Y-%m') = DATE_FORMAT(NOW(), '%Y-%m') GROUP by room.Name Order by 'Total' DESC LIMIT 1", label14, label9, "Total", "Name");
            sysReport.second("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where DATE_FORMAT(date_registered, '%Y-%m') = DATE_FORMAT(NOW(), '%Y-%m') GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 1", label15, label11, "Total", "Name");
            sysReport.third("SELECT COUNT(guest.room_id) as 'Total', room.Name FROM guest INNER JOIN room on room.room_id = guest.room_id where DATE_FORMAT(date_registered, '%Y-%m') = DATE_FORMAT(NOW(), '%Y-%m') GROUP by room.Name Order by 'Total' DESC LIMIT 1 OFFSET 2", label16, label12, "Total", "Name");

        }

    }
}
