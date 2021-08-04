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
                .StartWith(context => Console.WriteLine("Hello"))
                .Recur(data => TimeSpan.FromSeconds(5), data => data.Counter > 5 ).Do(recur => recur
                    .StartWith(context => Console.WriteLine("Doing recurring task"))
                )
                .Then(context => Console.WriteLine("Doing normal tasks"));

        }

        public string Id => "HelloWorld";
            
        public int Version => 1;
                 
    }
}
