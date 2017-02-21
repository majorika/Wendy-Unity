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

        NotInOwnItemList = 80501,
        MaterialDoesNotExistOwnItemList = 80502,
        NotEnoughItem = 80503,
        CantReinforceItem = 80511,
        DidntRegisterReinfoceRequireItem = 80512,
        NoLongerReinforce = 80513,
        CantUpgradeItem = 80521,
        DidntRegisterUpgradeRequireItem = 80522,
        NoLongerUpgrade = 80523,
    }

}
