using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmploeeList_2
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Заполнение таблицы Department
        /// </summary>
        public static void FillDepartment()
        {
            try
            {
                Random r = new Random();
                for (int i = 1; i <= 5; i++)
                {
                    Department dep = new Department
                    {
                        DepName = ("Департамент " + i),
                        DepNum = i,
                    };

                    var sql = $@"Insert into Department (DepName, DepNum) Values (N'{dep.DepName}', '{dep.DepNum}')";//Формирование строки запроса
                    //var sql = $@"Delete from Department Where id>0"; //Удаление записей из таблицы

                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))//Создание подключения
                    {
                        connection.Open();

                        SqlCommand fillDepCommand = new SqlCommand(sql, connection);
                        fillDepCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Опс...");
            }           
        }
        /// <summary>
        /// Заполнение таблицы Employee
        /// </summary>
        public static void FillEmployee()
        {
            try
            {
                Random r = new Random();
                for (int i = 1; i <= 10; i++)
                {
                    var employee = new Employee
                    {
                        Surname = "Фамилия",
                        Name = "Имя",
                        Age = r.Next(18, 65),
                        Dep = r.Next(1, 5)
                    };
                    var sql = $@"Insert into Employee (Surname, Name, Age, Dep) 
                    Values (N'{employee.Surname}', N'{employee.Name}', '{employee.Age}', N'{employee.Dep}')";
                    //var sql = $@"Delete from Employee Where id>0"; //Удаление записей из таблицы

                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    {
                        connection.Open();

                        SqlCommand fillEmpCommand = new SqlCommand(sql, connection);
                        fillEmpCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Опс...");
            }
        }
    }
}
