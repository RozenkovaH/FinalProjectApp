using System;
using System.Media;
using System.Windows.Forms;

namespace OGE_Tests
{
    public partial class ListeningTest : Form
    {
        Timer t = new Timer();

        private QueryBuilder qb = new QueryBuilder();

        SoundPlayer sp = new SoundPlayer();

        private TestInstance ti;

        private bool fullTest;

        private bool btn = true;

        public ListeningTest(TestInstance ti, bool fullTest)
        {
            this.ti = ti;
            this.fullTest = fullTest;
            InitializeComponent();
            t.Tick += new EventHandler(timer_Tick);
            t.Interval = 1000 * 300;
            t.Enabled = true;
            t.Start();
        }

        private void ListeningTest_Load(object sender, EventArgs e)
        {
            rtbInstructions1.Text = ti.tasks[2].instruction;
            rtbOptions1.Text = ti.tasks[2].text;
            rtbInstructions2.Text = ti.tasks[3].instruction;
            rtbOptions2.Text = ti.tasks[3].text;
            rtbInstructions3.Text = ti.tasks[4].instruction;
            rtbOptions3.Text = ti.tasks[4].text;
        }

        private void btnPlay1_Click(object sender, EventArgs e)
        {
            sp.SoundLocation = ti.tasks[2].audioPath;
            sp.Play();
        }

        private void btnPlay2_Click(object sender, EventArgs e)
        {
            sp.SoundLocation = ti.tasks[3].audioPath;
            sp.Play();
        }

        private void btnPlay3_Click(object sender, EventArgs e)
        {
            sp.SoundLocation = ti.tasks[4].audioPath;
            sp.Play();
        }

        private void btnStop1_Click(object sender, EventArgs e)
        {
            sp.Stop();
        }

        private void btnStop2_Click(object sender, EventArgs e)
        {
            sp.Stop();
        }

        private void btnStop3_Click(object sender, EventArgs e)
        {
            sp.Stop();
        }

        private void tbPlaceA_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbPlaceA.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 54);
        }

        private void tbPlaceB_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbPlaceB.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 54);
        }

        private void tbPlaceC_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbPlaceC.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 54);
        }

        private void tbPlaceD_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbPlaceD.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 54);
        }

        private void tbStatementA_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbStatementA.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 55);
        }

        private void tbStatementB_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbStatementB.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 55);
        }

        private void tbStatementC_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbStatementC.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 55);
        }

        private void tbStatementD_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbStatementD.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 55);
        }

        private void tbStatementE_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbStatementE.MaxLength = 1;
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 55);
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

        private void btnFinish_Click(object sender, EventArgs e)
        {
            ti.tasks[2].userAnswers.Add(1, tbPlaceA.Text);
            ti.tasks[2].userAnswers.Add(2, tbPlaceB.Text);
            ti.tasks[2].userAnswers.Add(3, tbPlaceC.Text);
            ti.tasks[2].userAnswers.Add(4, tbPlaceD.Text);
            ti.tasks[2].saveUserAnswers();
            ti.tasks[3].userAnswers.Add(1, tbStatementA.Text);
            ti.tasks[3].userAnswers.Add(2, tbStatementB.Text);
            ti.tasks[3].userAnswers.Add(3, tbStatementC.Text);
            ti.tasks[3].userAnswers.Add(4, tbStatementD.Text);
            ti.tasks[3].userAnswers.Add(5, tbStatementE.Text);
            ti.tasks[3].saveUserAnswers();
            ti.tasks[4].userAnswers.Add(1, tbAnswer1.Text);
            ti.tasks[4].userAnswers.Add(2, tbAnswer2.Text);
            ti.tasks[4].userAnswers.Add(3, tbAnswer3.Text);
            ti.tasks[4].userAnswers.Add(4, tbAnswer4.Text);
            ti.tasks[4].userAnswers.Add(5, tbAnswer5.Text);
            ti.tasks[4].userAnswers.Add(6, tbAnswer6.Text);
            ti.tasks[4].saveUserAnswers();

            if (!fullTest)
            {
                MyResults mr = new MyResults(ti, btn);
                mr.Show();
            }
            else
            {
                ReadingTest rt = new ReadingTest(ti, fullTest);
                rt.Show();
            }
            t.Stop();
            sp.Stop();
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Время истекло!");
            t.Stop();
            sp.Stop();
            this.Close();
            if (!fullTest)
            {
                MyResults mr = new MyResults(ti, btn);
                mr.Show();
            }
            else
            {
                ReadingTest rt = new ReadingTest(ti, fullTest);
                rt.Show();
            }
        }
    }
}
