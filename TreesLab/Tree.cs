using System;
using System.Collections.Generic;
using System.Text;

namespace TreesLab
{
    class Tree
    {
        Node top;

        class Node
        {
            int type;
            Node parent,leftSon,rightSon;
            public Node LeftNode { get { return leftSon; } }
            public Node RightNode { get { return rightSon; } }
            public float Visit()
            {
                return 0;
            }
        }

        class NodeVar : Node
        {
            public NodeVar(float a)
            {
                this.a = a;
            }
            float a;
            public float Visit()
            {
                return a;
            }
        }
        
        class NodeOp : Node
        {
            string op;
            public NodeOp(string op)
            {
                this.op = op;
            }
            public float Visit()
            {
                float a = LeftNode.Visit();
                float b = RightNode.Visit();
                switch (op)
                {
                    case "+":
                        return a + b;
                        
                    case "-":
                        return a - b;
                        
                    case "/":
                        return a / b;
                        
                    case "*":
                        return a * b;
                          
                    case "^":
                        return MathF.Pow(a,b);
                    default:
                        return 0;
                }
            }
        }
        
        class Condition : Node
        {
            public Condition(string cond)
            {
                this.cond = cond;
            }
            string cond;
            public float Visit()
            {
                float a = LeftNode.Visit();
                float b = RightNode.Visit();
                switch (cond)
                {
                    case ">":
                        if (a > b)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }

                    case ">=":
                        if (a >= b)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }

                    case "<":
                        if (a < b)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    case "<=":
                        if (a <= b)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    case "==":
                        if (a == b)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    case "||":
                        if (a > 0|| b>0)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    case "&&":
                        if (a>0&&b>0)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    default:
                        if (a != b)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                }
            }
        }
        
        class Cycle : Node
        {
            public float Visit()
            {
                while (LeftNode.Visit() > 0)
                {
                    RightNode.Visit();
                }
                return 1;
            }
        }


    }
}
