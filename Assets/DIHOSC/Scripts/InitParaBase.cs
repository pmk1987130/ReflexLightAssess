using System;
namespace UnityOSC
{
    public class InitParaBase
    {
        private ArmType _affectedArm;

        public ArmType AffectedArm
        {
            get { return _affectedArm; }
            set { _affectedArm = value; }
        }

        private float _totalTime;

        public float TotalTime
        {
            get { return _totalTime; }
            set { _totalTime = value; }
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

        private string _support;
        /// <summary>
        /// 支撑力
        /// </summary>
        public string Support
        {
            get { return _support; }
            set { _support = value; }
        }

        private string _language;
        /// <summary>
        /// 语言
        /// </summary>
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }

        private bool _visualAssistance;
        /// <summary>
        /// 若为ture，增加环境辅助，更加美观
        /// </summary>
        public bool VisualAssistance
        {
            get { return _visualAssistance; }
            set { _visualAssistance = value; }
        }
    }
    public enum ArmType
    {
        Right,
        Left,
        All
    }
}
