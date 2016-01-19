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

        public string fileName;
        public bool hasFileName = false;

        private void menuNew_Click(object sender, RoutedEventArgs e)
        {
            Window1 saveNewFilePrompt = new Window1();
            saveNewFilePrompt.Show();
        }

        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog menuOpen = new OpenFileDialog();
            menuOpen.Filter = "Text files (recommended) (*.txt)|*.txt| All files (*.*)|*.*";
            if (menuOpen.ShowDialog() == true)
            {
                OpenFile(menuOpen.FileName);
                fileName = menuOpen.FileName;
                hasFileName = true;
            }
        }

        private void menuSaveAs_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog menuSaveAs = new SaveFileDialog();
            menuSaveAs.Filter = "Text file (*.txt)|*.txt";
            if (menuSaveAs.ShowDialog() == true)
            {
                File.WriteAllText(menuSaveAs.FileName, textBox.Text);
                fileName = menuSaveAs.FileName;
                hasFileName = true;
            }
        }

        private void menuSave_Click(object sender, RoutedEventArgs e)
        {
            if (hasFileName)
            {
                File.WriteAllText(fileName, textBox.Text);
            }
            else
            {
                SaveFileDialog menuSaveAs = new SaveFileDialog();
                menuSaveAs.Filter = "Text file (*.txt)|*.txt";
                if (menuSaveAs.ShowDialog() == true)
                {
                    File.WriteAllText(menuSaveAs.FileName, textBox.Text);
                    fileName = menuSaveAs.FileName;
                    hasFileName = true;
                }
            }
        }

        private void menuClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow1.Close();
        }

        public void OpenFile(string fileName)
        {
            textBox.Text = File.ReadAllText(fileName);
        }
    }
}
