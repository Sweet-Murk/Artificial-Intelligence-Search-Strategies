using System.Globalization;
using System.Collections;
using System;

class State
{
    public string[] left_shore = new string[6];
    public string[] boat = new string[3];
    public string[] right_shore = new string[6];
    public bool boat_state;

    // another form of Node Constructor which accepts only the State;
 
    public State(string[] left_shore, string[] boat, string[] right_shore, bool boat_state)
    {
        this.left_shore = left_shore;
        this.boat = boat;
        this.right_shore = right_shore;
        this.boat_state = boat_state;
        
    }

    public void Display_State()
    {
        for(int i=0; i<left_shore.Length;i++)
        Console.Write(left_shore[i]+" ");
        Console.WriteLine();
        for(int j=0; j<boat.Length;j++)
        Console.Write(boat[j]+" ");
        Console.WriteLine();
        for(int k=0; k<right_shore.Length;k++)
        Console.Write(right_shore[k]+" ");
        Console.WriteLine();
        Console.WriteLine(boat_state);
        Console.WriteLine("_______________________");  
    }

}