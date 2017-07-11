using System;
public class AxisArea : IComparable<AxisArea>
{
    float axis;

    public float Axis
    {
        get { return axis; }
        set { axis = value; }
    }
    int countPos;

    public int CountPos
    {
        get { return countPos; }
        set { countPos = value; }  
    }
    public AxisArea(int myaxis, int count)
    {
        axis = myaxis;
        countPos = count;
    }

    public int CompareTo(AxisArea other)
    {
        return other.countPos.CompareTo(this.countPos);
    }
}
public enum AxisType
{
    Axis_X,
    Axis_Y,
    Axis_Z,
}