using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PasswordGenerator.Annotations;

namespace PasswordGenerator
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        private int _passwordsLength;
        private int _count;
        private bool _passwordCompl;


        public bool PasswordCompl
        {
            get => _passwordCompl;
            set
            {
                _passwordCompl = value; 
                OnPropertyChanged(nameof(Passwords));
            }
        }

        

        public ObservableCollection<PasswordModel> Passwords => !PasswordCompl ? new ObservableCollection<PasswordModel>(
                PasswordGeneratorModel.GetPasswords(PasswordLength, Count, PasswordGenerator.PasswordCompl.Complicated)) :
            new ObservableCollection<PasswordModel>(
                PasswordGeneratorModel.GetPasswords(PasswordLength, Count, PasswordGenerator.PasswordCompl.Simple));


        public int Count
        {
            get { return _count; }
            set
            {
                _count = value; 
                OnPropertyChanged(nameof(Passwords));
            }
        }


        public int PasswordLength
        {
            get { return _passwordsLength; }
            set
            {
                _passwordsLength = value; 
                OnPropertyChanged(nameof(Passwords));
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}