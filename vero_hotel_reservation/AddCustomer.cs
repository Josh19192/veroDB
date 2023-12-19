﻿using System;
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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            OperationDB.LoadComboBox("Select * from room where availability = 'Available'", cbxRoom);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void cbxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            OperationDB.GetroomData(cbxRoom);
            OperationDB.GetroomPrice(cbxRoom, lblPrice);
            label6.Text = DataChecker.ct.Capacity.ToString();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            int bel10 = 0;
            int ab10 = 0;
            int totaloccu = 0;

            int.TryParse(Txt10.Text, out ab10);

            totaloccu = Math.Abs(bel10 + ab10);
            // lblPrice.Text = totalcost.ToString();
            if (TxtName.Text == "" || Txtcon.Text == "" || cbxRoom.Text == "" || Txt10.Text == "")
            {
                MessageBox.Show("Please fill the data Completely");
            }
            else if(Txtcon.Text.Length != 11 )
            {
                MessageBox.Show("Invalid Contact no.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Confirm Registration?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                {
                    // Check the user's response and return a boolean value
                    if (result == DialogResult.Yes)
                    {
                        OperationDB.saveUpdateDelete("INSERT INTO `guest`(`Name`, `ContactNo.`, `room_id`, `no._of_occupants`, `Overall_payment`, `date_registered`) VALUES ('" + TxtName.Text + "','" + Txtcon.Text + "','" + DataChecker.ct.roomid.ToString() + "','" + totaloccu + "','" + Lbltot.Text + "','" + dateTimePicker1.Text + "')", "Registered");
                        OperationDB.updatecottageavAilability(cbxRoom);
                        this.Close();                      
                        //  OperationDB.saveUpdateDelete("INSERT INTO `cottage`(`Name`, `Capacity`, `Price`, `date_created`) VALUES('" + TxtName.Text + "','" + TxtCapacity.Text + "','" + TxtPrice.Text + "','" + dateTimePicker1.Text + "')", "Saved");
                    }
                }
            }
        }
        private void Txt10_TextChanged(object sender, EventArgs e)
        {

            double no_of_occupants = 0;
            double fee_price = 20;
            double room_price = 0;
            double bill_amount = 0;

            double.TryParse(Txt10.Text, out no_of_occupants);
            double.TryParse(lblPrice.Text, out room_price);



            Math.Abs(no_of_occupants * fee_price);
            bill_amount = Math.Abs(room_price);
            Lbltot.Text = bill_amount.ToString();

        }

        private void Txt10_TextChanged_1(object sender, EventArgs e)
        {
            double no_of_occupants = 0;
            double cottage_price = 0;
            double bill_amount = 0;

            double.TryParse(Txt10.Text, out no_of_occupants);
            double.TryParse(lblPrice.Text, out cottage_price);

            bill_amount = Math.Abs(no_of_occupants * cottage_price);
            Lbltot.Text = bill_amount.ToString();

        }
    }
}
