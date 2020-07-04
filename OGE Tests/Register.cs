using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OGE_Tests
{
    public partial class Register : Form
    {

        public Register()
        {
            InitializeComponent();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbPassword.MaxLength = 15;
            tbPassword.PasswordChar = '*';
        }

        private void tbPassword2_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbPassword2.MaxLength = 15;
            tbPassword2.PasswordChar = '*';
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text != tbPassword2.Text)
            {
                MessageBox.Show("Введённые пароли не совпали");
                tbPassword.Text = "";
                tbPassword2.Text = "";
            }

            else if (tbFIO.Text != "" && tbLogin.Text != "" && tbPassword.Text != "" && tbPassword2.Text != "")
            {
                try
                {

                    QueryBuilder qb = new QueryBuilder();

                    User.fullName = tbFIO.Text;
                    User.login = tbLogin.Text;
                    User.isAdmin = false;

                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("Login", tbLogin.Text);
                    param.Add("Password", Encryptor.GetHash(tbPassword.Text));
                    param.Add("fullname", tbFIO.Text);
                    param.Add("isadmin", 0);

                    User.id = qb.AddRow("logpass", param);

                    MessageBox.Show("Добро пожаловать, " + tbFIO.Text + "!");
                    this.Hide();
                    MainMenu m = new MainMenu();
                    m.Show();
                }

                catch (Exception)
                {
                    MessageBox.Show("Непредвиденная ошибка сервера");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Authorization a = new Authorization();
            a.Show();

            this.Hide();
        }
    }
}
