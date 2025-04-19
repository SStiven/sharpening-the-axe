namespace AddTwoNumbers;

//https://leetcode.com/problems/add-two-numbers/description/
public class AddTwoNumbers2
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var count1 = CountDigits(l1);
        var count2 = CountDigits(l2);

        var longest = count1 >= count2 ? l1 : l2;
        var shortest = count1 < count2 ? l1 : l2;

        var root = new ListNode();
        int carry = 0;
        var current = root;

        while (longest is not null || carry != 0)
        {
            int l = longest is not null ? longest.val : 0;
            int s = shortest is not null ? shortest.val : 0;
            
            var r = l + s + carry;
            carry = r > 9 ? r / 10 : 0;
            var digit = r > 9 ? r % 10 : r;

            current.val = digit;
            if (carry > 0 || (longest is not null && longest.next is not null))
            {
                var node = new ListNode();
                current.next = node;
                current = node;
            }


            longest = longest is not null ? longest.next : null;
            shortest = shortest is not null ? shortest.next : null;
        }

        return root;
    }

    private static int CountDigits(ListNode node)
    {
        var current = node;
        int numDigits = 1;
        while (current.next != null)
        {
            current = current.next;
            numDigits += 1;
        }

        return numDigits;
    }
}