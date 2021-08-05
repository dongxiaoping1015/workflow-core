using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Sample01.Steps;

namespace WorkflowCore.Sample01
{
    public class HelloWorldWorkflow : IWorkflow<MyWorkflowParams>
    {
        public void Build(IWorkflowBuilder<MyWorkflowParams> builder)
        {
            builder
                .StartWith(context => Console.WriteLine("Begin"))
                .Saga(saga => saga
                    .StartWith(context => Console.WriteLine("Task 1"))
                    .CompensateWith(context => Console.WriteLine("Undo Task 1"))
                    .Then(context =>
                    {
                        Console.WriteLine("Task 2");
                    })
                    .CompensateWith(context => Console.WriteLine("Undo Task 2"))
                    .Then(context => Console.WriteLine("Task 3"))
                    .CompensateWith(context => Console.WriteLine("Undo Task 3"))
                )
                .OnError(Models.WorkflowErrorHandling.Retry, TimeSpan.FromSeconds(5))
                .Then(context => Console.WriteLine("Doing normal tasks"));

        }

        public string Id => "HelloWorld";
            
        public int Version => 1;
                 
    }
}
