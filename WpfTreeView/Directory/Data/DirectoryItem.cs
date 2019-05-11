namespace WpfTreeView.Directory.Data
{
    /// <summary>
    /// Information about a directory item such as a drive file or folder 
    /// </summary>
    public class DirectoryItem
    {
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
        public string Name => this.Type==DirectotyItemType.Drive ?this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath);
    }
}