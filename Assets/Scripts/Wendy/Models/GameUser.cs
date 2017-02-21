using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wendy
{
    [System.Serializable]
    public class GameUser
    {
        public int GameUserID;
        public string NickName;
        public string Locale;
        public int OffsetTime;
        public string OffsetTimeUpdateAt;
        public string createAt;
        public string loginAt;
    }
}
