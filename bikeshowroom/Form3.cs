using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bikeshowroom
{
    public partial class Manager_Menu : Form
    {
        string empId;
        public Manager_Menu()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        public Manager_Menu(string id)
        {
            InitializeComponent();
            empId = id;
            this.CenterToScreen();

        }
        private void exitBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void backBtn_MouseClick(object sender, MouseEventArgs e)
        {
            new LogInForm().Show();
            this.Hide();
        }


        private void bikeCtrlPanel_MouseClick(object sender, MouseEventArgs e)
        {
            new Bike_Panel(empId).Show();
            this.Hide();
        }

        private void empCtrlPanel_MouseClick(object sender, MouseEventArgs e)
        {
            //form7
            new empControl(empId).Show();
            this.Hide();
        }

        private void bikeCtrlPanel_MouseEnter(object sender, EventArgs e)
        {
            BikeCtrlPanel.BackColor = Color.FromArgb(0, 120, 120);
        }

        private void bikeCtrlPanel_MouseLeave(object sender, EventArgs e)
        {
            BikeCtrlPanel.BackColor = Color.FromArgb(0, 150, 150);
        }

        private void empCtrlPanel_MouseEnter(object sender, EventArgs e)
        {
            empCtrlPanel.BackColor = Color.FromArgb(0, 120, 120);
        }

        private void empCtrlPanel_MouseLeave(object sender, EventArgs e)
        {
            empCtrlPanel.BackColor = Color.FromArgb(0, 150, 150);
        }

        private void salesCtrlPanel_MouseEnter(object sender, EventArgs e)
        {
            salesCtrlPanel.BackColor = Color.FromArgb(0, 120, 120);
        }

        private void salesCtrlPanel_MouseLeave(object sender, EventArgs e)
        {
            salesCtrlPanel.BackColor = Color.FromArgb(0, 150, 150);
        }

        private void accountCtrlPanel_MouseEnter(object sender, EventArgs e)
        {
            accountCtrlPanel.BackColor = Color.FromArgb(0, 120, 120);
        }

        private void accountCtrlPanel_MouseLeave(object sender, EventArgs e)
        {
            accountCtrlPanel.BackColor = Color.FromArgb(0, 150, 150);
        }

        private void backBtn_MouseEnter(object sender, EventArgs e)
        {
            backBtn.BackColor = Color.FromArgb(0, 120, 120);
        }

        private void backBtn_MouseLeave(object sender, EventArgs e)
        {
            backBtn.BackColor = Color.FromArgb(0, 150, 150);
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

        private void salesCtrlPanel_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            new Form8(empId).Show();
        }

        private void accountCtrlPanel_MouseClick(object sender, MouseEventArgs e)
        {
            new Form10(empId).Show();
            this.Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
    }
}
