using UnityEngine;
using Wendy;

public class LoginScene : MonoBehaviour
{
    private Client _client = null;

	void Start ()
    {
		if (_client == null)
        {
            _client = new Wendy.Client("http://localhost:3000");
        }

        StartCoroutine(_client.GetToken(SystemInfo.deviceUniqueIdentifier, resToken =>
        {
            if (resToken.IsSuccess)
            {
                StartCoroutine(_client.GetGameUser(resGameUser =>
                {
                    var gameUser = resGameUser.UserInfo;
                    Debug.Log(JsonUtility.ToJson(gameUser));
                }));

                StartCoroutine(_client.GetDefineCurrency(res => { }));
                StartCoroutine(_client.GetDefineItem(res => { }));
                StartCoroutine(_client.GetRewardGoodsGroups(res => { }));
                StartCoroutine(_client.GetRewardSetGroup(res => { }));

                StartCoroutine(_client.GetOwnCurrency(res => { }));
                StartCoroutine(_client.GetOwnItem(res => { }));

                return;
            }

            switch (resToken.Error)
            {
                case Error.UnregisteredDevice:
                    StartCoroutine(_client.RegisterDevice(SystemInfo.deviceUniqueIdentifier, Wendy.DeviceType.UnityEditor, res => { }));
                    break;

                case Error.CreateID:
                    StartCoroutine(_client.RegisterUser(SystemInfo.deviceUniqueIdentifier, "majorika-pc", "ko_kr", 9, res => { }));
                    break;
            }
        }));
	}
}
