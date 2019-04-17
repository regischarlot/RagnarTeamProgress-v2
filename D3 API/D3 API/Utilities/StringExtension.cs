using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace D3_API.Utilities
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Repeat()
        ///     
        /// </summary>
        public static string Repeat(this char chatToRepeat, int repeat)
        {
            return new string(chatToRepeat, repeat);
        }

        /// <summary>
        ///     Repeat()
        ///     
        /// </summary>
        public static string Repeat(this string stringToRepeat, int repeat)
        {
            var builder = new StringBuilder(repeat*stringToRepeat.Length);
            for (int i = 0; i < repeat; i++)
            {
                builder.Append(stringToRepeat);
            }
            return builder.ToString();
        }

        /// <summary>
        ///     MaxLength()
        ///     
        /// </summary>
        public static string MaxLength(this string value, int maxLength)
        {
            if (value.Length > maxLength)
                return value.Substring(0, maxLength);
            return value;
        }

        /// <summary>
        ///     ToSQL()
        ///     
        /// </summary>
        public static string ToSQL(this string value)
        {
            return value.Replace("'", "''");
        }

        /// <summary>
        ///     ReadFile()
        ///     
        /// </summary>
        public static string ReadFile(this string filename)
        {
            using (StreamReader streamReader = new StreamReader(filename))
            {
                string s = streamReader.ReadToEnd();
                return s;
            }
        }

        /// <summary>
        ///     WriteFile()
        ///     
        /// </summary>
        public static bool WriteFile(this string value, string filename)
        {
            using (StreamWriter outfile = new StreamWriter(filename))
                outfile.Write(value);
            return true;
        }

        /// <summary>
        ///     ToStream()
        ///
        /// </summary>
        public static Stream ToStream(this string value)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(value);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        ///     EncodeXmlSpecialCharacters
        ///     
        /// </summary>
        public static string EncodeXmlSpecialCharacters(this string value)
        {
            string s = value;
            if (!string.IsNullOrEmpty(s))
            {
                // First convert the special Microsoft Word smart quotes
                s = s.Replace('\u2018', '\'');
                s = s.Replace('\u2019', '\'');
                s = s.Replace('\u201b', '\'');
                s = s.Replace('\u2032', '\'');
                s = s.Replace('\u201c', '"');
                s = s.Replace('\u201d', '"');
                s = s.Replace('\u201e', '"');
                s = s.Replace('\u201f', '"');
                s = s.Replace('\u2033', '"');

                s = s.Replace("&", "&amp;");
                s = s.Replace(">", "&gt;");
                s = s.Replace("<", "&lt;");
                s = s.Replace("\"", "&quot;");
            }
            return s;
        }

        /// <summary>
        ///     DecodeXmlSpecialCharacters
        ///     
        /// </summary>
        public static string DecodeXmlSpecialCharacters(this string value)
        {
            string s = value;
            if (!string.IsNullOrEmpty(s))
            {
                s = s.Replace("&gt;", ">");
                s = s.Replace("&lt;", "<");
                s = s.Replace("&quot;", "\"");
                s = s.Replace("&amp;", "&");
            }
            return s;
        }

        /// <summary>
        ///     GetItem()
        ///     
        /// </summary>
        public static string GetItem(this string value, char cSeparator, int index)
        {
            string result = string.Empty;
            List<String> lst = new List<String>(value.Split(cSeparator));
            if (index < lst.Count)
                result = lst[index];
            return result.Trim();
        }

        /// <summary>
        ///     GetPart()
        ///     
        /// </summary>
        public static string GetPart(this string value, string part)
        {
            string s = String.Format("{0}=\"", new object[] { part });
            string result = value;
            int n = result.IndexOf(s, StringComparison.Ordinal);
            if (n != -1)
            {
                result = result.Remove(0, n + s.Length);
                n = result.IndexOf("\"", StringComparison.Ordinal);
                if (n != -1)
                    result = result.Remove(n);
            }
            else
                result = string.Empty;
            return result;
        }

        /// <summary>
        ///     JSONToDateTime()
        ///     
        /// </summary>
        public static DateTime? ToJDate(this string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return null;
                value = value.Replace('"', ' ').Trim();
                String[] parts = value.Split(new[] { 'T' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 1)
                    return DateTime.ParseExact(parts[0], "yyyy-M-dd", CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

        /// <summary>
        ///     StartOfLineAt()
        ///     
        /// </summary>
        public static int StartOfLineAt(this string value, int currentPos)
        {
            int cp = currentPos;
            while (cp > 0 && value[cp] != '\n' && value[cp] != '\r')
                cp--;
            return cp;
        }

        /// <summary>
        ///     Soundex()
        ///     Reference: http://www.techrepublic.com/blog/software-engineer/how-do-i-implement-the-soundex-function-in-c/
        /// 
        /// </summary>
        public static string Soundex(this string value)
        {
            StringBuilder result = new StringBuilder();
            if (!string.IsNullOrEmpty(value))
            {
                string previousCode = string.Empty;
                result.Append(value.Substring(0, 1));
                for (int i = 1; i < value.Length; i++)
                {
                    string currentLetter = value.Substring(i, 1).ToLower();
                    string currentCode = string.Empty;
                    if ("bfpv".IndexOf(currentLetter, StringComparison.Ordinal) > -1)
                        currentCode = "1";
                    else if ("cgjkqsxz".IndexOf(currentLetter, StringComparison.Ordinal) > -1)
                        currentCode = "2";
                    else if ("dt".IndexOf(currentLetter, StringComparison.Ordinal) > -1)
                        currentCode = "3";
                    else if ("l".Equals(currentLetter, StringComparison.Ordinal))
                        currentCode = "4";
                    else if ("mn".IndexOf(currentLetter, StringComparison.Ordinal) > -1)
                        currentCode = "5";
                    else if ("r".Equals(currentLetter, StringComparison.Ordinal))
                        currentCode = "6";
                    if (!currentCode.Equals(previousCode))
                        result.Append(currentCode);
                    if (result.Length == 4)
                        break;
                    if (!string.IsNullOrEmpty(currentCode))
                        previousCode = currentCode;
                }
            }
            if (result.Length < 4)
                result.Append(new string('0', 4 - result.Length));
            return result.ToString().ToUpper();
        }

        /// <summary>
        ///     QIFValueToDate()
        ///     Reference: http://www.techrepublic.com/blog/software-engineer/how-do-i-implement-the-soundex-function-in-c/
        /// 
        /// </summary>
        public static DateTime QIFValueToDate(this string value)
        {
            if (value.IndexOf("'", StringComparison.Ordinal) >= 0)
            {
                string s1 = value.GetItem('\'', 0).Replace(" ", "0");
                string s2 = value.GetItem('\'', 1).TrimEnd();
                switch (s2.Length)
                {
                    case 0:
                        s2 = "2000";
                        break;
                    case 1:
                        s2 = "200" + s2;
                        break;
                    case 2:
                        s2 = "20" + s2;
                        break;
                }
                return (s1 + "/" + s2).ToDateTime();
            }
            else
                return value.Replace(" ", "0").ToDateTime();
        }

        /// <summary>
        ///     OFXValueToDate()
        /// 
        /// </summary>
        public static DateTime OFXValueToDate(this string value)
        {
            DateTime dt = DateTime.Today;
            if (value.Length >= 8)
                dt = DateTime.ParseExact(value.Substring(0, 8), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            return dt;
        }

        /// <summary>
        ///     FirstChars()
        /// 
        /// </summary>
        public static string FirstChars(this string value, int length)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            if (value.Length < length)
                return value;
            return value.Substring(0, length);
        }

        /// <summary>
        ///     JSONToDateTime()
        ///     
        /// </summary>
        public static Guid ToGuid(this string value)
        { 
            try
            {
                if (!string.IsNullOrEmpty(value))
                    return new Guid(value);                
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
            return Guid.Empty;
        }

        /// <summary>
        ///     NoQuote()
        ///     
        /// </summary>
        public static string NoQuote(this string value)
        {
            string result = value;
            if (!string.IsNullOrEmpty(result))
            {
                if ((result[0] == '"' && result[result.Length - 1] == '"') || 
                    (result[0] == '\'' && result[result.Length - 1] == '\''))
                {
                    result = result.Remove(0, 1);
                    result = result.Remove(result.Length - 1, 1);
                }
            }
            return result;
        }

        /// <summary>
        ///     ToISO8601()
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToISO8601(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return (DateTime?)null;
            try
            {
                return DateTime.ParseExact(value, "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'", CultureInfo.InvariantCulture);
            }
            catch
            {
                return (DateTime?)null;
            }
        }

        /// <summary>
        ///     ToJsonLong()
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToJsonLong(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return (DateTime?)null;
            try
            {
                return DateTime.ParseExact(value, "yyyy'-'MM'-'dd'T'HH':'mm':'ss", CultureInfo.InvariantCulture);
            }
            catch
            {
                return (DateTime?)null;
            }
        }

        /// <summary>
        ///     ToJsonLong()
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToJSONShortDate(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return (DateTime?)null;
            try
            {
                return DateTime.ParseExact(value, "yyyy'-'MM'-'dd", CultureInfo.InvariantCulture);
            }
            catch
            {
                return (DateTime?)null;
            }
        }

        public static string[] ToSplitByComma(this string value)
        {
            List<string> res = new List<string>();
            int i = 0;
            string chunk = string.Empty;
            if (!string.IsNullOrEmpty(value))
                while (i < value.Length)
                {
                    if (value[i] == ',')
                    {
                        res.Add(chunk);
                        chunk = String.Empty;
                    }
                    else if (value[i] == '\"')
                    {
                        i++;
                        while (i < value.Length && value[i] != '\"')
                            chunk += value[i++];
                    }
                    else
                        chunk += value[i];
                    i++;
                }
            if (!string.IsNullOrEmpty(chunk))
                res.Add(chunk);
            return res.ToArray();
        }

        public static string CastEmptyIfNull(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            return value;
        }
    }
}
