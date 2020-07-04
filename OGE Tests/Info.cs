using System;
using System.Windows.Forms;

namespace OGE_Tests
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu m = new MainMenu();
            m.Show();

            this.Hide();
        }

        private void btnFAQ_Click(object sender, EventArgs e)
        {
            FAQ faq = new FAQ();
            faq.Show();
            this.Hide();
        }

        private void btnExamStrategies_Click(object sender, EventArgs e)
        {
            ExamStrats es = new ExamStrats();
            es.Show();
            this.Hide();
        }
    }
}
