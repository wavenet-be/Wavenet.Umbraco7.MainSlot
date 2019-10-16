// <copyright file="EnsureMainSlotFilter.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco7.MainSlot
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Umbraco.Web.Editors;

    using static Wavenet.Umbraco7.MainSlot.Constants;

    /// <summary>
    /// <see cref="EnsureMainSlotFilter"/>.
    /// </summary>
    /// <seealso cref="IActionFilter" />
    public class EnsureMainSlotFilter : IActionFilter
    {
        /// <summary>
        /// Called after the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        /// <summary>
        /// Called before an action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction &&
                filterContext.Controller is BackOfficeController)
            {
                var request = filterContext.RequestContext.HttpContext.Request;
                var cookies = request.Cookies;
                var hasSlotCookie = cookies.AllKeys.Contains(RoutingCookie, StringComparer.OrdinalIgnoreCase);
                if (hasSlotCookie)
                {
                    if (cookies[RoutingCookie].Value != ProductionSlot)
                    {
                        filterContext.Result = new RedirectToMainSlotActionResult(request.RawUrl, true);
                    }
                    else
                    {
                        RedirectToMainSlotActionResult.EnsureProductionSlot(filterContext.RequestContext.HttpContext);
                    }
                }
                else
                {
                    filterContext.Result = new RedirectToMainSlotActionResult($"/umbraco/wavenet/ensureproduction/index?redirectUrl={HttpUtility.UrlEncode(request.RawUrl)}", false);
                }
            }
        }
    }
}