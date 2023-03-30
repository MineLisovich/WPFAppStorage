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
using WpfAppStorage.ViewModels;

namespace WpfAppStorage.Views.AddWindows
{
    /// <summary>
    /// Interaction logic for WindowAddProvider.xaml
    /// </summary>
    public partial class WindowAddProvider : Window
    {
        public WindowAddProvider()
        {
            InitializeComponent();
            DataContext = new DataVM();
        }
    }
}
