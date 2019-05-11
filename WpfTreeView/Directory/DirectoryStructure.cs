using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using WpfTreeView.Directory.Data;

namespace WpfTreeView.Directory
{
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets all Logical Drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return System.IO.Directory.GetLogicalDrives().Select(drive => new DirectoryItem
            {
                FullPath = drive, Type = DirectotyItemType.Drive
            }).ToList();
        }


        /// <summary>
        /// Find the file or Folder Name
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string directoryPath)
        {
            if (String.IsNullOrWhiteSpace(directoryPath))
            {
                return String.Empty;
            }

            //make all slashes back slashes
            var normalisePath = directoryPath.Replace('/', '\\');

            //find the last index
            var lastIndex = normalisePath.LastIndexOf('\\');

            //if we dont find the last path return the directoryPath
            if (lastIndex <= 0)
            {
                return directoryPath;
            }

            //return the name after the last backslash
            return directoryPath.Substring(lastIndex + 1);
        }


        /// <summary>
        /// Gets the directory's top level content
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static List<DirectoryItem> GetirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();

            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);
                if (dirs.Length>0)
                {
                    items.AddRange(dirs.Select(dir=> new DirectoryItem
                    {
                        FullPath = dir,
                        Type = DirectotyItemType.Folder
                    }));
                }
            }
            catch
            {
                // ignored
            }

            try
            {
                var files =System.IO.Directory.GetFiles(fullPath);
                if (files.Length > 0)
                {
                    items.AddRange(files.Select(file=>new DirectoryItem
                    {
                        FullPath = file,
                        Type = DirectotyItemType.File
                    }));
                }

            }
            catch
            {
                // ignored
            }

            return items;
        }
    }
}