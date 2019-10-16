// <copyright file="RedirectToMainSlotActionResult.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco7.MainSlot
{
    using System.Web;
    using System.Web.Mvc;

    using static Wavenet.Umbraco7.MainSlot.Constants;

    /// <summary>
    ///   <see cref="RedirectToMainSlotActionResult" />.
    /// </summary>
    /// <seealso cref="ActionResult" />
    public class RedirectToMainSlotActionResult : ActionResult
    {
        /// <summary>
        /// Set cookie with redirection.
        /// </summary>
        private readonly bool setCookie;

        /// <summary>
        /// The URL.
        /// </summary>
        private readonly string url;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedirectToMainSlotActionResult" /> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="setCookie">if set to <c>true</c> set the cookie with redirection.</param>
        public RedirectToMainSlotActionResult(string url, bool setCookie)
        {
            this.url = url;
            this.setCookie = setCookie;
        }

        /// <summary>
        /// Ensures the production slot.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void EnsureProductionSlot(HttpContextBase context)
        {
            context.Response.SetCookie(new HttpCookie(RoutingCookie, ProductionSlot) { HttpOnly = true, Domain = context.Request.Url.Host, Path = "/" });
        }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
        /// </summary>
        /// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            var httpContext = context.RequestContext.HttpContext;
            var response = httpContext.Response;
            response.StatusCode = RedirectStatusCode;
            response.Headers[HeaderLocation] = this.url;
            if (this.setCookie)
            {
                EnsureProductionSlot(httpContext);
            }
        }
    }
}