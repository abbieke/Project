using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Project.Web
{
    public static class AutofacConfig
    {
        public static void Run()
        {
            // === 1. 建立容器 ===
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(Assembly.Load("Project.Repository"))
                .Where(x => x.Name.EndsWith("Repository", StringComparison.Ordinal))
                .AsImplementedInterfaces();

            //B.註冊所有名稱為Service結尾的物件
            builder.RegisterAssemblyTypes(Assembly.Load("Project.Service"))
                .Where(x => x.Name.EndsWith("Service", StringComparison.Ordinal))
                .AsImplementedInterfaces();

            builder.RegisterFilterProvider();

            // === 3. 由Builder建立容器 ===
            var container = builder.Build();

            // === 4. 把容器設定給DependencyResolver ===
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}