// <copyright file="EnsureProductionController.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco7.MainSlot
{
    using System.Web.Mvc;

    using Umbraco.Web.Mvc;

    /// <summary>
    /// <see cref="EnsureProductionController"/>.
    /// </summary>
    /// <seealso cref="SurfaceController" />
    [PluginController("Wavenet")]
    public class EnsureProductionController : SurfaceController
    {
        /// <summary>
        /// Indexes the specified redirect URL.
        /// </summary>
        /// <param name="redirectUrl">The redirect URL.</param>
        /// <returns>The redirection.</returns>
        public ActionResult Index(string redirectUrl)
            => new RedirectToMainSlotActionResult(redirectUrl, true);
    }
}