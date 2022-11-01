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
using System.Data;
using Microsoft.Win32;
using System.Data.Entity;
using System.IO;


namespace DetskiMagaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddProduct.xaml
    /// </summary>
    public partial class PageAddProduct : Page
    {
        string mainImg;
        List<string> imgList = new List<string>();

        public PageAddProduct()
        {
            InitializeComponent();
            comboBox2.SelectedValuePath = "ID";
            comboBox2.DisplayMemberPath = "Manufacturer1";
            comboBox2.ItemsSource = ConnectOdb.ConObj.Manufacturer.ToList();

            comboBox3.SelectedValuePath = "ID";
            comboBox3.DisplayMemberPath = "provider1";
            comboBox3.ItemsSource = ConnectOdb.ConObj.Provider.ToList();

            comboBox4.SelectedValuePath = "category_number";
            comboBox4.DisplayMemberPath = "category_name";
            comboBox4.ItemsSource = ConnectOdb.ConObj.ProductCategory.ToList();


        }

        private void AddIMG_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image | *.png; *.jpg";
            fd.ShowDialog();
            mainImgName.Text = fd.SafeFileName;
            mainImg = fd.SafeFileName;
        }

        private void typeEdIzmCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Lb1.Content = ((ComboBoxItem)(((ComboBox)sender).SelectedItem)).Content.ToString();
        }

        private void saveAddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product()
                {

                    article_number = articleTX.Text,
                    name = titleTX.Text,
                    stoimost = Convert.ToInt32(StoimTX.Text),
                    max_discount = Convert.ToInt32(MaxSkdTX.Text),
                    discount = Convert.ToInt32(scidTX.Text),
                    quanitity_in_stock = Convert.ToInt32(colSkladTX.Text),
                    description = descTX.Text,
                    photo = StringImage.Text,
                    unit = Convert.ToString(Lb1.Content),
                    manufacturer2 = (comboBox2.SelectedItem as Manufacturer).ID,
                    provider2 = (comboBox3.SelectedItem as Provider).ID,
                    category_number = (comboBox4.SelectedItem as ProductCategory).category_number

                };

                ConnectOdb.ConObj.Product.Add(product);
                ConnectOdb.ConObj.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameObj.MainFrame.Navigate(new PageAddProduct());
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }


        }

        
    }


    }

