using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleCalcWpfSample01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 被演算子の入力時イベントハンドラ
        /// </summary>
        /// <param name="sender">TextBoxオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void _txtOperand_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string strValue = textBox.Text.Replace(",", string.Empty);

            // ▼備考
            // Regex は正規表現を扱うためのクラス
            // Regex.IsMatchは、指定した正規表現パターンに合致する場合は"true"
            // 合致しない場合は"false"を返すメソッド

            // e.Handled は"true"で入力された文字を受け取らず、"false"で受け取るプロパティ
            // （簡易的な説明で、Handledに対する正しい説明ではない）

            // e.Text は入力された一文字を扱うプロパティ

            // 正規表現で先頭のマイナスと数値、1つの小数点のみの入力を許可
            Regex regex = new Regex(@"^-?[0-9]*\.?[0-9]*$");
            e.Handled = !regex.IsMatch(strValue + e.Text);
        }

        /// <summary>
        /// キー押下時イベントハンドラ
        /// </summary>
        /// <param name="sender">コントロールオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            // 押下されたのがエンターキーの場合、処理実行
            if(e.Key == Key.Enter)
            {
                // Shift押下の有無でフォーカス移動の方向（順行、逆行）を設定
                var direction = Keyboard.Modifiers == ModifierKeys.Shift ?
                    FocusNavigationDirection.Previous : FocusNavigationDirection.Next;

                // フォーカス移動を実行
                ((FrameworkElement)FocusManager.GetFocusedElement(this))?.MoveFocus(new TraversalRequest(direction));
            }
        }
    }
}