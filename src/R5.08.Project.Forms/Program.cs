using Microsoft.Extensions.Configuration;
using Autofac;
using Microsoft.EntityFrameworkCore;
using R5._08.Project.Database;
using R5._08.Project.Database.Interface;
using System.Diagnostics.CodeAnalysis;

namespace ProjetForm
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            IContainer v_Container = Configure();

            using (ILifetimeScope scope = v_Container.BeginLifetimeScope())
            {
                IUnitOfWork m_UnitOfWork = scope.Resolve<IUnitOfWork>();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new HomeForm(m_UnitOfWork));
            }
        }

        public static IContainer Configure()
        {
            ContainerBuilder v_ContainerBuilder = new();

            IConfigurationBuilder v_ConfigurationBuilder = new ConfigurationBuilder()
                .AddUserSecrets<Program>();

            IConfigurationRoot v_ConfigurationRoot = v_ConfigurationBuilder.Build();

            string v_ConnectionString = v_ConfigurationRoot["ConnectionString"]
                ?? throw new NotImplementedException("You must enter the connection string");

            DbContextOptionsBuilder v_DbContextOptionsBuilder = new DbContextOptionsBuilder<DbProjectContext>()
                .UseMySql(v_ConnectionString, ServerVersion.Parse("10.10.2-mariadb"));

            v_ContainerBuilder.RegisterType<DbProjectContext>().WithParameter("options", v_DbContextOptionsBuilder.Options).AsSelf().InstancePerLifetimeScope();

            v_ContainerBuilder.RegisterType<UnitOfWork<DbProjectContext>>().As<IUnitOfWork>().InstancePerLifetimeScope();

            return v_ContainerBuilder.Build();
        }
    }
}