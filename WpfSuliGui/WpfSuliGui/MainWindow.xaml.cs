using System;
using System.Collections.Generic;
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

namespace WpfSuliGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                var sorok = File.ReadAllLines("nevekGUI.txt", Encoding.Default);
                for (int i = 0; i < sorok.Length; i++)
                {
                    lista.Items.Add(sorok[i]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }


        }

        private void buttontorles_Click(object sender, RoutedEventArgs e)
        {
            if (lista.SelectedItem==null)
            {
                MessageBox.Show("Törléshez jelöljön ki egy elemet!");
            } else
            {
                lista.Items.Remove(lista.SelectedItem);
            }
        }

        private void buttonmentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream fajl = new FileStream("nevekNEW.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(fajl, Encoding.Default);
                foreach (var i in lista.Items)
                {
                    writer.WriteLine(i.ToString());
                }
                writer.Close();
                MessageBox.Show("Fájlba írás kész!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
