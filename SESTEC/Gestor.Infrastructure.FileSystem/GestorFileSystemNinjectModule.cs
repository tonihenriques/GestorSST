using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace Gestor.Infrastructure.FileSystem
{
    public class GestorFileSystemNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(c => c.FromThisAssembly().IncludingNonPublicTypes().SelectAllClasses().BindDefaultInterfaces());
        }
    }
}