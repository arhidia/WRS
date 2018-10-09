using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Specialized;
using System.Web;

namespace WashingtonRedskins
{
    static class Parsers
    {
        static public NameValueCollection parseURLEncoded(string data)
        {
            var dict = new NameValueCollection();
            var arr = data.Split('&');
            foreach(string s in arr)
            {
                var k = Uri.UnescapeDataString(s.Split('=')[0]).Replace("+", " ");
                var val = Uri.UnescapeDataString(s.Split('=')[1]).Replace("+", " ");
                dict.Add(k, val);
            }
            return dict;
        }
        static public NameValueCollection parseFormData(string data)
        {
            var dict = new NameValueCollection();

            var arr = data.Replace("\r\n", "").Split(' ', '-', '"');
            arr = arr.Where(item => item != string.Empty).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i].StartsWith("name="))
                {
                    dict.Add(arr[i + 1], arr[i + 2]);
                    i = i + 2;
                }
            }
            return dict;
        }
    }
}
