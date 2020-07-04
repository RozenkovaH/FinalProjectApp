using System;
using System.Windows.Forms;

namespace OGE_Tests
{
    public partial class GramVocabTest : Form
    {
        Timer t = new Timer();

        private QueryBuilder qb = new QueryBuilder();

        private TestInstance ti;

        private bool btn = true;

        public GramVocabTest(TestInstance ti)
        {
            this.ti = ti;
            InitializeComponent();
            t.Tick += new EventHandler(timer_Tick);
            t.Interval = 1000 * 300;
            t.Enabled = true;
            t.Start();
        }

        private void GramVocabTest_Load(object sender, EventArgs e)
        {
            rtbInstructions1.Text = ti.tasks[7].instruction;
            rtbTask1.Text = ti.tasks[7].text;
            rtbInstructions2.Text = ti.tasks[9].instruction;
            rtbTask2.Text = ti.tasks[9].text;
        }

        private void tbGram1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbGram2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbGram3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbGram4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbGram5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbGram6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbGram7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbGram8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbGram9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbVocab1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbVocab2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbVocab3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbVocab4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbVocab5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void tbVocab6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Constraint.isAppropriateSymbol(e.KeyChar, 96, 123);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            ti.tasks[7].userAnswers.Add(1, tbGram1.Text);
            ti.tasks[7].userAnswers.Add(2, tbGram2.Text);
            ti.tasks[7].userAnswers.Add(3, tbGram3.Text);
            ti.tasks[7].userAnswers.Add(4, tbGram4.Text);
            ti.tasks[7].userAnswers.Add(5, tbGram5.Text);
            ti.tasks[7].userAnswers.Add(6, tbGram6.Text);
            ti.tasks[7].userAnswers.Add(7, tbGram7.Text);
            ti.tasks[7].userAnswers.Add(8, tbGram8.Text);
            ti.tasks[7].userAnswers.Add(9, tbGram9.Text);
            ti.tasks[7].saveUserAnswers();
            ti.tasks[9].userAnswers.Add(1, tbVocab1.Text);
            ti.tasks[9].userAnswers.Add(2, tbVocab2.Text);
            ti.tasks[9].userAnswers.Add(3, tbVocab3.Text);
            ti.tasks[9].userAnswers.Add(4, tbVocab4.Text);
            ti.tasks[9].userAnswers.Add(5, tbVocab5.Text);
            ti.tasks[9].userAnswers.Add(6, tbVocab6.Text);
            ti.tasks[9].saveUserAnswers();

            MyResults mr = new MyResults(ti, btn);
            mr.Show();
            t.Stop();
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Время истекло!");
            t.Stop();
            this.Close();
            MyResults mr = new MyResults(ti, btn);
            mr.Show();
        }
    }
}
