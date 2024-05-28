using System;
using System.Collections.Generic;

class Graph
{
    private int[,] adjacencyMatrix;
    private int vertices;

    public Graph(int vertexCount)
    {
        vertices = vertexCount;
        adjacencyMatrix = new int[vertices, vertices];
    }

    public void AddEdge(int source, int destination)
    {
        adjacencyMatrix[source, destination] = 1;
        adjacencyMatrix[destination, source] = 1;
    }

    public void DFS(int start)
    {
        bool[] visited = new bool[vertices];
        Stack<int> stack = new Stack<int>();

        visited[start] = true;
        stack.Push(start);

        Console.WriteLine("Обход в глубину:");

        while (stack.Count > 0)
        {
            int current = stack.Pop();
            Console.Write(current + " ");

            for (int i = 0; i < vertices; i++)
            {
                if (adjacencyMatrix[current, i] == 1 && !visited[i])
                {
                    visited[i] = true;
                    stack.Push(i);
                }
            }
        }

        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Graph graph = new Graph(7);

        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(2, 6);

        graph.DFS(0);
    }
}
