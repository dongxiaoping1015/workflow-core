using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Sample01.Middleware;
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
            host.RegisterWorkflow<AuditWorkflow, AuditData>();
            host.Start();
            Console.WriteLine("Host已创建");
            while (Console.ReadLine() != "Exit")
            {
                Console.WriteLine("1. 创建新审批流程");
                Console.WriteLine("2. 审批工作流");
                switch (Console.ReadLine())
                {
                    case "1":
                        host.StartWorkflow("AuditWorkflow");
                        break;
                    case "2":
                        UpdateAuditWorkflow(host);
                        break;
                }
            }
            Console.WriteLine("");

            Console.ReadLine();
            host.Stop();
        }

        private static void UpdateAuditWorkflow(IWorkflowHost host)
        {
            Console.WriteLine("输入步骤名");
            var stepEvent = Console.ReadLine();
            Console.WriteLine("输入WorkflowId");
            var workflowId = Console.ReadLine();
            host.PublishEvent(stepEvent, workflowId, null);
        }
                
        private static IServiceProvider ConfigureServices()
        {
            //setup dependency injection
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            //services.AddWorkflow();
            services.AddWorkflow(x => x.UseSqlServer(@"Server=.;Database=WorkflowCore;uid=sa;pwd=123456", true, true));
            //services.AddWorkflow(x => x.UseMongoDB(@"mongodb://localhost:27017", "workflow"));
            //services.AddWorkflowStepMiddleware<AddMetadataToLogsMiddleware>();
            //services.AddWorkflowMiddleware<AddDescriptionWorkflowMiddleware>();
            //services.AddWorkflowMiddleware<PrintWorkflowSummaryMiddleware>();
            //services.AddTransient<CustomMessage>();
            //services.AddTransient<DoSomething>();
            //services.AddTransient<GoodbyeWorld>();

            //services.AddTransient<IDescriptiveWorkflowParams, MyWorkflowParams>();

            //services.AddLogging(cfg =>
            //{
            //    cfg.AddConsole(x => x.IncludeScopes = true);
            //    cfg.AddDebug();
            //});

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }


    }
}
