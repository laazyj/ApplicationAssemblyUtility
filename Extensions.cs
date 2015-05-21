using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSpares.Levity
{
    public static class Extensions
    {
        /// <summary>
        /// print duoble digits in minor and build field
        /// </summary>
        /// <param name="ver"></param>
        /// <returns></returns>
        //depth field is a stub for future extension 
        public static string ToStringDouble00(this Version ver, int depth = 3)
        {
            return string.Format("{0}.{1:00}.{2:00}", ver.Major, ver.Minor, ver.Build);
        }
    }
}
