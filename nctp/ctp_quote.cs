using System;
using System.IO;
using System.Runtime.InteropServices;
using System.IO.Compression;

namespace nctp
{
    public class ctp_quote
    {
        private readonly AssembyLoader loader;
        IntPtr _api = IntPtr.Zero, _spi = IntPtr.Zero;
        private int nRequestID = 0;
        delegate IntPtr Create();
        private delegate IntPtr DelegateRegisterSpi(IntPtr api, IntPtr pSpi);

        public ctp_quote()
        {
            loader = new AssembyLoader("ctp_quote");
            Directory.CreateDirectory("log");

            _api = ((Create)loader.Invoke("CreateApi", typeof(Create)))();
            _spi = ((Create)loader.Invoke("CreateSpi", typeof(Create)))();
            (loader.Invoke("RegisterSpi", typeof(DelegateRegisterSpi)) as DelegateRegisterSpi)?.Invoke(_api, _spi);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleRelease(IntPtr api);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleInit(IntPtr api);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleJoin(IntPtr api);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleRegisterFront(IntPtr api, string pszFrontAddress);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleRegisterNameServer(IntPtr api, string pszNsAddress);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleRegisterFensUserInfo(IntPtr api, ref CThostFtdcFensUserInfoField pFensUserInfo);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleRegisterSpi(IntPtr api, IntPtr pSpi);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleSubscribeMarketData(IntPtr api, IntPtr ppInstrumentID, int nCount);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleUnSubscribeMarketData(IntPtr api, IntPtr ppInstrumentID, int nCount);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleSubscribeForQuoteRsp(IntPtr api, IntPtr ppInstrumentID, int nCount);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleUnSubscribeForQuoteRsp(IntPtr api, IntPtr ppInstrumentID, int nCount);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleReqUserLogin(IntPtr api, ref CThostFtdcReqUserLoginField pReqUserLoginField, int nRequestID);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleReqUserLogout(IntPtr api, ref CThostFtdcUserLogoutField pUserLogout, int nRequestID);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleReqQryMulticastInstrument(IntPtr api, ref CThostFtdcQryMulticastInstrumentField pQryMulticastInstrument, int nRequestID);

        /// <summary>
        /// 删除接口对象本身
        /// <para>不再使用本接口对象时,调用该函数删除接口对象</para>
        /// </summary>
        /// <returns></returns>
        public IntPtr Release()
        {
            return (loader.Invoke("Release", typeof(DeleRelease)) as DeleRelease)(_api);
        }

        /// <summary>
        /// 初始化
        /// <para>初始化运行环境,只有调用后,接口才开始工作</para>
        /// </summary>
        /// <returns></returns>
        public IntPtr Init()
        {
            return (loader.Invoke("Init", typeof(DeleInit)) as DeleInit)(_api);
        }

        /// <summary>
        /// 等待接口线程结束运行
        /// <para>线程退出代码</para>
        /// </summary>
        /// <returns></returns>
        public IntPtr Join()
        {
            return (loader.Invoke("Join", typeof(DeleJoin)) as DeleJoin)(_api);
        }

        /// <summary>
        /// 注册前置机网络地址
        /// </summary>
        /// <param name="pszFrontAddress">前置机网络地址，格式：protocol://ipaddress:port</param>
        /// <returns></returns>
        public IntPtr RegisterFront(string pszFrontAddress)
        {
            return (loader.Invoke("RegisterFront", typeof(DeleRegisterFront)) as DeleRegisterFront)(_api, pszFrontAddress);
        }

        /// <summary>
        /// 注册名字服务器网络地址
        /// <para>RegisterNameServer优先于RegisterFront</para>
        /// </summary>
        /// <param name="pszNsAddress">名字服务器网络地址</param>
        /// <returns></returns>
        public IntPtr RegisterNameServer(string pszNsAddress)
        {
            return (loader.Invoke("RegisterNameServer", typeof(DeleRegisterNameServer)) as DeleRegisterNameServer)(_api, pszNsAddress);
        }

        /// <summary>
        /// 注册名字服务器用户信息
        /// </summary>
        /// <param name="BrokerID"></param>
        /// <param name="UserID"></param>
        /// <param name="LoginMode"></param>
        /// <returns></returns>
        public IntPtr RegisterFensUserInfo(string BrokerID = "", string UserID = "", TThostFtdcLoginModeType LoginMode = TThostFtdcLoginModeType.THOST_FTDC_LM_Trade)
        {
            CThostFtdcFensUserInfoField pFensUserInfo = new CThostFtdcFensUserInfoField
            {
                BrokerID = BrokerID,
                UserID = UserID,
                LoginMode = LoginMode,
            };
            return (loader.Invoke("RegisterFensUserInfo", typeof(DeleRegisterFensUserInfo)) as DeleRegisterFensUserInfo)(_api, ref pFensUserInfo);
        }

        /// <summary>
        /// 注册回调接口
        /// </summary>
        /// <param name="pSpi"></param>
        /// <returns></returns>
        public IntPtr RegisterSpi(IntPtr pSpi)
        {
            return (loader.Invoke("RegisterSpi", typeof(DeleRegisterSpi)) as DeleRegisterSpi)(_api, pSpi);
        }

        /// <summary>
        /// 订阅行情
        /// </summary>
        /// <param name="ppInstrumentID">合约ID</param>
        /// <param name="nCount">要订阅行情的合约个数</param>
        /// <returns></returns>
        public IntPtr SubscribeMarketData(IntPtr ppInstrumentID, int nCount = 1)
        {
            return (loader.Invoke("SubscribeMarketData", typeof(DeleSubscribeMarketData)) as DeleSubscribeMarketData)(_api, ppInstrumentID, nCount);
        }

        /// <summary>
        /// 退订行情
        /// </summary>
        /// <param name="ppInstrumentID">合约ID</param>
        /// <param name="nCount">要退订行情的合约个数</param>
        /// <returns></returns>
        public IntPtr UnSubscribeMarketData(IntPtr ppInstrumentID, int nCount = 1)
        {
            return (loader.Invoke("UnSubscribeMarketData", typeof(DeleUnSubscribeMarketData)) as DeleUnSubscribeMarketData)(_api, ppInstrumentID, nCount);
        }

        /// <summary>
        /// 订阅询价
        /// </summary>
        /// <param name="ppInstrumentID">合约ID</param>
        /// <param name="nCount">合约个数</param>
        /// <returns></returns>
        public IntPtr SubscribeForQuoteRsp(IntPtr ppInstrumentID, int nCount = 1)
        {

            return (loader.Invoke("SubscribeForQuoteRsp", typeof(DeleSubscribeForQuoteRsp)) as DeleSubscribeForQuoteRsp)(_api, ppInstrumentID, nCount);
        }

        /// <summary>
        /// 退订询价
        /// </summary>
        /// <param name="ppInstrumentID">合约ID</param>
        /// <param name="nCount">合约个数</param>
        /// <returns></returns>
        public IntPtr UnSubscribeForQuoteRsp(IntPtr ppInstrumentID, int nCount = 1)
        {

            return (loader.Invoke("UnSubscribeForQuoteRsp", typeof(DeleUnSubscribeForQuoteRsp)) as DeleUnSubscribeForQuoteRsp)(_api, ppInstrumentID, nCount);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="TradingDay"></param>
        /// <param name="BrokerID"></param>
        /// <param name="UserID"></param>
        /// <param name="Password"></param>
        /// <param name="UserProductInfo"></param>
        /// <param name="InterfaceProductInfo"></param>
        /// <param name="ProtocolInfo"></param>
        /// <param name="MacAddress"></param>
        /// <param name="OneTimePassword"></param>
        /// <param name="reserve1"></param>
        /// <param name="LoginRemark"></param>
        /// <param name="ClientIPPort"></param>
        /// <param name="ClientIPAddress"></param>
        /// <returns></returns>
        public IntPtr ReqUserLogin(string TradingDay = "", string BrokerID = "", string UserID = "", string Password = "", string UserProductInfo = "", string InterfaceProductInfo = "", string ProtocolInfo = "", string MacAddress = "", string OneTimePassword = "", string reserve1 = "", string LoginRemark = "", int ClientIPPort = 0, string ClientIPAddress = "")
        {
            CThostFtdcReqUserLoginField pReqUserLoginField = new CThostFtdcReqUserLoginField
            {
                TradingDay = TradingDay,
                BrokerID = BrokerID,
                UserID = UserID,
                Password = Password,
                UserProductInfo = UserProductInfo,
                InterfaceProductInfo = InterfaceProductInfo,
                ProtocolInfo = ProtocolInfo,
                MacAddress = MacAddress,
                OneTimePassword = OneTimePassword,
                reserve1 = reserve1,
                LoginRemark = LoginRemark,
                ClientIPPort = ClientIPPort,
                ClientIPAddress = ClientIPAddress,
            };
            return (loader.Invoke("ReqUserLogin", typeof(DeleReqUserLogin)) as DeleReqUserLogin)(_api, ref pReqUserLoginField, this.nRequestID++);
        }

        /// <summary>
        /// 用户登出
        /// </summary>
        /// <param name="BrokerID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public IntPtr ReqUserLogout(string BrokerID = "", string UserID = "")
        {
            CThostFtdcUserLogoutField pUserLogout = new CThostFtdcUserLogoutField
            {
                BrokerID = BrokerID,
                UserID = UserID,
            };
            return (loader.Invoke("ReqUserLogout", typeof(DeleReqUserLogout)) as DeleReqUserLogout)(_api, ref pUserLogout, this.nRequestID++);
        }

        /// <summary>
        /// 请求查询组播合约
        /// </summary>
        /// <param name="TopicID"></param>
        /// <param name="reserve1"></param>
        /// <param name="InstrumentID"></param>
        /// <returns></returns>
        public IntPtr ReqQryMulticastInstrument(int TopicID = 0, string reserve1 = "", string InstrumentID = "")
        {
            CThostFtdcQryMulticastInstrumentField pQryMulticastInstrument = new CThostFtdcQryMulticastInstrumentField
            {
                TopicID = TopicID,
                reserve1 = reserve1,
                InstrumentID = InstrumentID,
            };
            return (loader.Invoke("ReqQryMulticastInstrument", typeof(DeleReqQryMulticastInstrument)) as DeleReqQryMulticastInstrument)(_api, ref pQryMulticastInstrument, this.nRequestID++);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        delegate void DeleSet(IntPtr spi, Delegate func);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnFrontConnected();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnFrontDisconnected(int nReason);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnHeartBeatWarning(int nTimeLapse);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRspUserLogin(ref CThostFtdcRspUserLoginField pRspUserLogin, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRspUserLogout(ref CThostFtdcUserLogoutField pUserLogout, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRspQryMulticastInstrument(ref CThostFtdcMulticastInstrumentField pMulticastInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRspError(ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRspSubMarketData(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRspUnSubMarketData(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRspSubForQuoteRsp(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRspUnSubForQuoteRsp(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRtnDepthMarketData(ref CThostFtdcDepthMarketDataField pDepthMarketData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRtnForQuoteRsp(ref CThostFtdcForQuoteRspField pForQuoteRsp);

        /// <summary>
        /// 当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用
        /// </summary>
        /// <param name="func"></param>
        public void SetOnFrontConnected(DeleOnFrontConnected func) { (loader.Invoke("SetOnFrontConnected", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理
        /// </summary>
        /// <param name="func"></param>
        public void SetOnFrontDisconnected(DeleOnFrontDisconnected func) { (loader.Invoke("SetOnFrontDisconnected", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 心跳超时警告。当长时间未收到报文时，该方法被调用
        /// </summary>
        /// <param name="func"></param>
        public void SetOnHeartBeatWarning(DeleOnHeartBeatWarning func) { (loader.Invoke("SetOnHeartBeatWarning", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 登录请求响应
        /// </summary>
        /// <param name="func"></param>
        public void SetOnRspUserLogin(DeleOnRspUserLogin func) { (loader.Invoke("SetOnRspUserLogin", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 登出请求响应
        /// </summary>
        /// <param name="func"></param>
        public void SetOnRspUserLogout(DeleOnRspUserLogout func) { (loader.Invoke("SetOnRspUserLogout", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 请求查询组播合约响应
        /// </summary>
        /// <param name="func"></param>
        public void SetOnRspQryMulticastInstrument(DeleOnRspQryMulticastInstrument func) { (loader.Invoke("SetOnRspQryMulticastInstrument", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 错误应答
        /// </summary>
        /// <param name="func"></param>
        public void SetOnRspError(DeleOnRspError func) { (loader.Invoke("SetOnRspError", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 订阅行情应答
        /// </summary>
        /// <param name="func"></param>
        public void SetOnRspSubMarketData(DeleOnRspSubMarketData func) { (loader.Invoke("SetOnRspSubMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 取消订阅行情应答
        /// </summary>
        /// <param name="func"></param>
        public void SetOnRspUnSubMarketData(DeleOnRspUnSubMarketData func) { (loader.Invoke("SetOnRspUnSubMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 订阅询价应答
        /// </summary>
        /// <param name="func"></param>
        public void SetOnRspSubForQuoteRsp(DeleOnRspSubForQuoteRsp func) { (loader.Invoke("SetOnRspSubForQuoteRsp", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 取消订阅询价应答
        /// </summary>
        /// <param name="func"></param>
        public void SetOnRspUnSubForQuoteRsp(DeleOnRspUnSubForQuoteRsp func) { (loader.Invoke("SetOnRspUnSubForQuoteRsp", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 深度行情通知
        /// </summary>
        /// <param name="func"></param>
        public void SetOnRtnDepthMarketData(DeleOnRtnDepthMarketData func) { (loader.Invoke("SetOnRtnDepthMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }
        /// <summary>
        /// 询价通知
        /// </summary>
        /// <param name="func"></param>
        public void SetOnRtnForQuoteRsp(DeleOnRtnForQuoteRsp func) { (loader.Invoke("SetOnRtnForQuoteRsp", typeof(DeleSet)) as DeleSet)(_spi, func); }
    }
}