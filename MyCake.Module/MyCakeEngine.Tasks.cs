using System;
using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Build;
using Cake.Core;

namespace MyCake.Module
{
    public sealed partial class MyCakeEngine
    {
        private void RegisterTasks()
        {
            RegisterTask("Default")
                .Does(TableOfTasksTask);

            RegisterTask("Restore")
                .Description("Restores packages for the .NET Core solution")
                .Does(RestoreTask);

            RegisterTask("Build")
                .Description("Builds the .NET Core solution")
                .Does(BuildTask);
        }

        private void BuildTask(ICakeContext context)
        {
            context.DotNetCoreBuild("MYCake.Demo.sln", new DotNetCoreBuildSettings
            {
                Configuration = context.Configuration.GetValue("Configuration") ?? "Release",
                Verbosity = DotNetCoreVerbosity.Detailed,
            });
        }

        private void TableOfTasksTask()
        {
            foreach (ICakeTaskInfo task in Tasks)
            {
                if (task.Name.Equals("Default", StringComparison.OrdinalIgnoreCase))
                    continue;
                if (task.Name.StartsWith("_"))
                    continue;
                Console.WriteLine($"{task.Name} -- {task.Description}");
            }
        }

        public static void RestoreTask(ICakeContext context)
        {
            context.DotNetCoreRestore();
        }
    }
}
