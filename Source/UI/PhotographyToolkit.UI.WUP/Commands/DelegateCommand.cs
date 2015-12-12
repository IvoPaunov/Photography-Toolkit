namespace PhotographyToolkit.UI.WUP.Commands
{
    using System;
    using System.Windows.Input;

    public class DelegateCommand :ICommand
    {
        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute();
        }

        public event EventHandler CanExecuteChanged;

        private Func<bool> canExecute;
        private Action execute;

        public void Execute(object parameter)
        {
            this.execute();
        }
    }
}
