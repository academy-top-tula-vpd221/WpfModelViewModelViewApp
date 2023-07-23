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

namespace WpfModelViewModelViewApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new AppViewModel(new BaseDialogService(), new JsonFileService());
            this.DataContext = viewModel;

            //var command = new AppCommand(p => { MessageBox.Show("Coomand " + p.ToString()); });
            //command.Execute("Hello");
        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {
            string str = String.Empty;
            foreach (var em in viewModel.Employees)
                str += em + "\n";
            MessageBox.Show(str);
        }
    }
}
