using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WashingtonRedskins.Validation
{
    public delegate bool validateDelegate(string input);

    public class ValidationCollection
    {
        public Dictionary<string, List<validateDelegate>> rows;

        public ValidationCollection()
        {
            rows = new Dictionary<string, List<validateDelegate>>();
        }
    }

    public static class Validate
    {
        public static bool checkMinLength(string input, int length)
        {
            if (input != string.Empty)
            {
                if (!(input.Length > length))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool checkMaxLength(string input, int length)
        {
            if (input != string.Empty)
            {
                if (!(input.Length < length))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool checkLength(string input, int length)
        {
            if (input != string.Empty)
            {
                if (input.Length != length)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool checkNumeric(string input)
        {
            if (input != string.Empty)
            {
                try
                {
                    int.Parse(input);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        public static bool checkRequired(string input)
        {
            if (input == string.Empty)
            {
                return false;
            }
            return true;
        }
        public static bool checkIsTime(string input)
        {
            if (input != string.Empty)
            {
                try
                {
                    DateTime.ParseExact(input, "HH:mm:ss", null);
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool checkIsDateTime(string input)
        {
            if (input != string.Empty)
            {
                try
                {
                    DateTime.Parse(input);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class ValidationRow
    {
        public List<validateDelegate> delegates;

        public ValidationRow()
        {
            delegates = new List<validateDelegate>();
        }
    }

    public class ValidationBuilder
    {
        public ValidationCollection build(string[] pattern)
        {
            ValidationCollection template = new ValidationCollection();

            foreach (string p in pattern)
            {
                string name = null;
                List<validateDelegate> delegates = new List<validateDelegate>();

                var dict = p.Trim().Split(',')
                              .Select(s => s.Split('='))
                              .ToDictionary(a => a[0].Trim(), a => a[1]);
                foreach (KeyValuePair<string, string> kvp in dict)
                {
                    switch (kvp.Key)
                    {
                        case "name":
                            name = kvp.Value;
                            break;
                        case "isRequired":
                            delegates.Add(Validate.checkRequired);
                            break;
                        case "isNumeric":
                            delegates.Add(Validate.checkNumeric);
                            break;
                        case "isDateTime":
                            delegates.Add(Validate.checkIsDateTime);
                            break;
                        case "isTime":
                            delegates.Add(Validate.checkIsTime);
                            break;
                        case "minLength":
                            delegates.Add((input) => Validate.checkMinLength(input, int.Parse(kvp.Value)));
                            break;
                        case "maxLength":
                            delegates.Add((input) => Validate.checkMaxLength(input, int.Parse(kvp.Value)));
                            break;
                        case "length":
                            delegates.Add((input) => Validate.checkLength(input, int.Parse(kvp.Value)));
                            break;
                    }
                }
                template.rows.Add(name, delegates);
            }
            return template;
        }
    }
}
