using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wendy
{
    [System.Serializable]
    public class DefineCurrency
    {
        public int CurrencyID;
        public string Name;
        public int MaxQNTY;
        public RechargeInfo RechargeInfo;
    }

    [System.Serializable]
    public class RechargeInfo
    {
        public int RechargeCurrencyID;
        public int IntervalTime;
        public int IntervalChargeAmount;
        public bool SetMaxSwitch;
        public string SetMaxPattern;
    }
}
