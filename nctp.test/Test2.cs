using System;
using System.Collections.Generic;
using System.Text;

namespace nctp.test
{

    public class TradeExt : CTPTrade
    {
        public TradeExt()
        {
        }
    }

    public class Test2
    {
        public string TradeFrontAddr { get; set; }
        public string Broker { get; set; }
        public string Investor { get; set; }
        public string Password { get; set; }
        public string ProductInfo { get; set; }
        public string AppID { get; set; }
        public string AuthCode { get; set; }
        private TradeExt _t;

        public void Run()
        {
            _t = new TradeExt()
            {
                FrontAddr = TradeFrontAddr,
                Broker = Broker,
                Investor = Investor,
                Password = Password,
                ProductInfo = ProductInfo,
                AppID = AppID,
                AuthCode = AuthCode,
            };
            _t.OnFrontConnected += _t_OnFrontConnected;
            _t.OnRspUserLogin += _t_OnRspUserLogin;
            _t.ReqConnect();
        }

        private void _t_OnRspUserLogin(object sender, ErrorEventArgs e)
        {
            if (e.ErrorID == 0)
            {
                Console.WriteLine("t:user login success");
            }
            else
            {
                Console.WriteLine($"t:user login fail {e.ErrorID}={e.ErrorMsg}");
            }
        }

        private void _t_OnFrontConnected(object sender, EventArgs e)
        {
            Console.WriteLine("t:connected");
            _t.ReqUserLogin();
        }
    }
}
