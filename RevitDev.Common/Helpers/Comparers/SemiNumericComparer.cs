using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RevitDev.Common.Helpers.Comparers;

public class SemiNumericComparer : IComparer<string>
{
    private readonly string _numericPattern;

    public SemiNumericComparer(string numericPattern = @"[-+]?\d*\.\d+|\d+")
    {
        _numericPattern = numericPattern;
    }

    public int Compare(string? s1, string? s2)
    {
        var num1 = Regex.Match(s1!, _numericPattern);
        var num2 = Regex.Match(s2!, _numericPattern);

        if (num1.Success && num2.Success)
        {
            var dNum1 = double.Parse(num1.Value, CultureInfo.InvariantCulture);
            var dNum2 = double.Parse(num2.Value, CultureInfo.InvariantCulture);

            // If two numbers are the same, then check the length
            // of the original text (for case: "000" and "0000").
            if (dNum1.Equals(dNum2))
            {
                return s1!.Length - s2!.Length;
            }

            return dNum1.CompareTo(dNum2);
        }

        if (num1.Success)
        {
            return 1;
        }

        if (num2.Success)
        {
            return -1;
        }

        return string.Compare(
            s1, s2, true, CultureInfo.InvariantCulture);
    }
}