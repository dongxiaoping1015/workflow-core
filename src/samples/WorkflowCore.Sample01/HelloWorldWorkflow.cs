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
                .Parallel()
                .Do(then =>
                    then.StartWith<DoSomething>()
                            .Input(step => step.Message, data => "Do 1")
                            .Delay(s => TimeSpan.FromSeconds(5))
                        .Then<CustomMessage>()
                            .Input(step => step.Message, data => "Then Do 1")
                    )
                .Do(then =>
                    then.StartWith<DoSomething>()
                            .Input(step => step.Message, data => "Do 2")
                        .Then<CustomMessage>()
                            .Input(step => step.Message, data => "Then Do 2")
                    )
                .Join()
                .Then<GoodbyeWorld>();
        }

        public string Id => "HelloWorld";
            
        public int Version => 1;
                 
    }
}
