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
       /* private Машина _CurCar = new Машина();
        private Работник _CurWorker = new Работник();
        private Услуги _CurServices = new Услуги();*/
        public JournalAddEditPage(Запись SelectedJournal)
        {
            InitializeComponent();
            DataContext = _CurJournal;
           /* DataContext = _CurCar;
            DataContext = _CurWorker;
            DataContext = _CurServices;*/
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
           /* StringBuilder Errors = new StringBuilder();

            if (_CurCar.Cars == null)
                Errors.AppendLine("Выберите машину");
            if (_CurWorker.Worker == null)
                Errors.AppendLine("Выберите работника");
            if (_CurServices == null)
                Errors.AppendLine("Выберите услугу");
            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }
            if (_CurJournal.ИД_Записи == 0)
            {
                
                ZTDBEntities.GetContext().Запись.Add(_CurJournal);
                return;
            }*/ 
        }
    }
}
