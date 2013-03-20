﻿using System.Windows;
using System;
using System.ComponentModel;

namespace ESRI.ArcLogistics.App
{
    /// <summary>
    /// Provides helper extensions for the <see cref="System.Windows.Application"/>
    /// objects.
    /// </summary>
    internal static class ApplicationExtensions
    {
        /// <summary>
        /// Finds string resource with the specified key.
        /// </summary>
        /// <param name="application">The application instance to search
        /// resources in.</param>
        /// <param name="key">The name of the resource to search.</param>
        /// <returns>The resource string with the specified key.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="application"/> argument is a null reference.</exception>
        /// <exception cref="System.Windows.ResourceReferenceKeyNotFoundException">
        /// The resource string was not found.</exception>
        /// <exception cref="System.InvalidCastException">The resource was found
        /// but it is not a string.</exception>
        public static string FindString(
            this Application application,
            object key)
        {
            if (application == null)
            {
                throw new ArgumentNullException("application");
            }

            return (string)application.FindResource(key);
        }

        /// <summary>
        /// Finds and formats the string resource with the specified key and specified
        /// arguments and throws an exception if the string resource was not found.
        /// </summary>
        /// <param name="application">The application instance to search
        /// resources in.</param>
        /// <param name="key">The name of the string resource to search.</param>
        /// <param name="args">The collection of objects to format.</param>
        /// <returns>The resource string for the specified key with format items
        /// replaced by corresponding objects in <paramref name="args"/>.</returns>
        /// <returns>The resource string with the specified key.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="application"/> or <paramref name="args"/> is a null
        /// reference.</exception>
        /// <exception cref="T:System.Windows.ResourceReferenceKeyNotFoundException">
        /// The resource string was not found.</exception>
        /// <exception cref="T:System.InvalidCastException">The resource was found
        /// but it is not a string.</exception>
        public static string GetString(
            this Application application,
            object key,
            params object[] args)
        {
            if (application == null)
            {
                throw new ArgumentNullException("application");
            }

            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            var formatString = application.FindString(key);
            var result = string.Format(formatString, args);

            return result;
        }
    }
}
