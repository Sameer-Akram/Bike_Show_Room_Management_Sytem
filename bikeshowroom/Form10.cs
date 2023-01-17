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
    public partial class Form10 : Form
    {
        string userID, OrderID, isPurch;
        public Form10(string id)
        {
            InitializeComponent();
            gridFill();
            cashCollector();
            userID = id;
        }

        private void gridFill()
        {
            data.con.Open();
            SqlCommand accountAllCmd = new SqlCommand("select * from Account", data.con);
            SqlDataAdapter accountAllAdapter = new SqlDataAdapter(accountAllCmd);
            DataSet accountAllData = new DataSet();
            accountAllAdapter.Fill(accountAllData);
            viewBikeGrid.Rows.Clear();
            for (int i = 0; i < (accountAllData.Tables[0].Rows.Count); i++)
            {
                string manufOrder = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[0]);
                string custOrder;
                string Amount = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[1]);
                string isPayment = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[2]);
                string payDate = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[3]);

                DataGridViewRow pushData = new DataGridViewRow();
                pushData.CreateCells(viewBikeGrid);
                if (isPayment=="FALSE")
                {
                    custOrder = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[0]);
                    pushData.Cells[0].Value = custOrder;
                    pushData.Cells[3].Value = "Sale";

                }
                else
                {
                    pushData.Cells[0].Value = manufOrder;
                    pushData.Cells[3].Value = "Purchase";
                }

                pushData.Cells[1].Value = Amount;
                pushData.Cells[2].Value = Convert.ToDateTime(payDate).Date;


                viewBikeGrid.Rows.Add(pushData);

            }

            data.con.Close();
        }



        void checkSale()
        {
            data.con.Open();
            SqlCommand accountAllCmd = new SqlCommand("select * from Account where IS_PAID = 'FALSE'", data.con);
            SqlDataAdapter accountAllAdapter = new SqlDataAdapter(accountAllCmd);
            DataSet accountAllData = new DataSet();
            accountAllAdapter.Fill(accountAllData);

            viewBikeGrid.Rows.Clear();
            for (int i = 0; i < (accountAllData.Tables[0].Rows.Count); i++)
            {
                string custOrder = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[0]);
                string Amount = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[1]);
                string isPayment = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[2]);
                string payDate = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[3]);

                DataGridViewRow pushData = new DataGridViewRow();
                pushData.CreateCells(viewBikeGrid);

                pushData.Cells[0].Value = custOrder;
                pushData.Cells[3].Value = "Sale";

                pushData.Cells[1].Value = Amount;
                pushData.Cells[2].Value = Convert.ToDateTime(payDate).Date;


                viewBikeGrid.Rows.Add(pushData);

            }

            data.con.Close();
        }

        void checkPurch()
        {
            data.con.Open();
            SqlCommand accountAllCmd = new SqlCommand("select * from Account where IS_PAID = 'TRUE'", data.con);
            SqlDataAdapter accountAllAdapter = new SqlDataAdapter(accountAllCmd);
            DataSet accountAllData = new DataSet();
            accountAllAdapter.Fill(accountAllData);

            viewBikeGrid.Rows.Clear();
            for (int i = 0; i < (accountAllData.Tables[0].Rows.Count); i++)
            {
                string manfOrder = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[0]);
                string Amount = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[1]);
                string isPayment = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[2]);
                string payDate = Convert.ToString(accountAllData.Tables[0].Rows[i].ItemArray[3]);

                DataGridViewRow pushData = new DataGridViewRow();
                pushData.CreateCells(viewBikeGrid);

                pushData.Cells[0].Value = manfOrder;
                pushData.Cells[3].Value = "Purchase";

                pushData.Cells[1].Value = Amount;
                pushData.Cells[2].Value = Convert.ToDateTime(payDate).Date;


                viewBikeGrid.Rows.Add(pushData);

            }

            data.con.Close();
        }

        private void cashCollector()
        {
            data.con.Open();
            SqlCommand recAmountCmd = new SqlCommand("select sum(Account.Amount) from Account where Account.IS_PAID = 'FALSE' ", data.con);
            SqlDataAdapter recAmountAdapter = new SqlDataAdapter(recAmountCmd);
            DataSet recAmountData = new DataSet();
            recAmountAdapter.Fill(recAmountData);
            string amountRecieved = Convert.ToString(recAmountData.Tables[0].Rows[0].ItemArray[0]);

            SqlCommand spentAmountCmd = new SqlCommand("select sum(Account.Amount) from Account where Account.IS_PAID = 'TRUE' ", data.con);
            SqlDataAdapter spentAmountAdapter = new SqlDataAdapter(spentAmountCmd);
            DataSet spentAmountData = new DataSet();
            spentAmountAdapter.Fill(spentAmountData);
            string amountSpent = Convert.ToString(spentAmountData.Tables[0].Rows[0].ItemArray[0]);

            SqlCommand netAmountCmd = new SqlCommand("SELECT (SELECT SUM(ACCOUNT.AMOUNT) FROM ACCOUNT WHERE ACCOUNT.IS_PAID = 'FALSE') - (SELECT SUM(ACCOUNT.AMOUNT) FROM ACCOUNT WHERE ACCOUNT.IS_PAID = 'TRUE')", data.con);
            SqlDataAdapter netAmountAdapter = new SqlDataAdapter(netAmountCmd);
            DataSet netAmountData = new DataSet();
            netAmountAdapter.Fill(netAmountData);
            string amountNet = Convert.ToString(netAmountData.Tables[0].Rows[0].ItemArray[0]);

            data.con.Close();

            amountRecLbl.Text = amountRecieved;
            amountSpentLbl.Text = amountSpent;
            netAmountLbl.Text = amountNet;
        }

        private void sellBikePanel_MouseClick(object sender, MouseEventArgs e)
        {
            checkSale();
        }

        private void buyBikePanel_MouseClick(object sender, MouseEventArgs e)
        {
            checkPurch();
        }

        private void total_detaills_MouseClick(object sender, MouseEventArgs e)
        {
            gridFill();
        }

        private void backBtn_MouseClick(object sender, MouseEventArgs e)
        {
            new Manager_Menu(userID).Show();
            this.Hide();

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

        private void total_detaills_MouseEnter(object sender, EventArgs e)
        {
            totaldetaills.BackColor = Color.FromArgb(0, 120, 120);
        }

        private void total_detaills_MouseLeave(object sender, EventArgs e)
        {
            totaldetaills.BackColor = Color.Transparent;

        }

        private void backBtn_MouseEnter(object sender, EventArgs e)
        {
            backBtn.BackColor = Color.FromArgb(0, 120, 120);

        }

        private void viewBikeGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isPurchase;
            if (isPurch == "Sale")
            {
                isPurchase = false;
            }
            else
                isPurchase = true;



            Form formBackground = new Form();
            try
            {
                using (Form9 uu = new Form9(OrderID, isPurchase, userID, false))
                {
                    formBackground.StartPosition = FormStartPosition.CenterScreen;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .50d;
                    //formBackground.BackColor = Color.Black;
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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backBtn_MouseLeave(object sender, EventArgs e)
        {
            backBtn.BackColor = Color.Transparent;

        }

        private void viewBikeGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            DataGridViewRow row = viewBikeGrid.Rows[rowIndex];

            OrderID = Convert.ToString(row.Cells[0].Value);
            isPurch = Convert.ToString(row.Cells[3].Value);

        }
    }
}
