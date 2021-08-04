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
                .ForEach(data => new List<int>() {1, 2, 3, 4,})
                    .Do(x => x
                        .StartWith<CustomMessage>()
                            .Input(step => step.Message, (data, context) => context.Item.ToString())
                        .Then<DoSomething>())
                .Then<GoodbyeWorld>();
        }

        public string Id => "HelloWorld";
            
        public int Version => 1;
                 
    }
}
