using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
namespace vero_hotel_reservation
{
    class Customerdb
    {
        public static void getcustid(DataGridViewRow clickedrow)
        {
            if (clickedrow.Index >= 0)
            {
                string name = clickedrow.Cells["Name"].Value.ToString();
                string query = "Select * from guest where Name = '" + name + "'";
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    DataChecker.cd.guestid = int.Parse((read["guest_id"] + "").ToString());
                    DataChecker.cd.contact_no = (read["ContactNo."] + "").ToString();
                    DataChecker.cd.totoccu = int.Parse((read["no._of_occupants"] + "").ToString());
                    DataChecker.cd.totpayment = int.Parse((read["Overall_payment"] + "").ToString());
                    DataChecker.cd.paystatus = (read["Payment_Status"] + "").ToString();
                    DataChecker.cd.dateregistered = DateTime.Parse((read["date_registered"] + "").ToString());
                    DataChecker.cd.status = (read["status"] + "").ToString();
                    DataChecker.cd.name = (read["Name"] + "").ToString();
                    DataChecker.cd.room_id = int.Parse((read["room_id"]).ToString());
                }
                read.Close();
                con.Close();
            }
        }
        public static void getcustroom(DataGridViewRow clickedrow)
        {
            if (clickedrow.Index >= 0)
            {
                string name = clickedrow.Cells["Name"].Value.ToString();
                string query = "SELECT room.Name as 'Room Name', guest.Name from guest INNER JOIN room on room.room_id = guest.room_id where guest.Name = '" + name + "'";
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    DataChecker.cd.room = (read["Room Name"] + "").ToString();

                }
                read.Close();
                con.Close();
            }
        }
        public static void updatecustomerstatus()
        {
            try
            {

                string paymentstat = "Paid";
                string status = "Checked-in";
                MySqlConnection con = Connection.GetConnection();
                string query = "UPDATE guest set Payment_Status ='" + paymentstat + "',status ='" + status + "'where guest_id ='" + DataChecker.cd.guestid.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    //DataChecker.ct.availability = "Unavailable";
                }
                read.Close();
                con.Close();
            }
            catch
            {

            }
        }
        public static void updatecustomerstatus1()
        {
            try
            {


                string status = "Checked-out";
                MySqlConnection con = Connection.GetConnection();
                string query = "UPDATE guest set  status ='" + status + "'where guest_id ='" + DataChecker.cd.guestid.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    //DataChecker.ct.availability = "Unavailable";
                }
                read.Close();
                con.Close();
            }
            catch
            {

            }
        }
        public static void updatecottavailability()
        {
            try
            {


                string availability = "Available";
                MySqlConnection con = Connection.GetConnection();
                string query = "UPDATE cottage set  Availability ='" + availability + "'where cott_id ='" + DataChecker.cd.room_id.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    //DataChecker.ct.availability = "Unavailable";
                }
                read.Close();
                con.Close();
            }
            catch
            {

            }
        }
        public static void updatecustomerstatus2()
        {
            try
            {


                string status = "Cancelled Registration";
                MySqlConnection con = Connection.GetConnection();
                string query = "UPDATE guest set  status ='" + status + "'where guest_id ='" + DataChecker.cd.guestid.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    //DataChecker.ct.availability = "Unavailable";
                }
                read.Close();
                con.Close();
            }
            catch
            {

            }
        }
        public static void updatecustomerstatcanc()
        {
            try
            {


                string status = "Unregistered";
                MySqlConnection con = Connection.GetConnection();
                string query = "UPDATE guest set  payment_status ='" + status + "'where guest_id ='" + DataChecker.cd.guestid.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    //DataChecker.ct.availability = "Unavailable";
                }
                read.Close();
                con.Close();
            }
            catch
            {

            }
        }
    }
}
