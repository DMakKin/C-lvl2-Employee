using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_Lesson_8.Models
{
    public class GetEmpl
    {
        private SqlConnection sqlConnection;

        public GetEmpl()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                       Initial Catalog=Lesson7_190818;
                                       Integrated Security=True;
                                       ";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        public List<Employee> GetList()
        {
            List<Employee> empList = new List<Employee>();

            string sql = @"Select * From Employee";

            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        empList.Add(
                            new Employee()
                            {
                                Surname = reader["Surname"].ToString(),
                                Name = reader["Name"].ToString(),
                                Age = reader["Age"].ToString(),
                                Dep = reader["Dep"].ToString()
                            });
                    }
                }
            }
            return empList;
        }

        public Employee GetEmplId(int Id)
        {
            string sql = $@"SELECT * FROM People WHERE Id={Id}";
            Employee temp = new Employee();
            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        temp = new Employee()
                        {
                            Surname = reader["Surname"].ToString(),
                            Name = reader["Name"].ToString(),
                            Age = reader["Age"].ToString(),
                            Dep = reader["Dep"].ToString()
                        };
                    }
                }
            }
            return temp;
        }

        public bool AddEmployee(Employee Worker)
        {
            try
            {
                string sqlAdd = $@" INSERT INTO Employee(Surname, Name, Age, Dep)
                               VALUES(N'{Worker.Surname}',
                                      N'{Worker.Name}',
                                      N'{Worker.Age}',
                                      N'{Worker.Dep}' )";

                using (var com = new SqlCommand(sqlAdd, sqlConnection))
                {
                    com.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}