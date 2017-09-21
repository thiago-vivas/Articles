using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Globalization_CustomWebHelper.Resource;

namespace WebHelpers.WebHelperSampleClass
{
    /// <summary>
    /// Implements a HTML Helper to load the enums with its translations
    /// </summary>
    public static class WebHelperSampleClass
    {
        private static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = "", Value = "" } };

        /// <summary>
        /// HTML helper to be used to load the enums with its translations
        /// </summary>
        /// <param name="firstLineCombo">the data to appear in the first line of the combo</param>
        /// <returns>A combo with the translations of the enums</returns>
        public static MvcHtmlString DisplayEnum<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, string firstLineCombo)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var enumType = GetNonNullableModelType(metadata);
            IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();

            IEnumerable<SelectListItem> items = new[] { new SelectListItem
            {
                Text = firstLineCombo,
                Value = "0",
                Selected = true
            }
            }.Concat(
                from value in values
                select new SelectListItem
                {
                    Text = GetEnumDescription(value),
                    Value = value.ToString(),
                    Selected = false
                });

            return htmlHelper.DropDownListFor(expression, items);
        }

        /// <summary>
        /// Gets the type of the enum
        /// </summary>
        /// <param name="modelMetadata">the model</param>
        /// <returns>return the type of enum</returns>
        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            var realModelType = modelMetadata.ModelType;
            var underlyingType = Nullable.GetUnderlyingType(realModelType);

            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }

            return realModelType;
        }

        /// <summary>
        /// Gets the description of each enum
        /// </summary>
        /// <returns>the description translated of the respective enum</returns>
        private static string GetEnumDescription<TEnum>(TEnum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            var resourceValueName = ((System.ComponentModel.DataAnnotations.DisplayAttribute)(attributes[0])).Description;

            return Resources.ResourceManager.GetString(resourceValueName);

        }
    }
}