﻿using System;
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
    public partial class SaleManCtrl : Form
    {
        string mainEmpID;
        bool isUpdateData, isNewData = false;
        bool nameChange, contactChange, pinChange, addressChange, emailChange = false; //validate the change for update
        bool nameFlag, pinFlag, addressFlag, contactFlag, emailFlag; //for error checking

        data.empInfo updateEmp;

        public SaleManCtrl()
        {
            InitializeComponent();
        }
        public SaleManCtrl(string id)
        {
            InitializeComponent();
            pictureVanish();
            startChecker();
            isNewData = true;
            mainEmpID = id;
            hireBtn.Location = new Point(383, 384);
            updateBtn.Enabled = updateBtn.Visible = false;
            Console.WriteLine("asim");
        }
        public SaleManCtrl(data.empInfo emp, string empID)
        {
            InitializeComponent();
            pictureVanish();
            updateBtn.Location = new Point(383, 384);
            hireBtn.Enabled = hireBtn.Visible = false;
            isUpdateData = true;
            mainEmpID = empID;
            updateEmp = emp;
            nameBox.Text = emp.name;
            pinBox.Text = emp.pin;
            addressBox.Text = emp.address;
            contactBox.Text = emp.contact;
            emailBox.Text = emp.email;
        }

        private void startChecker()
        {
            if (nameBox.Text == "") nameFlag = true;
            if (pinBox.Text == "") pinFlag = true;
            if (addressBox.Text == "") addressFlag = true;
            if (contactBox.Text == "") contactFlag = true;
            if (emailBox.Text == "") emailFlag = true;
        }

        private void pictureVanish()
        {
            nameBoxErrorIcon.Visible = false;
            pinBoxErrorIcon.Visible = false;
            addressBoxErrorIcon.Visible = false;
            contactBoxErrorIcon.Visible = false;
            emailBoxErrorIcon.Visible = false;
        }

        private void hireBtn_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (isNewData)
            {
                string name = nameBox.Text;
                string pin = pinBox.Text;
                string contact = contactBox.Text;
                string address = addressBox.Text;
                string email = emailBox.Text;

                if ((nameFlag || contactFlag || pinFlag || addressFlag || emailFlag) == true)
                {
                    if (nameFlag) nameBoxErrorIcon.Visible = true;
                    if (pinFlag) pinBoxErrorIcon.Visible = true;
                    if (addressFlag) addressBoxErrorIcon.Visible = true;
                    if (contactFlag) contactBoxErrorIcon.Visible = true;
                    if (emailFlag) emailBoxErrorIcon.Visible = true;
                    MessageBox.Show("The given input is invalid.\nPlease enter correct information and fill fields to required information.", "OK");
                }
                else
                {
                    //this block of code will check whether the employee email is valid or not as it is also a unique value
                    data.con.Open();
                    string mEmailCheckQuery = "select * from employee where email = @email";
                    SqlCommand mEmailCheckCMD = new SqlCommand(mEmailCheckQuery, data.con);
                    mEmailCheckCMD.Parameters.AddWithValue("@email", email);
                    SqlDataAdapter mEmailCheckAdapter = new SqlDataAdapter(mEmailCheckCMD);
                    DataSet mEmailCheckSet = new DataSet();
                    mEmailCheckAdapter.Fill(mEmailCheckSet);
                    data.con.Close();
                    if (mEmailCheckSet.Tables[0].Rows.Count == 0)
                    {
                        data.con.Open();
                        //this block is used to generate new employee id by getting id from database just the digit part
                        string getEmpIdQuery = "Select id from employee where designation = 'Salesman' ";
                        SqlCommand getEmpIdCmd = new SqlCommand(getEmpIdQuery, data.con);
                        SqlDataAdapter empIdAdapter = new SqlDataAdapter(getEmpIdCmd);
                        DataSet empIdDataSet = new DataSet();
                        empIdAdapter.Fill(empIdDataSet);

                        String id;
                        if ((empIdDataSet.Tables[0].Rows.Count) > 0)
                        {
                            id = Convert.ToString(((empIdDataSet.Tables[0].Rows.Count) + 1));
                        }
                        else
                        {
                            id = "0";
                        }


                        //this block of code is used to add new employees
                        string newEmpQuery = "INSERT INTO EMPLOYEE(id,name,password,contact,address,email,designation,hire,fire,status,sales) VALUES(@id,@name,@password,@contact,@address,@email,'Salesman',(CONVERT(DATE, GETDATE())),NULL,'Working',0)";
                        SqlCommand newEmpCmd = new SqlCommand(newEmpQuery, data.con);
                        newEmpCmd.Parameters.AddWithValue("@id", id);
                        newEmpCmd.Parameters.AddWithValue("@name", name);
                        newEmpCmd.Parameters.AddWithValue("@contact", contact);
                        newEmpCmd.Parameters.AddWithValue("@address", address);
                        newEmpCmd.Parameters.AddWithValue("@email", email);
                        newEmpCmd.Parameters.AddWithValue("@password", pin);
                        newEmpCmd.ExecuteNonQuery();

                        data.con.Close();
                        MessageBox.Show("New Employee has been Successfuly Added.");
                        nameBox.Text = contactBox.Text = pinBox.Text = addressBox.Text = contactBox.Text = emailBox.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("The given Email is invalid.\nPlease recheck it", "OK");
                        emailBoxErrorIcon.Visible = true;
                    }
                }
            }
        }


        private void updateBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (isUpdateData)
            {
                if (nameChange || pinChange || addressChange || contactChange || emailChange)
                {
                    string name = nameBox.Text;
                    string pin = pinBox.Text;
                    string contact = contactBox.Text;
                    string address = addressBox.Text;
                    string email = emailBox.Text;
                    string employeeId = updateEmp.id;

                    //this block of code will check whether the manufacturer email is valid or not as it is also a unique value
                    data.con.Open();
                    string mEmailCheckQuery = "select * from employee where email = @email and id <> @id";
                    SqlCommand mEmailCheckCMD = new SqlCommand(mEmailCheckQuery, data.con);
                    mEmailCheckCMD.Parameters.AddWithValue("@email", email);
                    mEmailCheckCMD.Parameters.AddWithValue("@id", employeeId);
                    SqlDataAdapter mEmailCheckAdapter = new SqlDataAdapter(mEmailCheckCMD);
                    DataSet mEmailCheckSet = new DataSet();
                    mEmailCheckAdapter.Fill(mEmailCheckSet);
                    data.con.Close();
                    if (mEmailCheckSet.Tables[0].Rows.Count == 0)
                    {

                        data.con.Open();
                        string updateEmpQuery = "Update employee set name = @newName, password = @newPin, contact = @newContact, address = @newAddress, email = @newEmail  where id = @updateId";
                        SqlCommand updateEmpCMD = new SqlCommand(updateEmpQuery, data.con);
                        updateEmpCMD.Parameters.AddWithValue("@newName", name);
                        updateEmpCMD.Parameters.AddWithValue("@newPin", pin);
                        updateEmpCMD.Parameters.AddWithValue("@newContact", contact);
                        updateEmpCMD.Parameters.AddWithValue("@newAddress", address);
                        updateEmpCMD.Parameters.AddWithValue("@newEmail", email);
                        updateEmpCMD.Parameters.AddWithValue("@updateId", employeeId);
                        updateEmpCMD.ExecuteNonQuery();
                        data.con.Close();

                        MessageBox.Show("Employee Data has been Successfuly Updated.");
                        nameBox.Text = contactBox.Text = pinBox.Text = addressBox.Text = contactBox.Text = emailBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("The given Email is invalid.\nPlease recheck it", "OK");
                        emailBoxErrorIcon.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("You Haven't Changed any Data.", "OK");
                }
            }
        }


        private void backBtn_MouseClick(object sender, MouseEventArgs e)
        {
            new empControl(mainEmpID).Show();
            this.Hide();
        }

        //checking whether the user has updated data or not
        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            if (updateEmp.name != nameBox.Text)
                nameChange = true;
        }
        private void contactBox_TextChanged(object sender, EventArgs e)
        {
            if (updateEmp.contact != contactBox.Text)
                contactChange = true;
        }
        private void pinBox_TextChanged(object sender, EventArgs e)
        {
            if (updateEmp.pin != pinBox.Text)
                pinChange = true;
        }
        private void addressBox_TextChanged(object sender, EventArgs e)
        {
            if (updateEmp.address != addressBox.Text)
                addressChange = true;
        }
        private void emailBox_TextChanged(object sender, EventArgs e)
        {
            if (updateEmp.email != emailBox.Text)
                emailChange = true;
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
            nameBox.ForeColor = Color.FromArgb(0, 150, 150);
        }

        private void pinBox_Enter(object sender, EventArgs e)
        {
            pinBoxErrorIcon.Visible = false;
            pinBox.BorderStyle = BorderStyle.None;
            pinBox.BackColor = Color.FromArgb(0, 120, 120);
            pinBox.ForeColor = Color.White;
        }
        private void pinBox_Leave(object sender, EventArgs e)
        {
            if (pinBox.Text == "")
            {
                pinBoxErrorIcon.Visible = true;
                pinFlag = true;
            }
            else
            {
                pinBoxErrorIcon.Visible = false;
                pinFlag = false;
            }
            pinBoxErrorIcon.BackColor = Color.Transparent;
            pinBox.BorderStyle = BorderStyle.Fixed3D;
            pinBox.BackColor = Color.White;
            pinBox.ForeColor = Color.FromArgb(0, 150, 150);
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
            addressBox.ForeColor = Color.FromArgb(0, 150, 150);
        }

        private void contactBox_Enter(object sender, EventArgs e)
        {
            contactBoxErrorIcon.Visible = false;
            contactBox.BorderStyle = BorderStyle.None;
            contactBox.BackColor = Color.FromArgb(0, 100, 100);
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
            contactBox.ForeColor = Color.FromArgb(0, 150, 150);
        }

        private void emailBox_Enter(object sender, EventArgs e)
        {
            emailBoxErrorIcon.Visible = false;
            emailBox.BorderStyle = BorderStyle.None;
            emailBox.BackColor = Color.FromArgb(0, 100, 100);
            emailBox.ForeColor = Color.White;
        }
        private void emailBox_Leave(object sender, EventArgs e)
        {
            if (emailBox.Text == "")
            {
                emailBoxErrorIcon.Visible = true;
                emailFlag = true;
            }
            else
            {
                emailBoxErrorIcon.Visible = false;
                emailFlag = false;
            }
            emailBoxErrorIcon.BackColor = Color.Transparent;
            emailBox.BorderStyle = BorderStyle.Fixed3D;
            emailBox.BackColor = Color.White;
            emailBox.ForeColor = Color.FromArgb(0, 150, 150);
        }


        //validating input of textboxes
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
        private void contactBox_KeyPress(object sender, KeyPressEventArgs e)
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
        private void pinBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //for button styling
        private void hireBtn_MouseEnter(object sender, EventArgs e)
        {
            hireBtn.BackColor = Color.FromArgb(0, 120, 120);
        }
        private void hireBtn_MouseLeave(object sender, EventArgs e)
        {
            hireBtn.BackColor = Color.FromArgb(0, 150, 150);
        }

        private void updateBtn_MouseEnter(object sender, EventArgs e)
        {
            updateBtn.BackColor = Color.FromArgb(0, 120, 120);
        }
        private void updateBtn_MouseLeave(object sender, EventArgs e)
        {
            updateBtn.BackColor = Color.FromArgb(0, 150, 150);
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
