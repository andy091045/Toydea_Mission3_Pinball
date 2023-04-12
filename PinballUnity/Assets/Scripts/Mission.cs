using UnityEngine;

public class Mission
{
    public int number;
    public string description;
    public Vector3 position;
    public int nextNumber_;

    public Mission(int number, string description, Vector3 position, int nextNumber_)
    {
        this.number = number;
        this.description = description;
        this.nextNumber_ = nextNumber_;
        this.position = position; 
    }
}
