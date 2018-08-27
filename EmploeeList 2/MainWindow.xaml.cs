using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace EmploeeList_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Определение переменных
        public static SqlConnection connection;
        public static SqlConnectionStringBuilder connectionString;
        DataTable empTable;
        SqlDataAdapter adapter;
        SqlCommand command;
        public static DataTable depTable;
        public static SqlDataAdapter depAdapter;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }                  

        public void Window_Load(object sender, RoutedEventArgs e)
        {
            #region Установка соединения с БД
            connectionString = new SqlConnectionStringBuilder 
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "Lesson7_190818",
                Pooling = true
            };
            #endregion
            #region Заполнение таблиц
            //FillDepartment();
            //FillEmployee();
            #endregion
            #region Обработка данных
            connection = new SqlConnection(connectionString.ConnectionString);
            adapter = new SqlDataAdapter();
            depAdapter = new SqlDataAdapter();

            //Select
            command = new SqlCommand("Select ID, Surname, Name, Age, Dep from Employee", connection);//Описание запроса
            adapter.SelectCommand = command;//Привсваивание запроса адаптеру
            //SelectDep
            command = new SqlCommand("Select ID, DepName, DepNum from Department", connection);
            depAdapter.SelectCommand = command;

            //Insert
            command = new SqlCommand(@"Insert Into Employee (Surname, Name, Age, Dep)
                          Values (@Surname, @Name, @Age, @Dep); Set @ID = @@Identity;", connection);//Описание запроса

            command.Parameters.Add("@Surname", SqlDbType.NVarChar, -1, "Surname");//Добавление параметров запроса
            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            command.Parameters.Add("@Age", SqlDbType.NVarChar, -1, "Age");
            command.Parameters.Add("@Dep", SqlDbType.NVarChar, -1, "Dep");
            SqlParameter param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            adapter.InsertCommand = command;//Привсваивание запроса адаптеру

            //InsertDep
            command = new SqlCommand(@"Insert Into Department (DepName, DepNum)
                          Values (@DepName, @DepNum); Set @ID = @@Identity;", connection);
            command.Parameters.Add("@DepName", SqlDbType.NVarChar, -1, "DepName");
            command.Parameters.Add("@DepNum", SqlDbType.NVarChar, -1, "DepNum");
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            depAdapter.InsertCommand = command;

            //Update
            command = new SqlCommand(@"Update Employee Set Surname = @Surname, Name = @Name, Age = @Age, 
                          Dep = @Dep Where ID = @ID", connection);

            command.Parameters.Add("@Surname", SqlDbType.NVarChar, -1, "Surname");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            command.Parameters.Add("@Age", SqlDbType.NVarChar, -1, "Age");
            command.Parameters.Add("@Dep", SqlDbType.NVarChar, -1, "Dep");
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");            
            adapter.UpdateCommand = command;

            //UpdateDep
            command = new SqlCommand(@"Update Department Set DepName = @DepName, DepNum = @DepNum Where ID = @ID", connection);
            command.Parameters.Add("@DepName", SqlDbType.NVarChar, -1, "DepName");
            command.Parameters.Add("@DepNum", SqlDbType.NVarChar, -1, "DepNum");
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            depAdapter.UpdateCommand = command;

            //Delete
            command = new SqlCommand("Delete From Employee Where ID = @ID", connection);
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            param.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = command;

            
            empTable = new DataTable();//Создание новой таблицы
            adapter.Fill(empTable);//Заполнение таблицы сотрудников данными из БД
            EmployeeDataGrid.DataContext = empTable.DefaultView;//Привязка таблицы к форме

            depTable = new DataTable();//Создание новой таблицы
            depAdapter.Fill(depTable);//Заполнение таблицы департаментов данными из БД            
            #endregion
        }
        /// <summary>
        /// Обработка нажатия кнопки добавления сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEmpButton_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = empTable.NewRow();//Создание новой строки            
            EmpWindow empWindow = new EmpWindow(newRow);//Создание нового окна с присвоением созданой строки
            empWindow.ShowDialog();//Запуск диалогового окна

            if (empWindow.DialogResult.Value)
            {
                empTable.Rows.Add(empWindow.resultRow);//Добавление новой строки
                adapter.Update(empTable);//Обновление таблицы с данными
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки изменения сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeEmpButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem != null)//Проверка наличия выделения содрудника
            {
                DataRowView newRow = (DataRowView)EmployeeDataGrid.SelectedItem;//Создание новой строки равной выделеной
                newRow.BeginEdit();//Начало изменения

                EmpWindow empWindow = new EmpWindow(newRow.Row);//Создание нового окна с присвоением созданой строки
                empWindow.ShowDialog();//Запуск диалогового окна
                if (empWindow.DialogResult.Value)
                {
                    newRow.EndEdit();//Конец обновления
                    adapter.Update(empTable);//Обновление таблицы с данными
                }
                else
                {
                    newRow.CancelEdit();//Отмена
                }
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки удаления сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem == null)//Проверка наличия выделения содрудника
            {
                MessageBox.Show("Выберите сотрудника");
            }
            else
            {
                DataRowView rowView = (DataRowView)EmployeeDataGrid.SelectedItem;
                rowView.Row.Delete();//Удаление строки
                adapter.Update(empTable);//Обновление таблицы с данными
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки департаментов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepButton_Click(object sender, RoutedEventArgs e)
        {            
            DepWindow depWindow = new DepWindow();//Создание окна
            depWindow.Show();//Запуск окна
        }
        /// <summary>
        /// Обновление формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDataGrid.DataContext = null;
            EmployeeDataGrid.DataContext = empTable.DefaultView;
        }
    }
}