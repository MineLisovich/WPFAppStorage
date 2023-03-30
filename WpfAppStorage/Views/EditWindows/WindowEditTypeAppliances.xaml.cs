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
    /// Interaction logic for WindowEditTypeAppliances.xaml
    /// </summary>
    public partial class WindowEditTypeAppliances : Window
    {
        public WindowEditTypeAppliances(TypeApplicances typeApplicancesToEdit)
        {
            InitializeComponent();
            DataContext = new DataVM();
            DataVM.TypeAplicancesApplic = typeApplicancesToEdit;
            DataVM.TypeApplicancesName = typeApplicancesToEdit.NameType;
        }
    }
}
