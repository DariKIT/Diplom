using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zolotoy_telenok_0._1
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            CarsList.ItemsSource = ZTDBEntities.GetContext().Машина.ToList();
            ServicesList.ItemsSource = ZTDBEntities.GetContext().Услуги.ToList();
            WorkerList.ItemsSource = ZTDBEntities.GetContext().Работник.ToList();
            
         
        }

        private void CarsEditBtn_Click(object sender, RoutedEventArgs e) //Редактирование машин
        {

        }

        private void ServicesEditBtn_Click(object sender, RoutedEventArgs e) //Редактирование услуг
        {

        }

        private void WorkerEditBtn_Click(object sender, RoutedEventArgs e) //Редактирование сотрудников
        {

        }

        private void JournalEditBtn_Click(object sender, RoutedEventArgs e)//Редактирование журнала
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)//Проверка кнопки
        {
            if (JournalTabItem.IsSelected)
            {
                Manager.MainFrame.Navigate(new JournalAddEditPage());
            }
            if (ApplicationsTabItem.IsSelected)
            {
               
            }
            if (WorkersTadItem.IsSelected)
            {
                Manager.MainFrame.Navigate(new WorkersAddEditPage());
            }
            if (ServicesTapItem.IsSelected)
            {
                Manager.MainFrame.Navigate(new ServicesAddEditPage());
            }
            if (CarsTabItem.IsSelected)
            {
                Manager.MainFrame.Navigate(new CarsAddEditPage(null));
            }

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ZTDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(i => i.Reload());
            CarsList.ItemsSource = ZTDBEntities.GetContext().Машина.ToList();
        }
    }
}
