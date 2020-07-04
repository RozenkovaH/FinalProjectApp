using System;
using System.Windows.Forms;

namespace OGE_Tests
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            tbFIO.Text = User.fullName;
            tbLogin.Text = User.login;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text != "" && tbPassword2.Text != "")
            {
                if (tbPassword.Text == tbPassword2.Text)
                {
                    QueryBuilder qb = new QueryBuilder();
                    qb.SetStringFieldValue("LogPass", "Password", User.id, Encryptor.GetHash(tbPassword.Text));
                    MessageBox.Show("Ваш пароль успешно изменён");
                    tbPassword.Text = "";
                    tbPassword2.Text = "";
                }

                else
                {
                    MessageBox.Show("Введённые пароли не совпали");
                    tbPassword.Text = "";
                    tbPassword2.Text = "";
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu m = new MainMenu();
            m.Show();

            this.Hide();
        }
    }
}
