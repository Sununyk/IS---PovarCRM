using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PovarCRM.Models;

namespace PovarCRM.Viewers.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox1.Text != string.Empty)
            {
                using (var context = new PovarDbContext())
                {
                    User user = this.user = context.Users
                       .Include(u => u.Role)                       // Загружаем роль
                           .ThenInclude(r => r.RolePermissions)   // Загружаем права роли
                       .FirstOrDefault(u => u.UserName == textBox2.Text)
                       ?? throw new Exception();


                    if (user != null && user.VerifyPassword(textBox1.Text))
                    {
                        // Successful login
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.IsLogin = true;
                        this.user = user;
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                    {
                        // Invalid credentials
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.IsLogin = false;
                        this.textBox2.Clear();
                        this.textBox1.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
