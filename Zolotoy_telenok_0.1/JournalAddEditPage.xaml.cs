using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;

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

            CarsMarkCB.ItemsSource = ZTDBEntities.GetContext().Машина.ToList();
            WorkerCB.ItemsSource = ZTDBEntities.GetContext().Работник.ToList();
            ServicesCB.ItemsSource = ZTDBEntities.GetContext().Услуги.ToList();

            if (SelectedJournal == null)
                _CurJournal = SelectedJournal;
            DataContext = _CurJournal;

        }



        private void back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private int GetSumma(Машина машина, Услуги услуга)
        {
            if (машина.Класс == 2)
            {
                return (int)(Convert.ToInt64(услуга.Цена) * 1.2);
            }
            else if (машина.Класс == 3)
            {
                return (int)(Convert.ToInt64(услуга.Цена) * 1.3);
            }
            else if (машина.Класс == 4)
            {
                return (int)(Convert.ToInt64(услуга.Цена) * 1.4);
            }
            else if (машина.Класс == 5)
            {
                return (int)(Convert.ToInt64(услуга.Цена) * 1.5);
            }
            else
            {
                return (int)услуга.Цена;
            }
        }


        private void SaveJournalBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((DataPick.SelectedDate).ToString());
            StringBuilder Errors = new StringBuilder();
            if ((CarsMarkCB.SelectedItem as Машина) == null)
                Errors.AppendLine("Вы не выбрали машину");
            if ((WorkerCB.SelectedItem as Работник) == null)
                Errors.AppendLine("Вы не выбрали мойщика");
            if ((ServicesCB.SelectedItem as Услуги) == null)
                Errors.AppendLine("Вы не выбрали услугу");
            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }

            
            
                ZTDBEntities.GetContext().Запись.Add(new Запись()
                {
                    Машина = CarsMarkCB.SelectedItem as Машина,
                    Работник = WorkerCB.SelectedItem as Работник,
                    Услуги = ServicesCB.SelectedItem as Услуги,
                    Сумма = GetSumma(CarsMarkCB.SelectedItem as Машина, ServicesCB.SelectedItem as Услуги),
                    Дата = DataPick.SelectedDate.Value,

                });
            
            ZTDBEntities.GetContext().SaveChanges();

        }
    }
}
