using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVC.Extensions
{
    public static class HtmlHelperExtension
    {
        public static string DisplayNameFor<TModelItem, TResult>(this IHtmlHelper<IEnumerable<TModelItem>> htmlHelper, Expression<Func<TModelItem, TResult>> expression, IStringLocalizer localizer)
        {
            return localizer[htmlHelper.DisplayNameFor(expression)];
        }
        public static string DisplayFor(this IHtmlHelper helper, string expression, IStringLocalizer localizer)
        {
            return localizer[expression];
        }
    }
}
