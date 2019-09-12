﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Views.HtmlHelpers
{
    public static partial class HtmlButtonHelper
    {
        public static MvcHtmlString EditButton(this HtmlHelper html, string url, string buttonSize = null)
        {
            buttonSize = buttonSize ?? "xs";
            var text = "Edit";
            var builder = new StringBuilder();
            builder.AppendFormat($"<a class=\"btn btn-success btn-{buttonSize} editButton\" href=\"{url}\" >");
            builder.AppendFormat($"<span>{text}</span>");
            builder.Append("</a>");
            return MvcHtmlString.Create(builder.ToString());
        }
        public static MvcHtmlString DeleteButton(this HtmlHelper html, string url, string attribute = null)
        {
            var text = "Delete";
            var builder = new StringBuilder();
            builder.AppendFormat($"<a class=\"btn btn-danger btn-sm\" data-toggle=\"confirmation\" data-url=\"{url}\"{attribute}>");
            builder.AppendFormat($"<span data-toggle=\"tooltip\" data-placement=\"top\" title=\"{text}\">");
            builder.AppendFormat("<i class=\"fa fa-trash-o fa-fw\"></i>");
            builder.Append("</span>");
            builder.Append("</a>");
            return MvcHtmlString.Create(builder.ToString());
        }
        public static MvcHtmlString SaveButton(this HtmlHelper html, string url, string attribute = null)
        {
            var text = "Save";
            var builder = new StringBuilder();
            builder.AppendFormat($"<a class=\"btn btn-danger btn-sm\" data-toggle=\"confirmation\" data-url=\"{url}\"{attribute}>");
            builder.AppendFormat($"<span data-toggle=\"tooltip\" data-placement=\"top\" title=\"{text}\">");
            builder.AppendFormat("<i class=\"fa fa-trash-o fa-fw\"></i>");
            builder.Append("</span>");
            builder.Append("</a>");
            return MvcHtmlString.Create(builder.ToString());

        }
    }
}