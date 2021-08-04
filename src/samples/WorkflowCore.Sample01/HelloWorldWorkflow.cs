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
                .StartWith(context => ExecutionResult.Next())
                .WaitFor("MyEvent", data => "0")
                .Output(data => data.Value, step => step.EventData)
                .Then<CustomMessage>()
                .Input(step => step.Message, data => "The data from the event is " + data.Value);
            //builder                
            //    .UseDefaultErrorBehavior(WorkflowErrorHandling.Suspend)
            //    .StartWith<HelloWorld>()                
            //    .Then<GoodbyeWorld>();
        }

        public string Id => "HelloWorld";
            
        public int Version => 1;
                 
    }
}
