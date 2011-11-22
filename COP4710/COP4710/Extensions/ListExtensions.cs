using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace COP4710.Extensions
{
    public static class ListExtensions
    {
        public static SelectList ToSelectList<T>(this T enumeration, string selected)
        {
            var source = Enum.GetValues(typeof(T));

            var items = new Dictionary<object, string>();

            var displayAttributeType = typeof(DisplayAttribute);

            foreach (var value in source)
            {
                FieldInfo field = value.GetType().GetField(value.ToString());

                DisplayAttribute attrs = (DisplayAttribute)field.
                              GetCustomAttributes(displayAttributeType, false).First();

                items.Add(value, attrs.GetName());
            }

            return new SelectList(items, "Key", "Value", selected);
        }

    }
}