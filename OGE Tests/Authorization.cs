using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OGE_Tests
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbPassword.MaxLength = 15;
            tbPassword.PasswordChar = '*';
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text != "" && tbPassword.Text != "")
            {
                QueryBuilder qb = new QueryBuilder();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("Login", tbLogin.Text);
                param.Add("Password", Encryptor.GetHash(tbPassword.Text));
                List<int> Ids = qb.GetIdsByFields("LogPass", param);
                bool success = false;

                if(Ids.Count == 1)
                {
                    success = true;
                    User.id = Ids[0];
                }

                if (success)
                {
                    User.fullName = qb.GetStringFieldValue("LogPass", "FullName", User.id);
                    User.login = tbLogin.Text;
                    User.isAdmin = false;
                    MessageBox.Show("Успешная авторизация");
                    this.Hide();
                    MainMenu m = new MainMenu();
                    m.Show();
                }
                else
                {
                    MessageBox.Show("Неверная пара логин-пароль");
                    tbPassword.Text = "";
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();

            this.Hide();
        }
    }
}
