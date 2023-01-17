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
    public partial class Form8 : Form
    {
        string OrderID, userID;
        bool isPurchase;
        public Form8(string empID)
        {
            InitializeComponent();
            purchGridFill();
            userID = empID;
        }

        private void purchGridFill()
        {
            viewBikeGrid.Columns[3].Visible = true;
            viewBikeGrid.Columns[4].Visible = false;
            isPurchase = true;

            data.con.Open();
            string saleQuery = "Select STOCK_PAYMENT.ORDER_ID, bike_record.name,EMPLOYEE.name,MANUFACTURER.MANUFACTURER_NAME,MANUF_ORDER.BILL, STOCK_PAYMENT.PAYMENT_DATE from STOCK_PAYMENT inner join MANUF_ORDER on STOCK_PAYMENT.ORDER_ID = MANUF_ORDER.ORDER_ID inner join bike_record on MANUF_ORDER.BIKE_ID = bike_record.id inner join EMPLOYEE on MANUF_ORDER.EMPLOYEE_ID = EMPLOYEE.id inner join MANUFACTURER on MANUF_ORDER.MANUFACTURER_ID = MANUFACTURER.MANUFACTURER_ID";
            SqlCommand viewBikeCmd = new SqlCommand(saleQuery, data.con);
            SqlDataAdapter viewBikeAdapter = new SqlDataAdapter(viewBikeCmd);
            DataSet BikeData = new DataSet();
            viewBikeAdapter.Fill(BikeData);

            viewBikeGrid.Rows.Clear();
            for (int i = 0; i < (BikeData.Tables[0].Rows.Count); i++)
            {
                string PaymentID = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[0]);
                string BikeName = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[1]);
                string EmployeeName = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[2]);
                string ManufacturerName = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[3]);
                string Bill = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[4]);
                string Date = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[5]);

                DateTime newDate = Convert.ToDateTime(Date).Date;

                DataGridViewRow pushData = new DataGridViewRow();
                pushData.CreateCells(viewBikeGrid);
                pushData.Cells[0].Value = PaymentID;
                pushData.Cells[1].Value = BikeName;
                pushData.Cells[2].Value = EmployeeName;
                pushData.Cells[3].Value = ManufacturerName;
                pushData.Cells[5].Value = Bill;
                pushData.Cells[6].Value = newDate;

                viewBikeGrid.Rows.Add(pushData);

            }

            data.con.Close();
        }

        private void salesGridFill()
        {
            viewBikeGrid.Columns[3].Visible = false;
            viewBikeGrid.Columns[4].Visible = true;
            isPurchase = false;

            data.con.Open();
            string purchQuery = "Select SELL_PAYMENT.ORDER_ID, bike_record.name, EMPLOYEE.name, CUSTOMER.CUSTOMER_NAME,CUSTOMER_ORDER.BILL, SELL_PAYMENT.PAYMENT_DATE from SELL_PAYMENT inner join CUSTOMER_ORDER on SELL_PAYMENT.ORDER_ID = CUSTOMER_ORDER.ORDER_ID inner join bike_record on CUSTOMER_ORDER.BIKE_ID = bike_record.id inner join EMPLOYEE on CUSTOMER_ORDER.EMPLOYEE_ID = EMPLOYEE.id inner join CUSTOMER on CUSTOMER_ORDER.CUSTOMER_CNIC = CUSTOMER.CUSTOMER_CNIC";
            SqlCommand viewBikeCmd = new SqlCommand(purchQuery, data.con);
            SqlDataAdapter viewBikeAdapter = new SqlDataAdapter(viewBikeCmd);
            DataSet BikeData = new DataSet();
            viewBikeAdapter.Fill(BikeData);

            viewBikeGrid.Rows.Clear();
            for (int i = 0; i < (BikeData.Tables[0].Rows.Count); i++)
            {
                string PaymentID = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[0]);
                string BikeName = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[1]);
                string EmployeeName = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[2]);
                string CustomerName = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[3]);
                string Bill = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[4]);
                string Date = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[5]);

                DateTime newDate = Convert.ToDateTime(Date).Date;

                DataGridViewRow pushData = new DataGridViewRow();
                pushData.CreateCells(viewBikeGrid);
                pushData.Cells[0].Value = PaymentID;
                pushData.Cells[1].Value = BikeName;
                pushData.Cells[2].Value = EmployeeName;
                pushData.Cells[4].Value = CustomerName;
                pushData.Cells[5].Value = Bill;
                pushData.Cells[6].Value = newDate;

                viewBikeGrid.Rows.Add(pushData);

            }

            data.con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sellBikePanel_MouseClick(object sender, MouseEventArgs e)
        {
            salesGridFill();
        }

        private void buyBikePanel_MouseClick(object sender, MouseEventArgs e)
        {
            purchGridFill();
        }

        private void exitBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void viewBikeGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (Form9 uu = new Form9(OrderID, isPurchase, userID, false))
                {
                    formBackground.StartPosition = FormStartPosition.CenterScreen;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .50d;
                //    formBackground.BackColor = Color.Black;
                    formBackground.WindowState = FormWindowState.Normal;
                    formBackground.TopMost = true;
                    formBackground.Location = this.Location;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    uu.Owner = formBackground;
                    uu.ShowDialog();

                    formBackground.Dispose();
                    formBackground.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
                formBackground.Hide();
            }
        }

        private void viewBikeGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = viewBikeGrid.Rows[rowIndex];

            OrderID = Convert.ToString(row.Cells[0].Value);
        }

        private void sellBikePanel_MouseEnter(object sender, EventArgs e)
        {
            sellBikePanel.BackColor = Color.FromArgb(0, 120, 120);
        }

        private void sellBikePanel_MouseLeave(object sender, EventArgs e)
        {
            sellBikePanel.BackColor = Color.Transparent;
        }

        private void buyBikePanel_MouseEnter(object sender, EventArgs e)
        {
            buyBikePanel.BackColor = Color.FromArgb(0, 120, 120);
        }

        private void buyBikePanel_MouseLeave(object sender, EventArgs e)
        {
            buyBikePanel.BackColor = Color.Transparent;
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
            Application.Exit();
        }

        private void backBtn_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            new Manager_Menu(userID).Show();
        }
    }

}
