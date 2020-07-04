using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OGE_Tests
{
    public partial class ChooseTestResults : Form
    {
        private List<TestInstance> testInstances = TestInstanceFactory.getAll();

        private Dictionary<ListViewItem, TestInstance> mapping = new Dictionary<ListViewItem, TestInstance>();

        private bool btn = false;

        public ChooseTestResults()
        {
            InitializeComponent();
            foreach (TestInstance test in testInstances)
            {
                ListViewItem item = new ListViewItem(test.dateBeg.ToString());
                mapping.Add(item, test);
                lvResults.Items.Add(item);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu m = new MainMenu();
            m.Show();
            this.Hide();
        }

        private void lvResults_ItemActivate(object sender, EventArgs e)
        {
            if (lvResults.SelectedItems.Count > 0) {
                ListViewItem item = lvResults.SelectedItems[0];
                MyResults mr = new MyResults(mapping[item], btn);
                mr.Show();
                this.Hide();
            }
        }
    }
}
