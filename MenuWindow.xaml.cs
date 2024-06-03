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
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace Projektusamogus
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }
        private void Level1Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(1);
            mainWindow.Show();
            this.Close();
        }
        private void Level2Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(2);
            mainWindow.Show();
            this.Close();
        }
        private void Level3Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(3);
            mainWindow.Show();
            this.Close();
        }
    }
}
