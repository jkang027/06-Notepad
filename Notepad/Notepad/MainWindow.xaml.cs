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
using System.IO;
using Microsoft.Win32;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuNew_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menuNew = new MainWindow();
            menuNew.Show();
        }

        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog menuOpen = new OpenFileDialog();
            menuOpen.Filter = "Text files (recommended) (*.txt)|*.txt| All files (*.*)|*.*";
            if (menuOpen.ShowDialog() == true)
                textBox.Text = File.ReadAllText(menuOpen.FileName);
        }

        private void menuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog menuSave = new SaveFileDialog();
            menuSave.Filter = "Text file (*.txt)|*.txt";
            if (menuSave.ShowDialog() == true)
                File.WriteAllText(menuSave.FileName, textBox.Text);
        }

        private void menuClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow1.Close();
        }
    }
}
