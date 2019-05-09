using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //get every drive on the machine
            foreach (var drive in Directory.GetLogicalDrives())
            {
                //create ne item for it
                var item = new TreeViewItem
                {
                    //set the header
                    Header = drive,
                    //set the full path
                    Tag = drive
                };

              
                item.Items.Add(null);


                //listen for expand event
                item.Expanded += Item_Expanded;

                FolderView.Items.Add(item);
            }
        }

        #region FolderExpanded

        private void Item_Expanded(object sender, RoutedEventArgs e)
        {
            var item = sender as TreeViewItem;

            //if the items contain ony the dummy data
            if (item?.Items.Count!=1 ||item.Items[0]!=null)
            {
                return;
            }
            item.Items.Clear();
            var fullPath = item.Tag as string ?? "";

            #region GetDirectories

            var directories = new List<string>();
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }

            }
            catch
            {
                // ignored
            }

            directories.ForEach(directoryPath =>
            {
                var subItem = new TreeViewItem
                {
                    //set header as folder name
                    Header = GetFileFolderName(directoryPath),
                    Tag = directoryPath
                };

                subItem.Items.Add(null);
                //handle subitem the expanding
                subItem.Expanded += Item_Expanded;

                item.Items.Add(subItem);
            });

            #endregion

            var files = new List<string>();
            try
            {
                var dirs = Directory.GetFiles(fullPath);
                if (dirs.Length > 0)
                {
                    files.AddRange(dirs);
                }

            }
            catch
            {
                // ignored
            }

            files.ForEach(filePath =>
            {
                var subItem = new TreeViewItem
                {
                    //set header as folder name
                    Header = GetFileFolderName(filePath),
                    Tag = filePath
                };

                item.Items.Add(subItem);
            });
        }


        #endregion
       
        
        
        /// <summary>
        /// Find the file or Folder Name
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                return string.Empty;
            }
            //make all slashes back slashes
            var normalisePath = directoryPath.Replace('/','\\');

            //find the last index
            var lastIndex = normalisePath.LastIndexOf('\\');

            //if we dont find the last path return the directoryPath
            if (lastIndex<=0)
            {
                return directoryPath;
            }
            //return the name after the last backslash
            return directoryPath.Substring(lastIndex+1);
        }


    }
}
