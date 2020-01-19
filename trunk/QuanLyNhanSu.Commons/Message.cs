using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Commons
{
    public class Message
    {
        public string _strMsg { get; set; }
        public MessageType _msgType { get; set; }
        public string _strDescription { get; set; }
        public Message(MessageType msgType)
        {
            _msgType = msgType;
        }
        public Message()
        {
            _strMsg = "";
            _msgType = MessageType.Success;
            _strDescription = "";
        }
        public Message(string strMsg,MessageType msgType,string strDescription)
        {
            _strMsg = strMsg;_msgType = msgType;_strDescription = strDescription;
        }
    }
    public enum MessageType
    {
         Error,
         Success,
         Warning
    }
    public enum API_CODE
    {
        THANHCONG = 1,
        DEFAULT = 10,
        EXCEPTION = -1
    }
    public class APIResult
    {
        public string code { get; set; }
        public Object data { get; set; }
        public Object datadetail { get; set; }
        public string message { get; set; }
        public string description { get; set; }
        public string error_code { get; set; }
        public APIResult()
        {
            description = "";
            error_code = Commons.API_CODE.DEFAULT.GetHashCode().ToString();
        }
        public APIResult(HttpStatusCode status, string _data = "")
        {
            code = status.GetHashCode().ToString();
            data = _data;
            message = status.ToString();
            description = "";
            if (status == HttpStatusCode.ExpectationFailed)
                error_code = Commons.API_CODE.EXCEPTION.GetHashCode().ToString();
            else
                error_code = Commons.API_CODE.DEFAULT.GetHashCode().ToString();
        }
    }
}
