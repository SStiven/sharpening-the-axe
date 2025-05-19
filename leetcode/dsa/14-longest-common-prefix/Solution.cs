namespace LongestCommonPrefix;

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        int count = 0;

        var firstWord = strs[0];

        if (strs.Length == 1)
        {
            return firstWord;
        }


        int maxLCP = ShortestWordLength(strs);
        for (int i = 0; i < maxLCP; i++)
        {
            var charToCheck = firstWord[i];
            for (int j = 1; j < strs.Length; j++)
            {
                var nextWord = strs[j];
                if (charToCheck != nextWord[i])
                {
                    return firstWord.Substring(0, count);
                }
            }

            count += 1;
        }

        return firstWord.Substring(0, count);

    }

    private static int ShortestWordLength(string[] strs)
    {
        int shortestLength = int.MaxValue;
        foreach (var s in strs)
        {
            if (s.Length < shortestLength)
            {
                shortestLength = s.Length;
            }
        }

        return shortestLength;
    }
}