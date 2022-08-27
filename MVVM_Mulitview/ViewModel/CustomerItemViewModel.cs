using MVVM_Mulitview.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Mulitview.ViewModel
{
    public class CustomerItemViewModel : ValidationViewModelBase
    {

        private readonly Customer _model;

        public CustomerItemViewModel(Customer model)
        {
            _model = model;

        }


        public int Id => _model.Id;

        public string? FirstName
        {
            get => _model.FirstName;
            set
            {
                _model.FirstName = value;
                RaisePropretyChanged();
                if (string.IsNullOrEmpty(_model.FirstName))
                {
                    AddError("Firstname is required", nameof(FirstName));
                }
                else
                {
                    ClearErrors(nameof(FirstName));
                }
            }
        }

        public string? LastName
        {
            get => _model.LastName;
            set
            {
                _model.LastName = value;
                RaisePropretyChanged();
            }
        }

        public bool IsDeveloper
        {
            get => _model.IsDeveloper;
            set
            {
                _model.IsDeveloper = value;
                RaisePropretyChanged();
            }
        }


    }
}

