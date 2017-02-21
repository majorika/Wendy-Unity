using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wendy
{
    public class DefineCurrency
    {
        public int CurrencyID;
        public string Name;
        public int MaxQnty;
        public RechargeInfo RechargeInfo;
    }

    public class RechargeInfo
    {
        public int Interval;
        public int IntervalChargeAmount;
        public bool SetMaxSwitch;
        public string SetMaxPattern;
    }
}
