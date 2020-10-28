using FreshFruit.Controller;
using FreshFruit.Model;
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

namespace FreshFruit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, BucketEventListener
    {
        Seller wahyu;
        public MainWindow()
        {
            InitializeComponent();
            Bucket KeranjangBuah = new Bucket(4);
            BucketController bucketController = new BucketController(KeranjangBuah, this);

            wahyu = new Seller("Wahyu", bucketController);
            ListBoxBucket.ItemsSource = KeranjangBuah.findAll();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Fruit anggur = new Fruit("Anggur");
            wahyu.addFruit(anggur);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Fruit apel = new Fruit("Apel");
            wahyu.addFruit(apel);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Fruit pisang = new Fruit("Pisang");
            wahyu.addFruit(pisang);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Fruit jeruk = new Fruit("Jeruk");
            wahyu.addFruit(jeruk);
        }
        public void onFailed(string message)
        {
            MessageBox.Show(message, "Warning!");
        }
        public void onSucceed(string message)
        {
            ListBoxBucket.Items.Refresh();
        }
    }
}
