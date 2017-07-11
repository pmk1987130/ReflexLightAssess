using System;
namespace UnityOSC
{
    /// <summary>
    /// Determining a three coordinate systems
    /// </summary>
    public class OperatingLimits
    {
        private float _minX;

        public float MinX
        {
            get { return _minX; }
            set { _minX = value; }
        }

        private float _maxX;

        public float MaxX
        {
            get { return _maxX; }
            set { _maxX = value; }
        }

        private float _minY;

        public float MinY
        {
            get { return _minY; }
            set { _minY = value; }
        }

        private float _maxY;

        public float MaxY
        {
            get { return _maxY; }
            set { _maxY = value; }
        }

        private float _minZ;

        public float MinZ
        {
            get { return _minZ; }
            set { _minZ = value; }
        }

        private float _maxZ;

        public float MaxZ
        {
            get { return _maxZ; }
            set { _maxZ = value; }
        }

        private Coordinate _center;

        public Coordinate Center
        {
            get { return _center; }
            set { _center = value; }
        }
    }
}
