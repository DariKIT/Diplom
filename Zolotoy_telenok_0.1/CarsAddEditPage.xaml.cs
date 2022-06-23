using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Zolotoy_telenok_0._1
{
    /// <summary>
    /// Логика взаимодействия для CarsAddEditPage.xaml
    /// </summary>
    public partial class CarsAddEditPage : Page
    {
        private Машина _CurCars = new Машина();
        public CarsAddEditPage(Машина SelectedCar)
        {
            InitializeComponent();
            if (SelectedCar != null)
                _CurCars = SelectedCar;
            DataContext = _CurCars;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-6]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SaveCarBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_CurCars.Марка))
                Errors.AppendLine("Введите марку машины!");
            if (string.IsNullOrWhiteSpace(_CurCars.Модель))
                Errors.AppendLine("Введите модель машины!");
            if (_CurCars.Класс < 1 || _CurCars.Класс > 5)
                Errors.AppendLine("Класс машины от 1 до 5");
            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }

            if (_CurCars.ИД_Машины == 0)
                ZTDBEntities.GetContext().Машина.Add(_CurCars);
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
