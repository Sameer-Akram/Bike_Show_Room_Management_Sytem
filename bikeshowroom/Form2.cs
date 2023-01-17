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

    public partial class Bike_Panel : Form
    {
       
        string empId = "";
        string BikeID = "";
        string C_Status = "";
        public Bike_Panel()
        {
            InitializeComponent();
            gridFill();
            this.CenterToScreen();
        }

        public Bike_Panel(string id)
        {
            InitializeComponent();
            this.CenterToScreen();
            data.con.Close();
            gridFill();
            empId = id;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backBtn_MouseClick(object sender, MouseEventArgs e)
        {
            data.con.Open();
            string checkEmpQuery = "select designation from employee where id = @id";
            SqlCommand checkEmpCmd = new SqlCommand(checkEmpQuery, data.con);
            checkEmpCmd.Parameters.AddWithValue("@id", empId);
            SqlDataAdapter checkEmpAdapter = new SqlDataAdapter(checkEmpCmd);
            DataSet empData = new DataSet();
            checkEmpAdapter.Fill(empData);

            string empDesig = Convert.ToString(empData.Tables[0].Rows[0].ItemArray[0]);
            data.con.Close();
            if (empDesig.ToLower() == "manager")
            {
                //this means that the user is manager
                new Manager_Menu(empId).Show();
                this.Hide();
            }
            else
            {
                new LogInForm().Show();
                this.Hide();
            }
        }

        private void exitBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void viewBikeGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = viewBikeGrid.Rows[rowIndex];

            string id = Convert.ToString(row.Cells[5].Value);

            string status = Convert.ToString(row.Cells[4].Value);
            BikeID = id;
            C_Status = status;

        }

        private void gridFill()
        {
           
            data.con.Open();
            SqlCommand viewBikeCmd = new SqlCommand("select * from bike_record", data.con);
            SqlDataAdapter viewBikeAdapter = new SqlDataAdapter(viewBikeCmd);
            DataSet BikeData = new DataSet();
            viewBikeAdapter.Fill(BikeData);

            viewBikeGrid.Rows.Clear();
            for (int i = 0; i < (BikeData.Tables[0].Rows.Count); i++)
            {
                string ID = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[0]);
                string Name = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[1]);
                string Model = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[2]);
                string Company = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[3]);
                string Price = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[4]);
                string Status = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[5]);

                DataGridViewRow pushData = new DataGridViewRow();
                pushData.CreateCells(viewBikeGrid);
                pushData.Cells[0].Value = Name;
                pushData.Cells[1].Value = Model;
                pushData.Cells[2].Value = Company;
                pushData.Cells[3].Value = Price;
                pushData.Cells[4].Value = Status;
                pushData.Cells[5].Value = ID;

                viewBikeGrid.Rows.Add(pushData);

            }

            data.con.Close();
        }

        private void viewAvailable()
        {
            
            data.con.Open();
            SqlCommand viewBikeCmd = new SqlCommand("select * from bike_record where status = 'Available'", data.con);
            SqlDataAdapter viewBikeAdapter = new SqlDataAdapter(viewBikeCmd);
            DataSet BikeData = new DataSet();
            viewBikeAdapter.Fill(BikeData);

            viewBikeGrid.Rows.Clear();
            for (int i = 0; i < (BikeData.Tables[0].Rows.Count); i++)
            {
                string ID = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[0]);
                string Name = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[1]);
                string Model = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[2]);
                string Company = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[3]);
                string Price = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[4]);
                string Status = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[5]);

                DataGridViewRow pushData = new DataGridViewRow();
                pushData.CreateCells(viewBikeGrid);
                pushData.Cells[0].Value = Name;
                pushData.Cells[1].Value = Model;
                pushData.Cells[2].Value = Company;
                pushData.Cells[3].Value = Price;
                pushData.Cells[4].Value = Status;
                pushData.Cells[5].Value = ID;

                viewBikeGrid.Rows.Add(pushData);

            }
            data.con.Close();
            
        }

        private void viewSold()
        {
            
            data.con.Open();
            SqlCommand viewBikeCmd = new SqlCommand("select * from bike_record where status = 'Sold'", data.con);
            SqlDataAdapter viewBikeAdapter = new SqlDataAdapter(viewBikeCmd);
            DataSet BikeData = new DataSet();
            viewBikeAdapter.Fill(BikeData);

            viewBikeGrid.Rows.Clear();
            for (int i = 0; i < (BikeData.Tables[0].Rows.Count); i++)
            {
                string ID = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[0]);
                string Name = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[1]);
                string Model = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[2]);
                string Company = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[3]);
                string Price = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[4]);
                string Status = Convert.ToString(BikeData.Tables[0].Rows[i].ItemArray[5]);

                DataGridViewRow pushData = new DataGridViewRow();
                pushData.CreateCells(viewBikeGrid);
                pushData.Cells[0].Value = Name;
                pushData.Cells[1].Value = Model;
                pushData.Cells[2].Value = Company;
                pushData.Cells[3].Value = Price;
                pushData.Cells[4].Value = Status;
                pushData.Cells[5].Value = ID;

                viewBikeGrid.Rows.Add(pushData);

            }
            data.con.Close();
            
        }

        private void buyBike()
        {
           
            data.con.Open();
            string checkEmpQuery = "select designation from employee where id = @id";
            SqlCommand checkEmpCmd = new SqlCommand(checkEmpQuery, data.con);
            checkEmpCmd.Parameters.AddWithValue("@id", empId);
            SqlDataAdapter checkEmpAdapter = new SqlDataAdapter(checkEmpCmd);
            DataSet empData = new DataSet();
            checkEmpAdapter.Fill(empData);

            string empDesig = Convert.ToString(empData.Tables[0].Rows[0].ItemArray[0]);
            Console.WriteLine(empDesig);
            data.con.Close();
            if (empDesig.ToLower() == "manager")
            {
                new BikeCtrl(empId).Show();
                this.Hide();
            }
            else if (empDesig.ToLower() == "salesman")
            {
                MessageBox.Show("You do not have Administrator Privilages.\nFor Addition of new stock inform higher authority.", "OK");
            }
            
        }

        private void BikeSell()
        {
            string id, status;
            id = BikeID;
            status = C_Status;
            if (status == "")
            {
                MessageBox.Show("No Stock Remaining.\nContact Higher Authority.", "OK");
            }
            else if (status.ToLower() == "available")
            {
                new BikeSell(empId, BikeID).Show();
                this.Hide();
            }
            else if (status.ToLower() == "sold")
            {
                MessageBox.Show("This Bike has already been Sold.\nSelect Another.", "OK");
            }
        }

        private void sellBikePanel_MouseClick(object sender, MouseEventArgs e)
        {
            BikeSell();
        }

        private void buyBikePanel_MouseClick(object sender, MouseEventArgs e)
        {
            buyBike();
        }

        private void viewSoldPanel_MouseClick(object sender, MouseEventArgs e)
        {
            viewSold();
        }

        private void viewAvailPanel_MouseClick(object sender, MouseEventArgs e)
        {
            viewAvailable();
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

        private void viewSoldPanel_MouseEnter(object sender, EventArgs e)
        {
            viewSoldPanel.BackColor = Color.FromArgb(0, 120, 120);
        }

        private void viewSoldPanel_MouseLeave(object sender, EventArgs e)
        {
            viewSoldPanel.BackColor = Color.Transparent;
        }

        private void viewAvailPanel_MouseEnter(object sender, EventArgs e)
        {
            viewAvailPanel.BackColor = Color.FromArgb(0, 120, 120);
        }

        private void viewAvailPanel_MouseLeave(object sender, EventArgs e)
        {
            viewAvailPanel.BackColor = Color.Transparent;
        }

        private void backBtn_MouseEnter(object sender, EventArgs e)
        {
            backBtn.BackColor = Color.FromArgb(0, 120, 120);
        }

        private void backBtn_MouseLeave(object sender, EventArgs e)
        {
            backBtn.BackColor = Color.Transparent;
        }

       
    }
}
