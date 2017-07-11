using System;
using System.Collections.Generic;
namespace UnityOSC
{
    public class OperatingRange
    {
        private DirectionType _type;

        public DirectionType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private List<Coordinate> _points;

        public List<Coordinate> Points
        {
            get { return _points; }
            set { _points = value; }
        }


    }

    public enum DirectionType
    {
        Top,
        Bottom,
        Left,
        Right,
        Front,
        Back
    }

    public class Coordinate
    {
        private float _x;

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        private float _y;

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        private float _z;

        public float Z
        {
            get { return _z; }
            set { _z = value; }
        }

    }


}
