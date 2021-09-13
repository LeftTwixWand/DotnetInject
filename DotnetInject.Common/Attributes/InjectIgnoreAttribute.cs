// <copyright file="InjectIgnoreAttribute.cs" company="Vladislav Horbachov">
// Copyright (c) Vladislav Horbachov. All rights reserved.
// </copyright>

using System;

namespace DotnetInject.Common.Attributes
{
    /// <summary>
    /// An attribute that simplifying dependency injection.
    /// Marked field will not be included to generated constructor.
    /// <para>
    /// This attribute can be used as follows:
    /// <code>
    /// [Inject]
    /// partial class MyViewModel
    /// {
    ///     private readonly ILogger _logger;
    ///
    ///     [InjectIgnore]
    ///     private readonly IService _service;
    /// }
    /// </code>
    /// </para>
    /// Generated source code will look like:
    /// <code>
    /// partial class MyViewModel
    /// {
    ///     private readonly ILogger _logger;
    ///
    ///     public MyViewModel(ILogger logger)
    ///     {
    ///         this._logger = logger;
    ///     }
    /// }
    /// </code>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class InjectIgnoreAttribute : Attribute
    {
    }
}