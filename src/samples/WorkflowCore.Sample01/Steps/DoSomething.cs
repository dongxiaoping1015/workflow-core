﻿using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Sample01
{    
    public class DoSomething : StepBody
    {
        public string Message { get; set; } = "";
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine($"Doing something...\n{ Message }");
            return ExecutionResult.Next();
        }
    }
}
