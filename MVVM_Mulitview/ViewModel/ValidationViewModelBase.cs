#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Mulitview.ViewModel
{
    public class ValidationViewModelBase : ViewModelBase, INotifyDataErrorInfo
    {

        private readonly Dictionary<string, List<string>> _errorByPropertyName = new Dictionary<string, List<string>>();

        public bool HasErrors => _errorByPropertyName.Any();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return propertyName != null && _errorByPropertyName.ContainsKey(propertyName)
             // if found , return errors by property name 
                ? _errorByPropertyName[propertyName]
            // else Return enumerator as string
                   : Enumerable.Empty<string>();

            throw new NotImplementedException();
        }

        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        //Adding error lines
        protected void AddError(string error, string propertyName)
        {
            // Check if error is already defined
            if (!_errorByPropertyName.ContainsKey(propertyName))
            {
                _errorByPropertyName[propertyName] = new List<string>();
            }

            if (!_errorByPropertyName[propertyName].Contains(error))
            {
                // Add error to the list
                _errorByPropertyName[propertyName].Add(error);
                // raise event
                OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                // Also raise this to be sure 
                RaisePropretyChanged(nameof(HasErrors));
            }
        }

        protected void ClearErrors(string propertyName)
        {
            if (_errorByPropertyName.ContainsKey(propertyName))
            {
                _errorByPropertyName.Remove(propertyName);
                OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                // Also raise this to be sure 
                RaisePropretyChanged(nameof(HasErrors));
            }
        }

     
    }
}
