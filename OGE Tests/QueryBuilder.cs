using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace OGE_Tests
{
    class QueryBuilder
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Христина\source\repos\OGE Tests\OGE Tests\Database.mdf;Integrated Security=True";

        private void ex(Exception e)
        {
            throw e;
        }

        public List<int> GetIdsByFields(string tableName, Dictionary<string, object> param) {
            List<int> ids = new List<int>();

            List<string> columns = new List<string>();
            columns.Add("id");

            List<Dictionary<string, Object>> values = getFieldsValueByFieldsValue(tableName, columns, param);

            foreach (Dictionary<string, Object> value in values)
            {
                ids.Add((int) value["id"]);
            }

            return ids;
        }

        public int AddRow(string tableName, Dictionary<string, object> param)
        {
            int id = -1;
            string head = "INSERT INTO " + tableName + "(";
            string body = "VALUES (";
            string getId = "SELECT CAST(@@IDENTITY AS INTEGER)";
            foreach (KeyValuePair<string, object> entry in param)
            {
                head = head + entry.Key + ",";
                body = body + "@" + entry.Key + ",";
            }
            head = head.Substring(0, head.Length - 1) + ")";
            body = body.Substring(0, body.Length - 1) + ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand ins = new SqlCommand(head + " " + body + "; " + getId, connection);
                    foreach (KeyValuePair<string, object> entry in param)
                    {
                        ins.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                    }
                    SqlDataReader reader = ins.ExecuteReader();
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                    reader.Close();                  
                }
            }
            catch (Exception e)
            {
                ex(e);
            }
            return id;
        }

        public void SetStringFieldValue(string tableName, string fieldName, int id, string fieldValue)
        {
            string queryText = "UPDATE " + tableName + " SET " +
                    fieldName + " = @" + fieldName + " " +
                    "WHERE id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand upd = new SqlCommand(queryText, connection);
                    upd.Parameters.AddWithValue("@" + fieldName, fieldValue);
                    upd.Parameters.AddWithValue("@id", id);
                    upd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                ex(e);
            }
        }

        public object GetFieldValue(string tableName, string fieldName, int id, bool isString)
        {
            object value = null;

            List<string> columns = new List<string>();
            columns.Add(fieldName);

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("id", id);

            List<Dictionary<string, Object>> values = getFieldsValueByFieldsValue(tableName, columns, param);

            value = values[0][fieldName];

            return value;
        }

        public string GetStringFieldValue(string tableName, string fieldName, int id)
        {
            return (string) GetFieldValue(tableName, fieldName, id, true); 
        }

        public int GetIntFieldValue(string tableName, string fieldName, int id)
        {
            return (int)GetFieldValue(tableName, fieldName, id, false);
        }

        public List<Dictionary<string, Object>> getFieldsValueByFieldsValue(string tableName, List<string> fields, Dictionary<string, object> param) {

            List<Dictionary<string, Object>> values = new List<Dictionary<string, Object>>();

            if (fields != null && fields.Count > 0)
            {

                string sql = "SELECT";

                foreach (string field in fields)
                {
                    if (sql.Length == 6)
                    {
                        sql = sql + " " + field;
                    }
                    else
                    {
                        sql = sql + ", " + field;
                    }
                }
                sql = sql + " FROM " + tableName;

                if (param != null && param.Count > 0)
                {
                    int i = 0;
                    foreach (KeyValuePair<string, object> entry in param)
                    {
                        if (!i.Equals(0))
                        {
                            sql = sql + " AND ";
                        }
                        else
                        {
                            sql = sql + " WHERE ";
                        }

                        sql = sql + entry.Key + "=@" + entry.Key;

                        i++;
                    }
                }
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand show = new SqlCommand(sql, connection);

                        if (param != null)
                        {
                            foreach (KeyValuePair<string, object> entry in param)
                            {
                                show.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                            }
                        }
                        SqlDataReader reader = show.ExecuteReader();
                        while (reader.Read())
                        {
                            Dictionary<string, Object> rowVal = new Dictionary<string, Object>();
                            values.Add(rowVal);
                            for (int i = 0; i < fields.Count(); i++)
                            {
                                if (!reader.IsDBNull(i))
                                {
                                    rowVal.Add(fields[i], reader.GetValue(i));
                                }
                                else
                                {
                                    rowVal.Add(fields[i], null);
                                }
                            }
                        }
                        reader.Close();
                    }
                }
                catch (Exception e)
                {
                    ex(e);
                }
            }
            return values;
        }
    }
}
