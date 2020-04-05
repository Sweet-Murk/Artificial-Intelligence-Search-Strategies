using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace practise
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string[] left_shore={"R1","R2","R3","R4","r1","r2","r3","r4"};
            string[] boat={"z","z","z"};
            string[] right_shore={"z","z","z","z","z","z","z","z"};
            */
            string[] left_shore={"R1","R2","R3","r1","r2","r3"};
            string[] boat={"z","z","z"};
            string[] right_shore={"z","z","z","z","z","z"};
            bool boat_state=true;
            State Start_State = new State(left_shore,boat,right_shore,boat_state);
            Node Start_Node = new Node(Start_State);
            Depth_First_Search(Start_Node);
            Breadth_First_Search(Start_Node);
            A_Star_Search(Start_Node);
        
        }
        static public double Heuristic(Node Node_F)
        {   
            int count_left_shore=0;
            for(int i=0;i<Node_F.State.left_shore.Length;i++)
            {
                if(Node_F.State.left_shore[i]!="z")
                {
                    count_left_shore++;
                }
            }
            return count_left_shore + Node_F.depth;
        }
        static void A_Star_Search(Node Start)
        {
            var Fringe = new PriorityQueue<double,Node>();
            List<State> children = new List<State>();
            GetSucc x = new GetSucc();
            Fringe.Enqueue(0,Start);

            while (Fringe.Count != 0)
            {
                Node Parent = (Node)Fringe.Dequeue();
                Parent.State.Display_State();
                if (Parent.State.left_shore[0]=="z"&&Parent.State.left_shore[1]=="z"&&Parent.State.left_shore[2]=="z"&&Parent.State.left_shore[3]=="z"&&Parent.State.left_shore[4]=="z"&&Parent.State.left_shore[5]=="z")
                {
                    Console.WriteLine();
                    Console.WriteLine("Find Goal   " + Parent.State);
                    Console.WriteLine(Parent.depth);
                    break;
                }
                State Parent_State = new State(Parent.State.left_shore,Parent.State.boat,Parent.State.right_shore,Parent.State.boat_state)
                        {
                            left_shore=new List<string>(Parent.State.left_shore).ToArray(),
                            boat=new List<string>(Parent.State.boat).ToArray(),
                            right_shore=new List<string>(Parent.State.right_shore).ToArray(),
                            boat_state=Parent.State.boat_state
                        };
                children = x.GetSussessor(Parent_State);
                for (int i = 0; i < children.Count; i++)
                {
                    State currentChildren = new State(Parent.State.left_shore,Parent.State.boat,Parent.State.right_shore,Parent.State.boat_state)
                    {
                        left_shore=new List<string>(children[i].left_shore).ToArray(),
                        boat=new List<string>(children[i].boat).ToArray(),
                        right_shore=new List<string>(children[i].right_shore).ToArray(),
                        boat_state=children[i].boat_state
                    };
                    Node Tem = new Node(currentChildren, Parent);
                    double priority = Heuristic(Tem);
                    Fringe.Enqueue(priority,Tem);
                }
            }
        }

        public static void Breadth_First_Search(Node Start)
        {
            GetSucc x = new GetSucc();
            List<State> children = new List<State>();
            Queue Fringe = new Queue();
            Fringe.Enqueue(Start);
            while (Fringe.Count != 0)
            {
                Node Parent = (Node)Fringe.Dequeue();
                Parent.State.Display_State();
                if (Parent.State.left_shore[0]=="z"&&Parent.State.left_shore[1]=="z"&&Parent.State.left_shore[2]=="z"&&Parent.State.left_shore[3]=="z"&&Parent.State.left_shore[4]=="z"&&Parent.State.left_shore[5]=="z")
                {
                    Console.WriteLine();
                    Console.WriteLine("Find Goal   " + Parent.State);
                    Console.WriteLine(Parent.depth);
                    break;
                }
                State Parent_State = new State(Parent.State.left_shore,Parent.State.boat,Parent.State.right_shore,Parent.State.boat_state)
                        {
                            left_shore=new List<string>(Parent.State.left_shore).ToArray(),
                            boat=new List<string>(Parent.State.boat).ToArray(),
                            right_shore=new List<string>(Parent.State.right_shore).ToArray(),
                            boat_state=Parent.State.boat_state
                        };
                children = x.GetSussessor(Parent_State);
                for (int i = 0; i < children.Count; i++)
                {
                    State currentChildren = new State(Parent.State.left_shore,Parent.State.boat,Parent.State.right_shore,Parent.State.boat_state)
                        {
                            left_shore=new List<string>(children[i].left_shore).ToArray(),
                            boat=new List<string>(children[i].boat).ToArray(),
                            right_shore=new List<string>(children[i].right_shore).ToArray(),
                            boat_state=children[i].boat_state
                        };
                    Node Tem = new Node(currentChildren, Parent);
                    Fringe.Enqueue(Tem);

                }

            }

        }
        
        public static void Depth_First_Search(Node Start)
        {
            GetSucc x = new GetSucc();
            List<State> children = new List<State>();
            Stack Fringe = new Stack();
            Fringe.Push(Start);
            while (Fringe.Count != 0)
            {
                Node Parent = (Node)Fringe.Pop();
                Parent.State.Display_State();
                if (Parent.State.left_shore[0]=="z"&&Parent.State.left_shore[1]=="z"&&Parent.State.left_shore[2]=="z"&&Parent.State.left_shore[3]=="z"&&Parent.State.left_shore[4]=="z"&&Parent.State.left_shore[5]=="z"/* &&Parent.State.left_shore[6]=="z"&&Parent.State.left_shore[7]=="z"*/)
                {
                    Console.WriteLine();
                    Console.WriteLine("Find Goal   " + Parent.State);
                    Console.WriteLine(Parent.depth);
                    break;
                }
                State Parent_State = new State(Parent.State.left_shore,Parent.State.boat,Parent.State.right_shore,Parent.State.boat_state)
                        {
                            left_shore=new List<string>(Parent.State.left_shore).ToArray(),
                            boat=new List<string>(Parent.State.boat).ToArray(),
                            right_shore=new List<string>(Parent.State.right_shore).ToArray(),
                            boat_state=Parent.State.boat_state
                        };
                children = x.GetSussessor(Parent_State);
                for (int i = 0; i < children.Count; i++)
                {
                    State currentChildren = new State(Parent.State.left_shore,Parent.State.boat,Parent.State.right_shore,Parent.State.boat_state)
                        {
                            left_shore=new List<string>(children[i].left_shore).ToArray(),
                            boat=new List<string>(children[i].boat).ToArray(),
                            right_shore=new List<string>(children[i].right_shore).ToArray(),
                            boat_state=children[i].boat_state
                        };
                    Node Tem = new Node(currentChildren, Parent);
                    Fringe.Push(Tem);

                }
            }

        }

    }
}
