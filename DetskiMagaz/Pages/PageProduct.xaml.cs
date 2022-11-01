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
using System.Windows.Threading;



namespace DetskiMagaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        public PageProduct()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();

            ConnectOdb.ConObj.Provider.ToList();
            gridList.ItemsSource = ConnectOdb.ConObj.Product.ToList();


        }
        public void UpdateData(object sender, object e)
        {
            var HistoryProduct = ConnectOdb.ConObj.Product.ToList();
            ListProduct.ItemsSource = HistoryProduct;
            ListProduct.ItemsSource = ConnectOdb.ConObj.Product.Where(x => x.name.StartsWith(TxtSearch.Text)).ToList();

            ConnectOdb.ConObj.Manufacturer.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.MainFrame.Navigate(new PageEditNew((sender as Button).DataContext as Product));
        }

        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            gridList.ItemsSource = ConnectOdb.ConObj.Product.OrderBy(x => x.name).ToList();
        }

        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            gridList.ItemsSource = ConnectOdb.ConObj.Product.OrderByDescending(x => x.name).ToList();
        }
    }

    }
