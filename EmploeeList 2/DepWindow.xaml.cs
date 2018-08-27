using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace EmploeeList_2
{
    /// <summary>
    /// Логика взаимодействия для DepWindow.xaml
    /// </summary>
    public partial class DepWindow : Window
    {
        public DataRow resultRow { get; set; }
        DataRowView newRow;
        SqlCommand command;
        SqlDataReader reader;
        int depID = 0;

        public DepWindow()
        {
            InitializeComponent();
            DepDataGrid.DataContext = MainWindow.depTable.DefaultView;
        }     
        /// <summary>
        /// Добавление нового департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNameButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.connection.Open();
            command = new SqlCommand($@"Select DepNum from Department", MainWindow.connection);//Запрос имеющихся ID департаментом
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (depID < System.Convert.ToInt32(reader.GetValue(0)))
                    depID = System.Convert.ToInt32(reader.GetValue(0));
            }//Нахождение последнего ID
            MainWindow.connection.Close();

            DataRow newRow = MainWindow.depTable.NewRow();//Создание новой строки департамента
            newRow["DepName"] = DepNameBox.Text;//Присвоение введенного имени
            newRow["DepNum"] = depID + 1;//Присвоение нового ID
            MainWindow.depTable.Rows.Add(newRow);//Добавление строки
            MainWindow.depAdapter.Update(MainWindow.depTable);//Обновление таблицы          
        }
        /// <summary>
        /// Изменение департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeNameButton_Click(object sender, RoutedEventArgs e)
        {
            newRow = (DataRowView)DepDataGrid.SelectedItem;//Копирование выделенной строки
            if (newRow != null)
            {
                newRow.BeginEdit();
                newRow["DepName"] = DepNameBox.Text;//Изменение наименования
                newRow.EndEdit();
                MainWindow.depAdapter.Update(MainWindow.depTable);                
            }
        }
        /// <summary>
        /// Отмена изменения департаментов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
