using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Collections;

class GetSucc
{
    public List<State> GetSussessor(State State)
    {
        List<State> Result = new List<State>();
        State temperaryState = new State(State.left_shore,State.boat,State.right_shore,State.boat_state)
        {
            left_shore=new List<string>(State.left_shore).ToArray(),
            boat=new List<string>(State.boat).ToArray(),
            right_shore=new List<string>(State.right_shore).ToArray(),
            boat_state=State.boat_state 
        };
        
        if(State.boat_state == true)
        {
            for(int i=0;i<State.left_shore.Length;i++)
            {
                for(int j=0;j<State.boat.Length;j++)
                {
                    if(State.boat[j]=="z"||(State.boat[0]!="z"&&State.boat[1]!="z"&&State.boat[2]!="z"))
                    {
                        string temp=State.boat[j];
                        State.boat[j]=State.left_shore[i];
                        State.left_shore[i]=temp;
                        State.boat_state=true;
                        if(Condition(State) == true)
                        {
                            State.boat_state=false;
                            State currentState = new State(State.left_shore,State.boat,State.right_shore,State.boat_state)
                                {
                                    left_shore=new List<string>(State.left_shore).ToArray(),
                                    boat=new List<string>(State.boat).ToArray(),
                                    right_shore=new List<string>(State.right_shore).ToArray(),
                                    boat_state=State.boat_state
                                };
                            Result.Add(currentState);   
                        }
                    }
                }  
            }
            return Result;
        }

        if(State.boat_state == false)
        {
            for(int j=0;j<State.boat.Length;j++)
            {
                for(int i=0;i<State.right_shore.Length;i++)
                {
                    string temp=State.boat[j];
                    State.boat[j]=State.right_shore[i];
                    State.right_shore[i]=temp;
                    State.boat_state=false;
                    if(Condition(State) == true)
                    {
                        State.boat_state=true;
                        State currentState = new State(State.left_shore,State.boat,State.right_shore,State.boat_state)
                        {
                        left_shore=new List<string>(State.left_shore).ToArray(),
                        boat=new List<string>(State.boat).ToArray(),
                        right_shore=new List<string>(State.right_shore).ToArray(),
                        boat_state=State.boat_state
                        };
                        Result.Add(currentState);      
                    }              
                }
            }   
            return Result;         
        }
        return Result;
    }

    public bool Condition(State Parent)
    {
        if((Parent.left_shore.Contains("r1"))&&!Parent.left_shore.Contains("R1"))
        {
            if(Parent.left_shore.Contains("R2")||Parent.left_shore.Contains("R3")||Parent.left_shore.Contains("R4"))
            {
                return false;
            }

        }
        if((Parent.left_shore.Contains("r2"))&&!Parent.left_shore.Contains("R2"))
        {
            if(Parent.left_shore.Contains("R1")||Parent.left_shore.Contains("R3")||Parent.left_shore.Contains("R4"))
            {
                return false;
            }

        }
        if((Parent.left_shore.Contains("r3"))&&!Parent.left_shore.Contains("R3"))
        {
            if(Parent.left_shore.Contains("R1")||Parent.left_shore.Contains("R2")||Parent.left_shore.Contains("R4"))
            {
                return false;
            }

        }
        if((Parent.left_shore.Contains("r4"))&&!Parent.left_shore.Contains("R4"))
        {
            if(Parent.left_shore.Contains("R1")||Parent.left_shore.Contains("R2")||Parent.left_shore.Contains("R3"))
            {
                return false;
            }
        }
        if((Parent.boat.Contains("r1"))&&!Parent.boat.Contains("R1"))
        {
            if(Parent.boat.Contains("R2")||Parent.boat.Contains("R3")||Parent.boat.Contains("R4"))
            {
                return false;
            }

        }
        if((Parent.boat.Contains("r2"))&&!Parent.boat.Contains("R2"))
        {
            if(Parent.boat.Contains("R1")||Parent.boat.Contains("R3")||Parent.boat.Contains("R4"))
            {
                return false;
            }

        }
        if((Parent.boat.Contains("r3"))&&!Parent.boat.Contains("R3"))
        {
            if(Parent.boat.Contains("R1")||Parent.boat.Contains("R2")||Parent.boat.Contains("R4"))
            {
                return false;
            }

        }
        if((Parent.boat.Contains("r4"))&&!Parent.boat.Contains("R4"))
        {
            if(Parent.boat.Contains("R1")||Parent.boat.Contains("R2")||Parent.boat.Contains("R3"))
            {
                return false;
            }

        }
        if((Parent.right_shore.Contains("r1"))&&!Parent.right_shore.Contains("R1"))
        {
            if(Parent.right_shore.Contains("R2")||Parent.right_shore.Contains("R3")||Parent.right_shore.Contains("R4"))
            {
                return false;
            }

        }
        if((Parent.right_shore.Contains("r2"))&&!Parent.right_shore.Contains("R2"))
        {
            if(Parent.right_shore.Contains("R1")||Parent.right_shore.Contains("R3")||Parent.right_shore.Contains("R4"))
            {
                return false;
            }

        }
        if((Parent.right_shore.Contains("r3"))&&!Parent.right_shore.Contains("R3"))
        {
            if(Parent.right_shore.Contains("R1")||Parent.right_shore.Contains("R2")||Parent.right_shore.Contains("R4"))
            {
                return false;
            }

        }
        if((Parent.right_shore.Contains("r4"))&&!Parent.right_shore.Contains("R4"))
        {
            if(Parent.right_shore.Contains("R1")||Parent.right_shore.Contains("R2")||Parent.right_shore.Contains("R3"))
            {
                return false;
            }

        }
        if(Parent.boat_state==false&&Parent.boat[0]=="z"&&Parent.boat[1]=="z"&&Parent.boat[2]=="z")
            return false;
        if(Parent.boat_state==false&&(Parent.boat[0]!="z"&&Parent.boat[1]!="z"&&Parent.boat[2]!="z"))
            return false;
        return true;
    }
}
 