using System;
using System.Collections.Generic;

namespace OGE_Tests
{
    public class TestInstanceFactory
    {
        private static QueryBuilder qb = new QueryBuilder();

        private static int AddTestInstance()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("UserId", User.id);
            param.Add("DateBeg", DateTime.Now);
            return qb.AddRow("Test_Instance", param);
        }


        private static Dictionary<int, TaskInstance> AddModuleTask(TestInstance testInstance, int taskType)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            if (taskType > 0)
            {
                param.Add("TaskTypeId", taskType);
            }
            List<int> subTypeIds = qb.GetIdsByFields("Task_Subtype", param);

            Dictionary<int, TaskInstance> moduleTask = new Dictionary<int, TaskInstance>();
            foreach (int subTypeId in subTypeIds)
            {
                moduleTask.Add(subTypeId, TaskInstanceFactory.create(testInstance, subTypeId));
            }

            return moduleTask;
        }

        public static TestInstance create(int taskType) {

            TestInstance ti = new TestInstance();
            ti.id = AddTestInstance();
            ti.tasks = AddModuleTask(ti, taskType);
            return ti;
        }

        public static List<TestInstance> getAll() {

            List<TestInstance> testInstances = new List<TestInstance>();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("UserId", User.id);

            List<string> fields = new List<string>();
            fields.Add("Id");
            fields.Add("DateBeg");

            List<Dictionary<string, Object>> data = qb.getFieldsValueByFieldsValue("Test_Instance", fields, param);
            foreach (Dictionary<string, Object> row in data) {
                TestInstance ti = new TestInstance();
                testInstances.Add(ti);

                ti.id = (int) row["Id"];
                ti.dateBeg = (DateTime) row["DateBeg"];
                ti.tasks = TaskInstanceFactory.getAll(ti);

            }

            return testInstances;
        }
    }
}
