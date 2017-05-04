using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace JanitorSystem.Common
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Props til relaycommand klassen.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        private Action methodToExecute = null;

        private Func<bool> methodToDetectCanExecute = null;

        private DispatcherTimer canExecuteChangedTimer = null;
         

        public RelayCommand(Action methodToExecute, Func<bool> methodToDetectCanExecute)
        {
            this.methodToExecute = methodToExecute;
            this.methodToDetectCanExecute = methodToDetectCanExecute;
            this.canExecuteChangedTimer.Tick += canExecuteChangedTimer_Tick;
            this.canExecuteChangedTimer.Interval = new TimeSpan(0,0,1);
            this.canExecuteChangedTimer.Start();
        }


        public void Execute(object parameter)
        {
            this.methodToExecute();
        }

        public bool CanExecute(object parameter)
        {
            if (this.methodToDetectCanExecute == null)
            {
                return true;
            }
            else
            {
                return this.methodToDetectCanExecute();
            }
        }


        private void canExecuteChangedTimer_Tick(object sender, object e)
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
