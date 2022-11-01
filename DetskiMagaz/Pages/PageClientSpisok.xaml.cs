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

namespace DetskiMagaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageClientSpisok.xaml
    /// </summary>
    public partial class PageClientSpisok : Page
    {
        public PageClientSpisok()
        {
            InitializeComponent();
            CmbxUser.DisplayMemberPath = "FIO";
            CmbxUser.SelectedValuePath = "ID";
            CmbxUser.ItemsSource = ConnectOdb.ConObj.Users.Where(x => x.role1 == 3).ToList();
            GridUser.IsReadOnly = true;
            GridUser.ItemsSource = ConnectOdb.ConObj.Users.Where(x => x.ID == UsersObj.ID).ToList();
        }

        private void CmbxUser_SelectionChanges(object sender, SelectionChangedEventArgs e)
        {
            GridUser.ItemsSource = null;
            int SelectUser = Convert.ToInt32(CmbxUser.SelectedValue);
            GridUser.ItemsSource = ConnectOdb.ConObj.Users.Where(x => x.ID == SelectUser).ToList();
        }
    }
}
