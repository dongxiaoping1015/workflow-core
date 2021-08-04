using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Sample01.Steps;

namespace WorkflowCore.Sample01
{
    public class HelloWorldWorkflow : IWorkflow<MyDataClass>
    {
        public void Build(IWorkflowBuilder<MyDataClass> builder)
        {
            builder
                .StartWith(context => Console.WriteLine("Begin"))
                .Saga(saga => saga
                    .StartWith(context => Console.WriteLine("Task 1"))
                    .CompensateWith(context => Console.WriteLine("Undo Task 1"))
                    .Then(context =>
                    {
                        Console.WriteLine("Task 2");
                        throw new Exception("Ex");
                    })
                    .CompensateWith(context => Console.WriteLine("Undo Task 2"))
                    .Then(context => Console.WriteLine("Task 3"))
                    .CompensateWith(context => Console.WriteLine("Undo Task 3"))
                )
                .CompensateWith(context => Console.WriteLine("Undo All"))
                .Then(context => Console.WriteLine("Doing normal tasks"));

        }

        public string Id => "HelloWorld";
            
        public int Version => 1;
                 
    }
}
