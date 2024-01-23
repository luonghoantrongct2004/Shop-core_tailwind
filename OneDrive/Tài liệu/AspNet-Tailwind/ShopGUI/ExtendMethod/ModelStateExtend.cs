﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shop.Web.ExtendMethod
{
    public static class ModelStateExtend
    {
        public static void AddModelError(this ModelStateDictionary ModelState, string mgs)
        {
            ModelState.AddModelError(string.Empty, mgs);
        }
        public static void AddModelError(this ModelStateDictionary ModelState, IdentityResult result)
        {
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError(err.Description);
            }
        }
    }
}
