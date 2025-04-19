namespace LongestCommonPrefix;

public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        int count = 0;
        int maxLCP = ShortestWordLength(strs);

        for (int i = 0; i < maxLCP; i++)
        {
            for(int j = 0; j < strs.Length - 1; j++)
            {
                var s1 = strs[j];
                var s2 = strs[j + 1];
                if(s1[i] != s2[i])
                {
                    return strs[0].Substring(0, count);
                }
            }
            
            count += 1;
        }

        return strs[0].Substring(0, count);

    }

    private static int ShortestWordLength(string[] strs)
    {
        int shortestLength = int.MaxValue;
        foreach(var s in strs)
        {
            if(s.Length < shortestLength)
            {
                shortestLength = s.Length;
            }
        }

        return shortestLength;
    }
}