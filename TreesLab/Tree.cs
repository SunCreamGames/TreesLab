using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TreesLab
{
   public class Tree
    {
        public Node topNode;
        Hashtable table;
       public Tree(Hashtable hashtable)
        {
            this.table = hashtable;
            this.topNode = new Node(hashtable,Node.Operation.Empty,"",null);
        }

        public double Calculate()
        {
            return Convert.ToDouble(topNode.Visit());
        }
    }

        public class Node
        {
        Hashtable hashtable;
        Node parent;
        int type;
        string data;
        public enum Operation
            {
                Operator, Setter, Data, Empty
            }
            public Node(Hashtable hashtable, Operation op, string data, Node parent)
            {
            this.type = (int)op;
            this.hashtable = hashtable;
            this.parent = parent;
            this.data = data;
            Nodes = new List<Node>();
            }
           public List<Node> Nodes { get; set; }

            public string Visit()
            {
                switch (this.type)
                {
                    case (int)Operation.Operator:
                        switch (data)
                        {
                        case "+":
                            return (Convert.ToDouble(Nodes[0].Visit()) + Convert.ToDouble(Nodes[1].Visit())).ToString();

                        case "-":
                            if (Nodes[0].Visit() == Nodes[1].Visit())
                            {
                                return "0";
                            }
                            return (Convert.ToDouble(Nodes[0].Visit()) - Convert.ToDouble(Nodes[1].Visit())).ToString();

                        case "/":
                            return (Convert.ToDouble(Nodes[0].Visit()) / Convert.ToDouble(Nodes[1].Visit())).ToString();

                        case "*":
                            if(Nodes[0].Visit() == "0" || Nodes[1].Visit() == "0")
                            {
                                return "0";
                            }
                                return (Convert.ToDouble(Nodes[0].Visit()) * Convert.ToDouble(Nodes[1].Visit())).ToString();

                        default:
                                return (Math.Pow(Convert.ToDouble(Nodes[0].Visit()), Convert.ToDouble(Nodes[1].Visit()))).ToString();
                        }
                    case (int)Operation.Setter:
                        string s1 = Nodes[0].Visit();
                        string s2 = Nodes[1].Visit();
                        if(Double.TryParse(s2,out double x))
                    {
                        hashtable.Add(s1, s2);
                        return "";
                    }
                    else if(hashtable.ContainsKey(s2))
                    {
                        hashtable.Add(s1, hashtable[s2]);
                    }
                    else
                    {
                        s2 = Program.CreatePostfixNotation(s2);
                        Tree tempTree = new Tree(hashtable);
                        tempTree.topNode.BuildTree(s2);
                        hashtable.Add(s1,tempTree.Calculate().ToString());
                    }
                        return "";
                    case (int)Operation.Empty:
                        for (int i = 0; i < Nodes.Count-1; i++)
                        {
                            Nodes[i].Visit();
                        }
                        return Nodes[Nodes.Count-1].Visit();
                    case (int)Operation.Data:
                        {
                            if (hashtable.ContainsKey(data))
                            {
                                return hashtable[data].ToString();
                            }
                            else
                            {
                            return data;
                            }
                        }
                    default:
                        return "";
                }
            }   

        public void BuildTree(string problem)
        {
            Node pointer = new Node(hashtable, Operation.Empty, "", this);
            this.Nodes.Add(pointer);
            string[] tokens = problem.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = tokens.Length-1; i >= 0; i--)
            {
                switch (tokens[i])
                {
                    case "+": case "*": case "-": case "/": case "^":
                        Node op = new Node(hashtable, Operation.Operator, tokens[i], pointer);
                        if (pointer.parent != null)
                        {
                            pointer.Nodes.Insert(0, op);
                        }
                        else
                        {
                            pointer.Nodes.Insert(pointer.Nodes.Count-2,op);
                        }
                        pointer = op;
                        break;
                    case "=":
                        Node set = new Node(hashtable, Operation.Setter, tokens[i], pointer);
                        pointer.Nodes.Add(set);
                        pointer = set;
                        break;
                    default:
                        if (hashtable.ContainsKey(tokens[i]))
                        {
                            pointer.Nodes.Insert(0, new Node(hashtable, Operation.Data, hashtable[tokens[i]].ToString(), pointer));
                        }
                        else
                        {
                            pointer.Nodes.Insert(0, new Node(hashtable, Operation.Data, tokens[i], pointer));
                        }
                        break;
                }
                while (pointer.Nodes.Count > 1 && (pointer.type == (int)Operation.Setter || pointer.type == (int)Operation.Operator))
                {
                    pointer = pointer.parent;
                }
            }
        }
       
        
        }
    
}