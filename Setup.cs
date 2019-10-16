// <copyright file="Setup.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco7.MainSlot
{
    using System.Web.Mvc;

    using Umbraco.Core;

    /// <summary>
    /// <see cref="Setup"/>.
    /// </summary>
    /// <seealso cref="ApplicationEventHandler" />
    public class Setup : ApplicationEventHandler
    {
        /// <summary>
        /// Overridable method to execute when Bootup is completed, this allows you to perform any other bootup logic required for the application.
        /// Resolution is frozen so now they can be used to resolve instances.
        /// </summary>
        /// <param name="umbracoApplication">The Umbraco Application.</param>
        /// <param name="applicationContext">The application context.</param>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            GlobalFilters.Filters.Add(new EnsureMainSlotFilter());
        }
    }
}