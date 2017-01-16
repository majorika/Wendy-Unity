using UnityEngine;
using System.Collections;

namespace Wendy
{
    public enum Error
    {
        Unknown = 99999,

        DontHaveRequiredParams = 99101,
        CredentialFailure = 99102,

        UnregisteredDevice = 80101,
        UsedOnOtherDevice = 80103,
        CreateID = 80202,
        UsedNickName = 80203,
        NickNameToLongOrShot = 80204,
    }

}
