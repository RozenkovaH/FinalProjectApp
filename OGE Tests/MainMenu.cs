using System;
using System.Windows.Forms;

namespace OGE_Tests
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Profile p = new Profile();
            p.Show();

            this.Hide();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Info i = new Info();
            i.Show();

            this.Hide();
        }

        private void btnTakeTest_Click(object sender, EventArgs e)
        {
            ChooseTest ct = new ChooseTest();
            ct.Show();

            this.Hide();
        }

        private void btnMyProgress_Click(object sender, EventArgs e)
        {
            ChooseTestResults ctr = new ChooseTestResults();
            ctr.Show();
            this.Hide();
        }
    }
}
