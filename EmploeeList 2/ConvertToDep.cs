using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Data;

namespace EmploeeList_2
{
    public class ConvertToDep : IValueConverter
    {
        SqlCommand command;        
        SqlDataReader reader;
        string dep;
        /// <summary>
        /// Конвертер, переводит ID в наименование департамента
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tragetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type tragetType, object parameter, CultureInfo culture)
        {            
            MainWindow.connection.Open();
            command = new SqlCommand(
                $@"Select DepName from Department where Department.DepNum = {System.Convert.ToString(value)}", 
                MainWindow.connection);//Запрос для отбора соответствующего наименования

            try
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dep = System.Convert.ToString(reader.GetValue(0));
                    }//Запись департамента в переменную
                }
                catch { }
             
            MainWindow.connection.Close();
            return dep;
        }
        public object ConvertBack(object value, Type tragetType, object parameter, CultureInfo culture)
        {
            int num = System.Convert.ToInt32(value);//Тестовые данные 
            return num + 100;//Оставил так как требуется return, но он мне не нужен
        }
    }
}