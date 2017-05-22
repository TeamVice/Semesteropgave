using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Common
{
/// <summary>
/// This class implemenets the INotifyPropertyChanged interfase. 
/// The interfase enables that changes updated in a view is implementaed by the view model in the system. 
/// </summary>
    public class ViewPropertyChanged : INotifyPropertyChanged
    {
        #region Property of datatype PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Method to handle updating the view

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
       
     
    }
}
