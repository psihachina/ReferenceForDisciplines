using System;

namespace ReferenceForDisciplines.Annotations
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RazorWriteMethodAttribute : Attribute
    {
    }
}