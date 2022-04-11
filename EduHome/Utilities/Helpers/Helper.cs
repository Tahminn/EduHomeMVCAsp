﻿using System;
using System.Collections.Generic;
using System.IO;

namespace EduHome.Utilities.Helpers
{
    public static class Helper
    {
        public static string GetFilePath(string root, string folder, string fileName)
        {
            return Path.Combine(root, folder, fileName);
        }
        public static void DeleteFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
        public static int GetPageCount(int count, int take)
        {
            var pageCount = (int)Math.Ceiling((decimal)count / take);
            return pageCount;
        }
    }
}
