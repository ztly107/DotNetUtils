/*******************************************
 * Copyright (c) 2016 ztly107
 * License: MIT
 * Description: 汉字转全拼，汉字转首字母。
 * 需要引用微软类库：https://www.microsoft.com/zh-cn/download/confirmation.aspx?id=15251
 * 缺点，多音字处理欠佳。
 * https://github.com/ztly107/DotNetUtils
 * ******************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.International.Converters.PinYinConverter;

namespace LSlib.Utils
{
    public class PinYinConv
    {
        /// <summary>
        /// 获取字符串首字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetFirstPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, 1);
                    // break;
                }
                catch
                {
                    r = "转换出现错误";
                }
            }
            return r;
        }
        /// <summary>
        /// 获取字符串全拼
        /// </summary>
        /// <param name="str">要转换的字符串，无法避免多音字</param>
        /// <returns></returns>
        public static string GetPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    var pinyins = chineseChar.Pinyins;
                    foreach (var pinyin in pinyins)
                    {
                        if (pinyin != null)
                        {
                            r += pinyin.Substring(0, pinyin.Length - 1);
                            break;
                        }

                    }
                }
                catch
                {
                    r = "转换出现错误";
                }
            }
            return r;
        }          
    }        
}
