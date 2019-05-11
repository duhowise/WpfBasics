using System.Collections.ObjectModel;
using System.Linq;
using WpfTreeView.Directory.Data;
using WpfTreeView.Directory.ViewModels.Base;

namespace WpfTreeView.Directory.ViewModels
{
    /// <summary>
    /// View model for the main application directory view
    /// </summary>
    public class DirectoryStructureViewModel:BaseViewModel
    {
        public DirectoryStructureViewModel()
        {
            Items=new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure
                .GetLogicalDrives().Select(drive=>new DirectoryItemViewModel( drive.FullPath,DirectotyItemType.Drive)));
        }
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

    }
}