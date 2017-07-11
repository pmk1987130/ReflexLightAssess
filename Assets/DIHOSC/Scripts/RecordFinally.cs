using System;
namespace UnityOSC
{
    public sealed class RecordFinally : Record
    {
        private string _gameId;
        /// <summary>
        /// 游戏ID
        /// </summary>
        public string GameId
        {
            get { return _gameId; }
            set { _gameId = value; }
        }

        private DateTime _recordedDate;
        /// <summary>
        /// 记录产生的时间
        /// </summary>
        public DateTime RecordedDate
        {
            get { return _recordedDate; }
            set { _recordedDate = value; }
        }
    }
}
