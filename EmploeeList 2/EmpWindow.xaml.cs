using System.Data;
using System.Windows;

namespace EmploeeList_2
{
    /// <summary>
    /// Логика взаимодействия для EmpWindow.xaml
    /// </summary>
    public partial class EmpWindow : Window
    {
        public DataRow resultRow { get; set; }//Создание вспомогательной строки
        public EmpWindow(DataRow dataRow)
        {
            InitializeComponent();
            resultRow = dataRow;
            DepForEmpDataGrid.DataContext = MainWindow.depTable.DefaultView;
        }
        /// <summary>
        /// Заполнение полей данными выделенной строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            SurnameBox.Text = resultRow["Surname"].ToString();
            NameBox.Text = resultRow["Name"].ToString();
            AgeBox.Text = resultRow["Age"].ToString();
            DepBlock.Text = resultRow["Dep"].ToString();
        }
        /// <summary>
        /// Присвоение введенных значений новой строке 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            resultRow["Surname"] = SurnameBox.Text;
            resultRow["Name"] = NameBox.Text;
            resultRow["Age"] = AgeBox.Text;
            resultRow["Dep"] = DepBlock.Text;
            DialogResult = true;
        }        
        /// <summary>
        /// Отмена обработки сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
