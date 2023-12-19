using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace vero_hotel_reservation
{
    class OperationDB
    {
        public static void Login(string query)
        {
            //   query = "Select * from staff_info where username = '" + user + "' and password ='" + pass + "'";
            
        }
        public static void saveUpdateDelete(string sql, string action)
        {

            MySqlConnection con = Connection.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
                // control.VoiceOutput(action);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error!!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void Todayguest(string sqlQuery, Label lbl, string choice)
        {
            try
            {
                string sql = sqlQuery;
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DataChecker.cd.maxcustomer = int.Parse((reader[choice]).ToString());
                    lbl.Text = DataChecker.cd.maxcustomer.ToString();
                    //  comboBox.Items.Add(reader.GetString(1));
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                lbl.Text = "0";
            }
        }
        public static void AddForm(Form f, Panel panel)
        {
            panel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel.Controls.Add(f);
            f.Show();
        }
        public static void dgvViewing(string sqlQuery, DataGridView dgv)
        {
            try
            {
                string sql = sqlQuery;
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dgv.DataSource = tbl;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void LoadComboBox(string sqlQuery, ComboBox comboBox)
        {
            try
            {
                string sql = sqlQuery;
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    comboBox.Items.Add(reader["Name"] + "").ToString();
                    //  comboBox.Items.Add(reader.GetString(1));
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void GetroomData(ComboBox cbx)
        {
            MySqlConnection con = Connection.GetConnection();
            string query = "Select room_id from room where Name = '" + cbx.SelectedItem.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                DataChecker.ct.roomid = int.Parse((read["room_id"] + "").ToString());
                // Instance.getcatdata.catid = read.GetInt32(0);
                // Instance.getcatdata.searchChkr = true;
                //Instance.getdata.catid = int.Parse((read["category_id"] + "").ToString());
            }
            read.Close();
            con.Close();
        }
        public static void GetroomPrice(ComboBox cbx, Label lbl)
        {
            MySqlConnection con = Connection.GetConnection();
            string query = "Select * from room where Name = '" + cbx.SelectedItem.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                DataChecker.ct.price = int.Parse((read["Price"] + "").ToString());
                DataChecker.ct.Capacity = int.Parse((read["Capacity"] + "").ToString());
                lbl.Text = DataChecker.ct.price.ToString();
                // Instance.getcatdata.catid = read.GetInt32(0);
                // Instance.getcatdata.searchChkr = true;
                //Instance.getdata.catid = int.Parse((read["category_id"] + "").ToString());
            }
            read.Close();
            con.Close();
        }
        public static void updatecottageavAilability(ComboBox cbx)
        {
            try
            {

                string availability = "Unavailable";
                MySqlConnection con = Connection.GetConnection();
                string query = "UPDATE room set Availability ='" + availability + "'where room_id ='" + DataChecker.ct.roomid.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    DataChecker.ct.availability = "Unavailable";
                }
                read.Close();
                con.Close();
            }
            catch
            {

            }
        }
        public static void TodayRevenue(string sqlQuery, Label lbl)
        {
            try
            {
                string sql = sqlQuery;
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DataChecker.cd.todreven = double.Parse((reader["sum(Overall_Payment)"] + "").ToString());
                    lbl.Text = DataChecker.cd.todreven.ToString("N2");
                    //  comboBox.Items.Add(reader.GetString(1));
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                lbl.Text = "0.00";
            }
        }
        public static void MaxTransactionDate()
        {
            MySqlConnection con = Connection.GetConnection();
            string query = "Select room.Name, Max(Guest.date_registered) as 'Date Occupied', room.Availability FROM room Inner JOIN guest on room.room_id = guest.room_id where room.Availability = 'Unavailable' GROUP by room.Name ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                DataChecker.ct.date = DateTime.Parse((read["Date Occupied"] + "").ToString());
                // DataChecker.ct.price = int.Parse((read["Price"] + "").ToString());
                //  lbl.Text = DataChecker.ct.price.ToString();
                // Instance.getcatdata.catid = read.GetInt32(0);
                // Instance.getcatdata.searchChkr = true;
                //Instance.getdata.catid = int.Parse((read["category_id"] + "").ToString());
                //SELECT All(cottage.Name), max(guest.date_registered) as 'Date Occupied', cottage.Availability from guest
                //  Inner JOIN cottage on cottage.cott_id = guest.cott_id where cottage.Availability = 'Unavailable';
            }
            read.Close();
            con.Close();
        }
    }
}
