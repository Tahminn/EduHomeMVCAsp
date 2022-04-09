using System;
using System.Collections.Generic;

namespace EduHome.Utilities.Helpers
{
    public class Helper
    {
        public static int GetPageCount(int count, int take)
        {
            var pageCount = (int)Math.Ceiling((decimal)count / take);
            return pageCount;
        }
    }
}
