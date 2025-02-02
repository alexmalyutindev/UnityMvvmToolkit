﻿using System;

namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit {}
}

namespace UnityMvvmToolkit.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ObservableAttribute : Attribute
    {
        /// <summary>
        /// If PropertyName is not specified, the field name will be converted from '_name' or 'm_name' to 'Name'.
        /// </summary>
        /// <param name="propertyName">Property name to bind.</param>
        public ObservableAttribute(string propertyName = "")
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; init; }
    }
}