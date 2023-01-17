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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bikeshowroom
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            LblVanish();
            pinBox.PasswordChar = '*';

        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void nameBox_Enter(object sender, EventArgs e)
        {
            if (nameBox.Text == "Username")
            {
                nameBox.Text = "";
            }
            namePnl.BorderStyle = BorderStyle.FixedSingle;
            namePnl.BackColor = Color.FromArgb(0, 130, 130);
            nameBox.BackColor = Color.FromArgb(0, 130, 130);
            nameBox.ForeColor = Color.White;
            userImage.BackColor = Color.FromArgb(0, 130, 130);
            lockImage.BackColor = Color.White;
            LblVanish();

        }
        private void nameBox_Leave(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                nameBox.Text = "Username";
            }
            namePnl.BackColor = Color.White;
            nameBox.BackColor = Color.White;
            nameBox.ForeColor = Color.Black;
            userImage.BackColor = Color.White;

        }
        private void pinBox_Enter(object sender, EventArgs e)
        {
            if (pinBox.Text == "Password")
            {
                pinBox.Text = "";
                pinBox.PasswordChar = '*';
            }
            pinPnl.BorderStyle = BorderStyle.FixedSingle;
            pinPnl.BackColor = Color.FromArgb(0, 130, 130);
            pinBox.BackColor = Color.FromArgb(0, 130, 130);
            pinBox.ForeColor = Color.White;
            lockImage.BackColor = Color.FromArgb(0, 130, 130);
            userImage.BackColor = Color.White;
            LblVanish();
        }
        private void pinBox_Leave(object sender, EventArgs e)
        {
            if (pinBox.Text == "")
            {
                pinBox.Text = "Password";
                pinBox.PasswordChar = '\0';
            }
            pinPnl.BackColor = Color.White;
            pinBox.BackColor = Color.White;
            pinBox.ForeColor = Color.Black;
            lockImage.BackColor = Color.White;
        }
        private void logBtn_MouseEnter(object sender, EventArgs e)
        {
            logBtn.FlatAppearance.BorderColor = Color.White;
            logBtn.FlatAppearance.BorderSize = 1;
            logBtn.BackColor = Color.FromArgb(34, 36, 49);
            logBtn.ForeColor = Color.White;
        }
        private void logBtn_MouseLeave(object sender, EventArgs e)
        {
            logBtn.BackColor = Color.White;
            logBtn.ForeColor = Color.Black;
        }
        private void exitBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void exitBtn_MouseEnter(object sender, EventArgs e)
        {
            exitBtn.BackColor = Color.Red;
            exitBtn.ForeColor = Color.White;
        }
        private void LblVanish()
        {
            nameErrorIcon.Visible = false;
            pinErrorIcon.Visible = false;
        }
        private void LblVisible()
        {
            nameErrorIcon.Visible = true;
            pinErrorIcon.Visible = true;
       
        }

        private void exitBtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            String Desgination;
            String status;
            String user=nameBox.Text;
            String pass= pinBox.Text;
           
            try
            {
                data.con.Open();
                String query = "select * from employee where name = '" + user + "' and password = '" + pass + "'";

                SqlDataAdapter sda = new SqlDataAdapter(query, data.con);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    Desgination = Convert.ToString(dt.Rows[0].ItemArray[6]);
                    status = Convert.ToString(dt.Rows[0].ItemArray[9]);
                    String id = Convert.ToString(dt.Rows[0].ItemArray[0]);
                    if (status.ToLower() == "working")
                    {
                        if (Desgination.ToLower() == "salesman")
                        {
                            new Bike_Panel(id).Show();
                            this.Hide();
                        }
                        else if (Desgination.ToLower() == "manager")
                        {

                            new Manager_Menu(id).Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nameBox.Clear();
                        pinBox.Clear();
                        nameBox.Focus();
                        LblVisible();

                    }


                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nameBox.Clear();
                    pinBox.Clear();
                    nameBox.Focus();
                    LblVisible();


                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                data.con.Close();
            }
        }


        private void logBtn_enter1(object sender, EventArgs e)
        {
            logBtn_Click(sender, e);
        }
    }
}
