using System;
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
                .Activity("activity-1", data => data.Value1)
                    .Output(data => data.Value2, step => step.Result)
                .Then<CustomMessage>()
                    .Input(step => step.Message, data => data.Value2);
        }

        public string Id => "HelloWorld";
            
        public int Version => 1;
                 
    }
}
