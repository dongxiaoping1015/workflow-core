using System;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Sample01.Middleware
{
    public class AddDescriptionWorkflowMiddleware : IWorkflowMiddleware
    {
        public WorkflowMiddlewarePhase Phase => WorkflowMiddlewarePhase.PreWorkflow;
        public Task HandleAsync(WorkflowInstance workflow, WorkflowDelegate next)
        {
            if (workflow.Data is IDescriptiveWorkflowParams descriptiveParams)
            {
                workflow.Description = descriptiveParams.Description;
                Console.WriteLine(workflow.Description);
            }

            return next();
        }
    }
}
