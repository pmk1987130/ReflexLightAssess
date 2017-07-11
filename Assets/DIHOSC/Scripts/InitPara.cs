using System;
using System.Collections.Generic;
namespace UnityOSC
{
    /// <summary>
    /// Start of the game required parameters
    /// </summary>
    public class InitPara : InitParaBase
    {
        private bool _isFirstStart;

        public bool IsFirstStart
        {
            get { return _isFirstStart; }
            set { _isFirstStart = value; }
        }

        private List<RecordBase> _previousRecord;
        /// <summary>
        /// 多关卡：所有历史数据
        /// 单关卡：上一次历史数据
        /// </summary>
        public List<RecordBase> PreviousRecord
        {
            get { return _previousRecord; }
            set { _previousRecord = value; }
        }

        private int _previousLevelNum;
        /// <summary>
        /// 上次关卡
        /// </summary>
        public int PreviousLevelNum
        {
            get { return _previousLevelNum; }
            set { _previousLevelNum = value; }
        }
    }
}
