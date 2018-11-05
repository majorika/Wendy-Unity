using System.Collections.Generic;

namespace Wendy
{
    [System.Serializable]
    public class Response
    {
        public int result;
        public string message;

        public Error Error
        {
            get
            {
                return (Error)result;
            }
        }

        public bool IsSuccess
        {
            get
            {
                return result == 0;
            }
        }
    }

    public class ListResponse<T> : Response
    {
        public List<T> list;
    }

    public class TokenResponse : Response
    {
        public string token;
    }

    public class GameUserResponse : Response
    {
        public GameUser UserInfo;
    }

    public class RewardResponse : Response
    {
        public Reward reward;
    }
    public class DefineCurrencyResponse : ListResponse<DefineCurrency> { }

    public class OwnCurrencyResponse : ListResponse<OwnCurrency> { }

    public class DefineItemResponse : ListResponse<DefineItem> { }

    public class OwnItemResponse : ListResponse<OwnItem> { }

    public class DefineReinforceItemResponse : ListResponse<DefineReinforceItem> { }

    public class DefineUpgradeItemResponse : ListResponse<DefineUpgradeItem> { }

    public class RewardSetGroupResponse : ListResponse<RewardSetGroup> { }

    public class RewardGoodsGroupResponse : ListResponse<RewardGoodsGroup> { }
}