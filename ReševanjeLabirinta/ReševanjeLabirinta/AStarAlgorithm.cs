using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;
using System.Diagnostics;

namespace ReševanjeLabirinta {
    class AStarAlgorithm {

        public static string Solve(int[,] grid, bool aStart) {
            var watch = Stopwatch.StartNew();
            long nanoStart = nanoTime();

            Node start = FindStart(grid);
            List<Node> ends = FindEnds(grid);

            start.fScore = GetHeuristicDistance(start, ends, aStart);

            List<Node> closedSet = new List<Node>();

            List<Node> openSetList = new List<Node>();
            SimplePriorityQueue<Node> openSet = new SimplePriorityQueue<Node>();
            openSet.Enqueue(start, start.gScore);
            openSetList.Add(start);

            // string output = "";
            int node_count = 0;

            while(openSet.Count > 0) {
                Node current = openSet.Dequeue();
                openSetList.Remove(current);

                // output += $"\n{current.ToString()}";
                foreach(Node finish in ends) {
                    if (current.x == finish.x && current.y == finish.y) {
                        return ReturnPath(current, node_count, watch, nanoStart);
                    }
                }

                closedSet.Add(current);
                List<Node> neighbors = GetNeighbors(current, grid, ends, aStart);

                foreach(Node neighbor in neighbors) {
                    if (closedSet.Contains(neighbor)) continue;

                    if(!openSetList.Contains(neighbor)) {
                        openSet.Enqueue(neighbor, neighbor.gScore + neighbor.fScore);
                        openSetList.Add(neighbor);
                    } else  {
                        Node existingElement = openSetList.Find(e => (e.x == neighbor.x && e.y == neighbor.y));
                        if (existingElement.gScore > neighbor.gScore) {
                            openSet.UpdatePriority(neighbor, neighbor.gScore + neighbor.fScore);
                            openSetList.Remove(neighbor);
                            openSetList.Add(neighbor);
                        }
                    }
                }
                node_count++;

            }
            //  Debug.WriteLine("No resoult found!!");
            // return $"Start point: {start.ToString()}\neFinish: {finish.ToString()}\nNo resoult found!\n!{output}";
            return "No result found!";
        }

        static string ReturnPath(Node node, int node_cont, Stopwatch watch, long nanoStart) {
            int steps = 0;
            Count count = new Count();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return $"{GenerateResponse(node, count)}\ntotalCost: {node.gScore}\npath length: {count.value}\nnodes visited: {node_cont}\nElapsed time: {elapsedMs}ms";
        }

        class Count {
            public int value;
        }

        static string GenerateResponse(Node node, Count count) {
            if(node == null) return "";

            count.value += 1;
            return GenerateResponse(node.parent, count) + $"<{node.x},{node.y}>\n";
        }

        static List<Node> GetNeighbors(Node node, int[,] grid, List<Node> ends, bool aStart) {
            int x = node.x, y = node.y;

            List<Node> neighbors = new List<Node>();

            if (x - 1 > 0) {
                Node newNode = CreateNeighbor(x - 1, y, node, ends, grid, aStart);
                if(newNode != null) neighbors.Add(newNode);
            }
            if (y - 1 > 0) {
                Node newNode = CreateNeighbor(x, y - 1, node, ends, grid, aStart);
                if (newNode != null) neighbors.Add(newNode);
            }
            if (x + 1 < grid.GetLength(0)) {
                Node newNode = CreateNeighbor(x + 1, y, node, ends, grid, aStart);
                if (newNode != null) neighbors.Add(newNode);
            }
            if (y + 1 < grid.GetLength(1)) {
                Node newNode = CreateNeighbor(x, y + 1, node, ends, grid, aStart);
                if (newNode != null) neighbors.Add(newNode);
            }

            return neighbors;
        }

        static Node CreateNeighbor(int x, int y, Node parent, List<Node> ends, int[,] grid, bool aStart) {
            if (grid[x, y] == -1 || grid[x, y] == -2) return null;
            if (grid[x, y] == -3) return new Node(x, y, parent, parent.gScore);

            Node newNode = new Node(x, y, parent, parent.gScore + grid[x, y]);
            newNode.fScore = GetHeuristicDistance(newNode, ends, aStart);
            return newNode;
        }


        static Node FindStart(int[,] grid) {
            
            for(int i = 0; i < grid.GetLength(0); i++) {
                for(int j  = 0; j < grid.GetLength(1); j++) {
                    if (grid[i,j] == -2) return new Node(i, j);
                }
            }
            throw new Exception($"No start(-2) was found was found in the given grid.");
        }

        static List<Node> FindEnds(int[,] grid) {
            List<Node> ends = new List<Node>();

            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    if (grid[i, j] == -3) ends.Add(new Node(i ,j));
                }
            }
            return ends;
        }

        static int GetHeuristicDistance(Node node, List<Node> ends, bool aStart) {
            if (!aStart) return 0;
            int minDistance = -1;
            foreach(Node end in ends) {
                int d = Math.Abs(node.x - end.x) + Math.Abs(node.y - end.y);
                if (minDistance == -1 || minDistance > d) minDistance = d;
            }
            return minDistance;
        }

        private static long nanoTime() {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
    }

    class Node : IEquatable<Node> {
        public int x;
        public int y;
        public Node parent;
        public int gScore;
        public int fScore;

        public Node(int p1, int p2, Node p = null, int gS = 0, int fS = 0) {
            x = p1;
            y = p2;
            parent = p;
            gScore = gS;
            fScore = fS;
        }

        public override string ToString() {
            return $"<{x}, {y}>, score: <{gScore},{fScore}>";
        }

        public bool Equals(Node node) { 
            if (node.x == x && node.y == y) return true;
            return false;
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            Node objAsNode = obj as Node;
            if (objAsNode == null) return false;

            return Equals(objAsNode);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
