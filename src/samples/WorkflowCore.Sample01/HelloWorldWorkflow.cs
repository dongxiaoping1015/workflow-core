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
            var branch1 = builder.CreateBranch()
                .StartWith<CustomMessage>()
                    .Input(step => step.Message, data => "hi from 1")
                .Then<CustomMessage>()
                    .Input(step => step.Message, data => "bye from 1");
            var branch2 = builder.CreateBranch()
                .StartWith<CustomMessage>()
                .Input(step => step.Message, data => "hi from 2")
                .Then<CustomMessage>()
                .Input(step => step.Message, data => "bye from 2");
            builder
                .StartWith<HelloWorld>()
                .Decide(data => data.Value1)
                    .Branch((data, outcome) => data.Value1 == "one", branch1)
                    .Branch((data, outcome) => data.Value1 == "two", branch2);
        }

        public string Id => "HelloWorld";
            
        public int Version => 1;
                 
    }
}
