using PROG_3B_ST10255309.Models;
using System.Collections.Generic;

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
    }

        // Binary Search tree implementation
        public class IssueRequest
        {
            private Node root;

            public IssueRequest()
            {
                root = null;
            }

            public void Insert(Report report)
            {
                root = InsertRequest(root, report);
            }

            // Inserting service requests into the tree by ID
            private Node InsertRequest(Node node, Report report)
            {
                if (node == null)
                {
                    return new Node(report);
                }

                if (report.Id < node.Data.Id)
                {
                    node.Left = InsertRequest(node.Left, report);
                }

                else if (report.Id > node.Data.Id)
                {
                    node.Right = InsertRequest(node.Right, report);
                }

                return node;
            }

            public Report Search(int id)
            {
                return SearchReport(root, id);
            }

            // Searching for a Issued report by ID
            private Report SearchReport(Node node, int id)
            {
                if (node == null)
                {
                    return null;
                }

                if (id == node.Data.Id)
                {
                    return node.Data;
                }

                else if (id < node.Data.Id)
                {
                    return SearchReport(node.Left, id);
                }
                else
                {
                    return SearchReport(node.Right, id);
                }
            }

            // Retrieving all reports in order
            public List<Report> GetOrdered()
            {
                List<Report> reports = new List<Report>();
                InOrder(root, reports);
                return reports;
            }

            private void InOrder(Node node, List<Report> reports)
            {
                if (node != null)
                {
                    InOrder(node.Left, reports);
                    reports.Add(node.Data);
                    InOrder(node.Right, reports);
                }
            }

            public int Count()
            {
                return GetCount(root);
            }

            // Counting the number of reports inside the tree
            private int GetCount(Node node)
            {
                if (node == null)
                    return 0;
                return 1 + GetCount(node.Left) + GetCount(node.Right);

                
            }
        }   
}
// VanderWilt, A. (2019). Introduction to Binary Search Trees. [online] Medium. Available at: https://medium.com/better-programming/introduction-to-binary-search-trees-dde166368210 [Accessed 7 Nov. 2025].