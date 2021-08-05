using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Sample01.Steps
{
    public class WorkflowEndStep : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("--------------Workflow End--------------");
            Console.WriteLine("------------------------------------------");
            return ExecutionResult.Next();
        }
    }
}