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

namespace bikeshowroom
{
    public partial class Form9 : Form
    {
        string idOrder = "\0";
        string userID;
        bool fromAccount;
        bool isPurch = true;
        public Form9(string orderID, bool isPurchase, string empID, bool fromAcc)
        {
            InitializeComponent();
            idOrder = orderID;
            isPurch = isPurchase;
            userID = empID;
            gridfill();
            fromAccount = fromAcc;
        }

        void gridfill()
        {
            string bikeInfoQuery = "\0";
            string cust_manufQuery = "\0";
            string empInfoQuery = "\0";
            string orderInfoQuery = "\0";

            if (isPurch)
            {
                bikeInfoQuery = " Select bike_record.name,bike_record.id,bike_record.model,bike_record.company FROM MANUF_ORDER " +
                    "INNER JOIN STOCK_PAYMENT ON MANUF_ORDER.ORDER_ID = STOCK_PAYMENT.ORDER_ID" +
                    " INNER JOIN bike_record ON MANUF_ORDER.BIKE_ID = bike_record.id WHERE STOCK_PAYMENT.ORDER_ID = @id";

                cust_manufQuery = "SELECT MANUFACTURER.MANUFACTURER_NAME, MANUFACTURER.MANUFACTURER_ID, MANUFACTURER.MANUFACTURER_CONTACT," +
                    " MANUFACTURER.MANUFACTURER_ADDRESS FROM STOCK_PAYMENT " +
                    "INNER JOIN MANUF_ORDER ON STOCK_PAYMENT.ORDER_ID = MANUF_ORDER.ORDER_ID " +
                    "INNER JOIN MANUFACTURER ON MANUF_ORDER.MANUFACTURER_ID = MANUFACTURER.MANUFACTURER_ID " +
                    "WHERE STOCK_PAYMENT.ORDER_ID =@id ";


                empInfoQuery = "Select EMPLOYEE.id, EMPLOYEE.name, EMPLOYEE.contact, EMPLOYEE.designation" +
                    " FROM STOCK_PAYMENT" +
                    " INNER JOIN MANUF_ORDER ON STOCK_PAYMENT.ORDER_ID = MANUF_ORDER.ORDER_ID " +
                    "INNER JOIN EMPLOYEE ON MANUF_ORDER.EMPLOYEE_ID = EMPLOYEE.id " +
                    "WHERE STOCK_PAYMENT.ORDER_ID =@id ";


                orderInfoQuery = "SELECT MANUF_ORDER.ORDER_ID, MANUF_ORDER.BILL, MANUF_ORDER.ORDER_DATE  " +
                    "FROM MANUF_ORDER " +
                    "INNER JOIN STOCK_PAYMENT ON STOCK_PAYMENT.ORDER_ID = MANUF_ORDER.ORDER_ID " +
                    "WHERE STOCK_PAYMENT.ORDER_ID = @id";

            }
            else
            {
                bikeInfoQuery = "Select	bike_record.name, bike_record.id, bike_record.model, bike_record.company FROM CUSTOMER_ORDER " +
                    "INNER JOIN SELL_PAYMENT ON SELL_PAYMENT.ORDER_ID = CUSTOMER_ORDER.ORDER_ID " +
                    "INNER JOIN bike_record ON CUSTOMER_ORDER.BIKE_ID = bike_record.id WHERE CUSTOMER_ORDER.ORDER_ID = @id";


                cust_manufQuery = "SELECT CUSTOMER.CUSTOMER_NAME, CUSTOMER.CUSTOMER_CNIC,CUSTOMER.CUSTOMER_CONTACT,CUSTOMER.CUSTOMER_ADDRESS " +
                    "FROM SELL_PAYMENT " +
                    "INNER JOIN CUSTOMER_ORDER ON SELL_PAYMENT.ORDER_ID = CUSTOMER_ORDER.ORDER_ID " +
                    "INNER JOIN CUSTOMER ON CUSTOMER_ORDER.CUSTOMER_CNIC = CUSTOMER.CUSTOMER_CNIC WHERE SELL_PAYMENT.ORDER_ID = @id ";


                empInfoQuery = "Select EMPLOYEE.id, EMPLOYEE.name, EMPLOYEE.contact, EMPLOYEE.designation" +
                    " FROM SELL_PAYMENT" +
                    " INNER JOIN CUSTOMER_ORDER ON SELL_PAYMENT.ORDER_ID = CUSTOMER_ORDER.ORDER_ID " +
                    "INNER JOIN EMPLOYEE ON CUSTOMER_ORDER.EMPLOYEE_ID = EMPLOYEE.id " +
                    "WHERE SELL_PAYMENT.ORDER_ID =@id ";

                orderInfoQuery = "SELECT CUSTOMER_ORDER.ORDER_ID, CUSTOMER_ORDER.BILL, CUSTOMER_ORDER.ORDER_DATE  " +
                    "FROM CUSTOMER_ORDER " +
                    "INNER JOIN SELL_PAYMENT ON SELL_PAYMENT.ORDER_ID = CUSTOMER_ORDER.ORDER_ID " +
                    "WHERE SELL_PAYMENT.ORDER_ID = @id";



            }
            data.con.Open();

            //Data for bike
            SqlCommand bikeInfoCmd = new SqlCommand(bikeInfoQuery, data.con);
            bikeInfoCmd.Parameters.AddWithValue("@id", idOrder);
            SqlDataAdapter bikeInfoAdapter = new SqlDataAdapter(bikeInfoCmd);
            DataSet bikeInfoData = new DataSet();
            bikeInfoAdapter.Fill(bikeInfoData);

            bikeNameLbl.Text = Convert.ToString(bikeInfoData.Tables[0].Rows[0].ItemArray[0]);
            bikeIDLbl.Text = Convert.ToString(bikeInfoData.Tables[0].Rows[0].ItemArray[1]);
            bikeCompanyLbl.Text = Convert.ToString(bikeInfoData.Tables[0].Rows[0].ItemArray[2]);
            bikeModelLbl.Text = Convert.ToString(bikeInfoData.Tables[0].Rows[0].ItemArray[3]);


            //Data for Employee
            SqlCommand empInfoCmd = new SqlCommand(empInfoQuery, data.con);
            empInfoCmd.Parameters.AddWithValue("@id", idOrder);
            SqlDataAdapter empInfoAdapter = new SqlDataAdapter(empInfoCmd);
            DataSet empInfoData = new DataSet();
            empInfoAdapter.Fill(empInfoData);

            empIDLbl.Text = Convert.ToString(empInfoData.Tables[0].Rows[0].ItemArray[0]);
            empNameLbl.Text = Convert.ToString(empInfoData.Tables[0].Rows[0].ItemArray[1]);
            empContactLbl.Text = Convert.ToString(empInfoData.Tables[0].Rows[0].ItemArray[2]);
            empDesignationLbl.Text = Convert.ToString(empInfoData.Tables[0].Rows[0].ItemArray[3]);

            //Data for Customer or Seller
            SqlCommand sellerCustInfoCmd = new SqlCommand(cust_manufQuery, data.con);
            sellerCustInfoCmd.Parameters.AddWithValue("@id", idOrder);
            SqlDataAdapter sellerCustInfoAdapter = new SqlDataAdapter(sellerCustInfoCmd);
            DataSet sellerCustInfoData = new DataSet();
            sellerCustInfoAdapter.Fill(sellerCustInfoData);

            sellerNameLbl.Text = Convert.ToString(sellerCustInfoData.Tables[0].Rows[0].ItemArray[0]);
            sellerIDLbl.Text = Convert.ToString(sellerCustInfoData.Tables[0].Rows[0].ItemArray[1]);
            sellerContactLbl.Text = Convert.ToString(sellerCustInfoData.Tables[0].Rows[0].ItemArray[2]);
            sellerAddressLbl.Text = Convert.ToString(sellerCustInfoData.Tables[0].Rows[0].ItemArray[3]);

            //Data for Order info
            SqlCommand orderInfoCmd = new SqlCommand(orderInfoQuery, data.con);
            orderInfoCmd.Parameters.AddWithValue("@id", idOrder);
            SqlDataAdapter orderInfoAdapter = new SqlDataAdapter(orderInfoCmd);
            DataSet orderInfoData = new DataSet();
            orderInfoAdapter.Fill(orderInfoData);

            orderIDLbl.Text = Convert.ToString(orderInfoData.Tables[0].Rows[0].ItemArray[0]);
            orderBillLbl.Text = Convert.ToString(orderInfoData.Tables[0].Rows[0].ItemArray[1]);
            orderDateLbl.Text = Convert.ToString(orderInfoData.Tables[0].Rows[0].ItemArray[2]);



            data.con.Close();


        }

        private void backBtn_MouseClick(object sender, MouseEventArgs e)
        {
            //if (fromAccount)
            //    new Form10(userID).Show();
            //else
            //    new Form8(userID).Show();
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
            exitBtn.BackColor = Color.White;
            exitBtn.ForeColor = Color.Red;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
