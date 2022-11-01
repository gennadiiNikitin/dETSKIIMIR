using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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


namespace DetskiMagaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditNew.xaml
    /// </summary>
    public partial class PageEditNew : Page
    {
        string mainImg;
        List<string> imgList = new List<string>();

        public PageEditNew(Product product)
        {
            InitializeComponent();
            comboBox2.SelectedIndex = (int)product.manufacturer2 - 1;
            comboBox2.SelectedValuePath = "ID";
            comboBox2.DisplayMemberPath = "Manufacturer1";
            comboBox2.ItemsSource = ConnectOdb.ConObj.Manufacturer.ToList();

            comboBox3.SelectedIndex = (int)product.provider2 - 1;
            comboBox3.SelectedValuePath = "ID";
            comboBox3.DisplayMemberPath = "provider1";
            comboBox3.ItemsSource = ConnectOdb.ConObj.Provider.ToList();

            ProductObj.article_number = product.article_number;

            articleTX.Text = product.article_number;
            titleTX.Text = product.name;
            StoimTX.Text = Convert.ToString(product.stoimost);
            MaxSkdTX.Text = Convert.ToString(product.max_discount);
            descTX.Text = product.description;
            StringImage.Text = product.photo;

        }

        private void saveAddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<Product> products = ConnectOdb.ConObj.Product.Where(x => x.article_number == ProductObj.article_number).AsEnumerable().
                  Select(x =>
                  {
                      x.article_number = articleTX.Text;
                      x.name = titleTX.Text;
                      x.stoimost = Convert.ToInt32(StoimTX.Text);
                      x.max_discount = Convert.ToInt32(MaxSkdTX.Text);
                      x.description = descTX.Text;
                      x.manufacturer2 = (comboBox2.SelectedItem as Manufacturer).ID;
                      x.provider2 = (comboBox3.SelectedItem as Provider).ID;
                      x.unit = Convert.ToString(Lb1.Content);


                      if (string.IsNullOrWhiteSpace(StringImage.Text))
                      {
                          x.photo = "../Resources/logo.png";
                      }
                      else
                      {
                          x.photo = "../Resources/" + mainImg;
                      }


                      return x;
                  });

                foreach (Product product in products)
                {
                    ConnectOdb.ConObj.Entry(product).State = System.Data.Entity.EntityState.Modified;
                }

                ConnectOdb.ConObj.SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameObj.MainFrame.Navigate(new PageProduct());
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }

        }

        private void typeEdIzmCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Lb1.Content = ((ComboBoxItem)(((ComboBox)sender).SelectedItem)).Content.ToString();
        }


        private void AddIMG_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image | *.png; *.jpg";
            fd.ShowDialog();
            mainImgName.Text = fd.SafeFileName;
            mainImg = fd.SafeFileName;
            StringImage.Text = "../Resources/" + mainImg;
        }
    }
        }
    
