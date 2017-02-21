using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wendy
{
    public class Response<T>
    {
        public bool IsSuccess
        {
            get
            {
                return ErrorCode == 200;
            }
        }

        public int ErrorCode;
        public Error Error;
        public T Data;
    }
}