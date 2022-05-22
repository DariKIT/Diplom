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
            JournalList.ItemsSource = ZTDBEntities.GetContext().Запись.ToList();


        }

        private void CarsEditBtn_Click(object sender, RoutedEventArgs e) //Редактирование машин
        {
            Manager.MainFrame.Navigate(new CarsAddEditPage((sender as Button).DataContext as Машина));
        }

        private void ServicesEditBtn_Click(object sender, RoutedEventArgs e) //Редактирование услуг
        {
            Manager.MainFrame.Navigate(new ServicesAddEditPage((sender as Button).DataContext as Услуги));
        }

        private void WorkerEditBtn_Click(object sender, RoutedEventArgs e) //Редактирование сотрудников
        {
            Manager.MainFrame.Navigate(new WorkersAddEditPage((sender as Button).DataContext as Работник));
        }

        private void JournalEditBtn_Click(object sender, RoutedEventArgs e)//Редактирование журнала
        {
            Manager.MainFrame.Navigate(new JournalAddEditPage((sender as Button).DataContext as Запись));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)//Проверка кнопки
        {
            if (JournalTabItem.IsSelected)
            {
                Manager.MainFrame.Navigate(new JournalAddEditPage(null));
            }
            if (ApplicationsTabItem.IsSelected)
            {
               
            }
            if (WorkersTadItem.IsSelected)
            {
                Manager.MainFrame.Navigate(new WorkersAddEditPage(null));
            }
            if (ServicesTapItem.IsSelected)
            {
                Manager.MainFrame.Navigate(new ServicesAddEditPage(null));
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
            ServicesList.ItemsSource = ZTDBEntities.GetContext().Услуги.ToList();
            WorkerList.ItemsSource = ZTDBEntities.GetContext().Работник.ToList();
            JournalList.ItemsSource = ZTDBEntities.GetContext().Запись.ToList();
        }

        private void RemBtn_Click(object sender, RoutedEventArgs e)
        {
            if (JournalTabItem.IsSelected)
            {
                var WorkForRem = JournalList.SelectedItems.Cast<Запись>().ToList();
                if (MessageBox.Show($"Хотите ли вы удалить {WorkForRem.Count()} Элементы?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ZTDBEntities.GetContext().Запись.RemoveRange(WorkForRem);
                        ZTDBEntities.GetContext().SaveChanges();
                        JournalList.ItemsSource = ZTDBEntities.GetContext().Запись.ToList();
                        MessageBox.Show("Данные удалены");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            if (ApplicationsTabItem.IsSelected)
            {

            }
            if (WorkersTadItem.IsSelected)
            {
                var WorkersForRem = WorkerList.SelectedItems.Cast<Работник>().ToList();
                if (MessageBox.Show($"Хотите ли вы удалить {WorkersForRem.Count()} Элементы?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ZTDBEntities.GetContext().Работник.RemoveRange(WorkersForRem);
                        ZTDBEntities.GetContext().SaveChanges();
                        WorkerList.ItemsSource = ZTDBEntities.GetContext().Работник.ToList();
                        MessageBox.Show("Данные удалены");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                }
            }
            if (ServicesTapItem.IsSelected)
            {
                var ServicesForRem = ServicesList.SelectedItems.Cast<Услуги>().ToList();
                if (MessageBox.Show($"Хотите ли вы удалить {ServicesForRem.Count()} Элементы?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ZTDBEntities.GetContext().Услуги.RemoveRange(ServicesForRem);
                        ZTDBEntities.GetContext().SaveChanges();
                        ServicesList.ItemsSource = ZTDBEntities.GetContext().Услуги.ToList();
                        MessageBox.Show("Данные удалены");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                }
            }
            if (CarsTabItem.IsSelected)
            {
                var CarsForRem = CarsList.SelectedItems.Cast<Машина>().ToList();
                if (MessageBox.Show($"Хотите ли вы удалить {CarsForRem.Count()} Элементы?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ZTDBEntities.GetContext().Машина.RemoveRange(CarsForRem);
                        ZTDBEntities.GetContext().SaveChanges();
                        CarsList.ItemsSource = ZTDBEntities.GetContext().Машина.ToList();
                        MessageBox.Show("Данные удалены");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                }
            }
        }
    }
}
