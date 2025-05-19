namespace FindXSumOfAllKLongSubarraysI;

class Program
{
    public static void Main(string[] args)
    {
        var s = new Solution();
        var lcs = s.FindXSum([1, 1, 2, 2, 3, 4, 2, 3], 6, 2);
        Console.WriteLine(lcs);

    }
}
