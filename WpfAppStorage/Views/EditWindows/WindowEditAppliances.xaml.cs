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
using WpfAppStorage.Models.Entities;
using WpfAppStorage.ViewModels;

namespace WpfAppStorage.Views.EditWindows
{
    /// <summary>
    /// Interaction logic for WindowEditAppliances.xaml
    /// </summary>
    public partial class WindowEditAppliances : Window
    {
        public WindowEditAppliances(Applicances applicancesToEdit)
        {
            InitializeComponent();
            DataContext = new DataVM();
            DataVM.SelectApplicances = applicancesToEdit;
            DataVM.NameApplic = applicancesToEdit.Name;
            DataVM.PriceApplic = applicancesToEdit.Price;
            DataVM.CountApplicancesApplic = applicancesToEdit.CountApplicances;
        }
    }
}
