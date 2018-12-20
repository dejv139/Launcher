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
            getButtons(buttons, fileInfos);
            files.ItemsSource = buttons;

        }

        private List<Button> buttons = new List<Button>();
        private List<string> fileInfos = new List<string>();
        private DirectoryInfo di = new DirectoryInfo(@"C:\Users\David Motúz\source\repos");

        private List<Button> getButtons(List<Button> items, List<string> files)
        {
            foreach (var fileInfo in di.GetFiles( "*.exe", SearchOption.AllDirectories))
            {
              
                if (!fileInfo.FullName.Contains("bin"))
                {
                    Button newBtn = new Button();
                    newBtn.Click += Button_Click;
                    newBtn.MinHeight = 180;
                    newBtn.Width = 500;
                    newBtn.Content = fileInfo.Name;
                    
                    items.Add(newBtn);
                    files.Add(fileInfo.FullName);
                }              
            }
            return items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process proc = new Process();
            Button btn = (Button)sender;

            

            proc.StartInfo = new ProcessStartInfo(btn.Content.ToString());
            proc.Start();
        
        }
    }
}
