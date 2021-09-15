// <copyright file="DependencyInjectionGenerator.SyntaxReceiver.cs" company="Vladislav Horbachov">
// Copyright (c) Vladislav Horbachov. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using DotnetInject.Common.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DotnetInject.SourceGenerators
{
    /// <inheritdoc cref="DependencyInjectionGenerator"/>
    public sealed partial class DependencyInjectionGenerator
    {
        /// <summary>
        /// An <see cref="ISyntaxContextReceiver"/> that selects candidate nodes to process.
        /// </summary>
        private sealed class SyntaxReceiver : ISyntaxContextReceiver
        {
            /// <summary>
            /// The list of info gathered during exploration.
            /// </summary>
            private readonly List<Item> gatheredInfo = new();

            /// <summary>
            /// Gets the collection of gathered info to process.
            /// </summary>
            public IReadOnlyCollection<Item> GatheredInfo => this.gatheredInfo;

            public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
            {
                if (context.Node is FieldDeclarationSyntax fieldDeclaration &&
                    context.SemanticModel.GetDeclaredSymbol(fieldDeclaration) is IFieldSymbol fieldSymbol &&
                    context.SemanticModel.Compilation.GetTypeByMetadataName(typeof(InjectAttribute).FullName) is INamedTypeSymbol injectSymbol &&
                    fieldSymbol.GetAttributes().Any(attribute => SymbolEqualityComparer.Default.Equals(attribute.AttributeClass, injectSymbol)))
                {
                    this.gatheredInfo.Add(new Item(fieldDeclaration.GetLeadingTrivia(), fieldSymbol));
                }
            }

            /// <summary>
            /// A model for a group of item representing a discovered type to process.
            /// </summary>
            /// <param name="LeadingTrivia">The leading trivia for the field declaration.</param>
            /// <param name="MethodSymbol">The <see cref="IMethodSymbol"/> instance for the target method.</param>
            public sealed record Item(SyntaxTriviaList LeadingTrivia, IFieldSymbol FieldSymbol);
        }
    }
}