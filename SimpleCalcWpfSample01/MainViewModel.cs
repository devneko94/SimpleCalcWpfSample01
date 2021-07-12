using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static SimpleCalcWpfSample01.Common;

namespace SimpleCalcWpfSample01
{
    /// <summary>
    /// MainViewModel
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        #region プロパティ
        /// <summary>
        /// 被演算子（左）
        /// </summary>
        public decimal? OperandLeft
        {
            get => _operandLeft;
            set
            {
                _operandLeft = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 被演算子（右）
        /// </summary>
        public decimal? OperandRight
        {
            get => _operandRight;
            set
            {
                _operandRight = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 演算子リスト
        /// </summary>
        public string[] OperatorList { get; set; } = { "＋", "－", "×", "÷" };

        /// <summary>
        /// 演算子インデックス
        /// </summary>
        public int OperatorIndex
        {
            get => _operatorIndex;
            set
            {
                _operatorIndex = (int)value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// リセットコマンド
        /// </summary>
        public DelegateCommand ResetCommand { get; }

        // 初期化演算子を使用する場合、変数やメソッドを使用できない（下記例ではdoResetCommandがメソッド）
        // public ICommand ResetCommand { get; private set; } = new DelegateCommand(doResetCommand);
        #endregion

        #region フィールド
        /// <summary>
        /// 被演算子（左）
        /// </summary>
        private decimal? _operandLeft = null;

        /// <summary>
        /// 被演算子（右）
        /// </summary>
        private decimal? _operandRight = null;

        /// <summary>
        /// 演算子インデックス
        /// </summary>
        private int _operatorIndex = 0;
        #endregion

        #region イベント
        /// <summary>
        /// 変更通知イベント
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainViewModel()
        {
            // コマンドを設定
            ResetCommand = new DelegateCommand(doResetCommand);
        }
        #endregion

        #region パブリックメソッド
        #endregion

        #region プライベートメソッド
        /// <summary>
        /// リセットコマンド実行メソッド
        /// </summary>
        private void doResetCommand()
        {
            // 初期化処理
            OperandLeft = null;
            OperandRight = null;
            OperatorIndex = 0;
        }
        #endregion

        #region イベントハンドラ
        /// <summary>
        /// 変更通知イベントハンドラ
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
