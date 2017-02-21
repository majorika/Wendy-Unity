using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wendy
{
    public class Client : IClient
    {
        private string _sURL = string.Empty;
        private bool _bInitialized = false;

        public void SetServerURL(string sURL)
        {
            _sURL = sURL;
            _bInitialized = true;
        }

        public void GetToken(string UUID, System.Action<Response<string>> callback = null)
        {
            
        }

        public void RegisterDevice(string UUID, DeviceType deviceType, System.Action<Response<bool>> callback = null)
        {
            
        }

        public void RegisterUser(string UUID, string nickname, string locale, int offsetTime, System.Action<Response<bool>> callback = null)
        {
            
        }

        public void GetGameUser(System.Action<Response<GameUser>> callback = null)
        {
            
        }

        public void GetDefineCurrency(System.Action<Response<List<DefineCurrency>>> callback = null)
        {
            
        }

        public void GetOwnCurrency(System.Action<Response<List<OwnCurrency>>> callback = null)
        {
            
        }

        public void GetDefineItem(System.Action<Response<List<DefineItem>>> callback = null)
        {
            
        }

        public void GetOwnItem(System.Action<Response<List<OwnItem>>> callback = null)
        {
            
        }

        public void GetDefineReinforceItem(System.Action<Response<DefineReinforceItem>> callback = null)
        {
            
        }

        public void GetDefineUpgradeItem(System.Action<Response<DefineUpgradeItem>> callback = null)
        {
            
        }

        public void ReinforceItem(OwnItem ownItem, List<string> listMaterialUID, List<string> listCurrencyUID, System.Action<Response<bool>> callback = null)
        {
        }


        public void UpgradeItem(OwnItem ownItem, List<string> listMaterialUID, List<string> listCurrencyUID, System.Action<Response<bool>> callback = null)
        {
            
        }
    }
}
