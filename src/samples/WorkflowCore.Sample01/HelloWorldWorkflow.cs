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
                .If(data => data.Counter < 3).Do(then => then
                    .StartWith<CustomMessage>()
                    .Input(step => step.Message, data => "Value is less than 3")
                )
                .If(data => data.Counter < 5).Do(then => then
                    .StartWith<CustomMessage>()
                    .Input(step => step.Message, data => "Value is less than 5")
                )
                .Then<GoodbyeWorld>();
        }

        public string Id => "HelloWorld";
            
        public int Version => 1;
                 
    }
}
