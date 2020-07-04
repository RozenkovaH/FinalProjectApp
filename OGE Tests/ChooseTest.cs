using System;
using System.Windows.Forms;

namespace OGE_Tests
{
    public partial class ChooseTest : Form
    {
        private QueryBuilder qb = new QueryBuilder();

        public ChooseTest()
        {
            InitializeComponent();
        }

        private void ChooseTest_Load(object sender, EventArgs e)
        {
            cbChooseTest.Items.AddRange(new string[] { "Аудирование", "Чтение", "Грамматика и лексика", "Все разделы" });
        }

        private void btnGenerateTest_Click(object sender, EventArgs e)
        {
            if (cbChooseTest.Text == "Аудирование")
            {
                MessageBox.Show("В разделе 'Аудирование' Вам будет предложено прослушать аудиозаписи и выполнить задания на проверку понимания услышанного. Время на выполнение: 30 минут. Вы можете завершить тест досрочно.");
                ListeningTest lt = new ListeningTest(TestInstanceFactory.create(3), false);
                lt.Show();
                this.Close();
            }
            else if (cbChooseTest.Text == "Чтение")
            {
                MessageBox.Show("Раздел 'Чтение' содержит задания на проверку понимания прочитанных текстов. Время на выполнение: 30 минут. Вы можете завершить тест досрочно.");
                ReadingTest rt = new ReadingTest(TestInstanceFactory.create(4), false);
                rt.Show();
                this.Hide();
            }
            else if (cbChooseTest.Text == "Грамматика и лексика")
            {
                MessageBox.Show("В разделе 'Грамматика и лексика' Вам будут предложены задания на лексико-грамматическое преобразование слов. Время на выполнение: 30 минут. Вы можете завершить тест досрочно.");
                GramVocabTest gvt = new GramVocabTest(TestInstanceFactory.create(5));
                gvt.Show();
                this.Hide();
            }
            else if (cbChooseTest.Text == "Все разделы")
            {
                MessageBox.Show("Тест сгенерирован. Время на выполнение: 90 минут. Вы можете завершить тест досрочно.");
                ListeningTest lt = new ListeningTest(TestInstanceFactory.create(-1), true);
                lt.Show();
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu m = new MainMenu();
            m.Show();
            this.Close();
        }
    }
}
