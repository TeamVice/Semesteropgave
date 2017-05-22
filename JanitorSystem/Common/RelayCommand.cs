using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace JanitorSystem.Common
{
    /// <summary>
    /// This class implemenets the ICommand interfase. 
    /// The interfase enables delagates to generate command buttons in the system. 
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Properties
        public event EventHandler CanExecuteChanged;

        private Action methodToExecute = null;

        private Func<bool> methodToDetectCanExecute = null;

        private DispatcherTimer canExecuteChangedTimer = null;
        #endregion

        #region Constructor

        public RelayCommand(Action methodToExecute, Func<bool> methodToDetectCanExecute)
        {
            this.methodToExecute = methodToExecute;
            this.methodToDetectCanExecute = methodToDetectCanExecute;
            //this.canExecuteChangedTimer.Tick += canExecuteChangedTimer_Tick;
            //this.canExecuteChangedTimer.Interval = new TimeSpan(0, 0, 1);
            //this.canExecuteChangedTimer.Start();
        }

        #endregion


        #region Method to execute

        public void Execute(object parameter)
        {
            this.methodToExecute();
        }

        #endregion

        #region Method to CanExecute

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


        #endregion

        #region Method we may use to make a button unclickable

         private void canExecuteChangedTimer_Tick(object sender, object e)
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        #endregion
       
    }
}
