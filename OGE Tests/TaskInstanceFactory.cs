using System;
using System.Collections.Generic;
using System.Linq;

namespace OGE_Tests
{
    public class TaskInstanceFactory
    {
        private static QueryBuilder qb = new QueryBuilder();

        private static Random rnd = new Random();

        private static int AddTask(int instanceId, int taskSubtypeId)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("TestInstanceId", instanceId);

            Dictionary<string, object> taskParam = new Dictionary<string, object>();
            taskParam.Add("TaskSubtypeId", taskSubtypeId);
            List<int> taskIds = qb.GetIdsByFields("Task", taskParam);

            int number = rnd.Next(0, taskIds.Count());

            param.Add("TaskId", taskIds[number]);
            return qb.AddRow("Test_Task", param);
        }

        private static void setMainData(TaskInstance taskInstance)
        {

            int taskId = qb.GetIntFieldValue("Test_Task", "TaskId", taskInstance.id);

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("Id", taskId);

            List<string> fields = new List<string>();
            fields.Add("Text");
            fields.Add("Audio");
            fields.Add("OptionsReading");
            fields.Add("TaskSubtypeId");

            List<Dictionary<string, object>> taskData = qb.getFieldsValueByFieldsValue("Task", fields, param);
            taskInstance.text = (string)taskData[0]["Text"];
            taskInstance.audioPath = (string)taskData[0]["Audio"];
            taskInstance.readingOptions = (string)taskData[0]["OptionsReading"];
            taskInstance.taskSubtypeId = (int)taskData[0]["TaskSubtypeId"];

            taskInstance.name = qb.GetStringFieldValue("Task_Subtype", "Name", taskInstance.taskSubtypeId);
            taskInstance.instruction = qb.GetStringFieldValue("Task_Subtype", "Instruction", taskInstance.taskSubtypeId);

            fields = new List<string>();
            fields.Add("Number");
            fields.Add("Answer");

            param = new Dictionary<string, object>();
            param.Add("TaskId", taskId);

            taskInstance.answers = new Dictionary<int, string>();
            List<Dictionary<string, object>> answers = qb.getFieldsValueByFieldsValue("Task_Answer", fields, param);

            foreach (Dictionary<string, object> answer in answers)
            {
                taskInstance.answers.Add((int)answer["Number"], (string)answer["Answer"]);
            }

        }

        public static TaskInstance create(TestInstance ti, int taskSubtypeId)
        {
            TaskInstance taskInstance = new TaskInstance(ti);

            taskInstance.id = AddTask(ti.id, taskSubtypeId);

            setMainData(taskInstance);

            taskInstance.userAnswers = new Dictionary<int, string>();

            return taskInstance;

        }

        public static void setUserAnswers(TaskInstance taskInstance) {
            taskInstance.userAnswers = new Dictionary<int, string>();
            taskInstance.rightAnswers = new Dictionary<int, bool>();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("TestTaskId", taskInstance.id);

            List<string> fields = new List<string>();
            fields.Add("Number");
            fields.Add("Answer");
            fields.Add("RightAnswer");

            List<Dictionary<string, object>> data = qb.getFieldsValueByFieldsValue("Test_Task_Answer", fields, param);
            foreach (Dictionary<string, object> row in data) {
                int number = (int)row["Number"];
                taskInstance.userAnswers.Add(number, (string)row["Answer"]);
                taskInstance.rightAnswers.Add(number, (bool)row["RightAnswer"]);
            }

        }

        public static Dictionary<int, TaskInstance> getAll(TestInstance ti) {
            Dictionary<int, TaskInstance> tasks = new Dictionary<int, TaskInstance>();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("TestInstanceId", ti.id);
            List<int> taskIds = qb.GetIdsByFields("Test_Task", param);

            foreach (int taskId in taskIds) {
                TaskInstance taskInstance = new TaskInstance(ti);
                taskInstance.id = taskId;

                setMainData(taskInstance);

                setUserAnswers(taskInstance);

                tasks.Add(taskInstance.taskSubtypeId, taskInstance);
            }

            return tasks;
        }
    }
}
