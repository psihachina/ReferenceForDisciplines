using System;

namespace ReferenceForDisciplines.Annotations
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class RazorWriteMethodParameterAttribute : Attribute
    {
    }
}