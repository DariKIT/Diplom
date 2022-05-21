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
    /// Логика взаимодействия для JournalAddEditPage.xaml
    /// </summary>
    public partial class JournalAddEditPage : Page
    {
        private Запись _CurJournal = new Запись();
        public JournalAddEditPage(Запись SelectedJournal)
        {
            InitializeComponent();
            DataContext = _CurJournal;
            if (SelectedJournal != null)
                _CurJournal = SelectedJournal;
            CarsMarkCB.ItemsSource = ZTDBEntities.GetContext().Машина.ToList();
            WorkerCB.ItemsSource = ZTDBEntities.GetContext().Работник.ToList();
            ServicesCB.ItemsSource = ZTDBEntities.GetContext().Услуги.ToList();

        }



        private void back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void SaveJournalBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();

            if (_CurJournal.ИД_Машины == 0)
                Errors.AppendLine("Выберите машину");
            if (_CurJournal.ИД_Работнка == 0)
                Errors.AppendLine("Выберите работника");
            if (_CurJournal.ИД_Услуги == 0)
                Errors.AppendLine("Выберите услугу");
            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }
            if (_CurJournal.ИД_Записи == 0)
            {
                MessageBox.Show("Успех");
                return;
            }
        }
    }
}
