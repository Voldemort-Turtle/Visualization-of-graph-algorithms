# This project is a Binary Search Tree (BST) implementation in C# that supports:
Insertion of nodes
Searching for values
Multiple tree traversal algorithms:
Breadth-First Search (BFS)
Depth-First Search (DFS)
In-Order Traversal
Pre-Order Traversal
Post-Order Traversal
Iterative DFS
Graphical visualization of the tree using Windows Forms
The application builds a BST structure in memory, prints traversal results to the console, and simultaneously opens a GUI window displaying the tree layout.

This project is ideal for:
1. Learning data structures
2. Understanding recursion vs iteration
3. Visualizing tree traversal algorithms
4. Demonstrating BST properties in practice

# Graphical Visualization
When the program runs, it opens a Windows Forms window displaying:
Nodes as blue circles
Values inside each node
Lines representing parent-child connections

# Requirements
Make sure you have installed:
.NET SDK 6.0 or newer
Windows OS (required for Windows Forms GUI)
# Run the Application
Open terminal in project directory: dotnet run
After running:
- Console will print traversal results
- GUI window will open displaying the BST

# Examples:
Post-Order Traversal : 1 4 7 6 5 12 32 21 15 10
 Console.WriteLine(drzewo.CzyZawiera(5));   // True
 Console.WriteLine(drzewo.CzyZawiera(20));  // False
 Output: True
         False
