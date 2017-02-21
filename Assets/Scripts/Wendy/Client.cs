using System.Collections;
using UnityEngine;
using UnityHTTP;

namespace Wendy
{
    public class Client
    {
        private string _sURL = string.Empty;
        private string _token = string.Empty;

        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(_token) == false;
            }
        }

        public Client(string sURL)
        {
            _sURL = sURL;
        }

        public void GetToken(string UUID, System.Action<Response> callback = null)
        {
            if (string.IsNullOrEmpty(UUID))
            {
                Debug.LogWarning(string.Format("UUID is null"));
                return;
            }

            Request req = new Request("GET", string.Format("{0}/device/token/{1}", _sURL, UUID));
            req.Send(res =>
            {
                var response = JsonUtility.FromJson<TokenResponse>(res.response.Text);

                if (response.IsSuccess)
                {
                    _token = response.token;
                }

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void RegisterDevice(string UUID, DeviceType deviceType, System.Action<Response> callback = null)
        {
            Hashtable param = new Hashtable();
            param.Add("UUID", UUID);
            param.Add("DeviceType", (int)deviceType);

            Request request = new Request("POST", string.Format("{0}/device", _sURL), param);
            request.Send(res =>
            {
                var response = JsonUtility.FromJson<Response>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void RegisterUser(string UUID, string nickname, string locale, int offsetTime, System.Action<Response> callback = null)
        {
            Hashtable param = new Hashtable();
            param.Add("NickName", nickname);
            param.Add("Locale", locale);
            param.Add("UUID", UUID);
            param.Add("OffsetTime", offsetTime);

            Request request = new Request("POST", string.Format("{0}/user", _sURL), param);
            request.Send(res =>
            {
                var response = JsonUtility.FromJson<TokenResponse>(res.response.Text);

                if (response.IsSuccess)
                {
                    _token = response.token;
                }

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetGameUser(System.Action<GameUserResponse> callback = null)
        {
            Request request = new Request("GET", string.Format("{0}/user", _sURL));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<GameUserResponse>(res.response.Text);
                
                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetDefineCurrency(System.Action<DefineCurrencyResponse> callback = null)
        {
            Request request = new Request("GET", string.Format("{0}/currency/define", _sURL));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<DefineCurrencyResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetOwnCurrency(System.Action<OwnCurrencyResponse> callback = null)
        {
            Request request = new Request("GET", string.Format("{0}/currency/own", _sURL));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<OwnCurrencyResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetDefineItem(System.Action<DefineItemResponse> callback = null)
        {
            Request request = new Request("GET", string.Format("{0}/item/define", _sURL));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                Debug.Log(res.response.Text);

                var response = JsonUtility.FromJson<DefineItemResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetOwnItem(System.Action<OwnItemResponse> callback = null)
        {
            Request request = new Request("GET", string.Format("{0}/item/own", _sURL));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                Debug.Log(res.response.Text);

                var response = JsonUtility.FromJson<OwnItemResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetDefineReinforceItem(System.Action<DefineReinforceItemResponse> callback = null)
        {
            Request request = new Request("GET", string.Format("{0}/item/define/reinforce", _sURL));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                Debug.Log(res.response.Text);

                var response = JsonUtility.FromJson<DefineReinforceItemResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetDefineUpgradeItem(System.Action<DefineUpgradeItemResponse> callback = null)
        {
            Request request = new Request("GET", string.Format("{0}/item/define/upgrade", _sURL));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                Debug.Log(res.response.Text);

                var response = JsonUtility.FromJson<DefineUpgradeItemResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        //public void ReinforceItem(OwnItem ownItem, List<string> listMaterialUID, List<string> listCurrencyUID, System.Action<Response<bool>> callback = null)
        //{
        //}


        //public void UpgradeItem(OwnItem ownItem, List<string> listMaterialUID, List<string> listCurrencyUID, System.Action<Response<bool>> callback = null)
        //{

        //}
    }
}
