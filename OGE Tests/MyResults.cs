using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OGE_Tests
{
    public partial class MyResults : Form
    {
        QueryBuilder qb = new QueryBuilder();

        TestInstance ti = new TestInstance();

        public MyResults(TestInstance ti, bool btn)
        {
            this.ti = ti;
            InitializeComponent();

            if (btn == false)
                btnBack.Text = "Назад";
            else
                btnBack.Text = "Вернуться в главное меню";

            foreach (KeyValuePair<int, TaskInstance> taskPair in ti.tasks)
            {
                string taskTypeName = qb.GetStringFieldValue(
                    "Task_Type", "Name",
                    qb.GetIntFieldValue("Task_Subtype", "TaskTypeId", taskPair.Key)
                    );
                foreach (KeyValuePair<int, string> answerPair in taskPair.Value.answers)
                {
                    ListViewItem item = new ListViewItem(taskTypeName);
                    item.SubItems.Add(taskPair.Value.name);
                    item.SubItems.Add(answerPair.Key.ToString());
                    item.SubItems.Add(
                        taskPair.Value.userAnswers.ContainsKey(answerPair.Key) ?
                        taskPair.Value.userAnswers[answerPair.Key] : "");
                    item.SubItems.Add(answerPair.Value);
                    bool right = taskPair.Value.rightAnswers.ContainsKey(answerPair.Key) ?
                        taskPair.Value.rightAnswers[answerPair.Key] : false;
                    item.SubItems.Add(right ? "\u2713".ToString() : "");
                    lvResults.Items.Add(item);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (btnBack.Text == "Назад")
            {
                ChooseTestResults ctr = new ChooseTestResults();
                ctr.Show();
                this.Hide();
            }

            else
            {
                MainMenu m = new MainMenu();
                m.Show();
                this.Hide();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(lvResults.Width, lvResults.Height);
            lvResults.DrawToBitmap(bitmap, lvResults.ClientRectangle);
            e.Graphics.DrawImage(bitmap, new Point(50, 50));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
