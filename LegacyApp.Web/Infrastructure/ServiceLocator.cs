using Ninject;

namespace LegacyApp.Web.Infrastructure
{
    public static class ServiceLocator
    {
        private static readonly StandardKernel kernel = new StandardKernel();

        public static IKernel Instance { get { return kernel; } }

        public static T GetService<T>()
        {
            return kernel.Get<T>();
        }
    }
}