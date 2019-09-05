using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cake.Common.Tools.DotNetCore;
using Cake.Core;
using Cake.Core.Diagnostics;

namespace MyCake.Module
{
    public sealed partial class MyCakeEngine : ICakeEngine
    {
        private readonly ICakeEngine _cakeEngine;

        public MyCakeEngine(ICakeDataService dataService, ICakeLog log)
        {
            _cakeEngine = new CakeEngine(dataService, log);
            RegisterTasks();
        }

        public IReadOnlyList<ICakeTaskInfo> Tasks => _cakeEngine.Tasks;

        public event EventHandler<SetupEventArgs> Setup
        {
            add
            {
                _cakeEngine.Setup += value;
            }

            remove
            {
                _cakeEngine.Setup -= value;
            }
        }

        public event EventHandler<TeardownEventArgs> Teardown
        {
            add
            {
                _cakeEngine.Teardown += value;
            }

            remove
            {
                _cakeEngine.Teardown -= value;
            }
        }

        public event EventHandler<TaskSetupEventArgs> TaskSetup
        {
            add
            {
                _cakeEngine.TaskSetup += value;
            }

            remove
            {
                _cakeEngine.TaskSetup -= value;
            }
        }

        public event EventHandler<TaskTeardownEventArgs> TaskTeardown
        {
            add
            {
                _cakeEngine.TaskTeardown += value;
            }

            remove
            {
                _cakeEngine.TaskTeardown -= value;
            }
        }

        public void RegisterSetupAction(Action<ISetupContext> action)
        {
            _cakeEngine.RegisterSetupAction(action);
        }

        public void RegisterSetupAction<TData>(Func<ISetupContext, TData> action) where TData : class
        {
            _cakeEngine.RegisterSetupAction(action);
        }

        public CakeTaskBuilder RegisterTask(string name)
        {
            return _cakeEngine.RegisterTask(name);
        }

        public void RegisterTaskSetupAction(Action<ITaskSetupContext> action)
        {
            _cakeEngine.RegisterTaskSetupAction(action);
        }

        public void RegisterTaskSetupAction<TData>(Action<ITaskSetupContext, TData> action) where TData : class
        {
            _cakeEngine.RegisterTaskSetupAction(action);
        }

        public void RegisterTaskTeardownAction(Action<ITaskTeardownContext> action)
        {
            _cakeEngine.RegisterTaskTeardownAction(action);
        }

        public void RegisterTaskTeardownAction<TData>(Action<ITaskTeardownContext, TData> action) where TData : class
        {
            _cakeEngine.RegisterTaskTeardownAction(action);
        }

        public void RegisterTeardownAction(Action<ITeardownContext> action)
        {
            _cakeEngine.RegisterTeardownAction(action);
        }

        public void RegisterTeardownAction<TData>(Action<ITeardownContext, TData> action) where TData : class
        {
            _cakeEngine.RegisterTeardownAction(action);
        }

        public Task<CakeReport> RunTargetAsync(ICakeContext context, IExecutionStrategy strategy, ExecutionSettings settings)
        {
            return _cakeEngine.RunTargetAsync(context, strategy, settings);
        }
    }
}
