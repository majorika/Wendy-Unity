using UnityEngine;
using Wendy;

public class LoginScene : MonoBehaviour {
    private Client _client = null;

	void Start ()
    {
		if (_client == null)
        {
            _client = new Wendy.Client("http://192.168.0.33:3000");
        }

        _client.GetToken(SystemInfo.deviceUniqueIdentifier, resToken =>
        {
            if (resToken.IsSuccess)
            {
                _client.GetGameUser(resGameUser =>
                {
                    var gameUser = resGameUser.UserInfo;
                    Debug.Log(JsonUtility.ToJson(gameUser));
                });

                _client.GetDefineCurrency(res => { });
                _client.GetDefineItem(res => { });
                _client.GetRewardGoodsGroups(res => { });
                _client.GetRewardSetGroup(res => { });

                _client.GetOwnCurrency(res => { });
                _client.GetOwnItem(res => { });

                return;
            }
            
            switch (resToken.Error)
            {
                case Error.UnregisteredDevice:
                    _client.RegisterDevice(SystemInfo.deviceUniqueIdentifier, Wendy.DeviceType.UnityEditor, res => {});
                    break;

                case Error.CreateID:
                    _client.RegisterUser(SystemInfo.deviceUniqueIdentifier, "majorika-pc", "ko_kr", 9, res => {});
                    break;
            }
        });
	}
}
