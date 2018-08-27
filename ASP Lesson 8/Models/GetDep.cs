using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_Lesson_8.Models
{
    public class GetDep
    {
        private SqlConnection sqlConnection;

        public GetDep()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                       Initial Catalog=Lesson7_190818;
                                       Integrated Security=True;
                                       ";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        public List<Department> GetDepList()
        {
            List<Department> depList = new List<Department>();

            string sql = @"Select * From Department";

            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        depList.Add(
                            new Department()
                            {
                                DepName = reader["DepName"].ToString(),
                                DepNum = reader["DepNum"].ToString()
                            });
                    }
                }
            }
            return depList;
        }

        public Department GetDepId(int Id)
        {
            string sql = $@"SELECT * FROM Department WHERE Id={Id}";
            Department temp = new Department();
            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp = new Department()
                        {
                            DepName = reader["DepName"].ToString(),
                            DepNum = reader["DepNum"].ToString()
                        };
                    }
                }
            }
            return temp;
        }        
    }
}