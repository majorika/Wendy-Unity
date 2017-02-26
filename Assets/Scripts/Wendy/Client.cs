using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityHTTP;

namespace Wendy
{
    public class Client
    {
        private readonly string _sUrl;
        private string _token = string.Empty;

        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(_token) == false;
            }
        }

        public Client(string sUrl)
        {
            _sUrl = sUrl;
        }

        public void GetToken(string uuid, System.Action<Response> callback = null)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                Debug.LogWarning("UUID is null");
                return;
            }

            var req = new Request("GET", string.Format("{0}/device/token/{1}", _sUrl, uuid));
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

        public void RegisterDevice(string uuid, DeviceType deviceType, System.Action<Response> callback = null)
        {
            var param = new Hashtable()
            {
                { "UUID", uuid}, {"DeviceType", (int)deviceType }
            };

            var request = new Request("POST", string.Format("{0}/device", _sUrl), param);
            request.Send(res =>
            {
                var response = JsonUtility.FromJson<Response>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void RegisterUser(string uuid, string nickname, string locale, int offsetTime, System.Action<Response> callback = null)
        {
            var param = new Hashtable()
            {
                {"NickName", nickname }, {"Locale", locale }, {"UUID", uuid }, {"OffsetTime", offsetTime }
            };

            var request = new Request("POST", string.Format("{0}/user", _sUrl), param);
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
            var request = new Request("GET", string.Format("{0}/user", _sUrl));
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
            var request = new Request("GET", string.Format("{0}/currency/define", _sUrl));
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
            var request = new Request("GET", string.Format("{0}/currency/own", _sUrl));
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
            var request = new Request("GET", string.Format("{0}/item/define", _sUrl));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<DefineItemResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetOwnItem(System.Action<OwnItemResponse> callback = null)
        {
            var request = new Request("GET", string.Format("{0}/item/own", _sUrl));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<OwnItemResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetDefineReinforceItem(System.Action<DefineReinforceItemResponse> callback = null)
        {
            var request = new Request("GET", string.Format("{0}/item/define/reinforce", _sUrl));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<DefineReinforceItemResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetDefineUpgradeItem(System.Action<DefineUpgradeItemResponse> callback = null)
        {
            var request = new Request("GET", string.Format("{0}/item/define/upgrade", _sUrl));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<DefineUpgradeItemResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void ReinforceItem(OwnItem ownItem, List<string> listMaterialUid, List<string> listCurrencyUid, System.Action<Response> callback = null)
        {
            var param = new Hashtable()
            {
                {"materialItemUID", listMaterialUid }, {"CurrencyUID", listCurrencyUid }
            };

            var request = new Request("POST", string.Format("{0}/item/reinforce/{1}", _sUrl, ownItem.OwnItemUID), param);
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<Response>(res.response.Text);
                
                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void UpgradeItem(OwnItem ownItem, List<string> listMaterialUid, List<string> listCurrencyUid, System.Action<Response> callback = null)
        {
            var param = new Hashtable()
            {
                {"materialItemUID", listMaterialUid }, {"CurrencyUID", listCurrencyUid }
            };

            var request = new Request("POST", string.Format("{0}/item/upgrade/{1}", _sUrl, ownItem.OwnItemUID), param);
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<Response>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void UseCoupon(string couponName, System.Action<RewardResponse> callback = null)
        {
            var request = new Request("POST", string.Format("{0}/coupon/use/{1}", _sUrl, couponName));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<RewardResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetRewardSetGroup(System.Action<RewardSetGroupResponse> callback = null)
        {
            var request = new Request("GET", string.Format("{0}/reward/set", _sUrl));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<RewardSetGroupResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }

        public void GetRewardGoodsGroups(System.Action<RewardGoodsGroupResponse> callback = null)
        {
            var request = new Request("GET", string.Format("{0}/reward/goods", _sUrl));
            request.AddHeader("Authorization", _token);

            request.Send(res =>
            {
                var response = JsonUtility.FromJson<RewardGoodsGroupResponse>(res.response.Text);

                if (callback != null)
                {
                    callback(response);
                }
            });
        }
    }
}
