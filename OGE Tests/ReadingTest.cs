using System;
using System.Windows.Forms;

namespace OGE_Tests
{
    public partial class ReadingTest : Form
    {
        Timer t = new Timer();

        private QueryBuilder qb = new QueryBuilder();

        private TestInstance ti;

        private bool fullTest;

        private bool btn = true;

        public ReadingTest(TestInstance ti, bool fullTest)
        {
            this.ti = ti;
            this.fullTest = fullTest;
            InitializeComponent();
            t.Tick += new EventHandler(timer_Tick);
            t.Interval = 1000 * 300;
            t.Enabled = true;
            t.Start();
        }

        private void ReadingTest_Load(object sender, EventArgs e)
        {
            rtbInstructions1.Text = ti.tasks[5].instruction;
            rtbOptions1.Text = ti.tasks[5].readingOptions;
            rtbText1.Text = ti.tasks[5].text;
            rtbInstructions2.Text = ti.tasks[6].instruction;
            rtbOptions2.Text = ti.tasks[6].readingOptions;
            rtbText2.Text = ti.tasks[6].text;
        }

        private void tbTitleA_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbTitleA.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 57);
        }

        private void tbTitleB_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbTitleB.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 57);
        }

        private void tbTitleC_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbTitleC.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 57);
        }

        private void tbTitleD_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbTitleD.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 57);
        }

        private void tbTitleE_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbTitleE.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 57);
        }

        private void tbTitleF_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbTitleF.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 57);
        }

        private void tbTitleG_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbTitleG.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 57);
        }

        private void tbAnswer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbAnswer1.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 52);
        }

        private void tbAnswer2_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbAnswer2.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 52);
        }

        private void tbAnswer3_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbAnswer3.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 52);
        }

        private void tbAnswer4_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbAnswer4.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 52);
        }

        private void tbAnswer5_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbAnswer5.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 52);
        }

        private void tbAnswer6_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbAnswer6.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 52);
        }

        private void tbAnswer7_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbAnswer7.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 52);
        }

        private void tbAnswer8_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbAnswer8.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 52);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            ti.tasks[5].userAnswers.Add(1, tbTitleA.Text);
            ti.tasks[5].userAnswers.Add(2, tbTitleB.Text);
            ti.tasks[5].userAnswers.Add(3, tbTitleC.Text);
            ti.tasks[5].userAnswers.Add(4, tbTitleD.Text);
            ti.tasks[5].userAnswers.Add(5, tbTitleE.Text);
            ti.tasks[5].userAnswers.Add(6, tbTitleF.Text);
            ti.tasks[5].userAnswers.Add(7, tbTitleG.Text);
            ti.tasks[5].saveUserAnswers();
            ti.tasks[6].userAnswers.Add(1, tbAnswer1.Text);
            ti.tasks[6].userAnswers.Add(2, tbAnswer2.Text);
            ti.tasks[6].userAnswers.Add(3, tbAnswer3.Text);
            ti.tasks[6].userAnswers.Add(4, tbAnswer4.Text);
            ti.tasks[6].userAnswers.Add(5, tbAnswer5.Text);
            ti.tasks[6].userAnswers.Add(6, tbAnswer6.Text);
            ti.tasks[6].userAnswers.Add(7, tbAnswer7.Text);
            ti.tasks[6].userAnswers.Add(8, tbAnswer8.Text);
            ti.tasks[6].saveUserAnswers();

            if (!fullTest)
            {
                MyResults mr = new MyResults(ti, btn);
                mr.Show();
            }
            else
            {
                GramVocabTest gvt = new GramVocabTest(ti);
                gvt.Show();
            }
            t.Stop();
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Время истекло!");
            t.Stop();
            this.Close();
            if (!fullTest)
            {
                MyResults mr = new MyResults(ti, btn);
                mr.Show();
            }
            else
            {
                GramVocabTest gvt = new GramVocabTest(ti);
                gvt.Show();
            }
        }
    }
}
