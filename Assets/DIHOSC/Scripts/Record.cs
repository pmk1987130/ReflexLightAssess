using System;
namespace UnityOSC
{
    public class Record : RecordBase
    {

        private float _duration;
        /// <summary>
        /// 持续时间
        /// </summary>
        public float Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        private float _supportForce;
        /// <summary>
        /// 支撑力
        /// </summary>
        public float SupportForce
        {
            get { return _supportForce; }
            set { _supportForce = value; }
        }

        private float _maxForce;
        /// <summary>
        /// 最大力
        /// </summary>
        public float MaxForce
        {
            get { return _maxForce; }
            set { _maxForce = value; }
        }

        private float _damping;
        /// <summary>
        /// 阻尼
        /// </summary>
        public float Damping
        {
            get { return _damping; }
            set { _damping = value; }
        }

        private float _responseTime;
        /// <summary>
        /// 反应时
        /// </summary>
        public float ResponseTime
        {
            get { return _responseTime; }
            set { _responseTime = value; }
        }

        private float _accuracy;
        /// <summary>
        /// 准确率
        /// </summary>
        public float Accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; }
        }

        private float _smoothesss;
        /// <summary>
        /// 平滑度
        /// </summary>
        public float Smoothesss
        {
            get { return _smoothesss; }
            set { _smoothesss = value; }
        }
        
    }
}
