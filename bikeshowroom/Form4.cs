using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bikeshowroom
{
    public partial class BikeSell : Form
    {
        string empId, BikeID;
        bool nameFlag, cnicFlag, addressFlag, contactFlag;

        public BikeSell()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public BikeSell(string id)
        {
            InitializeComponent();
            empId = id;
            this.CenterToScreen();
        }
        public BikeSell(string id, string bikeID)
        {
            InitializeComponent();
            empId = id;
            BikeID = bikeID;
            pictureVanish();
            startChecker();
        }

        private void pictureVanish()
        {
            nameBoxErrorIcon.Visible = false;
            cnicBoxErrorIcon.Visible = false;
            addressBoxErrorIcon.Visible = false;
            contactBoxErrorIcon.Visible = false;
        }
        private void startChecker()
        {
            if (nameBox.Text == "")
            {
                nameFlag = true;
            }

            if (cnicBox.Text == "")
            {
                cnicFlag = true;
            }
            if (addressBox.Text == "")
            {
                addressFlag = true;
            }

            if (contactBox.Text == "")
            {
                contactFlag = true;
            }
        }



        private void exitBtn_MouseEnter(object sender, EventArgs e)
        {
            exitBtn.BackColor = Color.Red;
            exitBtn.ForeColor = Color.White;
        }
        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            exitBtn.BackColor = Color.Transparent;
            exitBtn.ForeColor = Color.Red;
        }


        private void backBtn_MouseClick(object sender, MouseEventArgs e)
        {
            new Bike_Panel(empId).Show();
            this.Hide();
        }
        private void backBtn_MouseEnter(object sender, EventArgs e)
        {
            backBtn.BackColor = Color.FromArgb(0, 120, 120);
        }
        private void backBtn_MouseLeave(object sender, EventArgs e)
        {
            backBtn.BackColor = Color.Transparent;
        }


        private void sellBtn_MouseEnter(object sender, EventArgs e)
        {
            sellBtn.BackColor = Color.FromArgb(0, 120, 120);
        }
        private void sellBtn_MouseLeave(object sender, EventArgs e)
        {
            sellBtn.BackColor = Color.FromArgb(0, 120, 120);
        }
        private void sellBtn_MouseClick(object sender, MouseEventArgs e)
        {
            string cust_name, cust_cnic, cust_address, cust_contact;
            bool oldCustomer = false;
            bool newCustomer = true;
            cust_name = nameBox.Text;
            cust_cnic = cnicBox.Text;
            cust_address = addressBox.Text;
            cust_contact = contactBox.Text;
            if ((nameFlag || cnicFlag || addressFlag || contactFlag) == true)
            {
                if (nameFlag) nameBoxErrorIcon.Visible = true;
                if (cnicFlag) cnicBoxErrorIcon.Visible = true;
                if (addressFlag) addressBoxErrorIcon.Visible = true;
                if (contactFlag) contactBoxErrorIcon.Visible = true;

                MessageBox.Show("The given input is invalid.\nPlease enter correct information and fill fields to required information.", "OK");
            }
            else
            {
                /*so the way this thing works is that it first checks repition of cnic
                 if its not repeated then it is a new customer else it checks the name whether its an 
                old customer or invalid input*/

                //this piece of code checks whether the primary key is repeated or not
                data.con.Open();
                string cnicCheckQuery = "select * from CUSTOMER where CUSTOMER_CNIC = @id";
                SqlCommand cnicCheckCMD = new SqlCommand(cnicCheckQuery, data.con);
                cnicCheckCMD.Parameters.AddWithValue("@id", cust_cnic);
                SqlDataAdapter cnicCheckAdapter = new SqlDataAdapter(cnicCheckCMD);
                DataSet cnicCheckSet = new DataSet();
                cnicCheckAdapter.Fill(cnicCheckSet);
                data.con.Close();

                if ((cnicCheckSet.Tables[0].Rows.Count) > 0)
                {
                    newCustomer = false;
                    data.con.Open();     //if CNIC is repeated then checking name
                    string nameCheckQuery = "select * from CUSTOMER where CUSTOMER_NAME = @name and CUSTOMER_CNIC = @id";
                    SqlCommand nameCheckCMD = new SqlCommand(nameCheckQuery, data.con);
                    nameCheckCMD.Parameters.AddWithValue("@name", cust_name);
                    nameCheckCMD.Parameters.AddWithValue("@id", cust_cnic);
                    SqlDataAdapter nameCheckAdapter = new SqlDataAdapter(nameCheckCMD);
                    DataSet nameCheckSet = new DataSet();
                    nameCheckAdapter.Fill(nameCheckSet);
                    data.con.Close();
                    //if its true then its an old customer otherwise invalid input
                    if (nameCheckSet.Tables[0].Rows.Count > 0) oldCustomer = true;
                    else MessageBox.Show("The given CNIC/Name are Invalid. Please Input Correct CNIC and Name.", "OK");
                }
                if (newCustomer)
                {
                    //if its a new customer we add it in the database
                    //this block is used to insert the values in the column of customer
                    data.con.Open();
                    string insertQuery = "Insert into CUSTOMER(CUSTOMER_CNIC,CUSTOMER_NAME,CUSTOMER_CONTACT,CUSTOMER_ADDRESS) VALUES(@cnic,@name,@contact,@address)";
                    SqlCommand cmd = new SqlCommand(insertQuery, data.con);
                    cmd.Parameters.AddWithValue("@cnic", cust_cnic);
                    cmd.Parameters.AddWithValue("@name", cust_name);
                    cmd.Parameters.AddWithValue("@contact", cust_contact);
                    cmd.Parameters.AddWithValue("@address", cust_address);
                    cmd.ExecuteNonQuery();
                    data.con.Close();
                }
                if (oldCustomer || newCustomer)
                {
                    //from  here we have validated or added customer so we just resume the selling process
                    data.con.Open();
                    //this block is used to generate new order id by getting id from database just the digit part
                    string getOrderQuery = "Select ORDER_ID from CUSTOMER_ORDER ";
                    SqlCommand getCmd = new SqlCommand(getOrderQuery, data.con);
                    SqlDataAdapter orderAdapter = new SqlDataAdapter(getCmd);
                    DataSet orderData = new DataSet();
                    orderAdapter.Fill(orderData);
                    String id;
                    if ((orderData.Tables[0].Rows.Count) > 0)
                    {
                        id = Convert.ToString("COD" + ((orderData.Tables[0].Rows.Count) + 1));
                    }
                    else
                    {
                        id = "COD0";
                    }

                    String OrderID = id; //function that generates the Order_ID

                    //this block of code gets the price of car from database and increases it by 10%
                    string getPriceQuery = "Select bike_record.price from bike_record where bike_record.id = @id";
                    SqlCommand getPriceCmd = new SqlCommand(getPriceQuery, data.con);
                    getPriceCmd.Parameters.AddWithValue("@id", BikeID);
                    SqlDataAdapter priceAdapter = new SqlDataAdapter(getPriceCmd);
                    DataSet priceData = new DataSet();
                    priceAdapter.Fill(priceData);
                    int price = Convert.ToInt32(priceData.Tables[0].Rows[0].ItemArray[0]);
                    int newBill = price + ((price * 7) / 100);

                    //this block of code is used to store data for the order given by customer
                    string upOrderQuery = "Insert into Customer_Order(order_id,employee_id,bike_id,customer_cnic,order_date,bill) values(@Oid,@EmpID,@CiD,@cnic,getDate(),@bill)";
                    SqlCommand upCMD = new SqlCommand(upOrderQuery, data.con);
                    upCMD.Parameters.AddWithValue("@Oid", OrderID);
                    upCMD.Parameters.AddWithValue("@EmpID", empId);
                    upCMD.Parameters.AddWithValue("@CiD", BikeID);
                    upCMD.Parameters.AddWithValue("@cnic", cust_cnic);
                    upCMD.Parameters.AddWithValue("@bill", newBill);
                    upCMD.ExecuteNonQuery();

                    //this block of code is used to store data about the payment of sold car
                    string paymentQuery = "insert into SELL_PAYMENT(Order_ID,payment_Date) values(@order,getDate())";
                    SqlCommand paymentCMD = new SqlCommand(paymentQuery, data.con);
                    paymentCMD.Parameters.AddWithValue("@order", OrderID);
                    paymentCMD.ExecuteNonQuery();

                    //this block of code runs query that changes the status of car from available to sold
                    string updateCarQuery = "update bike_record set bike_record.status='Sold' where id = @id";
                    SqlCommand updateCMD = new SqlCommand(updateCarQuery, data.con);
                    updateCMD.Parameters.AddWithValue("@id", BikeID);
                    updateCMD.ExecuteNonQuery();


                    //this block of Code will update the number of sales for that employee
                    string updateSalesQuery = "Update employee set sales = (sales+1) where id = @id";
                    SqlCommand updateSaleCMD = new SqlCommand(updateSalesQuery, data.con);
                    updateSaleCMD.Parameters.AddWithValue("@id", empId);
                    updateSaleCMD.ExecuteNonQuery();

                    //this block of Code will update the number of sales for that employee
                    string updateAccountQuery = "Insert into Account(MANF_Order,AMOUNT,IS_PAID,PAYMENT_DATE) Values(@order,@amount,'FALSE',GETDATE())";
                    SqlCommand updateAccountCMD = new SqlCommand(updateAccountQuery, data.con);
                    updateAccountCMD.Parameters.AddWithValue("@order", OrderID);
                    updateAccountCMD.Parameters.AddWithValue("@amount", newBill);
                    updateAccountCMD.ExecuteNonQuery();

                    MessageBox.Show("Transaction Has been Completed Successfuly.");
                    data.con.Close();
                    new Bike_Panel(empId).Show();
                    this.Close();


                    nameBox.Text = "";
                    cnicBox.Text = "";
                    addressBox.Text = "";
                    contactBox.Text = "";

                }
            }

        }



        // This Block Contains the code for when does the focus comes into the textboxes
        private void nameBox_Enter(object sender, EventArgs e)
        {
            nameBoxErrorIcon.Visible = false;
            nameBox.BorderStyle = BorderStyle.None;
            nameBox.BackColor = Color.FromArgb(0, 120, 120);
            nameBox.ForeColor = Color.White;
        }
        private void nameBox_Leave(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                nameBoxErrorIcon.Visible = true;
                nameFlag = true;
            }
            else
            {
                nameBoxErrorIcon.Visible = false;
                nameFlag = false;
            }
            nameBoxErrorIcon.BackColor = Color.Transparent;
            nameBox.BorderStyle = BorderStyle.Fixed3D;
            nameBox.BackColor = Color.White;
            nameBox.ForeColor = Color.FromArgb(0, 120, 120);
        }

        private void cnicBox_Enter(object sender, EventArgs e)
        {
            cnicBoxErrorIcon.Visible = false;
            cnicBox.BorderStyle = BorderStyle.None;
            cnicBox.BackColor = Color.FromArgb(0, 120, 120);
            cnicBox.ForeColor = Color.White;
        }
        private void cnicBox_Leave(object sender, EventArgs e)
        {
            if ((cnicBox.Text == "") || (cnicBox.Text.Length != 13))
            {
                cnicBoxErrorIcon.Visible = true;
                cnicFlag = true;
            }
            else if (cnicBox.Text.Length == 13)
            {
                cnicBoxErrorIcon.Visible = false;
                cnicFlag = false;
            }
            cnicBoxErrorIcon.BackColor = Color.Transparent;
            cnicBox.BorderStyle = BorderStyle.Fixed3D;
            cnicBox.BackColor = Color.White;
            cnicBox.ForeColor = Color.FromArgb(0, 120, 120);
        }

        private void addressBox_Enter(object sender, EventArgs e)
        {
            addressBoxErrorIcon.Visible = false;
            addressBox.BorderStyle = BorderStyle.None;
            addressBox.BackColor = Color.FromArgb(0, 120, 120);
            addressBox.ForeColor = Color.White;
        }
        private void addressBox_Leave(object sender, EventArgs e)
        {
            if (addressBox.Text == "")
            {
                addressBoxErrorIcon.Visible = true;
                addressFlag = true;
            }
            else
            {
                addressBoxErrorIcon.Visible = false;
                addressFlag = false;
            }
            addressBoxErrorIcon.BackColor = Color.Transparent;
            addressBox.BorderStyle = BorderStyle.Fixed3D;
            addressBox.BackColor = Color.White;
            addressBox.ForeColor = Color.FromArgb(0, 120, 120);
        }

        private void contactBox_Enter(object sender, EventArgs e)
        {
            contactBoxErrorIcon.Visible = false;
            contactBox.BorderStyle = BorderStyle.None;
            contactBox.BackColor = Color.FromArgb(0, 120, 120);
            contactBox.ForeColor = Color.White;
        }
        private void contactBox_Leave(object sender, EventArgs e)
        {
            if ((contactBox.Text == "") || ((contactBox.Text.Length) != 11))
            {
                contactBoxErrorIcon.Visible = true;
                contactFlag = true;
            }
            else if (contactBox.Text.Length == 11)
            {
                contactBoxErrorIcon.Visible = false;
                contactFlag = false;
            }
            contactBoxErrorIcon.BackColor = Color.Transparent;
            contactBox.BorderStyle = BorderStyle.Fixed3D;
            contactBox.BackColor = Color.White;
            contactBox.ForeColor = Color.FromArgb(0, 120, 120);
        }




        //this code will help in validating the input

        private void nameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Input Incorrect.\nPlease Input in the way shown below each text field.", "OK");
                e.Handled = true;
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void contactBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void addressBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || (e.KeyChar == '/')
                || (e.KeyChar == '#') || (e.KeyChar == ',') || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Input Incorrect.\nPlease Input in the way shown below each text field.", "OK");
                e.Handled = true;
            }

        }

        private void cnicBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Input Incorrect.\nPlease Input in the way shown below each text field.", "OK");
                e.Handled = true;
            }
        }


        private string idGenerator(string id)
        {
            string digits, letters;
            letters = "COD";
            if (id == string.Empty)
            {
                digits = "000";
            }
            else
            {
                digits = new string(id.Where(char.IsDigit).ToArray());
            }
            int number;
            int.TryParse(digits, out number);
            string new_id = letters + (++number).ToString("D4");

            return new_id;
        }

    }
}
