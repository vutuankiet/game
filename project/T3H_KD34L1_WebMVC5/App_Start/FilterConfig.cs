﻿using System.Web;
using System.Web.Mvc;

namespace T3H_KD34L1_WebMVC5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
