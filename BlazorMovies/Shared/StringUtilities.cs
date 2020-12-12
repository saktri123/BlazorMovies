using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMovies.Shared
{
    public class StringUtilities
    {
        public static string ConvertToCamal(string value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in value.Split(" "))
            {
                if (item.Length <= 1) continue;
                sb.Append(item[0].ToString().ToUpper() + item.Substring(1) + " ");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
