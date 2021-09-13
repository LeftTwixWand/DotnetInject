// <copyright file="InjectAttribute.cs" company="Vladislav Horbachov">
// Copyright (c) Vladislav Horbachov. All rights reserved.
// </copyright>

using System;

namespace DotnetInject.Common.Attributes
{
    /// <summary>
    /// An attribute that simplifying dependency injection.
    /// Marked field will be included to generated constructor.
    /// Marked class will include all private readonly fields for dependency injection.
    /// <para>
    /// This attribute can be used as follows:
    /// <code>
    /// partial class MyViewModel
    /// {
    ///     [Inject]
    ///     private readonly ILogger _logger;
    ///
    ///     [Inject]
    ///     private readonly IService _service;
    ///
    ///     private readonly IIgnorableService _ignorableService;
    /// }
    /// </code>
    /// </para>
    /// <para>
    /// Also, attribute can be applied for class. It will inject all the private fields with readonly modifier, except fields with attribute <see cref="InjectIgnoreAttribute"/>.
    /// <code>
    /// [Inject]
    /// partial class MyViewModel
    /// {
    ///     private readonly ILogger _logger;
    ///     private readonly IService _service;
    ///     [InjectIgnore]
    ///     private readonly IIgnorableService _ignorableService;
    /// }
    /// </code>
    /// </para>
    /// <para>
    /// Generated source code will looks like:
    /// <code>
    /// partial class MyViewModel
    /// {
    ///     private readonly ILogger _logger;
    ///     private readonly IService _service;
    ///
    ///     public MyViewModel(ILogger logger, IService service)
    ///     {
    ///         this._logger = logger;
    ///         this._service = service;
    ///     }
    /// }
    /// </code>
    /// </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class InjectAttribute : Attribute
    {
    }
}