using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wendy
{
    [System.Serializable]
    public class RewardGoodsGroup
    {
        public int RewardGoodsGroupID;
        public string Description;
        public List<ReawrdGoods> GoodsInfo;
    }

    [System.Serializable]
    public class ReawrdGoods
    {
        public int RewardGoodsUID;
        public int AmountMin;
        public int AmountMax;
        public float DropRatio;
        public int ItemID;
        public int RewardGoodsGroupID;
    }
}