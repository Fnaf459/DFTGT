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

    public void AddRandomEdges(int numberOfEdges)
    {
        Random random = new Random();

        for (int i = 0; i < numberOfEdges; i++)
        {
            int source = random.Next(vertices);
            int destination = random.Next(vertices);

            AddEdge(source, destination);
        }
    }

    public void PrintGraph()
    {
        Console.WriteLine("Матрица смежности графа:");
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                Console.Write(adjacencyMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
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
            Console.WriteLine("Извлечена " + current);

            Console.Write(current + " ");

            for (int i = 0; i < vertices; i++)
            {
                if (adjacencyMatrix[current, i] == 1 && !visited[i])
                {
                    visited[i] = true;
                    stack.Push(i);
                    Console.WriteLine("Добавлена " + i);
                }
            }
        }

        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int numberOfVertices = 10;
        int numberOfEdges = 15;

        Graph graph = new Graph(numberOfVertices);

        graph.AddRandomEdges(numberOfEdges);

        graph.PrintGraph();

        int startVertex = 0;
        graph.DFS(startVertex);
    }
}
