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
    class RoomDB
    {
        public static void getroomid(DataGridViewRow clickedrow)
        {
            if (clickedrow.Index >= 0)
            {
                string name = clickedrow.Cells["Name"].Value.ToString();
                string query = "Select room_id from room where Name = '" + name + "'";
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {

                    DataChecker.ct.roomid = int.Parse((read["room_id"] + "").ToString());
                }
                read.Close();
                con.Close();
            }
        }
    }
}
