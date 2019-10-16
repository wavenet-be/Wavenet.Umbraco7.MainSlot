// <copyright file="Constants.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco7.MainSlot
{
    /// <summary>
    ///   <see cref="Constants"/>.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The "Location" header.
        /// </summary>
        public const string HeaderLocation = "Location";

        /// <summary>
        /// The production slot.
        /// </summary>
        public const string ProductionSlot = "self";

        /// <summary>
        /// The redirect status code.
        /// </summary>
        public const int RedirectStatusCode = 307;

        /// <summary>
        /// The routing cookie.
        /// </summary>
        public const string RoutingCookie = "x-ms-routing-name";
    }
}