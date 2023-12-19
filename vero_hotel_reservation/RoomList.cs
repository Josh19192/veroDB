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
    public partial class RoomList : Form
    {
        public RoomList()
        {
            InitializeComponent();
        }

        private void RoomList_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            OperationDB.saveUpdateDelete("INSERT INTO `room`(`Name`, `Capacity`, `Price`, `date_created`) VALUES('" + TxtName.Text + "','" + TxtCapacity.Text + "','" + TxtPrice.Text + "','" + dateTimePicker1.Text + "')", "Saved");
            AddRoom ar = new AddRoom();
            this.Hide();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
