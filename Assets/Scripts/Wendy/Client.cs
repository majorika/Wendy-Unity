using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Wendy
{
    public class Client
    {
        readonly string _url;
        string _token = string.Empty;

        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(_token) == false;
            }
        }

        public Client(string url)
        {
            _url = url;
        }

        public IEnumerator GetToken(string uuid, System.Action<Response> callback = null)
        {
            using (var req = UnityWebRequest.Get($"{_url}/device/token/{uuid}"))
            {
                req.chunkedTransfer = false;
                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<TokenResponse>(req.downloadHandler.text);
                if (response.IsSuccess)
                {
                    _token = response.token;
                }

                callback?.Invoke(response);
            }
        }

        public IEnumerator RegisterDevice(string uuid, DeviceType deviceType, System.Action<Response> callback = null)
        {
            var param = new WWWForm();
            param.AddField("UUID", uuid);
            param.AddField("DeviceType", (int)deviceType);

            using (var req = UnityWebRequest.Post($"{_url}/device", param))
            {
                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<Response>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator RegisterUser(string uuid, string nickname, string locale, int offsetTime, System.Action<Response> callback = null)
        {
            var param = new WWWForm();
            param.AddField("NickName", nickname);
            param.AddField("Locale", locale);
            param.AddField("UUID", uuid);
            param.AddField("OffsetTime", offsetTime);

            using (var req = UnityWebRequest.Post($"{_url}/user", param))
            {
                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<TokenResponse>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator GetGameUser(System.Action<GameUserResponse> callback = null)
        {
            using (var req = UnityWebRequest.Get($"{_url}/user"))
            {
                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<GameUserResponse>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator GetDefineCurrency(System.Action<DefineCurrencyResponse> callback = null)
        {
            using (var req = UnityWebRequest.Get($"{_url}/currency/define"))
            {
                req.SetRequestHeader("Authorization", _token);

                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<DefineCurrencyResponse>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator GetOwnCurrency(System.Action<OwnCurrencyResponse> callback = null)
        {
            using (var req = UnityWebRequest.Get($"{_url}/currency/own"))
            {
                req.SetRequestHeader("Authorization", _token);

                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<OwnCurrencyResponse>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator GetDefineItem(System.Action<DefineItemResponse> callback = null)
        {
            using (var req = UnityWebRequest.Get($"{_url}/item/define"))
            {
                req.SetRequestHeader("Authorization", _token);

                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<DefineItemResponse>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator GetOwnItem(System.Action<OwnItemResponse> callback = null)
        {
            using (var req = UnityWebRequest.Get($"{_url}/item/own"))
            {
                req.SetRequestHeader("Authorization", _token);

                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<OwnItemResponse>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator GetDefineReinforceItem(System.Action<DefineReinforceItemResponse> callback = null)
        {
            using (var req = UnityWebRequest.Get($"{_url}/item/define/reinforce"))
            {
                req.SetRequestHeader("Authorization", _token);

                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<DefineReinforceItemResponse>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator GetDefineUpgradeItem(System.Action<DefineUpgradeItemResponse> callback = null)
        {
            using (var req = UnityWebRequest.Get($"{_url}/item/define/upgrade"))
            {
                req.SetRequestHeader("Authorization", _token);

                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<DefineUpgradeItemResponse>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator ReinforceItem(OwnItem ownItem, List<string> listMaterialUid, List<string> listCurrencyUid, System.Action<Response> callback = null)
        {
            var param = new WWWForm();
            foreach (var item in listMaterialUid)
            {
                param.AddField("materialItemUID[]", item);
            }
            foreach (var item in listCurrencyUid)
            {
                param.AddField("CurrencyUID[]", item);
            }

            using (var req = UnityWebRequest.Post($"{_url}/item/reinforce/{ownItem.OwnItemUID}", param))
            {
                req.SetRequestHeader("Authorization", _token);

                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<Response>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator UpgradeItem(OwnItem ownItem, List<string> listMaterialUid, List<string> listCurrencyUid, System.Action<Response> callback = null)
        {
            var param = new WWWForm();
            foreach (var item in listMaterialUid)
            {
                param.AddField("materialItemUID[]", item);
            }
            foreach (var item in listCurrencyUid)
            {
                param.AddField("CurrencyUID[]", item);
            }

            using (var req = UnityWebRequest.Post($"{_url}/item/upgrade/{ownItem.OwnItemUID}", param))
            {
                req.SetRequestHeader("Authorization", _token);

                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<Response>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator UseCoupon(string couponName, System.Action<RewardResponse> callback = null)
        {
            using (var req = UnityWebRequest.Post($"{_url}/coupon/use/{couponName}", new WWWForm()))
            {
                req.SetRequestHeader("Authorization", _token);

                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<RewardResponse>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator GetRewardSetGroup(System.Action<RewardSetGroupResponse> callback = null)
        {
            using (var req = UnityWebRequest.Get($"{_url}/reward/set"))
            {
                req.SetRequestHeader("Authorization", _token);

                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<RewardSetGroupResponse>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }

        public IEnumerator GetRewardGoodsGroups(System.Action<RewardGoodsGroupResponse> callback = null)
        {
            using (var req = UnityWebRequest.Get($"{_url}/reward/goods"))
            {
                req.SetRequestHeader("Authorization", _token);

                yield return req.SendWebRequest();

                if (req.isNetworkError)
                {
                    Debug.LogError($"error: {req.error}");
                    yield break;
                }

                var response = JsonUtility.FromJson<RewardGoodsGroupResponse>(req.downloadHandler.text);
                callback?.Invoke(response);
            }
        }
    }
}
