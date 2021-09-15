// <copyright file="DependencyInjectionGenerator.cs" company="Vladislav Horbachov">
// Copyright (c) Vladislav Horbachov. All rights reserved.
// </copyright>

using Microsoft.CodeAnalysis;

namespace DotnetInject.SourceGenerators
{
    /// <summary>
    /// A generator, which automatically creates constructor with dependencies initialization
    /// </summary>
    [Generator]
    public sealed partial class DependencyInjectionGenerator : ISourceGenerator
    {
        /// <inheritdoc/>
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(static () => new SyntaxReceiver());
        }

        /// <inheritdoc/>
        public void Execute(GeneratorExecutionContext context)
        {
        }
    }
}