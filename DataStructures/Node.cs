using PROG_3B_ST10255309.Models;

namespace PROG_3B_ST10255309.DataStructures
{
    public class Node
    {
        // Node for the Binary Search tree for organizing report statuses
        public Report Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(Report data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        // Binary Search tree
        public class IssueRequest
        {
            private Node root;

            public IssueRequest()
            {
                root = null;
            }
        }
    }
}
// VanderWilt, A. (2019). Introduction to Binary Search Trees. [online] Medium. Available at: https://medium.com/better-programming/introduction-to-binary-search-trees-dde166368210 [Accessed 7 Nov. 2025].