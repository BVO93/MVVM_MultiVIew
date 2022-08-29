using MVVM_Mulitview.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Mulitview.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {

        // LOCAL VAR 
        private readonly Settings _settings ;

        // CONSTRUCTORS

        public SettingsViewModel(Settings settings)
        {
            _settings = new Settings();
            _settings = settings;
        }

        public SettingsViewModel()
        {
            _settings = new Settings();
          _settings.TestVersion = true;
          _settings.Location = "Non Defined";
        }

        // PUBLIC VAR

        public string Location
        {
            get => _settings.Location;
            set
            {
                _settings.Location = value;
                RaisePropretyChanged();
            }
        }

        public bool testVersion
        {
            get => _settings.TestVersion;

            set
            {
                _settings.TestVersion = value;
                RaisePropretyChanged();
            }
        }




    }
}
