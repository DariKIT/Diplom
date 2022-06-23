using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Zolotoy_telenok_0._1
{
    /// <summary>
    /// Логика взаимодействия для WorkersAddEditPage.xaml
    /// </summary>
    public partial class WorkersAddEditPage : Page
    {
        private Работник _CurWorkers = new Работник();
        public WorkersAddEditPage(Работник _SelectedWorkers)
        {
            InitializeComponent();
            if (_SelectedWorkers != null)
                _CurWorkers = _SelectedWorkers;
            DataContext = _CurWorkers;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SaveWorkerAddBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_CurWorkers.Фамилия))
                Errors.AppendLine("ВВедите фамилию");
            if (string.IsNullOrWhiteSpace(_CurWorkers.Имя))
                Errors.AppendLine("ВВедите имя");
            if (string.IsNullOrWhiteSpace(_CurWorkers.Отчество))
                Errors.AppendLine("ВВедите отчество");
            if (string.IsNullOrWhiteSpace(_CurWorkers.Телефон))
                Errors.AppendLine("ВВедите телефон");
            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }
            if (_CurWorkers.ИД_Работника == 0)
                ZTDBEntities.GetContext().Работник.Add(_CurWorkers);
            try
            {
                ZTDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Сохранено");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }


        }
    }
}
