//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace TrashCollector.Helpers
//{
//    public static class EnumHelper
//    {
//        public static IEnumerable<SelectItemList> GetItems(this Type enumType)
//        {
//            if (!typeof(Enum).IsAssignableFrom(enumType))
//            {
//                throw new ArgumentException("Type must be an enum");
//            }
//            var names = Enum.GetNames(enumType);
//            var values = Enum.GetValues(enumType).Cast<int>;
//            var items = names.Zip(values, (name, value) =>
//            new SelectListItem
//            {
//                Text = name,
//                value = value.ToString()
//            });
//        }
//    }
//} 