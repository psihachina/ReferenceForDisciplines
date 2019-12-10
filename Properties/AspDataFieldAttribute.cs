using System;

namespace ReferenceForDisciplines.Annotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class AspDataFieldAttribute : Attribute
    {
    }
}