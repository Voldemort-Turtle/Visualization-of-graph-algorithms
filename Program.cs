using System;
using System.Collections;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;

namespace ConsoleApp11

{
    public class BSTNode
    {
        public int Value;
        public BSTNode Left;
        public BSTNode Right;

        public BSTNode(int value)
        {
            Value = value;
        }
    }

    public class BST
    {
        private BSTNode root;
        public void WypiszBFS()
        {
            if (root == null) return;

            Queue<BSTNode> kolejka = new Queue<BSTNode>();
            kolejka.Enqueue(root);
            while(kolejka.Count > 0)
            {
                BSTNode current = kolejka.Dequeue();
                if (current == null) continue;
                Console.WriteLine(current.Value + " ");
                if(current != null)
                {
                    kolejka.Enqueue(current.Left);

                }
                if(current != null)
                {
                    kolejka.Enqueue(current.Right);
                }
                
            }
            Console.WriteLine();
        }
        public void DFS()
        {
            DFSrek(root);
            Console.WriteLine();
        }

        public void DFSrek(BSTNode node)
        {
            if(node == null) return;
            Console.WriteLine(node.Value + " ");
            DFSrek(node.Left);
            DFSrek(node.Right);


        }

        public void WypiszInOrder()
        {
            WypiszInOrderRek(root);
            Console.WriteLine();
        }

        private void WypiszInOrderRek(BSTNode node)
        {
            if (node == null) return;

            WypiszInOrderRek(node.Left);       // Lewy
            Console.Write(node.Value + " ");   // Korzeń
            WypiszInOrderRek(node.Right);      // Prawy
        }

        public void WypiszPreOrder()
        {
            WypiszPreOrderRek(root);
            Console.WriteLine();
        }

        private void WypiszPreOrderRek(BSTNode node)
        {
            if (node == null) return;

            Console.Write(node.Value + " ");   // Korzeń
            WypiszPreOrderRek(node.Left);      // Lewy
            WypiszPreOrderRek(node.Right);     // Prawy
        }

        public void WypiszPostOrder()
        {
            WypiszPostOrderRek(root);
            Console.WriteLine();
        }

        private void WypiszPostOrderRek(BSTNode node)
        {
            if (node == null) return;

            WypiszPostOrderRek(node.Left);     // Lewy
            WypiszPostOrderRek(node.Right);    // Prawy
            Console.Write(node.Value + " ");   // Korzeń
        }
        

        public void Dodaj(int value)
        {
            if (root == null)
            {
                root = new BSTNode(value);
            }
            else
            {
                DodajRekurencyjnie(root, value);
            }
        }

        private void DodajRekurencyjnie(BSTNode node, int value)
        {
            if (value < node.Value)
            {
                if (node.Left == null)
                    node.Left = new BSTNode(value);
                else
                    DodajRekurencyjnie(node.Left, value);
            }
            else if (value > node.Value)
            {
                if (node.Right == null)
                    node.Right = new BSTNode(value);
                else
                    DodajRekurencyjnie(node.Right, value);
            }
            // Jeśli value == node.Value — ignorujemy duplikaty (standardowa implementacja BST)
        }

        public bool CzyZawiera(int value)
        {
            return CzyZawieraRekurencyjnie(root, value);
        }

        private bool CzyZawieraRekurencyjnie(BSTNode node, int value)
        {
            if (node == null)
                return false;

            if (value == node.Value)
                return true;

            if (value < node.Value)
                return CzyZawieraRekurencyjnie(node.Left, value);
            else
                return CzyZawieraRekurencyjnie(node.Right, value);
        }


        public void PokazGraficznie()
        {
            System.Windows.Forms.Application.Run(new TreeForm(root));
        }
        public void WypiszDFSIterative()
        {
            if (root == null) return;
            Stack<BSTNode> stack = new Stack<BSTNode>();
            stack.Push(root);

            while(stack.Count > 0)
            {
                 BSTNode current = stack.Pop();
                Console.WriteLine(current.Value + " ");

                if(current.Right != null) stack.Push(current.Right);
                if(current.Left != null) stack.Push(current.Left);
            }
            Console.WriteLine();
        }
    }
    public class TreeForm : Form
    {
        private BSTNode root;

        public TreeForm(BSTNode root)
        {
            this.root = root;
            this.Text = "Wizualizacja drzewa BST";
            this.Width = 900;
            this.Height = 700;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (root != null)
                RysujWezel(e.Graphics, root, 400, 50, 200);
        }

        private void RysujWezel(Graphics g, BSTNode node, int x, int y, int offset)
        {
            if (node == null)
                return;

            // rysujemy krawędzie
            if (node.Left != null)
            {
                g.DrawLine(Pens.Black, x, y, x - offset, y + 80);
                RysujWezel(g, node.Left, x - offset, y + 80, offset / 2);
            }

            if (node.Right != null)
            {
                g.DrawLine(Pens.Black, x, y, x + offset, y + 80);
                RysujWezel(g, node.Right, x + offset, y + 80, offset / 2);
            }

            // rysujemy okrąg (węzeł)
            var rect = new Rectangle(x - 20, y - 20, 40, 40);
            g.FillEllipse(Brushes.LightBlue, rect);
            g.DrawEllipse(Pens.Black, rect);

            // wartość w środku
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(node.Value.ToString(), new Font("Arial", 10), Brushes.Black, rect, sf);


        }


    }
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var drzewo = new BST();
            drzewo.Dodaj(10);
            drzewo.Dodaj(5);
            drzewo.Dodaj(6);
            drzewo.Dodaj(7);
            drzewo.Dodaj(4);
            drzewo.Dodaj(15);
            drzewo.Dodaj(1);
            drzewo.Dodaj(21);
            drzewo.Dodaj(32);
            drzewo.Dodaj(12);
            Thread thread = new Thread(() => drzewo.PokazGraficznie());
            thread.SetApartmentState(ApartmentState.STA); // wymóg dla Windows Forms
            thread.Start();


            // drzewo.WypiszPostOrder();
            // drzewo.DFS();
            //drzewo.WypiszDFSIterative();
            //drzewo.WypiszPreOrder();
            //drzewo.WypiszPostOrder();
            drzewo.WypiszPostOrder();

            Console.WriteLine(drzewo.CzyZawiera(5));   // True
            Console.WriteLine(drzewo.CzyZawiera(20));
        }
    }
}
