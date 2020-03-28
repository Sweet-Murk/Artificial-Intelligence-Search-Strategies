using System.Collections;
using System;

class Node
{
  public  int depth;
  public  State State;  
  public  Node Parent;
    // another form of Node Constructor which accepts only the State;
 
  public Node(State State)
  {
    this.State = State;
  }
    // this form of Generalization of Node Constructor which accepts 
    // any node root or ordinary node;
 
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