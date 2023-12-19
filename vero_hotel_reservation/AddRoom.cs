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
    public partial class AddRoom : Form
    {
        public AddRoom()
        {
            InitializeComponent();
        }
        public void Revefresh()
        {
            OperationDB.dgvViewing("SELECT `Name`, `Capacity`, `Availability`, `Price` FROM `room`", DgvRoom);
            TxtCapacity.Text = "";
            TxtName.Text = "";
            TxtPrice.Text = "";
            Lblavail.Text = "Available";
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            Refresh();
            TxtCapacity.Text = "";
            TxtName.Text = "";
            TxtPrice.Text = "";
            Lblavail.Text = "Available";
        }

        private void AddRoom_Load(object sender, EventArgs e)

        {
            OperationDB.dgvViewing("SELECT `Name`, `Capacity`, `Availability`, `Price` FROM `room`", DgvRoom);
            OperationDB.MaxTransactionDate();
            label1.Text = DataChecker.ct.date.ToString();
            ////string date = label1.Text.ToString();
            //// string date1 = "24/07/2023";
            ////string converteddate = ConvertDateFormat(date);
            //DateTime parseDate = DateTime.ParseExact(DataChecker.ct.date.ToString(), "dd/MM/yyyy", null);
            //label1.Text = parseDate.ToString("yyyy-MM-dd");
        }

        private void DgvCottage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                TxtName.Text = DgvRoom.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtCapacity.Text = DgvRoom.Rows[e.RowIndex].Cells[1].Value.ToString();
                Lblavail.Text = DgvRoom.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtPrice.Text = DgvRoom.Rows[e.RowIndex].Cells[3].Value.ToString();

                DataGridViewRow clickedrow = DgvRoom.Rows[e.RowIndex];
                RoomDB.getroomid(clickedrow);
            }
            catch
            {

            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            OperationDB.dgvViewing("Select Name,`Capacity`, `Availability`, `Price` FROM `room` where Name LIKE '%" + tbxSearch.Text + "%' ORDER BY room_id ASC ", DgvRoom);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtCapacity.Text == "" || TxtName.Text == "")
                {
                    MessageBox.Show("Please Select A Room to Update");
                }
                else
                {
                    {
                        DialogResult result = MessageBox.Show("Confirm Update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // Check the user's response and return a boolean value
                        if (result == DialogResult.Yes)
                        {
                            Refresh();
                            OperationDB.saveUpdateDelete("UPDATE `room` SET Name ='" + TxtName.Text + "',Price ='" + TxtPrice.Text + "',Capacity = '" + TxtCapacity.Text + "',Availability = '" + Lblavail.Text + "'where room_id ='" + DataChecker.ct.roomid.ToString() + "'", "Updated");

                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (TxtCapacity.Text == "" || TxtName.Text == "")
            {
                MessageBox.Show("Please Select A Room to Delete");
            }
            else
            {
                {
                    DialogResult result = MessageBox.Show("Aren you Sure to Delete this Room? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Check the user's response and return a boolean value
                    if (result == DialogResult.Yes)
                    {
                        Refresh();
                        OperationDB.saveUpdateDelete("Delete From room where room_id ='" + DataChecker.ct.roomid.ToString() + "'", "Deleted");

                    }
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            new RoomList().ShowDialog();
            this.Hide();
        }
    }
}
  



