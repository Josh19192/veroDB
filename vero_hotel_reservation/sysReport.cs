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
    class sysReport
    {
        public static void first(string sqlQuery, Label lbl, Label lbl1, string choice, string choice2)
        {
            try
            {
                string sql = sqlQuery;
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DataChecker.rp.first = int.Parse((reader[choice]).ToString());
                    lbl.Text = DataChecker.rp.first.ToString();
                    DataChecker.rp.firstName = (reader[choice2]).ToString();
                    lbl1.Text = DataChecker.rp.firstName.ToString();
                    //  comboBox.Items.Add(reader.GetString(1));
                }
                reader.Close();
                con.Close();
            }
            catch
            {

            }
        }
        public static void second(string sqlQuery, Label lbl, Label lbl1, string choice, string choice2)
        {
            try
            {
                string sql = sqlQuery;
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DataChecker.rp.second = int.Parse((reader[choice]).ToString());
                    lbl.Text = DataChecker.rp.second.ToString();
                    DataChecker.rp.secondName = (reader[choice2]).ToString();
                    lbl1.Text = DataChecker.rp.secondName.ToString();
                    //  comboBox.Items.Add(reader.GetString(1));
                }
                reader.Close();
                con.Close();
            }
            catch
            {

            }
        }
        public static void third(string sqlQuery, Label lbl, Label lbl1, string choice, string choice2)
        {
            try
            {
                string sql = sqlQuery;
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DataChecker.rp.third = int.Parse((reader[choice]).ToString());
                    lbl.Text = DataChecker.rp.third.ToString();
                    DataChecker.rp.thirdName = (reader[choice2]).ToString();
                    lbl1.Text = DataChecker.rp.thirdName.ToString();
                    //  comboBox.Items.Add(reader.GetString(1));
                }
                reader.Close();
                con.Close();
            }
            catch
            {

            }
        }
    }
}
