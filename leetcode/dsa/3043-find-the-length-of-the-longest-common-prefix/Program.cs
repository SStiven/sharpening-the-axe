namespace FindTheLengthOfTheLongestCommonPrefix;

class Program
{
    public static void Main(string[] args)
    {
        //Time Limit Exceeded
        var s = new Solution();
        //Works
        //var length = s.LongestCommonPrefix([1, 10, 100,1000], [1000]);


        //var length = s.LongestCommonPrefix([5], [33]);

        //If digit is zero can have problems
        var length = s.LongestCommonPrefix([4, 1], [40, 20]);
        Console.WriteLine(length);

    }
}