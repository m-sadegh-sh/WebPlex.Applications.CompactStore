namespace WebPlex.Applications.CompactStore.Mvc {
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class AdminRequiredAttribute : Attribute {}
}
