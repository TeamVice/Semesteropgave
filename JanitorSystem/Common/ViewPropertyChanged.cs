using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Common
{
    public class ViewPropertyChanged : INotifyPropertyChanged
    {
        #region Method to handle updating the view

         protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
       
        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
