using System;


namespace R5T.L0042.F000
{
    public static class Instances
    {
        public static F0000.IActionOperations ActionOperations => F0000.ActionOperations.Instance;
        public static L0031.IContextOperator ContextOperator => L0031.ContextOperator.Instance;
        public static IRepositoryContextConstructors RepositoryContextConstructors => F000.RepositoryContextConstructors.Instance;
        public static IRepositoryContextDestructors RepositoryContextDestructors => F000.RepositoryContextDestructors.Instance;
    }
}