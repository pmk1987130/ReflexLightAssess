using System;
namespace UnityOSC
{
    public class RecordBase
    {
        private float _score;

        public float Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private int _currentLevel;
        /// <summary>
        /// 
        /// Mark: This parameter is available for Many hurdles games
        /// </summary>
        public int CurrentLevel
        {
            get { return _currentLevel; }
            set { _currentLevel = value; }
        }
    }
}
