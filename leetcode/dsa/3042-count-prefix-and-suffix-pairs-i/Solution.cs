namespace CountPrefixAndSuffixPairsI;

public class Solution
{
    public int CountPrefixSuffixPairs(string[] words)
    {
        int count = 0;

        for (int j = 1; j < words.Length; j++)
        {
            for (int i = 0; i < j; i++)
            {
                if (IsPrefixAndSuffix(words[i], words[j]))
                {
                    count += 1;
                }
            }
        }

        return count;
    }

    private bool IsPrefixAndSuffix(string left, string right)
    {
        if (left.Length > right.Length)
        {
            return false;
        }

        return right.StartsWith(left) && right.EndsWith(left);
    }
}
