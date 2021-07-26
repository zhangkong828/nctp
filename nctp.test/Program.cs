using System;

namespace nctp.test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("test trade");
            // investor, pwd, instrument, price for buy
            TestTrade tt = null;
            //string addr = "tcp://180.168.146.187:10130";
            //string qaddr = "tcp://180.168.146.187:10131";

            string addr = "tcp://218.202.237.33:10203";
            string qaddr = "tcp://218.202.237.33:10213";

            string broker = "9999";
            string investor = "128821";
            string pwd = "6024@oppzk";
            string inst = "rb2110";
            string app = "simnow_client_test";
            string code = "0000000000000000";
            string proc = "";
            double price_for_buy = 3900;

            //tt = new TestTrade(inst, price_for_buy)
            //{
            //    FrontAddr = addr,
            //    Broker = broker,
            //    Investor = investor,
            //    Password = pwd,
            //    AppID = app,
            //    AuthCode = code,
            //    ProductInfo = app,
            //};

            //tt.Run();
            //Console.WriteLine("Press any key to continue . . . ");
            //Console.ReadKey(true);
            //if (tt.IsLogin)
            //{
            //    //tt.ReqOrderInsert("rb2101", DirectionType.Buy, OffsetType.Open, 4000, 2, 100000);
            //    Console.WriteLine("login");
            //}
            //Console.WriteLine("Press any key to continue . . . ");
            //Console.ReadKey(true);



            //Console.WriteLine("test quote");
            //TestQuote tq = new TestQuote(inst)
            //{
            //    FrontAddr = qaddr,
            //    Broker = broker,
            //};
            //tq.Run();
            //Console.WriteLine("Press any key to continue . . . ");
            //Console.ReadKey(true);
            ////tt.Release();
            //tq.Release();



            var test2 = new Test2();
            test2.TradeFrontAddr = addr;
            test2.Broker = broker;
            test2.Investor = investor;
            test2.Password = pwd;
            test2.ProductInfo = proc;
            test2.AppID = app;
            test2.AuthCode = code;

            test2.Run();










            Console.ReadKey(true);
        }

        private static void Tq_OnRtnTick(object sender, TickEventArgs e)
        {
            Console.WriteLine(e.Tick);
        }


    }
}
