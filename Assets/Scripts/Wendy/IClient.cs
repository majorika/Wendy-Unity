using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wendy
{
    public interface IClient
    {
        void GetToken(string UUID, System.Action<Response<string>> callback = null);

        void RegisterDevice(string UUID, DeviceType deviceType, System.Action<Response<bool>> callback = null);

        void RegisterUser(string UUID, string nickname, string locale, int offsetTime, System.Action<Response<bool>> callback = null);

        void GetGameUser(System.Action<Response<GameUser>> callback = null);

        void GetDefineCurrency(System.Action<Response<List<DefineCurrency>>> callback = null);

        void GetOwnCurrency(System.Action<Response<List<OwnCurrency>>> callback = null);

        void GetDefineItem(System.Action<Response<List<DefineItem>>> callback = null);

        void GetOwnItem(System.Action<Response<List<OwnItem>>> callback = null);

        void GetDefineReinforceItem(System.Action<Response<DefineReinforceItem>> callback = null);

        void GetDefineUpgradeItem(System.Action<Response<DefineUpgradeItem>> callback = null);

        void ReinforceItem(OwnItem ownItem, List<string> listMaterialUID, List<string> listCurrencyUID, System.Action<Response<bool>> callback = null);

        void UpgradeItem(OwnItem ownItem, List<string> listMaterialUID, List<string> listCurrencyUID, System.Action<Response<bool>> callback = null);
    }
}
