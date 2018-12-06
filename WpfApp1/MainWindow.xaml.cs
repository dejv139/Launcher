using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp1
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            foreach (string dirPath in Directory.GetFiles("D:\\motuzda16", "*.txt",SearchOption.AllDirectories))
            {
                string[] s = dirPath.Split('\\');
                Button newBtn = new Button();
                newBtn.Click += Button_Click;
                newBtn.MinHeight = 180;
                newBtn.Width = 180;
                newBtn.Content = s[s.Length - 1];
                files.Items.Add(newBtn);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process proc = new Process();
            Button btn = (Button)sender;
            string keyword = btn.Content.ToString();
            foreach (string dirPath in Directory.GetFiles("D:\\motuzda16", "*.txt", SearchOption.AllDirectories))
            {
                string[] s = dirPath.Split('\\');
                if (s[s.Length - 1] == keyword)
                {
                    proc.StartInfo = new ProcessStartInfo(dirPath);
                    proc.Start();
                }
            }

        }
    }
}
