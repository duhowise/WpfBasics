using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfTreeView.Directory.Data;
using WpfTreeView.Directory.ViewModels.Base;

namespace WpfTreeView.Directory.ViewModels
{
    public class DirectoryItemViewModel : BaseViewModel
    {
  

        public DirectoryItemViewModel(string fullPath, DirectotyItemType type)
        {
            FullPath = fullPath;
            Type = type;
            ExpandCommand = new RelayCommand(Expand);
            this.ClearChildren();
        }
        
        
        /// <summary>
        /// The Type of this Item
        /// </summary>
        public DirectotyItemType Type { get; set; }

        /// <summary>
        /// The absolute path to this item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory item
        /// </summary>
        public string Name => this.Type == DirectotyItemType.Drive
            ? this.FullPath
            : DirectoryStructure.GetFileFolderName(this.FullPath);

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public bool CanExpand => this.Type != DirectotyItemType.File;

        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                // If the UI tells us to expand...
                if (value == true)
                    // Find all children
                    Expand();
                // If the UI tells us to close
                else
                    this.ClearChildren();
            }
        }

        /// <summary>
        /// Removes all children and adds a dummy item
        /// </summary>
        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();
            //show the expand arrow if item is not an arrow
            if (Type!=DirectotyItemType.File)
            {
                Children.Add(null);
            }
        }

        /// <summary>
        /// Expands the directory and finds all the children
        /// </summary>
        private void Expand()
        {
            if (Type==DirectotyItemType.File)
            {
                return;
            }
            // Find all children
            var children = DirectoryStructure.GetirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));

        }



        public  ICommand ExpandCommand { get; set; }
    }
}