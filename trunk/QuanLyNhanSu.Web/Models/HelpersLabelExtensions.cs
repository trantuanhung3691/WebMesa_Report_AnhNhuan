using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Expressions;

namespace QuanLyNhanSu.Web.Models
{
    public static class HelpersLabelExtensions
    {
        public static MvcHtmlString MyDisplayNameFor<TModel, TValue>(this HtmlHelper<IEnumerable<TModel>> html, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TModel>());
            string displayName = metadata.DisplayName ?? metadata.PropertyName ?? ExpressionHelper.GetExpressionText(expression).Split('.').Last();
            var ngonngus = HttpContext.Current.Session[Commons.SessionKeys.NgonNgu] as Dictionary<string, string>;
            if (ngonngus != null)
            {
                if (ngonngus.ContainsKey(displayName))
                {
                    displayName = ngonngus[displayName].ToString();
                }
            }
            //var ngonngu = new VA_W_NGONNGUDao().Get(displayName);
            //if (ngonngu != null)
            //{
            //    switch (Commons.CONFIGVALUE.NgonNgu)
            //    {
            //        case 1:
            //            displayName = ngonngu.TiengViet;
            //            break;
            //        case 2:
            //            displayName = ngonngu.TiengAnh;
            //            break;
            //        case 3:
            //            displayName = ngonngu.TiengViet;
            //            break;
            //    }
            //}
                
            return new MvcHtmlString(HttpUtility.HtmlEncode(displayName));
        }
        public static MvcHtmlString MyLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return MyLabelFor(html, expression, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString MyLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {


            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            var ngonngus = HttpContext.Current.Session[Commons.SessionKeys.NgonNgu] as Dictionary<string, string>;
            if (ngonngus != null)
            {
                if (ngonngus.ContainsKey(labelText))
                {
                    labelText = ngonngus[labelText].ToString();
                }
            }
            //var ngonngu = new VA_W_NGONNGUDao().Get(labelText);
            //if (ngonngu != null)
            //{
            //    switch (Commons.CONFIGVALUE.NgonNgu)
            //    {
            //        case 1:
            //            labelText = ngonngu.TiengViet;
            //            break;
            //        case 2:
            //            labelText = ngonngu.TiengAnh;
            //            break;
            //        case 3:
            //            labelText = ngonngu.TiengViet;
            //            break;
            //    }
            //}
            TagBuilder tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}