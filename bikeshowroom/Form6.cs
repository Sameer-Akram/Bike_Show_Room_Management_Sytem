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
    public partial class BikeCtrl : Form
    {
        string empID;
        bool mLicenceFlag, mNameFlag, mAddressFlag, mContactFlag, mEmailFlag;
        bool bIDFlag, bNameFlag, bModelFlag, bCompanyFlag, bPriceFlag;
        public BikeCtrl()
        {
            InitializeComponent();
        }
        public BikeCtrl(string id)
        {
            InitializeComponent();
            pictureVanish();
            emptyChecker();
            empID = id;
        }

        private void emptyChecker()
        {
            if (licenseBox.Text == "") mLicenceFlag = true;
            if (nameBox.Text == "") mNameFlag = true;
            if (contactBox.Text == "") mContactFlag = true;
            if (addressBox.Text == "") mAddressFlag = true;
            if (emailBox.Text == "") mEmailFlag = true;

            if (bIDBox.Text == "") bIDFlag = true;
            if (cNameBox.Text == "") bNameFlag = true;
            if (cModelBox.Text == "") bModelFlag = true;
            if (cCmpyBox.Text == "") bCompanyFlag = true;
            if (cPriceBox.Text == "") bPriceFlag = true;

        }
        private void pictureVanish()
        {
            manufLicenseErrorIcon.Visible = false;
            manufNameErrorIcon.Visible = false;
            manufContactErrorIcon.Visible = false;
            manufAddressErrorIcon.Visible = false;
            manufEmailErrorIcon.Visible = false;

            BikeIDErrorIcon.Visible = false;
            BikeNameErrorIcon.Visible = false;
            BikeModelErrorIcon.Visible = false;
            BikeCompanyErrorIcon.Visible = false;
            BikePriceErrorIcon.Visible = false;
        }
        private void clearRows()
        {
            licenseBox.Text = "";
            nameBox.Text = "";
            emailBox.Text = "";
            addressBox.Text = "";
            contactBox.Text = "";

            bIDBox.Text = "";
            cNameBox.Text = "";
            cModelBox.Text = "";
            cCmpyBox.Text = "";
            cPriceBox.Text = "";
        }

        private void buyBtn_MouseClick(object sender, MouseEventArgs e)
        {
            bool isOldSeller = false;
            bool isnewSeller = true;

            string manfID = licenseBox.Text;
            string manfName = nameBox.Text;
            string manfEmail = emailBox.Text;
            string manfAddress = addressBox.Text;
            string manfContact = contactBox.Text;

            string BikeID = bIDBox.Text;
            string bikeName = cNameBox.Text;
            string bikeModel = cModelBox.Text;
            string bikeCompany = cCmpyBox.Text;
            string bikePrice = cPriceBox.Text;

            if ((mLicenceFlag || mNameFlag || mContactFlag || mAddressFlag || mEmailFlag
                || bIDFlag || bNameFlag || bModelFlag || bPriceFlag || bCompanyFlag))
            {
                if (mLicenceFlag) manufLicenseErrorIcon.Visible = true;
                if (mNameFlag) manufNameErrorIcon.Visible = true;
                if (mContactFlag) manufContactErrorIcon.Visible = true;
                if (mAddressFlag) manufAddressErrorIcon.Visible = true;
                if (mEmailFlag) manufEmailErrorIcon.Visible = true;

                if (bIDFlag) BikeIDErrorIcon.Visible = true;
                if (bNameFlag) BikeNameErrorIcon.Visible = true;
                if (bModelFlag) BikeModelErrorIcon.Visible = true;
                if (bCompanyFlag) BikeCompanyErrorIcon.Visible = true;
                if (bPriceFlag) BikePriceErrorIcon.Visible = true;

                MessageBox.Show("The given input is invalid.\nPlease enter correct information and fill fields to their Rquired Limit.", "OK");

            }
            else
            {
                //this block of code will check whether the bike id is valid or not
                data.con.Open();
                string cIDCheckQuery = "select * from bike_record where id = @id";
                SqlCommand cIDCheckCMD = new SqlCommand(cIDCheckQuery, data.con);
                cIDCheckCMD.Parameters.AddWithValue("@id", BikeID);
                SqlDataAdapter cIDCheckAdapter = new SqlDataAdapter(cIDCheckCMD);
                DataSet cIDCheckSet = new DataSet();
                cIDCheckAdapter.Fill(cIDCheckSet);
                data.con.Close();
                if (cIDCheckSet.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("The Entered Bike ID is incorrect.\nPlease recheck it", "OK");
                    BikeIDErrorIcon.Visible = true;
                }
                else //if it is valid then validating manufacturer
                {

                    //this piece of code checks whether the primary key of manufacturer is repeated or not
                    data.con.Open();
                    string mIDCheckQuery = "select * from manufacturer where manufacturer_id = @id";
                    SqlCommand mIDCheckCMD = new SqlCommand(mIDCheckQuery, data.con);
                    mIDCheckCMD.Parameters.AddWithValue("@id", manfID);
                    SqlDataAdapter mIDCheckAdapter = new SqlDataAdapter(mIDCheckCMD);
                    DataSet mIDCheckSet = new DataSet();
                    mIDCheckAdapter.Fill(mIDCheckSet);
                    data.con.Close();

                    if (mIDCheckSet.Tables[0].Rows.Count > 0)
                    {
                        isnewSeller = false;
                        //now we will check whether the cnic matches with the name
                        data.con.Open();     //if manufacturer id is repeated then checking name
                        string nameCheckQuery = "select * from manufacturer where manufacturer_name = @name and manufacturer_id = @id " +
                            "and manufacturer_email = @email";
                        SqlCommand nameCheckCMD = new SqlCommand(nameCheckQuery, data.con);
                        nameCheckCMD.Parameters.AddWithValue("@name", manfName);
                        nameCheckCMD.Parameters.AddWithValue("@id", manfID);
                        nameCheckCMD.Parameters.AddWithValue("@email", manfEmail);
                        SqlDataAdapter nameCheckAdapter = new SqlDataAdapter(nameCheckCMD);
                        DataSet nameCheckSet = new DataSet();
                        nameCheckAdapter.Fill(nameCheckSet);
                        data.con.Close();
                        if (nameCheckSet.Tables[0].Rows.Count > 0) isOldSeller = true;
                        else
                        {
                            MessageBox.Show("The Given Manufacturer's License/Name are invalid. Please recheck them or inform developer", "OK");
                            manufLicenseErrorIcon.Visible = manufNameErrorIcon.Visible = true;
                        }

                    }
                    if (isnewSeller)
                    {
                        //this block of code will check whether the manufacturer email is valid or not as it is also a unique value
                        data.con.Open();
                        string mEmailCheckQuery = "select * from manufacturer where manufacturer_email = @email";
                        SqlCommand mEmailCheckCMD = new SqlCommand(mEmailCheckQuery, data.con);
                        mEmailCheckCMD.Parameters.AddWithValue("@email", manfEmail);
                        SqlDataAdapter mEmailCheckAdapter = new SqlDataAdapter(mEmailCheckCMD);
                        DataSet mEmailCheckSet = new DataSet();
                        mEmailCheckAdapter.Fill(mEmailCheckSet);
                        data.con.Close();
                        if (mEmailCheckSet.Tables[0].Rows.Count == 0)
                        {
                            data.con.Open();
                            //this block of code adds a new dealer or manufacturer
                            string manufAddQuery = "INSERT INTO manufacturer(manufacturer_id,manufacturer_name,manufacturer_contact,manufacturer_email,manufacturer_address) Values(@id,@name,@contact,@email,@address)";
                            SqlCommand manufAddCMD = new SqlCommand(manufAddQuery, data.con);
                            manufAddCMD.Parameters.AddWithValue("@id", manfID);
                            manufAddCMD.Parameters.AddWithValue("@name", manfName);
                            manufAddCMD.Parameters.AddWithValue("@email", manfEmail);
                            manufAddCMD.Parameters.AddWithValue("@address", manfAddress);
                            manufAddCMD.Parameters.AddWithValue("@contact", manfContact);
                            manufAddCMD.ExecuteNonQuery();
                            data.con.Close();
                        }
                        else
                        {
                            isnewSeller = false; //so that it doesnt go ahead storing data and getting an exception
                            MessageBox.Show("The given Email is invalid.\nPlease recheck it", "OK");
                            manufEmailErrorIcon.Visible = true;

                        }
                    }

                    if (isOldSeller || isnewSeller)
                    {
                        data.con.Open();

                        //this block of code adds new bike
                        string BikeAddQuery = "INSERT INTO bike_record(id,name,model,company,status,price) Values(@cID,@cName,@cModel,@cCompany,'Available',@cPrice)";
                        SqlCommand BikeAddCMD = new SqlCommand(BikeAddQuery, data.con);
                        BikeAddCMD.Parameters.AddWithValue("@cID", BikeID);
                        BikeAddCMD.Parameters.AddWithValue("@cName", bikeName);
                        BikeAddCMD.Parameters.AddWithValue("@cModel", bikeModel);
                        BikeAddCMD.Parameters.AddWithValue("@cCompany", bikeCompany);
                        BikeAddCMD.Parameters.AddWithValue("@cPrice", bikePrice);
                        BikeAddCMD.ExecuteNonQuery();

                        //this block is used to generate new order id by getting id from database just the digit part
                        string getOrderQuery = "Select ORDER_ID from MANUF_ORDER ";
                        SqlCommand getCmd = new SqlCommand(getOrderQuery, data.con);
                        SqlDataAdapter orderAdapter = new SqlDataAdapter(getCmd);
                        DataSet orderData = new DataSet();
                        orderAdapter.Fill(orderData);
                        String id;
                        if ((orderData.Tables[0].Rows.Count) > 0)
                        {
                            id =Convert.ToString("MOD"+((orderData.Tables[0].Rows.Count) + 1));
                        }
                        else
                        {
                            id = "MOD0";
                        }
                       
                        String OrderID = id; //function that generates the Order_ID
                        Console.WriteLine(OrderID);
                        //this block of code adds a new order given to the manufacturer
                        string addOrderQuery = "INSERT INTO MANUF_ORDER(ORDER_ID,EMPLOYEE_ID,BIKE_ID,MANUFACTURER_ID,ORDER_DATE,BILL) Values(@orderID,@empID,@bikeID,@manfID,getdate(),@bill)";
                        SqlCommand addOrderCMD = new SqlCommand(addOrderQuery, data.con);
                        addOrderCMD.Parameters.AddWithValue("@orderID", OrderID);
                        addOrderCMD.Parameters.AddWithValue("@empID", empID);
                        addOrderCMD.Parameters.AddWithValue("@bikeID", BikeID);
                        addOrderCMD.Parameters.AddWithValue("@manfID", manfID);
                        addOrderCMD.Parameters.AddWithValue("@bill", bikePrice);
                        addOrderCMD.ExecuteNonQuery();

                        //this block of code generates the payment for the purchase
                        string addBill = "INSERT INTO STOCK_PAYMENT(ORDER_ID,PAYMENT_DATE) Values(@id,getdate())";
                        SqlCommand addBillCMD = new SqlCommand(addBill, data.con);
                        addBillCMD.Parameters.AddWithValue("@id", OrderID);
                        addBillCMD.ExecuteNonQuery();

                        //this block of code adds the new bike into the stock
                        string addStock = "INSERT INTO Stock(Order_ID,Bike_ID,REC_DATE) Values(@oID,@cID,getdate())";
                        SqlCommand addStockCMD = new SqlCommand(addStock, data.con);
                        addStockCMD.Parameters.AddWithValue("@oID", OrderID);
                        addStockCMD.Parameters.AddWithValue("@cID", BikeID);
                        addStockCMD.ExecuteNonQuery();

                        //this block of Code will update the number of sales for that employee
                        string updateAccountQuery = "Insert into Account(MANF_Order,AMOUNT,IS_PAID,PAYMENT_DATE) Values(@order,@amount,'TRUE',GETDATE())";
                        SqlCommand updateAccountCMD = new SqlCommand(updateAccountQuery, data.con);
                        updateAccountCMD.Parameters.AddWithValue("@order", OrderID);
                        updateAccountCMD.Parameters.AddWithValue("@amount", bikePrice);
                        updateAccountCMD.ExecuteNonQuery();

                        data.con.Close();
                        MessageBox.Show("New bike has been Successfuly Added.");
                        clearRows();
                    }
                }



            }

        }


        //Basic Styling of Textboxes
        private void licenseBox_Enter(object sender, EventArgs e)
        {
            manufLicenseErrorIcon.Visible = false;
            licenseBox.BorderStyle = BorderStyle.None;
            licenseBox.BackColor = Color.FromArgb(0, 120, 120);
            licenseBox.ForeColor = Color.White;
        }
        private void licenseBox_Leave(object sender, EventArgs e)
        {
            if (licenseBox.Text == "")
            {
                manufLicenseErrorIcon.Visible = true;
                mLicenceFlag = true;
            }
            else
            {
                manufLicenseErrorIcon.Visible = false;
                mLicenceFlag = false;
            }
            manufLicenseErrorIcon.BackColor = Color.Transparent;
            licenseBox.BorderStyle = BorderStyle.Fixed3D;
            licenseBox.BackColor = Color.White;
            licenseBox.ForeColor = Color.FromArgb(77, 74, 82);
        }

        private void nameBox_Enter(object sender, EventArgs e)
        {
            manufNameErrorIcon.Visible = false;
            nameBox.BorderStyle = BorderStyle.None;
            nameBox.BackColor = Color.FromArgb(0, 120, 120);
            nameBox.ForeColor = Color.White;
        }
        private void nameBox_Leave(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                manufNameErrorIcon.Visible = true;
                mNameFlag = true;
            }
            else
            {
                manufNameErrorIcon.Visible = false;
                mNameFlag = false;
            }
            manufNameErrorIcon.BackColor = Color.Transparent;
            nameBox.BorderStyle = BorderStyle.Fixed3D;
            nameBox.BackColor = Color.White;
            nameBox.ForeColor = Color.FromArgb(0, 160, 160);
        }

        private void contactBox_Enter(object sender, EventArgs e)
        {
            manufContactErrorIcon.Visible = false;
            contactBox.BorderStyle = BorderStyle.None;
            contactBox.BackColor = Color.FromArgb(0, 120, 120);
            contactBox.ForeColor = Color.White;
        }
        private void contactBox_Leave(object sender, EventArgs e)
        {
            if (contactBox.Text == "" || contactBox.Text.Length != 11)
            {
                manufContactErrorIcon.Visible = true;
                mContactFlag = true;
            }
            else
            {
                manufContactErrorIcon.Visible = false;
                mContactFlag = false;
            }
            manufContactErrorIcon.BackColor = Color.Transparent;
            contactBox.BorderStyle = BorderStyle.Fixed3D;
            contactBox.BackColor = Color.White;
            contactBox.ForeColor = Color.FromArgb(0, 160, 160);
        }

        private void addressBox_Enter(object sender, EventArgs e)
        {
            manufAddressErrorIcon.Visible = false;
            addressBox.BorderStyle = BorderStyle.None;
            addressBox.BackColor = Color.FromArgb(0, 120, 120);
            addressBox.ForeColor = Color.White;
        }
        private void addressBox_Leave(object sender, EventArgs e)
        {
            if (addressBox.Text == "")
            {
                manufAddressErrorIcon.Visible = true;
                mAddressFlag = true;
            }
            else
            {
                manufAddressErrorIcon.Visible = false;
                mAddressFlag = false;
            }
            manufAddressErrorIcon.BackColor = Color.Transparent;
            addressBox.BorderStyle = BorderStyle.Fixed3D;
            addressBox.BackColor = Color.White;
            addressBox.ForeColor = Color.FromArgb(0, 160, 160);
        }

        private void emailBox_Enter(object sender, EventArgs e)
        {
            manufEmailErrorIcon.Visible = false;
            emailBox.BorderStyle = BorderStyle.None;
            emailBox.BackColor = Color.FromArgb(0, 120, 120);
            emailBox.ForeColor = Color.White;
        }
        private void emailBox_Leave(object sender, EventArgs e)
        {
            if (emailBox.Text == "")
            {
                manufEmailErrorIcon.Visible = true;
                mEmailFlag = true;
            }
            else
            {
                manufEmailErrorIcon.Visible = false;
                mEmailFlag = false;
            }
            manufEmailErrorIcon.BackColor = Color.Transparent;
            emailBox.BorderStyle = BorderStyle.Fixed3D;
            emailBox.BackColor = Color.White;
            emailBox.ForeColor = Color.FromArgb(0, 160, 160);
        }



        private void cIDBox_Enter(object sender, EventArgs e)
        {
            BikeIDErrorIcon.Visible = false;
            bIDBox.BorderStyle = BorderStyle.None;
            bIDBox.BackColor = Color.FromArgb(0, 120, 120);
            bIDBox.ForeColor = Color.White;
        }
        private void cIDBox_Leave(object sender, EventArgs e)
        {
            if (bIDBox.Text == "")
            {
                BikeIDErrorIcon.Visible = true;
                bIDFlag = true;
            }
            else
            {
                BikeIDErrorIcon.Visible = false;
                bIDFlag = false;
            }
            BikeIDErrorIcon.BackColor = Color.Transparent;
            bIDBox.BorderStyle = BorderStyle.Fixed3D;
            bIDBox.BackColor = Color.White;
            bIDBox.ForeColor = Color.FromArgb(0, 160, 160);
        }

        private void cNameBox_Enter(object sender, EventArgs e)
        {
            BikeNameErrorIcon.Visible = false;
            cNameBox.BorderStyle = BorderStyle.None;
            cNameBox.BackColor = Color.FromArgb(0, 120, 120);
            cNameBox.ForeColor = Color.White;
        }
        private void cNameBox_Leave(object sender, EventArgs e)
        {
            if (cNameBox.Text == "")
            {
                BikeNameErrorIcon.Visible = true;
                bNameFlag = true;
            }
            else
            {
                BikeNameErrorIcon.Visible = false;
                bNameFlag = false;
            }
            BikeIDErrorIcon.BackColor = Color.Transparent;
            cNameBox.BorderStyle = BorderStyle.Fixed3D;
            cNameBox.BackColor = Color.White;
            cNameBox.ForeColor = Color.FromArgb(0, 160, 160);
        }

        private void cModelBox_Enter(object sender, EventArgs e)
        {
            BikeModelErrorIcon.Visible = false;
            cModelBox.BorderStyle = BorderStyle.None;
            cModelBox.BackColor = Color.FromArgb(0, 120, 120);
            cModelBox.ForeColor = Color.White;
        }
        private void cModelBox_Leave(object sender, EventArgs e)
        {
            if (cModelBox.Text == "" || cModelBox.Text.Length != 4)
            {
                BikeModelErrorIcon.Visible = true;
                bModelFlag = true;
            }
            else
            {
                BikeModelErrorIcon.Visible = false;
                bModelFlag = false;
            }
            BikeModelErrorIcon.BackColor = Color.Transparent;
            cModelBox.BorderStyle = BorderStyle.Fixed3D;
            cModelBox.BackColor = Color.White;
            cModelBox.ForeColor = Color.FromArgb(0, 160, 160);
        }

        private void cCmpyBox_Enter(object sender, EventArgs e)
        {
            BikeCompanyErrorIcon.Visible = false;
            cCmpyBox.BorderStyle = BorderStyle.None;
            cCmpyBox.BackColor = Color.FromArgb(0, 120, 120);
            cCmpyBox.ForeColor = Color.White;
        }
        private void cCmpyBox_Leave(object sender, EventArgs e)
        {
            if (cCmpyBox.Text == "")
            {
                BikeCompanyErrorIcon.Visible = true;
                bCompanyFlag = true;
            }
            else
            {
                BikeCompanyErrorIcon.Visible = false;
                bCompanyFlag = false;
            }
            BikeCompanyErrorIcon.BackColor = Color.Transparent;
            cCmpyBox.BorderStyle = BorderStyle.Fixed3D;
            cCmpyBox.BackColor = Color.White;
            cCmpyBox.ForeColor = Color.FromArgb(0, 160, 160);
        }

        private void cPriceBox_Enter(object sender, EventArgs e)
        {
            BikePriceErrorIcon.Visible = false;
            cPriceBox.BorderStyle = BorderStyle.None;
            cPriceBox.BackColor = Color.FromArgb(0, 120, 120);
            cPriceBox.ForeColor = Color.White;
        }
        private void cPriceBox_Leave(object sender, EventArgs e)
        {
            if (cPriceBox.Text == "")
            {
                BikePriceErrorIcon.Visible = true;
                bPriceFlag = true;
            }
            else
            {
                BikePriceErrorIcon.Visible = false;
                bPriceFlag = false;
            }
            BikePriceErrorIcon.BackColor = Color.Transparent;
            cPriceBox.BorderStyle = BorderStyle.Fixed3D;
            cPriceBox.BackColor = Color.White;
            cPriceBox.ForeColor = Color.FromArgb(0, 160, 160);
        }


        //Code for validating each input
        private void licenseBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Input Incorrect.\nPlease Input in the way shown below each text field.", "OK");
                e.Handled = true;
            }
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
        private void emailBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || (e.KeyChar == '@')
                || (e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Input Incorrect.\nPlease Input in the way shown below each text field.", "OK");
                e.Handled = true;
            }
        }
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


        private void cNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Input Incorrect.\nPlease Input in the way shown below each text field.", "OK");
                e.Handled = true;
            }
        }
        private void cCmpyBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void cPriceBox_KeyPress(object sender, KeyPressEventArgs e)
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
        private void cModelBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void buyBtn_MouseEnter(object sender, EventArgs e)
        {
            buyBtn.BackColor = Color.FromArgb(0, 120, 120);
        }

        

        private void buyBtn_MouseLeave(object sender, EventArgs e)
        {
            buyBtn.BackColor = Color.FromArgb(0, 160, 160);
        }

        private void cIDBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Input Incorrect.\nPlease Input in the way shown below each text field.", "OK");
                e.Handled = true;
            }
        }



        //Back Button and Exit Button Styling
        private void backBtn_MouseClick(object sender, MouseEventArgs e)
        {
            new Bike_Panel(empID).Show();
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

    }
}
