using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ReševanjeLabirinta
{
    public partial class ReševanjeLabirinta : Form
    {
        private static string file;
        private static int[,] matrix;
        private static List<List<Index>> path;
        private static List<Index> pathPrint;
        private static List<Index> visited;
        private static Index root;
        private static Index fin;
        private static double elapsed_time;

        public ReševanjeLabirinta()
        {
            InitializeComponent();
            comboBox.DataSource = loadAlgorithms();
        }

        private List<string> loadAlgorithms()
        {
            List<string> collection = new List<string>();
            collection.Add("A*");
            collection.Add("Dijkstra");
            collection.Add("DFS");
            collection.Add("BFS");
            return collection;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            opnFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            opnFileDialog.FilterIndex = 1;
            opnFileDialog.RestoreDirectory = true;
            opnFileDialog.FileName = "labirint.txt";

            file = string.Empty;
            if (opnFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = opnFileDialog.SafeFileName;

                    var fileStream = opnFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        List<List<int>> list = new List<List<int>>();
                        for (int i=0; reader.Peek() >= 0; i++)
                        {
                            var line = reader.ReadLine() + "\n";
                            list.Add(line.Split(',').Select(h => Int32.Parse(h)).ToList());
                            file += line;
                        }

                        lblLabMatrix.Text = file;
                        lblSelectedFile.Text = filePath;
                        toMatrix(list);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
        }

        private static void toMatrix(List<List<int>> lst)
        {
            int c = lst.Count;
            int r = lst[0].Count;
            matrix = new int[c, r];

            for(int i = 0; i < c; i++)
            {
                for (int z = 0; z < r; z++)
                {
                    var l = lst[i][z];
                    if(l == -2)
                    {
                        root = new Index(i, z);
                    }
                    matrix[i, z] = l;
                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {var stopwatch = new Stopwatch();
            prepare();
            switch ((string)comboBox.SelectedItem)
            {
                case "A*":
                    lblSolvedMatrix.Text = AStarAlgorithm.Solve(matrix, true);
                    break;
                case "Dijkstra":
                    lblSolvedMatrix.Text = AStarAlgorithm.Solve(matrix, false);
                    break;
                case "DFS":
                    stopwatch.Start();
                    Dfs(root, null);
                    pathPrint.Add(fin);
                    stopwatch.Stop();
                    elapsed_time = stopwatch.Elapsed.TotalMilliseconds;printPath();
                    
                    break;
                case "BFS":
                    Bfs(root); pathPrint.Add(path.Last().ElementAt(0)); printPath();
                    break;
                default: break;
            }
            
        }

        private void prepare()
        {
            path = new List<List<Index>>();
            visited = new List<Index>();
            lblSolvedMatrix.Text = "";
            pathPrint = new List<Index>();
            visited.Add(root);
            path.Add(new List<Index>() { root, null });
        }

        private static void shortestPath(Index index)
        {
            for (int i = path.Count - 2; i > 0; i--)
            {
                if (path[i].ElementAt(0).Equals(index))
                {
                    shortestPath(path[i].ElementAt(1));
                    pathPrint.Add(index);
                }
            }
        }

        private static void Bfs(Index index)
        {
            var mtx = matrix;

            List<Index> find = new List<Index>();
            find.Add(index);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (find.Count > 0)
            {
                index = find[0];
                find.Remove(index);
                Index up = new Index(index.row - 1, index.column);
                Index down = new Index(index.row + 1, index.column);
                Index right = new Index(index.row, index.column + 1);
                Index left = new Index(index.row, index.column - 1);

                if (up.row >= 0 && !visited.Contains<Index>(up))
                {
                    if (mtx[up.row, up.column] >= 0)
                    {
                        path.Add(new List<Index>() { up, index });
                        find.Add(up);
                        visited.Add(up);
                    }
                    else if (mtx[up.row, up.column] == -3)
                    {
                        path.Add(new List<Index>() { up, index });
                        break;
                    }

                }
                if (right.column < mtx.GetLength(1) && !visited.Contains(right))
                {
                    if (mtx[right.row, right.column] >= 0)
                    {
                        path.Add(new List<Index>() { right, index });
                        find.Add(right);
                        visited.Add(right);
                    }
                    else if (mtx[right.row, right.column] == -3)
                    {
                        path.Add(new List<Index>() { right, index });
                        break;
                    }
                }
                if (down.row < mtx.GetLength(0) && !visited.Contains(down))
                {
                    if (mtx[down.row, down.column] >= 0)
                    {
                        path.Add(new List<Index>() { down, index });
                        find.Add(down);
                        visited.Add(down);
                    }
                    else if (mtx[down.row, down.column] == -3)
                    {
                        path.Add(new List<Index>() { down, index });
                        break;
                    }
                }
                if (left.column >= 0 && !visited.Contains(left))
                {
                    if (mtx[left.row, left.column] >= 0)
                    {
                        path.Add(new List<Index>() { left, index });
                        find.Add(left);
                        visited.Add(left);
                    }
                    else if (mtx[left.row, left.column] == -3)
                    {
                        path.Add(new List<Index>() { left, index });
                        break;
                    }
                }

            }

            stopwatch.Stop();
            elapsed_time = stopwatch.Elapsed.TotalMilliseconds;

            pathPrint = new List<Index>();
            pathPrint.Add(path.First().ElementAt(0));
            shortestPath(path.Last().ElementAt(1));
        }

        private static void Dfs(Index index, Index parent)
        {
            if (matrix[index.row, index.column] == -3)
            {
                fin = index;
                shortestPath(fin);
                return;
            }
            else
            {
                Index up = new Index(index.row - 1, index.column);
                Index down = new Index(index.row + 1, index.column);
                Index right = new Index(index.row, index.column + 1);
                Index left = new Index(index.row, index.column - 1);

                if (up.row >= 0 && !visited.Contains<Index>(up))
                {
                    if (matrix[up.row, up.column] >= 0)
                    {
                        path.Add(new List<Index>() { up, index });
                        visited.Add(up);
                        Dfs(up, index);
                    }
                    else if (matrix[up.row, up.column] == -3)
                    {
                        path.Add(new List<Index>() { up, index });
                        fin = up;
                        shortestPath(index);
                        return;
                    }

                }
                if (left.column >= 0 && !visited.Contains(left))
                {
                    if (matrix[left.row, left.column] >= 0)
                    {
                        path.Add(new List<Index>() { left, index });
                        visited.Add(left);
                        Dfs(left, index);
                    }
                    else if (matrix[left.row, left.column] == -3)
                    {
                        path.Add(new List<Index>() { left, index });
                        fin = left;
                        shortestPath(index);
                        return;
                    }
                }
                if (down.row < matrix.GetLength(0) && !visited.Contains(down))
                {
                    if (matrix[down.row, down.column] >= 0)
                    {
                        path.Add(new List<Index>() { down, index });
                        visited.Add(down);
                        Dfs(down, index);
                    }
                    else if (matrix[down.row, down.column] == -3)
                    {
                        path.Add(new List<Index>() { down, index });
                        fin = down;
                        shortestPath(index);
                        return;
                    }
                }
                if (right.column < matrix.GetLength(1) && !visited.Contains(right))
                {
                    if (matrix[right.row, right.column] >= 0)
                    {
                        path.Add(new List<Index>() { right, index });
                        visited.Add(right);
                        Dfs(right, index);
                    }
                    else if (matrix[right.row, right.column] == -3)
                    {
                        path.Add(new List<Index>() { right, index });
                        fin = right;
                        shortestPath(index);
                        return;
                    }
                }
 
            }

           
        }

        private void printPath()
        {
            for (int i = 0; i < pathPrint.Count; i++)
            {
                lblSolvedMatrix.Text += i + 1 + ". " + pathPrint[i].row + " " + pathPrint[i].column + ",\n";
            }
            lblSolvedMatrix.Text += "najkrajša pot: " + pathPrint.Count;
            lblSolvedMatrix.Text +="\nvsa vozlišča: " + visited.Count;
            lblSolvedMatrix.Text += "\nčas: " + elapsed_time;
        }

    }
}
