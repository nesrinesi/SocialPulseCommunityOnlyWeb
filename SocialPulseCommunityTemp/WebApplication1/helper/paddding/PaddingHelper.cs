using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soft.web.components.paddding
{
    public static class PaddingHelper
    {
        public static string AddPadding20pxArround(string content)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($@"<div class=""padding20px"">");
            builder.Append(content);
            builder.Append("</div>");
            return builder.ToString();
        }
        public static string AddPadding10pxArround(string content)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($@"<div class=""padding10px"">");
            builder.Append(content);
            builder.Append("</div>");
            return builder.ToString();
        }
    }
}
