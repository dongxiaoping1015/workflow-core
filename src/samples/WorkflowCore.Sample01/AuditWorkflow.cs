using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Sample01.Steps;

namespace WorkflowCore.Sample01
{
    public class AuditWorkflow : IWorkflow<AuditData>
    {
        public void Build(IWorkflowBuilder<AuditData> builder)
        {
            builder
                .StartWith<WorkflowStartStep>()
                    .Output(data => data.WorkflowId, step => step.WorkflowId)
                .Then<FormSaveStep>()
                .WaitFor("FormSubmitEvent", data => data.WorkflowId)
                .Then<FormSubmitStep>()
                .WaitFor("SupervisorAuditEvent", data => data.WorkflowId)
                .Then<SupervisorAuditStep>()
                .Then<WorkflowEndStep>();
        }

        public string Id => "AuditWorkflow";

        public int Version => 1;
    }
}
