namespace WorkflowCore.Sample01
{
    public interface IDescriptiveWorkflowParams
    {
        string Description { get; }
    }

    // MyWorkflowParams.cs
    public class MyWorkflowParams : IDescriptiveWorkflowParams
    {
        public string Description => $"Run task '{TaskName}'";

        public string TaskName { get; set; }
    }
}
