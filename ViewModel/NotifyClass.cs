using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcProgram.ViewModel
{
   abstract class NotifyClass: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

       public void PropertyChangedMethod(string PropertyName)
       {
           if (PropertyChanged != null)
           {
               PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
           }               
       }
    }
}
