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
        
        public JournalAddEditPage()
        {
            InitializeComponent();
            CarsMarkCB.ItemsSource = ZTDBEntities.GetContext().Машина.Distinct().ToArray().ToList();




        }



        private void back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
