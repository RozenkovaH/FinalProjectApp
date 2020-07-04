using System;
using System.Collections.Generic;

namespace OGE_Tests
{

    public class TaskInstance
    {
        private static QueryBuilder qb = new QueryBuilder();

        public int id { get; set; }

        public TestInstance ti { get; }

        public string instruction { get; set; }

        public string text { get; set; }

        public string audioPath { get; set; }

        public string readingOptions { get; set; }

        public string name { get; set; }

        public int taskSubtypeId { get; set; }

        public Dictionary<int, string> answers { get; set; }

        public Dictionary<int, string> userAnswers { get; set; }

        public Dictionary<int, bool> rightAnswers { get; set; }

        public TaskInstance(TestInstance ti)
        {
            this.ti = ti;
        }

        public void saveUserAnswers()
        {
            this.rightAnswers = new Dictionary<int, bool>();
            foreach (KeyValuePair<int, string> answer in this.answers)
            {
                bool right = false;
                if (userAnswers.ContainsKey(answer.Key))
                {
                    right = answer.Value.Equals(userAnswers[answer.Key]);
                }
                this.rightAnswers.Add(answer.Key, right);

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TestTaskId", id);
                param.Add("Number", answer.Key);
                param.Add("Answer", userAnswers.ContainsKey(answer.Key) ? userAnswers[answer.Key] : "");
                param.Add("RightAnswer", right);

                qb.AddRow("Test_Task_Answer", param);
            }
        }

    }
}
