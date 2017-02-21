using UnityEngine;
using Wendy;

public class LoginScene : MonoBehaviour {
    Client _client = null;

	void Start ()
    {
		if (_client == null)
        {
            _client = new Wendy.Client("http://192.168.0.33:3000");
        }

        _client.GetToken(SystemInfo.deviceUniqueIdentifier, res =>
        {
            if (res.IsSuccess)
            {
                _client.GetGameUser(resGameUser =>
                {
                    var gameUser = resGameUser.UserInfo;
                    Debug.Log(JsonUtility.ToJson(gameUser));
                });

                _client.GetDefineCurrency(resDefineCurrency => { });

                _client.GetOwnCurrency(resOwnCurrency => { });

                return;
            }
            
            switch (res.Error)
            {
                case Error.UnregisteredDevice:
                    _client.RegisterDevice(SystemInfo.deviceUniqueIdentifier, Wendy.DeviceType.UnityEditor, resRegister => {});
                    break;

                case Error.CreateID:
                    _client.RegisterUser(SystemInfo.deviceUniqueIdentifier, "majorika-pc", "ko_kr", 9, resRegisterUser => {});
                    break;
            }
        });
	}
}
