using System;

namespace ReferenceForDisciplines.Annotations
{
    /// <summary>
    ///     Indicates that the marked parameter is a regular expression pattern.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class RegexPatternAttribute : Attribute
    {
    }
}