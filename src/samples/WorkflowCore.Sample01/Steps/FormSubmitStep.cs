using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Sample01.Steps
{
    public class FormSubmitStep : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("FormSubmitStep->表单已提交");
            return ExecutionResult.Next();
        }
    }
}