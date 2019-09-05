using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.Composition;
using MyCake.Module;

[assembly: CakeModule(typeof(CustomEngineModule))]

namespace MyCake.Module
{
    public class CustomEngineModule : ICakeModule
    {
        public void Register(ICakeContainerRegistrar registrar)
        {
            registrar.RegisterType<MyCakeEngine>().As<ICakeEngine>().Singleton();
        }
    }
}
