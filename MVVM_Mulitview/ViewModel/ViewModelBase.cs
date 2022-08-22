﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Mulitview.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        // The only implementation needed for INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // Simple method to raise event
        protected virtual void RaisePropretyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}
