using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WorkflowCore.Interface;
using WorkflowCore.Sample01.Steps;

namespace WorkflowCore.Sample01
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            //start the workflow host
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<HelloWorldWorkflow, MyDataClass>();        
            host.Start();            

            host.StartWorkflow("HelloWorld");

            var activity = host.GetPendingActivity("activity-1", "worker1", TimeSpan.FromMinutes(1)).Result;

            if (activity != null)
            {
                Console.WriteLine(activity.Parameters);
                host.SubmitActivitySuccess(activity.Token, "Some response data");
            }
            
            Console.ReadLine();
            host.Stop();
        }
                
        private static IServiceProvider ConfigureServices()
        {
            //setup dependency injection
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();
            //services.AddWorkflow(x => x.UseMongoDB(@"mongodb://localhost:27017", "workflow"));
            services.AddTransient<GoodbyeWorld>();
            
            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }


    }
}
