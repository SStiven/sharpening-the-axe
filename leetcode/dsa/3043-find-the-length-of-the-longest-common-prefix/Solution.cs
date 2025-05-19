namespace FindTheLengthOfTheLongestCommonPrefix;

public class Solution
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        int longest = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            for (int j = 0; j < arr2.Length; j++)
            {
                var prefixLength = LongestCommonPrefix(arr1[i], arr2[j]);
                longest = Math.Max(longest, prefixLength);
            }
        }

        return longest;
    }

    private int LongestCommonPrefix(int num1, int num2)
    {
        int numDigits1 = (int)Math.Floor(Math.Log10(num1)) + 1;
        int numDigits2 = (int)Math.Floor(Math.Log10(num2)) + 1;

        var minNumDigits = Math.Min(numDigits1, numDigits2);
        int count = 0;
        for (int i = 0; i < minNumDigits; i++)
        {
            int digit1 = GetDigitFromLeft(num1, i);
            int digit2 = GetDigitFromLeft(num2, i);
            if (digit1 != digit2)
            {
                return count;
            }

            count += 1;
        }

        return count;
    }

    private int GetDigitFromLeft(int num, int position)
    {
        int digits = (int)Math.Floor(Math.Log10(num)) + 1;

        int power = digits - position - 1;
        int divisor = (int)Math.Pow(10, power);
        int digit = (num / divisor) % 10;
        return digit;
    }
}
