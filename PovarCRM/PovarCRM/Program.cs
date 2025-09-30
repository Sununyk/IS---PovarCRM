using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PovarCRM.BusinessLogic.OrderFilter;
using PovarCRM.Models;
using PovarCRM.Repositories;
using PovarCRM.Repositories.Abstracts;
using PovarCRM.UIcontrollers;
using QuestPDF.Infrastructure;


namespace PovarCRM
{
    internal static class Program
    {
        [STAThread]
        //password for Sany - admin
        //password for Jamshut\Djamshut - worker
        static void Main()
        {

            ApplicationConfiguration.Initialize();

            ServiceCollection services = new ServiceCollection();
            services.AddScoped<UnitOfWork>();
            services.AddSingleton<CheckListViewController>();
            services.AddSingleton<OrderCheckListController>();
            services.AddScoped<ICheckListCalculator, FinanceCalculator>();
            services.AddSingleton<Form1>();
            services.AddScoped<OrderCheck>();

            Form1 mainForm = services.BuildServiceProvider().GetService<Form1>();
            //mainForm.InitWithController(services.BuildServiceProvider().GetService<CheckListViewController>());
            QuestPDF.Settings.License = LicenseType.Community;

            Application.Run(mainForm);
            
        }
    }
}