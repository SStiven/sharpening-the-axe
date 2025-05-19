namespace CountPrefixAndSuffixPairsI;

internal class Program
{
    static void Main(string[] args)
    {
        var s = new Solution();
        var c = s.CountPrefixSuffixPairs(["a", "aba", "ababa", "aa"]);
        Console.WriteLine(c);
    }
}
