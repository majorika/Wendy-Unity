using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wendy
{
    [System.Serializable]
    public class OwnItem
    {
        public int OwnItemUID;
        public int ItemID;
        public int CurrentQNTY;
        public int Level;
        public int Tier;
        public string UpdateTimeStamp;
    }
}