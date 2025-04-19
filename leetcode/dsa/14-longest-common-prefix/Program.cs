using LongestCommonPrefix;

class Program
{
    public static void Main(string[] args)
    {
        var s = new Solution();
        var lcs = s.LongestCommonPrefix(["flower", "flow", "flight"]);
        Console.WriteLine(lcs);
        
    }
}
