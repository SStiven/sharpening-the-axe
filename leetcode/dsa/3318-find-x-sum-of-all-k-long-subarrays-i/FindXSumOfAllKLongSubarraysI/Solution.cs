namespace FindXSumOfAllKLongSubarraysI;

public class Solution
{
    public int[] FindXSum(int[] nums, int k, int x)
    {

        int n = nums.Length;
        var result = new List<int>();

        var numToFrecuency = new Dictionary<int, int>();

        for (int i = 0; i < k; i++)
        {
            if (!numToFrecuency.ContainsKey(nums[i]))
            {
                numToFrecuency[nums[i]] = 1;
            }
            else
            {
                numToFrecuency[nums[i]] += 1;
            }
        }

        result.Add(CalcXSum(numToFrecuency, x));

        for (int i = k; i < n; i++)
        {
            int outNum = nums[i - k];
            int inNum = nums[i];

            numToFrecuency[outNum] -= 1;
            if (numToFrecuency[outNum] == 0)
            {
                numToFrecuency.Remove(outNum);
            }

            if (!numToFrecuency.ContainsKey(inNum))
            {
                numToFrecuency[inNum] = 1;
            }
            else
            {
                numToFrecuency[inNum] += 1;
            }

            result.Add(CalcXSum(numToFrecuency, x));
        }

        return result.ToArray();
    }

    private int CalcXSum(Dictionary<int, int> numToFrecuency, int x)
    {
        return numToFrecuency
            .OrderByDescending(p => p.Value)
            .ThenByDescending(p => p.Key)
            .Take(x)
            .Sum(p => p.Key * p.Value);
    }
}
