using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Sample01.Steps
{
    public class WorkflowStartStep : StepBody
    {
        public string WorkflowId { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("--------------Workflow Start--------------");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"WorkflowName=[{context.Workflow.WorkflowDefinitionId}],WorkflowID=[{context.Workflow.Id}],Version=[{context.Workflow.Version}]");
            WorkflowId = context.Workflow.Id;
            return ExecutionResult.Next();
        }
    }
}