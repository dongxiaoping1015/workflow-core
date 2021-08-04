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
                .StartWith<HelloWorld>()
                .While(data => data.Counter < 3)
                .Do(x => x
                    .StartWith<DoSomething>()
                        .Input(step => step.Message, data => data.Counter.ToString())
                    .Then<IncrementStep>()
                        .Input(step => step.Value1, data => data.Counter)
                        .Output(data => data.Counter, step => step.Value2))
                .Then<GoodbyeWorld>();
        }

        public string Id => "HelloWorld";
            
        public int Version => 1;
                 
    }
}
