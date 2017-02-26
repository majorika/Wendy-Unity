using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wendy
{
    [System.Serializable]
    public class RewardSetGroup
    {
        public int RewardSetGroupID;
        public string Description;
        public List<RewardSet> SetInfo;
    }

    [System.Serializable]
    public class RewardSet
    {
        public int RewardSetUID;
        public float DropRatio;
        public int RewardGoodsGroupID;
        public int RewardSetGroupID;
    }
}
