using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Sample01.Steps
{
    public class FormSaveStep : StepBody
    {

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("FormSaveStep->表单已经保存");
            return ExecutionResult.Next();
        }
    }
}