using UnityEngine;
using System.Collections;
using Restifizer;
using System;
using Wendy;

public class Sample : MonoBehaviour
{
    void Start()
    {
        GetToken(SystemInfo.deviceUniqueIdentifier, (resGetToken) =>
            {
                if (resGetToken.HasError)
                {
                    Error error = GetError(resGetToken.Error);

                    if (error == Error.UnregisteredDevice)
                    {
                        Debug.Log("Unregistered device, so attemp to register this deivce.");

                        RegisterDevice(SystemInfo.deviceUniqueIdentifier, Wendy.DeviceType.UnityEditor, (resRegisterDevice) =>
                            {
                                if (resRegisterDevice.HasError)
                                {
                                    Debug.Log(HashtableToString(resRegisterDevice.Error.ErrorRaw));
                                }
                                else
                                {
                                    Debug.Log("Register device success, register user.");

                                    RegisterUser(SystemInfo.deviceUniqueIdentifier, "TestNickName", "kr-KO", 9, (resRegisterUser) =>
                                        {
                                            if (resRegisterUser.HasError)
                                            {
                                                Debug.Log(HashtableToString(resRegisterUser.Error.ErrorRaw));
                                            }
                                            else
                                            {
                                                Debug.Log(HashtableToString(resRegisterUser.Resource));
                                            }
                                        });
                                }
                            });
                    }
                    else if (error == Error.CreateID)
                    {
                        Debug.Log("device registered, register user.");

                        RegisterUser(SystemInfo.deviceUniqueIdentifier, "majorika", "kr-KO", 9, (resRegisterUser) =>
                            {
                                if (resRegisterUser.HasError)
                                {
                                    Debug.Log(HashtableToString(resRegisterUser.Error.ErrorRaw));
                                }
                                else
                                {
                                    Debug.Log(HashtableToString(resRegisterUser.Resource));

                                    if (resRegisterUser.Resource.ContainsKey("token"))
                                    {
                                        RestifizerManager.Instance.ConfigJWTToken(resRegisterUser.Resource["token"].ToString());
                                    }
                                }
                            });
                    }
                }
                else
                {
                    Debug.Log(HashtableToString(resGetToken.Resource));

                    if (resGetToken.Resource.ContainsKey("token"))
                    {
                        RestifizerManager.Instance.ConfigJWTToken(resGetToken.Resource["token"].ToString());

                        GetDefinedCurrency((resDefinedCurrency) =>
                            {
                                if (resDefinedCurrency.HasError)
                                {
                                    Debug.LogError(HashtableToString(resDefinedCurrency.Error.ErrorRaw));
                                }
                                else
                                {
                                    if (resDefinedCurrency.IsList)
                                    {
                                        Debug.Log(ListToString(resDefinedCurrency.ResourceList));
                                    }
                                    else
                                    {
                                        Debug.Log(HashtableToString(resDefinedCurrency.Resource));
                                    }

                                    GetOwnedCurrency((resOwnedCurrency) =>
                                        {
                                            if (resOwnedCurrency.HasError)
                                            {
                                                Debug.LogError(HashtableToString(resOwnedCurrency.Error.ErrorRaw));
                                            }
                                            else
                                            {
                                                if (resOwnedCurrency.IsList)
                                                {
                                                    Debug.Log(ListToString(resOwnedCurrency.ResourceList));
                                                }
                                                else
                                                {
                                                    Debug.Log(HashtableToString(resOwnedCurrency.Resource));
                                                }
                                            }
                                        });
                                }
                            });
                    }
                }
            });
    }

    private void GetToken(string UUID, Action<RestifizerResponse> callback = null)
    {
        RestifizerManager.Instance.ResourceAt("device/token").One(UUID).Get(callback);
    }

    private void RegisterDevice(string UUID, Wendy.DeviceType deviceType, Action<RestifizerResponse> callback = null)
    {
        Hashtable param = new Hashtable();
        param.Add("UUID", UUID);
        param.Add("DeviceType", (int)deviceType);

        RestifizerManager.Instance.ResourceAt("device").Post(param, callback);
    }

    private void RegisterUser(string UUID, string nickname, string locale, int offsetTime, Action<RestifizerResponse> callback = null)
    {
        Hashtable param = new Hashtable();
        param.Add("UUID", UUID);
        param.Add("NickName", nickname);
        param.Add("Locale", locale);
        param.Add("OffsetTime", offsetTime);

        RestifizerManager.Instance.ResourceAt("user").WithJWTAuth().Post(param, callback);
    }

    private void GetUser(Action<RestifizerResponse> callback = null)
    {
        RestifizerManager.Instance.ResourceAt("user").WithJWTAuth().Get(callback);
    }

    private void GetDefinedCurrency(Action<RestifizerResponse> callback = null)
    {
        RestifizerManager.Instance.ResourceAt("currency/define").WithJWTAuth().Get(callback);
    }

    private void GetOwnedCurrency(Action<RestifizerResponse> callback = null)
    {
        RestifizerManager.Instance.ResourceAt("currency/own").WithJWTAuth().Get(callback);
    }

    private Error GetError(RestifizerError error)
    {
        if (error.ErrorRaw.ContainsKey("result"))
        {
            return (Error)((int)error.ErrorRaw["result"]);
        }
       
        return Error.Unknown;
    }

    private string HashtableToString(Hashtable table)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        var enumerator = table.Keys.GetEnumerator();

        while (enumerator.MoveNext())
        {
            var key = enumerator.Current;

            sb.AppendLine(string.Format("{0}: {1}", key, table[key]));
        }

        return sb.ToString();
    }

    private string ListToString(ArrayList list)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        var enumerator = list.GetEnumerator();

        while (enumerator.MoveNext())
        {
            var item = (Hashtable)enumerator.Current;

            sb.AppendLine(HashtableToString(item));
        }

        return sb.ToString();
    }
}
