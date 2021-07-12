using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace SimpleCalcWpfSample01
{
    /// <summary>
    /// 共通機能クラス
    /// </summary>
    public class Commands
    {
        /// <summary>
        /// コマンドクラス（引数なしAction）
        /// </summary>
        public class DelegateCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private Action _execute;
            private Func<bool> _canExecute;

            public DelegateCommand(Action action) : this(action, () => true) { }

            public DelegateCommand(Action action, Func<bool> func)
            {
                this._execute = action;
                this._canExecute = func;
            }

            public bool CanExecute(object parameter)
            {
                return this._canExecute();
            }

            public void Execute(object parameter)
            {
                this._execute();
            }

            public void OnCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// コマンドクラス（引数ありAtion）
        /// </summary>
        /// <typeparam name="T">引数の型</typeparam>
        public class DelegateCommand<T> : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private Action<T> _execute;
            private Func<T, bool> _canExecute;

            public DelegateCommand(Action<T> action) : this(action, (T) => true) { }

            public DelegateCommand(Action<T> action, Func<T, bool> func)
            {
                this._execute = action;
                this._canExecute = func;
            }

            public bool CanExecute(object parameter)
            {
                return this._canExecute((T)parameter);
            }

            public void Execute(object parameter)
            {
                this._execute((T)parameter);
            }

            public void OnCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
