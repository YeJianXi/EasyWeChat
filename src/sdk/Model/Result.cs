using System;
using System.Collections.Generic;
using System.Text;

namespace EasyWeChat.Model
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Msg { get; set; }

        public static Result Success(string msg ="OK")
        {
            return new Result()
            {
                IsSuccess = true,
                Msg = msg
            };
        
        }
        public static Result Fail(string msg)
        {
            return new Result()
            {
                IsSuccess = false,
                Msg = msg
            };

        }
    }
}
