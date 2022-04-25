using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool _isExecuting;

        private bool isExecuting
        {
            get { return _isExecuting; }
            set
            {
                _isExecuting = value;
                OnCanExecutedChanged();
            }
        }


        public override bool CanExecute(object parameter)
        {
            return !isExecuting && base.CanExecute(parameter);
        }

        public override async void Execute(object parameter)
        {
            isExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                isExecuting = false;
            }

        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
