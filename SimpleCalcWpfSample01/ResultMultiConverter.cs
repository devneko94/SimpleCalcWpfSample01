using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SimpleCalcWpfSample01
{
    /// <summary>
    /// 計算結果マルチコンバーター
    /// </summary>
    public class ResultMultiConverter : IMultiValueConverter
    {
        /// <summary>
        /// 計算元から計算結果算出
        /// </summary>
        /// <param name="values">値配列</param>
        /// <param name="targetType">対象の型</param>
        /// <param name="parameter">引数</param>
        /// <param name="culture">カルチャー</param>
        /// <returns>計算結果</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            decimal? value1 = (decimal?)values[0];
            decimal? value2 = (decimal?)values[1];
            int operatorIndex = (int)values[2];


            switch (operatorIndex)
            {
                case 0:
                    return value1 + value2;
                case 1:
                    return value1 - value2;
                case 2:
                    return value1 * value2;
                case 3:
                    if (operatorIndex == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return value1 / value2;
                    }
                default:
                    return null;
            }
        }

        // 計算結果から計算元は算出できないため定義しない
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
