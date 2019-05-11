using System.Windows;
using WpfTreeView.Directory.ViewModels;

namespace WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext= new DirectoryStructureViewModel();
          
        }

     
       

        
    }
}
