namespace AddTwoNumbers;

public class Program
{
    static void Main(string[] args)
    {
        AddTwoNumbers2 sol = new AddTwoNumbers2();

        var root1 = new AddTwoNumbers2.ListNode(9, new AddTwoNumbers2.ListNode(9, null));
        var root2 = new AddTwoNumbers2.ListNode(9, new AddTwoNumbers2.ListNode(9, null));

        //var root1 = new ListNode(2, new ListNode(4, new ListNode(9, null)));
        //var root2 = new ListNode(5, new ListNode(6, new ListNode(4, new ListNode(9, null))));

        //var root1 = new ListNode(9, new ListNode(9, new ListNode(9, null)));
        //var root2 = new ListNode(0, new ListNode(0, new ListNode(1, null)));

        //var root1 = new ListNode(0, null);
        //var root2 = new ListNode(0, null);


        var r = sol.AddTwoNumbers(root1, root2);
        Console.WriteLine(r);
    }
}
