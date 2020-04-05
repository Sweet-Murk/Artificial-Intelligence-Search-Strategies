using System.Collections;
using System;

class Node
{
  public  int depth;
  public  State State;  
  public  Node Parent;
 
  public Node(State State)
  {
    this.State = State;
  }
 
  public Node(State State,Node Parent)
  {
    this.State = State;
    this.Parent = Parent;
    if (Parent == null)
      this.depth = 0;
    else
      this.depth = Parent.depth + 1;        
  }

}