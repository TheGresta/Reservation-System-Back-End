using Autofac;
using Core.Utilities.Message;
using Core.Utilities.Message.Turkish;
using RezervationSystem.Business.Services.Abstract;
using RezervationSystem.Business.Services.Concrete;
using RezervationSystem.DataAccess.Abstract;
using RezervationSystem.DataAccess.Concrete.EntityFramework;
using Autofac.Extras.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Log.Middlewares.Services;

namespace RezervationSystem.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReserManager>().As<IReserService>().SingleInstance();
            builder.RegisterType<EfReserDal>().As<IReserDal>().SingleInstance();

            builder.RegisterType<TurkishLanguageMessage>().As<ILanguageMessage>().SingleInstance();

            builder.RegisterType<ReserRentManager>().As<IReserRentService>().SingleInstance();
            builder.RegisterType<EfReserRentDal>().As<IReserRentDal>().SingleInstance();
            builder.RegisterType<ConsoleLogger>().As<ILoggerService>().SingleInstance();

            builder.RegisterType<Core.Log.Middlewares.Services.ConsoleLogger>().As<ILoggerService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                });
        }
    }
}
