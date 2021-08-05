using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Sample01.Steps
{
    public class SupervisorAuditStep : StepBody
    {
        public Func<string, string> StepAction;
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("SupervisorAuditStep->主管审核通过");
            //StepAction("");
            return ExecutionResult.Next();
        }
    }
}