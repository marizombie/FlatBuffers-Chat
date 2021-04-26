using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FlatBufChat.Annotations;

namespace FlatBufChat.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public class RelayCommand : ICommand
        {
            public event EventHandler CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }

            private Action methodToExecute;
            private Func<bool> canExecuteEvaluator;

            public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
            {
                this.methodToExecute = methodToExecute;
                this.canExecuteEvaluator = canExecuteEvaluator;
            }

            public RelayCommand(Action methodToExecute) : this(methodToExecute, null)
            {
            }

            public bool CanExecute(object parameter)
            {
                return canExecuteEvaluator == null || canExecuteEvaluator.Invoke();
            }
            public void Execute(object parameter)
            {
                methodToExecute.Invoke();
            }
        }
    }
}
