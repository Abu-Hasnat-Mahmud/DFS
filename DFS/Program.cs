using System;
using System.Collections.Generic;
using System.Linq;

namespace DFS
{
    public class Node
    {
        public string Name { get; set; }
        public List<string> ConnectedNodes { get; set; }
        public bool IsVisited { get; set; }
    }

    public class Graph
    {
        public List<Node> Nodes { get; set; }
    }

    internal class Program
    {
        static List<string> stack = new();
        static List<string> VisitedNodes = new();
        static void Main(string[] args)
        {
            

            var graph = new Graph()
            {
                Nodes = new List<Node>
                {
                    new Node { Name = "A", ConnectedNodes = new List<string> { "B", "C" } },
                    new Node { Name = "B", ConnectedNodes = new List<string> { "D", "E" } },
                    new Node { Name = "C", ConnectedNodes = new List<string> { "F", "G" } },
                    new Node { Name = "D" },
                    new Node { Name = "E" },
                    new Node { Name = "F" },
                    new Node { Name = "G" },
                },
            };

            DFS(graph,graph.Nodes.Where(a => a.Name == "A").FirstOrDefault());

            Console.WriteLine($"DFS Visted nodes are : {String.Join(", ", VisitedNodes.Select(a => a))} ");
        }

        public static void DFS(Graph graph,Node node)
        {
            if (!node.IsVisited)
            {
                node.IsVisited = true;
                VisitedNodes.Add(node.Name);
                var connectedNode = node.ConnectedNodes?.ToList() ?? new List<string>();
                foreach(var child in connectedNode)
                {
                    DFS(graph, graph.Nodes.Where(a => a.Name == child).FirstOrDefault()?? new Node());
                }
            }
        }
       
    }
}
