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


namespace Notepad
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog menuSaveAs = new SaveFileDialog();
            menuSaveAs.Filter = "Text file (*.txt)|*.txt";
            if (menuSaveAs.ShowDialog() == true)
            {
                File.WriteAllText(menuSaveAs.FileName, "");
            }
            SaveNewFilePrompt.Close();

            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            newWindow.fileName = menuSaveAs.FileName;
            newWindow.OpenFile(newWindow.fileName);
            newWindow.hasFileName = true;
            newWindow.textBlock.Text = newWindow.fileName;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SaveNewFilePrompt.Close();
            MainWindow menuNew = new MainWindow();
            menuNew.Show();
        }
    }
}
