using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TreesLab
{
    class Tree
    {
        Hashtable hashtable;
        Node top;
        public Node Top { get { return top; } }
        public Tree(Hashtable hashtable)
        {
            Node top = new Node(hashtable, null, null, -1);
            this.top = top;
            this.hashtable = hashtable;
        }
        public class Node
        {
            Hashtable hashtable;
            int type;
            string data;
            Node parent;
            public List<Node> Nodes { get; set; }
            public Node(Hashtable hashtable, Node parent, string data, int type)
            {
                this.Nodes = new List<Node>();
                this.hashtable = hashtable;
                this.parent = parent;
                this.data = data;
                this.type = type;
            }
            public string Visit()
            {
                double p, a;
                switch (type)
                {
                    case 0:     // name of variable, key for hash
                            return data;
                    case 1:
                        // "=" 
                        //  1)visit left for key 
                        //  2)visit right for value
                        //  3)hashTab[1] = 2;
                        string key = Nodes[0].Visit();
                        double value = Convert.ToDouble(Nodes[1].Visit());
                        if (hashtable.ContainsKey(key))
                        {
                            hashtable[key] = value;
                        }
                        else
                        {
                            hashtable.Add(key, value);
                        }
                        return null;
                    case 2:
                        // Operations : + - * / ^ sqrt()
                        switch (data)
                        {

                            case "-":
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                return (a - p).ToString();
                            case "+":
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                return (a + p).ToString();
                            case "*":
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                return (a * p).ToString();
                            case "/":
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                return (a / p).ToString();
                            default:
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                return (MathF.Pow((float)a, (float)p)).ToString();

                        }
                    case 3:
                        // If
                        if (Nodes[0].Visit() != "0")
                        {
                            Nodes[1].Visit();
                        }
                        else
                        {
                            Nodes[2].Visit();
                        }
                        return null;
                    case 4:
                        // Condition
                        switch (data)
                        {
                            case "==":
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                if (a == p)
                                {
                                    return "1";
                                }
                                else
                                {
                                    return "0";
                                }
                            case "!=":
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                if (a != p)
                                {
                                    return "1";
                                }
                                else
                                {
                                    return "0";
                                }
                            case ">=":
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                if (a >= p)
                                {
                                    return "1";
                                }
                                else
                                {
                                    return "0";
                                }
                            case "<=":
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                if (a <= p)
                                {
                                    return "1";
                                }
                                else
                                {
                                    return "0";
                                }
                            case ">":
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                if (a > p)
                                {
                                    return "1";
                                }
                                else
                                {
                                    return "0";
                                }
                            case "<":
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                if (a < p)
                                {
                                    return "1";
                                }
                                else
                                {
                                    return "0";
                                }

                            case "||":
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                if (a != 0 || p != 0)
                                {
                                    return "1";
                                }
                                else
                                {
                                    return "0";
                                }
                            default:
                                a = Convert.ToDouble(Nodes[0].Visit());
                                p = Convert.ToDouble(Nodes[1].Visit());
                                if (a != 0 && p != 0)
                                {
                                    return "1";
                                }
                                else
                                {
                                    return "0";
                                }
                        }
                    case 5:
                        // If
                        while (Nodes[0].Visit() != "0")
                        {
                            Nodes[1].Visit();
                        }
                        return null;
                    default:
                        Nodes[0].Visit();
                        return Nodes[1].Visit();
                }
            }

            public Node AddNode(int type, string data)
            {
                Node addedNode = new Node(hashtable, this, data, type);
                Nodes.Add(addedNode);
                return addedNode;
            }
        }
    }
}