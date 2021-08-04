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
                .Schedule(dta => TimeSpan.FromSeconds(5)).Do(schedule => schedule
                    .StartWith(context => Console.WriteLine("Doing scheduled tasks"))
                )
                .Then(context => Console.WriteLine("Doing normal tasks"));

        }

        public string Id => "HelloWorld";
            
        public int Version => 1;
                 
    }
}
