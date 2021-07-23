using System;
using System.IO;
using System.Runtime.InteropServices;
using System.IO.Compression;

namespace nctp
{
	public class ctp_trade
	{
		private readonly AssembyLoader loader;
		IntPtr  _api = IntPtr.Zero, _spi = IntPtr.Zero;
		private int nRequestID = 0;
		delegate IntPtr Create();
		private delegate IntPtr DelegateRegisterSpi(IntPtr api, IntPtr pSpi);

		public ctp_trade()
		{
			loader = new AssembyLoader("ctp_trade");
			Directory.CreateDirectory("log");

			_api = ((Create)loader.Invoke("CreateApi", typeof(Create)))();
			_spi = ((Create)loader.Invoke("CreateSpi", typeof(Create)))();
			(loader.Invoke("RegisterSpi", typeof(DelegateRegisterSpi)) as DelegateRegisterSpi)?.Invoke(_api, _spi);

		}

        #region SE版本增加
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleGetVersion();
        public string GetVersion()
        {
            return Marshal.PtrToStringAnsi((loader.Invoke( "GetVersion", typeof(DeleGetVersion)) as DeleGetVersion)());
        }
        #endregion
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
		public delegate IntPtr DeleSubscribePrivateTopic(IntPtr api, THOST_TE_RESUME_TYPE nResumeType);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleSubscribePublicTopic(IntPtr api, THOST_TE_RESUME_TYPE nResumeType);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqAuthenticate(IntPtr api, ref CThostFtdcReqAuthenticateField pReqAuthenticateField, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleRegisterUserSystemInfo(IntPtr api, ref CThostFtdcUserSystemInfoField pUserSystemInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleSubmitUserSystemInfo(IntPtr api, ref CThostFtdcUserSystemInfoField pUserSystemInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqUserLogin(IntPtr api, ref CThostFtdcReqUserLoginField pReqUserLoginField, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqUserLogout(IntPtr api, ref CThostFtdcUserLogoutField pUserLogout, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqUserPasswordUpdate(IntPtr api, ref CThostFtdcUserPasswordUpdateField pUserPasswordUpdate, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqTradingAccountPasswordUpdate(IntPtr api, ref CThostFtdcTradingAccountPasswordUpdateField pTradingAccountPasswordUpdate, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqUserAuthMethod(IntPtr api, ref CThostFtdcReqUserAuthMethodField pReqUserAuthMethod, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqGenUserCaptcha(IntPtr api, ref CThostFtdcReqGenUserCaptchaField pReqGenUserCaptcha, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqGenUserText(IntPtr api, ref CThostFtdcReqGenUserTextField pReqGenUserText, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqUserLoginWithCaptcha(IntPtr api, ref CThostFtdcReqUserLoginWithCaptchaField pReqUserLoginWithCaptcha, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqUserLoginWithText(IntPtr api, ref CThostFtdcReqUserLoginWithTextField pReqUserLoginWithText, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqUserLoginWithOTP(IntPtr api, ref CThostFtdcReqUserLoginWithOTPField pReqUserLoginWithOTP, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqOrderInsert(IntPtr api, ref CThostFtdcInputOrderField pInputOrder, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqParkedOrderInsert(IntPtr api, ref CThostFtdcParkedOrderField pParkedOrder, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqParkedOrderAction(IntPtr api, ref CThostFtdcParkedOrderActionField pParkedOrderAction, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqOrderAction(IntPtr api, ref CThostFtdcInputOrderActionField pInputOrderAction, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryMaxOrderVolume(IntPtr api, ref CThostFtdcQryMaxOrderVolumeField pQryMaxOrderVolume, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqSettlementInfoConfirm(IntPtr api, ref CThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqRemoveParkedOrder(IntPtr api, ref CThostFtdcRemoveParkedOrderField pRemoveParkedOrder, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqRemoveParkedOrderAction(IntPtr api, ref CThostFtdcRemoveParkedOrderActionField pRemoveParkedOrderAction, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqExecOrderInsert(IntPtr api, ref CThostFtdcInputExecOrderField pInputExecOrder, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqExecOrderAction(IntPtr api, ref CThostFtdcInputExecOrderActionField pInputExecOrderAction, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqForQuoteInsert(IntPtr api, ref CThostFtdcInputForQuoteField pInputForQuote, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQuoteInsert(IntPtr api, ref CThostFtdcInputQuoteField pInputQuote, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQuoteAction(IntPtr api, ref CThostFtdcInputQuoteActionField pInputQuoteAction, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqBatchOrderAction(IntPtr api, ref CThostFtdcInputBatchOrderActionField pInputBatchOrderAction, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqOptionSelfCloseInsert(IntPtr api, ref CThostFtdcInputOptionSelfCloseField pInputOptionSelfClose, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqOptionSelfCloseAction(IntPtr api, ref CThostFtdcInputOptionSelfCloseActionField pInputOptionSelfCloseAction, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqCombActionInsert(IntPtr api, ref CThostFtdcInputCombActionField pInputCombAction, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryOrder(IntPtr api, ref CThostFtdcQryOrderField pQryOrder, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryTrade(IntPtr api, ref CThostFtdcQryTradeField pQryTrade, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryInvestorPosition(IntPtr api, ref CThostFtdcQryInvestorPositionField pQryInvestorPosition, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryTradingAccount(IntPtr api, ref CThostFtdcQryTradingAccountField pQryTradingAccount, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryInvestor(IntPtr api, ref CThostFtdcQryInvestorField pQryInvestor, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryTradingCode(IntPtr api, ref CThostFtdcQryTradingCodeField pQryTradingCode, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryInstrumentMarginRate(IntPtr api, ref CThostFtdcQryInstrumentMarginRateField pQryInstrumentMarginRate, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryInstrumentCommissionRate(IntPtr api, ref CThostFtdcQryInstrumentCommissionRateField pQryInstrumentCommissionRate, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryExchange(IntPtr api, ref CThostFtdcQryExchangeField pQryExchange, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryProduct(IntPtr api, ref CThostFtdcQryProductField pQryProduct, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryInstrument(IntPtr api, ref CThostFtdcQryInstrumentField pQryInstrument, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryDepthMarketData(IntPtr api, ref CThostFtdcQryDepthMarketDataField pQryDepthMarketData, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQrySettlementInfo(IntPtr api, ref CThostFtdcQrySettlementInfoField pQrySettlementInfo, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryTransferBank(IntPtr api, ref CThostFtdcQryTransferBankField pQryTransferBank, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryInvestorPositionDetail(IntPtr api, ref CThostFtdcQryInvestorPositionDetailField pQryInvestorPositionDetail, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryNotice(IntPtr api, ref CThostFtdcQryNoticeField pQryNotice, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQrySettlementInfoConfirm(IntPtr api, ref CThostFtdcQrySettlementInfoConfirmField pQrySettlementInfoConfirm, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryInvestorPositionCombineDetail(IntPtr api, ref CThostFtdcQryInvestorPositionCombineDetailField pQryInvestorPositionCombineDetail, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryCFMMCTradingAccountKey(IntPtr api, ref CThostFtdcQryCFMMCTradingAccountKeyField pQryCFMMCTradingAccountKey, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryEWarrantOffset(IntPtr api, ref CThostFtdcQryEWarrantOffsetField pQryEWarrantOffset, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryInvestorProductGroupMargin(IntPtr api, ref CThostFtdcQryInvestorProductGroupMarginField pQryInvestorProductGroupMargin, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryExchangeMarginRate(IntPtr api, ref CThostFtdcQryExchangeMarginRateField pQryExchangeMarginRate, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryExchangeMarginRateAdjust(IntPtr api, ref CThostFtdcQryExchangeMarginRateAdjustField pQryExchangeMarginRateAdjust, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryExchangeRate(IntPtr api, ref CThostFtdcQryExchangeRateField pQryExchangeRate, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQrySecAgentACIDMap(IntPtr api, ref CThostFtdcQrySecAgentACIDMapField pQrySecAgentACIDMap, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryProductExchRate(IntPtr api, ref CThostFtdcQryProductExchRateField pQryProductExchRate, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryProductGroup(IntPtr api, ref CThostFtdcQryProductGroupField pQryProductGroup, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryMMInstrumentCommissionRate(IntPtr api, ref CThostFtdcQryMMInstrumentCommissionRateField pQryMMInstrumentCommissionRate, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryMMOptionInstrCommRate(IntPtr api, ref CThostFtdcQryMMOptionInstrCommRateField pQryMMOptionInstrCommRate, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryInstrumentOrderCommRate(IntPtr api, ref CThostFtdcQryInstrumentOrderCommRateField pQryInstrumentOrderCommRate, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQrySecAgentTradingAccount(IntPtr api, ref CThostFtdcQryTradingAccountField pQryTradingAccount, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQrySecAgentCheckMode(IntPtr api, ref CThostFtdcQrySecAgentCheckModeField pQrySecAgentCheckMode, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQrySecAgentTradeInfo(IntPtr api, ref CThostFtdcQrySecAgentTradeInfoField pQrySecAgentTradeInfo, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryOptionInstrTradeCost(IntPtr api, ref CThostFtdcQryOptionInstrTradeCostField pQryOptionInstrTradeCost, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryOptionInstrCommRate(IntPtr api, ref CThostFtdcQryOptionInstrCommRateField pQryOptionInstrCommRate, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryExecOrder(IntPtr api, ref CThostFtdcQryExecOrderField pQryExecOrder, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryForQuote(IntPtr api, ref CThostFtdcQryForQuoteField pQryForQuote, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryQuote(IntPtr api, ref CThostFtdcQryQuoteField pQryQuote, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryOptionSelfClose(IntPtr api, ref CThostFtdcQryOptionSelfCloseField pQryOptionSelfClose, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryInvestUnit(IntPtr api, ref CThostFtdcQryInvestUnitField pQryInvestUnit, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryCombInstrumentGuard(IntPtr api, ref CThostFtdcQryCombInstrumentGuardField pQryCombInstrumentGuard, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryCombAction(IntPtr api, ref CThostFtdcQryCombActionField pQryCombAction, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryTransferSerial(IntPtr api, ref CThostFtdcQryTransferSerialField pQryTransferSerial, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryAccountregister(IntPtr api, ref CThostFtdcQryAccountregisterField pQryAccountregister, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryContractBank(IntPtr api, ref CThostFtdcQryContractBankField pQryContractBank, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryParkedOrder(IntPtr api, ref CThostFtdcQryParkedOrderField pQryParkedOrder, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryParkedOrderAction(IntPtr api, ref CThostFtdcQryParkedOrderActionField pQryParkedOrderAction, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryTradingNotice(IntPtr api, ref CThostFtdcQryTradingNoticeField pQryTradingNotice, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryBrokerTradingParams(IntPtr api, ref CThostFtdcQryBrokerTradingParamsField pQryBrokerTradingParams, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryBrokerTradingAlgos(IntPtr api, ref CThostFtdcQryBrokerTradingAlgosField pQryBrokerTradingAlgos, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQueryCFMMCTradingAccountToken(IntPtr api, ref CThostFtdcQueryCFMMCTradingAccountTokenField pQueryCFMMCTradingAccountToken, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqFromBankToFutureByFuture(IntPtr api, ref CThostFtdcReqTransferField pReqTransfer, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqFromFutureToBankByFuture(IntPtr api, ref CThostFtdcReqTransferField pReqTransfer, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQueryBankAccountMoneyByFuture(IntPtr api, ref CThostFtdcReqQueryAccountField pReqQueryAccount, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryClassifiedInstrument(IntPtr api, ref CThostFtdcQryClassifiedInstrumentField pQryClassifiedInstrument, int nRequestID);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate IntPtr DeleReqQryCombPromotionParam(IntPtr api, ref CThostFtdcQryCombPromotionParamField pQryCombPromotionParam, int nRequestID);
        public IntPtr Release()
        {
            return (loader.Invoke( "Release", typeof(DeleRelease)) as DeleRelease)(_api);
        }

		/// <summary>
		/// 初始化
		/// <para>初始化运行环境,只有调用后,接口才开始工作</para>
		/// </summary>
		/// <returns></returns>
		public IntPtr Init()
        {
            return (loader.Invoke( "Init", typeof(DeleInit)) as DeleInit)(_api);
        }

		/// <summary>
		/// 等待接口线程结束运行
		/// </summary>
		/// <returns></returns>
		public IntPtr Join()
        {
            return (loader.Invoke( "Join", typeof(DeleJoin)) as DeleJoin)(_api);
        }

		/// <summary>
		/// 注册前置机网络地址
		/// </summary>
		/// <param name="pszFrontAddress">前置机网络地址</param>
		/// <returns></returns>
		public IntPtr RegisterFront(string pszFrontAddress)
        {
            return (loader.Invoke( "RegisterFront", typeof(DeleRegisterFront)) as DeleRegisterFront)(_api, pszFrontAddress);
        }

		/// <summary>
		/// 注册名字服务器网络地址
		/// </summary>
		/// <param name="pszNsAddress">名字服务器网络地址</param>
		/// <returns></returns>
		public IntPtr RegisterNameServer(string pszNsAddress)
        {
            return (loader.Invoke( "RegisterNameServer", typeof(DeleRegisterNameServer)) as DeleRegisterNameServer)(_api, pszNsAddress);
        }

		/// <summary>
		/// 注册名字服务器用户信息
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <param name="LoginMode"></param>
		/// <returns></returns>
		public IntPtr RegisterFensUserInfo(string BrokerID = "",string UserID = "",TThostFtdcLoginModeType LoginMode = TThostFtdcLoginModeType.THOST_FTDC_LM_Trade)
        {
			CThostFtdcFensUserInfoField pFensUserInfo = new CThostFtdcFensUserInfoField
			{
				BrokerID = BrokerID,
				UserID = UserID,
				LoginMode = LoginMode,
			};
            return (loader.Invoke( "RegisterFensUserInfo", typeof(DeleRegisterFensUserInfo)) as DeleRegisterFensUserInfo)(_api, ref pFensUserInfo);
        }
                    

        public IntPtr RegisterSpi(IntPtr pSpi)
        {
            return (loader.Invoke( "RegisterSpi", typeof(DeleRegisterSpi)) as DeleRegisterSpi)(_api, pSpi);
        }

		/// <summary>
		/// 订阅私有流
		/// <para>该方法要在Init方法前调用。若不调用则不会收到私有流的数据</para>
		/// </summary>
		/// <param name="nResumeType">私有流重传方式 </param>
		/// <returns></returns>
		public IntPtr SubscribePrivateTopic(THOST_TE_RESUME_TYPE nResumeType)
        {
            return (loader.Invoke( "SubscribePrivateTopic", typeof(DeleSubscribePrivateTopic)) as DeleSubscribePrivateTopic)(_api, nResumeType);
        }

		/// <summary>
		/// 订阅公共流
		/// <para>该方法要在Init方法前调用。若不调用则不会收到公共流的数据</para>
		/// </summary>
		/// <param name="nResumeType">公共流重传方式</param>
		/// <returns></returns>
		public IntPtr SubscribePublicTopic(THOST_TE_RESUME_TYPE nResumeType)
        {
            return (loader.Invoke( "SubscribePublicTopic", typeof(DeleSubscribePublicTopic)) as DeleSubscribePublicTopic)(_api, nResumeType);
        }

		/// <summary>
		/// 客户端认证请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <param name="UserProductInfo"></param>
		/// <param name="AuthCode"></param>
		/// <param name="AppID"></param>
		/// <returns></returns>
		public IntPtr ReqAuthenticate(string BrokerID = "",string UserID = "",string UserProductInfo = "",string AuthCode = "",string AppID = "")
        {
			CThostFtdcReqAuthenticateField pReqAuthenticateField = new CThostFtdcReqAuthenticateField
			{
				BrokerID = BrokerID,
				UserID = UserID,
				UserProductInfo = UserProductInfo,
				AuthCode = AuthCode,
				AppID = AppID,
			};
            return (loader.Invoke( "ReqAuthenticate", typeof(DeleReqAuthenticate)) as DeleReqAuthenticate)(_api, ref pReqAuthenticateField, this.nRequestID++);
        }

		/// <summary>
		/// 注册用户终端信息，用于中继服务器多连接模式
		/// 需要在终端认证成功后，用户登录前调用该接口
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <param name="ClientSystemInfoLen"></param>
		/// <param name="ClientSystemInfo"></param>
		/// <param name="reserve1"></param>
		/// <param name="ClientIPPort"></param>
		/// <param name="ClientLoginTime"></param>
		/// <param name="ClientAppID"></param>
		/// <param name="ClientPublicIP"></param>
		/// <returns></returns>
		public IntPtr RegisterUserSystemInfo(string BrokerID = "",string UserID = "",int ClientSystemInfoLen = 0,string ClientSystemInfo = "",string reserve1 = "",int ClientIPPort = 0,string ClientLoginTime = "",string ClientAppID = "",string ClientPublicIP = "")
        {
			CThostFtdcUserSystemInfoField pUserSystemInfo = new CThostFtdcUserSystemInfoField
			{
				BrokerID = BrokerID,
				UserID = UserID,
				ClientSystemInfoLen = ClientSystemInfoLen,
				ClientSystemInfo = ClientSystemInfo,
				reserve1 = reserve1,
				ClientIPPort = ClientIPPort,
				ClientLoginTime = ClientLoginTime,
				ClientAppID = ClientAppID,
				ClientPublicIP = ClientPublicIP,
			};
            return (loader.Invoke( "RegisterUserSystemInfo", typeof(DeleRegisterUserSystemInfo)) as DeleRegisterUserSystemInfo)(_api, ref pUserSystemInfo);
        }

		/// <summary>
		/// 上报用户终端信息，用于中继服务器操作员登录模式
		/// 操作员登录后，可以多次调用该接口上报客户信息
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <param name="ClientSystemInfoLen"></param>
		/// <param name="ClientSystemInfo"></param>
		/// <param name="reserve1"></param>
		/// <param name="ClientIPPort"></param>
		/// <param name="ClientLoginTime"></param>
		/// <param name="ClientAppID"></param>
		/// <param name="ClientPublicIP"></param>
		/// <returns></returns>
		public IntPtr SubmitUserSystemInfo(string BrokerID = "",string UserID = "",int ClientSystemInfoLen = 0,string ClientSystemInfo = "",string reserve1 = "",int ClientIPPort = 0,string ClientLoginTime = "",string ClientAppID = "",string ClientPublicIP = "")
        {
			CThostFtdcUserSystemInfoField pUserSystemInfo = new CThostFtdcUserSystemInfoField
			{
				BrokerID = BrokerID,
				UserID = UserID,
				ClientSystemInfoLen = ClientSystemInfoLen,
				ClientSystemInfo = ClientSystemInfo,
				reserve1 = reserve1,
				ClientIPPort = ClientIPPort,
				ClientLoginTime = ClientLoginTime,
				ClientAppID = ClientAppID,
				ClientPublicIP = ClientPublicIP,
			};
            return (loader.Invoke( "SubmitUserSystemInfo", typeof(DeleSubmitUserSystemInfo)) as DeleSubmitUserSystemInfo)(_api, ref pUserSystemInfo);
        }

		/// <summary>
		/// 用户登录请求
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
		public IntPtr ReqUserLogin(string TradingDay = "",string BrokerID = "",string UserID = "",string Password = "",string UserProductInfo = "",string InterfaceProductInfo = "",string ProtocolInfo = "",string MacAddress = "",string OneTimePassword = "",string reserve1 = "",string LoginRemark = "",int ClientIPPort = 0,string ClientIPAddress = "")
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
            return (loader.Invoke( "ReqUserLogin", typeof(DeleReqUserLogin)) as DeleReqUserLogin)(_api, ref pReqUserLoginField, this.nRequestID++);
        }

		/// <summary>
		/// 登出请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public IntPtr ReqUserLogout(string BrokerID = "",string UserID = "")
        {
			CThostFtdcUserLogoutField pUserLogout = new CThostFtdcUserLogoutField
			{
				BrokerID = BrokerID,
				UserID = UserID,
			};
            return (loader.Invoke( "ReqUserLogout", typeof(DeleReqUserLogout)) as DeleReqUserLogout)(_api, ref pUserLogout, this.nRequestID++);
        }

		/// <summary>
		/// 用户口令更新请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <param name="OldPassword"></param>
		/// <param name="NewPassword"></param>
		/// <returns></returns>
		public IntPtr ReqUserPasswordUpdate(string BrokerID = "",string UserID = "",string OldPassword = "",string NewPassword = "")
        {
			CThostFtdcUserPasswordUpdateField pUserPasswordUpdate = new CThostFtdcUserPasswordUpdateField
			{
				BrokerID = BrokerID,
				UserID = UserID,
				OldPassword = OldPassword,
				NewPassword = NewPassword,
			};
            return (loader.Invoke( "ReqUserPasswordUpdate", typeof(DeleReqUserPasswordUpdate)) as DeleReqUserPasswordUpdate)(_api, ref pUserPasswordUpdate, this.nRequestID++);
        }

		/// <summary>
		/// 资金账户口令更新请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="AccountID"></param>
		/// <param name="OldPassword"></param>
		/// <param name="NewPassword"></param>
		/// <param name="CurrencyID"></param>
		/// <returns></returns>
		public IntPtr ReqTradingAccountPasswordUpdate(string BrokerID = "",string AccountID = "",string OldPassword = "",string NewPassword = "",string CurrencyID = "")
        {
			CThostFtdcTradingAccountPasswordUpdateField pTradingAccountPasswordUpdate = new CThostFtdcTradingAccountPasswordUpdateField
			{
				BrokerID = BrokerID,
				AccountID = AccountID,
				OldPassword = OldPassword,
				NewPassword = NewPassword,
				CurrencyID = CurrencyID,
			};
            return (loader.Invoke( "ReqTradingAccountPasswordUpdate", typeof(DeleReqTradingAccountPasswordUpdate)) as DeleReqTradingAccountPasswordUpdate)(_api, ref pTradingAccountPasswordUpdate, this.nRequestID++);
        }

		/// <summary>
		/// 查询用户当前支持的认证模式
		/// </summary>
		/// <param name="TradingDay"></param>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public IntPtr ReqUserAuthMethod(string TradingDay = "",string BrokerID = "",string UserID = "")
        {
			CThostFtdcReqUserAuthMethodField pReqUserAuthMethod = new CThostFtdcReqUserAuthMethodField
			{
				TradingDay = TradingDay,
				BrokerID = BrokerID,
				UserID = UserID,
			};
            return (loader.Invoke( "ReqUserAuthMethod", typeof(DeleReqUserAuthMethod)) as DeleReqUserAuthMethod)(_api, ref pReqUserAuthMethod, this.nRequestID++);
        }

		/// <summary>
		/// 用户发出获取图形验证码请求
		/// </summary>
		/// <param name="TradingDay"></param>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public IntPtr ReqGenUserCaptcha(string TradingDay = "",string BrokerID = "",string UserID = "")
        {
			CThostFtdcReqGenUserCaptchaField pReqGenUserCaptcha = new CThostFtdcReqGenUserCaptchaField
			{
				TradingDay = TradingDay,
				BrokerID = BrokerID,
				UserID = UserID,
			};
            return (loader.Invoke( "ReqGenUserCaptcha", typeof(DeleReqGenUserCaptcha)) as DeleReqGenUserCaptcha)(_api, ref pReqGenUserCaptcha, this.nRequestID++);
        }

		/// <summary>
		/// 用户发出获取短信验证码请求
		/// </summary>
		/// <param name="TradingDay"></param>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public IntPtr ReqGenUserText(string TradingDay = "",string BrokerID = "",string UserID = "")
        {
			CThostFtdcReqGenUserTextField pReqGenUserText = new CThostFtdcReqGenUserTextField
			{
				TradingDay = TradingDay,
				BrokerID = BrokerID,
				UserID = UserID,
			};
            return (loader.Invoke( "ReqGenUserText", typeof(DeleReqGenUserText)) as DeleReqGenUserText)(_api, ref pReqGenUserText, this.nRequestID++);
        }

		/// <summary>
		/// 用户发出带有动态口令的登陆请求
		/// </summary>
		/// <param name="TradingDay"></param>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <param name="Password"></param>
		/// <param name="UserProductInfo"></param>
		/// <param name="InterfaceProductInfo"></param>
		/// <param name="ProtocolInfo"></param>
		/// <param name="MacAddress"></param>
		/// <param name="reserve1"></param>
		/// <param name="LoginRemark"></param>
		/// <param name="Captcha"></param>
		/// <param name="ClientIPPort"></param>
		/// <param name="ClientIPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqUserLoginWithCaptcha(string TradingDay = "",string BrokerID = "",string UserID = "",string Password = "",string UserProductInfo = "",string InterfaceProductInfo = "",string ProtocolInfo = "",string MacAddress = "",string reserve1 = "",string LoginRemark = "",string Captcha = "",int ClientIPPort = 0,string ClientIPAddress = "")
        {
			CThostFtdcReqUserLoginWithCaptchaField pReqUserLoginWithCaptcha = new CThostFtdcReqUserLoginWithCaptchaField
			{
				TradingDay = TradingDay,
				BrokerID = BrokerID,
				UserID = UserID,
				Password = Password,
				UserProductInfo = UserProductInfo,
				InterfaceProductInfo = InterfaceProductInfo,
				ProtocolInfo = ProtocolInfo,
				MacAddress = MacAddress,
				reserve1 = reserve1,
				LoginRemark = LoginRemark,
				Captcha = Captcha,
				ClientIPPort = ClientIPPort,
				ClientIPAddress = ClientIPAddress,
			};
            return (loader.Invoke( "ReqUserLoginWithCaptcha", typeof(DeleReqUserLoginWithCaptcha)) as DeleReqUserLoginWithCaptcha)(_api, ref pReqUserLoginWithCaptcha, this.nRequestID++);
        }

		/// <summary>
		/// 用户发出带有短信验证码的登陆请求
		/// </summary>
		/// <param name="TradingDay"></param>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <param name="Password"></param>
		/// <param name="UserProductInfo"></param>
		/// <param name="InterfaceProductInfo"></param>
		/// <param name="ProtocolInfo"></param>
		/// <param name="MacAddress"></param>
		/// <param name="reserve1"></param>
		/// <param name="LoginRemark"></param>
		/// <param name="Text"></param>
		/// <param name="ClientIPPort"></param>
		/// <param name="ClientIPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqUserLoginWithText(string TradingDay = "",string BrokerID = "",string UserID = "",string Password = "",string UserProductInfo = "",string InterfaceProductInfo = "",string ProtocolInfo = "",string MacAddress = "",string reserve1 = "",string LoginRemark = "",string Text = "",int ClientIPPort = 0,string ClientIPAddress = "")
        {
			CThostFtdcReqUserLoginWithTextField pReqUserLoginWithText = new CThostFtdcReqUserLoginWithTextField
			{
				TradingDay = TradingDay,
				BrokerID = BrokerID,
				UserID = UserID,
				Password = Password,
				UserProductInfo = UserProductInfo,
				InterfaceProductInfo = InterfaceProductInfo,
				ProtocolInfo = ProtocolInfo,
				MacAddress = MacAddress,
				reserve1 = reserve1,
				LoginRemark = LoginRemark,
				Text = Text,
				ClientIPPort = ClientIPPort,
				ClientIPAddress = ClientIPAddress,
			};
            return (loader.Invoke( "ReqUserLoginWithText", typeof(DeleReqUserLoginWithText)) as DeleReqUserLoginWithText)(_api, ref pReqUserLoginWithText, this.nRequestID++);
        }

		/// <summary>
		/// 用户发出带有动态口令的登陆请求
		/// </summary>
		/// <param name="TradingDay"></param>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <param name="Password"></param>
		/// <param name="UserProductInfo"></param>
		/// <param name="InterfaceProductInfo"></param>
		/// <param name="ProtocolInfo"></param>
		/// <param name="MacAddress"></param>
		/// <param name="reserve1"></param>
		/// <param name="LoginRemark"></param>
		/// <param name="OTPPassword"></param>
		/// <param name="ClientIPPort"></param>
		/// <param name="ClientIPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqUserLoginWithOTP(string TradingDay = "",string BrokerID = "",string UserID = "",string Password = "",string UserProductInfo = "",string InterfaceProductInfo = "",string ProtocolInfo = "",string MacAddress = "",string reserve1 = "",string LoginRemark = "",string OTPPassword = "",int ClientIPPort = 0,string ClientIPAddress = "")
        {
			CThostFtdcReqUserLoginWithOTPField pReqUserLoginWithOTP = new CThostFtdcReqUserLoginWithOTPField
			{
				TradingDay = TradingDay,
				BrokerID = BrokerID,
				UserID = UserID,
				Password = Password,
				UserProductInfo = UserProductInfo,
				InterfaceProductInfo = InterfaceProductInfo,
				ProtocolInfo = ProtocolInfo,
				MacAddress = MacAddress,
				reserve1 = reserve1,
				LoginRemark = LoginRemark,
				OTPPassword = OTPPassword,
				ClientIPPort = ClientIPPort,
				ClientIPAddress = ClientIPAddress,
			};
            return (loader.Invoke( "ReqUserLoginWithOTP", typeof(DeleReqUserLoginWithOTP)) as DeleReqUserLoginWithOTP)(_api, ref pReqUserLoginWithOTP, this.nRequestID++);
        }

		/// <summary>
		/// 报单录入请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="OrderRef"></param>
		/// <param name="UserID"></param>
		/// <param name="OrderPriceType"></param>
		/// <param name="Direction"></param>
		/// <param name="CombOffsetFlag"></param>
		/// <param name="CombHedgeFlag"></param>
		/// <param name="LimitPrice"></param>
		/// <param name="VolumeTotalOriginal"></param>
		/// <param name="TimeCondition"></param>
		/// <param name="GTDDate"></param>
		/// <param name="VolumeCondition"></param>
		/// <param name="MinVolume"></param>
		/// <param name="ContingentCondition"></param>
		/// <param name="StopPrice"></param>
		/// <param name="ForceCloseReason"></param>
		/// <param name="IsAutoSuspend"></param>
		/// <param name="BusinessUnit"></param>
		/// <param name="RequestID"></param>
		/// <param name="UserForceClose"></param>
		/// <param name="IsSwapOrder"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="AccountID"></param>
		/// <param name="CurrencyID"></param>
		/// <param name="ClientID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqOrderInsert(string BrokerID = "",string InvestorID = "",string reserve1 = "",string OrderRef = "",string UserID = "",TThostFtdcOrderPriceTypeType OrderPriceType = TThostFtdcOrderPriceTypeType.THOST_FTDC_OPT_AnyPrice,TThostFtdcDirectionType Direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy,string CombOffsetFlag = "",string CombHedgeFlag = "",double LimitPrice = 0.0,int VolumeTotalOriginal = 0,TThostFtdcTimeConditionType TimeCondition = TThostFtdcTimeConditionType.THOST_FTDC_TC_IOC,string GTDDate = "",TThostFtdcVolumeConditionType VolumeCondition = TThostFtdcVolumeConditionType.THOST_FTDC_VC_AV,int MinVolume = 0,TThostFtdcContingentConditionType ContingentCondition = TThostFtdcContingentConditionType.THOST_FTDC_CC_Immediately,double StopPrice = 0.0,TThostFtdcForceCloseReasonType ForceCloseReason = TThostFtdcForceCloseReasonType.THOST_FTDC_FCC_NotForceClose,int IsAutoSuspend = 0,string BusinessUnit = "",int RequestID = 0,int UserForceClose = 0,int IsSwapOrder = 0,string ExchangeID = "",string InvestUnitID = "",string AccountID = "",string CurrencyID = "",string ClientID = "",string reserve2 = "",string MacAddress = "",string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcInputOrderField pInputOrder = new CThostFtdcInputOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				OrderRef = OrderRef,
				UserID = UserID,
				OrderPriceType = OrderPriceType,
				Direction = Direction,
				CombOffsetFlag = CombOffsetFlag,
				CombHedgeFlag = CombHedgeFlag,
				LimitPrice = LimitPrice,
				VolumeTotalOriginal = VolumeTotalOriginal,
				TimeCondition = TimeCondition,
				GTDDate = GTDDate,
				VolumeCondition = VolumeCondition,
				MinVolume = MinVolume,
				ContingentCondition = ContingentCondition,
				StopPrice = StopPrice,
				ForceCloseReason = ForceCloseReason,
				IsAutoSuspend = IsAutoSuspend,
				BusinessUnit = BusinessUnit,
				RequestID = RequestID,
				UserForceClose = UserForceClose,
				IsSwapOrder = IsSwapOrder,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
				ClientID = ClientID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqOrderInsert", typeof(DeleReqOrderInsert)) as DeleReqOrderInsert)(_api, ref pInputOrder, this.nRequestID++);
        }

		/// <summary>
		/// 预埋单录入请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="OrderRef"></param>
		/// <param name="UserID"></param>
		/// <param name="OrderPriceType"></param>
		/// <param name="Direction"></param>
		/// <param name="CombOffsetFlag"></param>
		/// <param name="CombHedgeFlag"></param>
		/// <param name="LimitPrice"></param>
		/// <param name="VolumeTotalOriginal"></param>
		/// <param name="TimeCondition"></param>
		/// <param name="GTDDate"></param>
		/// <param name="VolumeCondition"></param>
		/// <param name="MinVolume"></param>
		/// <param name="ContingentCondition"></param>
		/// <param name="StopPrice"></param>
		/// <param name="ForceCloseReason"></param>
		/// <param name="IsAutoSuspend"></param>
		/// <param name="BusinessUnit"></param>
		/// <param name="RequestID"></param>
		/// <param name="UserForceClose"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="ParkedOrderID"></param>
		/// <param name="UserType"></param>
		/// <param name="Status"></param>
		/// <param name="ErrorID"></param>
		/// <param name="ErrorMsg"></param>
		/// <param name="IsSwapOrder"></param>
		/// <param name="AccountID"></param>
		/// <param name="CurrencyID"></param>
		/// <param name="ClientID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqParkedOrderInsert(string BrokerID = "",string InvestorID = "",string reserve1 = "",string OrderRef = "",string UserID = "",TThostFtdcOrderPriceTypeType OrderPriceType = TThostFtdcOrderPriceTypeType.THOST_FTDC_OPT_AnyPrice,TThostFtdcDirectionType Direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy,string CombOffsetFlag = "",string CombHedgeFlag = "",double LimitPrice = 0.0,int VolumeTotalOriginal = 0,TThostFtdcTimeConditionType TimeCondition = TThostFtdcTimeConditionType.THOST_FTDC_TC_IOC,string GTDDate = "",TThostFtdcVolumeConditionType VolumeCondition = TThostFtdcVolumeConditionType.THOST_FTDC_VC_AV,int MinVolume = 0,TThostFtdcContingentConditionType ContingentCondition = TThostFtdcContingentConditionType.THOST_FTDC_CC_Immediately,double StopPrice = 0.0,TThostFtdcForceCloseReasonType ForceCloseReason = TThostFtdcForceCloseReasonType.THOST_FTDC_FCC_NotForceClose,int IsAutoSuspend = 0,string BusinessUnit = "",int RequestID = 0,int UserForceClose = 0,string ExchangeID = "",string ParkedOrderID = "",TThostFtdcUserTypeType UserType = TThostFtdcUserTypeType.THOST_FTDC_UT_Investor,TThostFtdcParkedOrderStatusType Status = TThostFtdcParkedOrderStatusType.THOST_FTDC_PAOS_NotSend,int ErrorID = 0,string ErrorMsg = "",int IsSwapOrder = 0,string AccountID = "",string CurrencyID = "",string ClientID = "",string InvestUnitID = "",string reserve2 = "",string MacAddress = "",string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcParkedOrderField pParkedOrder = new CThostFtdcParkedOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				OrderRef = OrderRef,
				UserID = UserID,
				OrderPriceType = OrderPriceType,
				Direction = Direction,
				CombOffsetFlag = CombOffsetFlag,
				CombHedgeFlag = CombHedgeFlag,
				LimitPrice = LimitPrice,
				VolumeTotalOriginal = VolumeTotalOriginal,
				TimeCondition = TimeCondition,
				GTDDate = GTDDate,
				VolumeCondition = VolumeCondition,
				MinVolume = MinVolume,
				ContingentCondition = ContingentCondition,
				StopPrice = StopPrice,
				ForceCloseReason = ForceCloseReason,
				IsAutoSuspend = IsAutoSuspend,
				BusinessUnit = BusinessUnit,
				RequestID = RequestID,
				UserForceClose = UserForceClose,
				ExchangeID = ExchangeID,
				ParkedOrderID = ParkedOrderID,
				UserType = UserType,
				Status = Status,
				ErrorID = ErrorID,
				ErrorMsg = ErrorMsg,
				IsSwapOrder = IsSwapOrder,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
				ClientID = ClientID,
				InvestUnitID = InvestUnitID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqParkedOrderInsert", typeof(DeleReqParkedOrderInsert)) as DeleReqParkedOrderInsert)(_api, ref pParkedOrder, this.nRequestID++);
        }

		/// <summary>
		/// 预埋撤单录入请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="OrderActionRef"></param>
		/// <param name="OrderRef"></param>
		/// <param name="RequestID"></param>
		/// <param name="FrontID"></param>
		/// <param name="SessionID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="OrderSysID"></param>
		/// <param name="ActionFlag"></param>
		/// <param name="LimitPrice"></param>
		/// <param name="VolumeChange"></param>
		/// <param name="UserID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ParkedOrderActionID"></param>
		/// <param name="UserType"></param>
		/// <param name="Status"></param>
		/// <param name="ErrorID"></param>
		/// <param name="ErrorMsg"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqParkedOrderAction(string BrokerID = "",string InvestorID = "",int OrderActionRef = 0,string OrderRef = "",int RequestID = 0,int FrontID = 0,int SessionID = 0,string ExchangeID = "",string OrderSysID = "",TThostFtdcActionFlagType ActionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete,double LimitPrice = 0.0,int VolumeChange = 0,string UserID = "",string reserve1 = "",string ParkedOrderActionID = "",TThostFtdcUserTypeType UserType = TThostFtdcUserTypeType.THOST_FTDC_UT_Investor,TThostFtdcParkedOrderStatusType Status = TThostFtdcParkedOrderStatusType.THOST_FTDC_PAOS_NotSend,int ErrorID = 0,string ErrorMsg = "",string InvestUnitID = "",string reserve2 = "",string MacAddress = "",string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcParkedOrderActionField pParkedOrderAction = new CThostFtdcParkedOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				OrderActionRef = OrderActionRef,
				OrderRef = OrderRef,
				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,
				ExchangeID = ExchangeID,
				OrderSysID = OrderSysID,
				ActionFlag = ActionFlag,
				LimitPrice = LimitPrice,
				VolumeChange = VolumeChange,
				UserID = UserID,
				reserve1 = reserve1,
				ParkedOrderActionID = ParkedOrderActionID,
				UserType = UserType,
				Status = Status,
				ErrorID = ErrorID,
				ErrorMsg = ErrorMsg,
				InvestUnitID = InvestUnitID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqParkedOrderAction", typeof(DeleReqParkedOrderAction)) as DeleReqParkedOrderAction)(_api, ref pParkedOrderAction, this.nRequestID++);
        }

		/// <summary>
		/// 报单操作请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="OrderActionRef"></param>
		/// <param name="OrderRef"></param>
		/// <param name="RequestID"></param>
		/// <param name="FrontID"></param>
		/// <param name="SessionID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="OrderSysID"></param>
		/// <param name="ActionFlag"></param>
		/// <param name="LimitPrice"></param>
		/// <param name="VolumeChange"></param>
		/// <param name="UserID"></param>
		/// <param name="reserve1"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqOrderAction(string BrokerID = "",string InvestorID = "",int OrderActionRef = 0,string OrderRef = "",int RequestID = 0,int FrontID = 0,int SessionID = 0,string ExchangeID = "",string OrderSysID = "",TThostFtdcActionFlagType ActionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete,double LimitPrice = 0.0,int VolumeChange = 0,string UserID = "",string reserve1 = "",string InvestUnitID = "",string reserve2 = "",string MacAddress = "",string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcInputOrderActionField pInputOrderAction = new CThostFtdcInputOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				OrderActionRef = OrderActionRef,
				OrderRef = OrderRef,
				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,
				ExchangeID = ExchangeID,
				OrderSysID = OrderSysID,
				ActionFlag = ActionFlag,
				LimitPrice = LimitPrice,
				VolumeChange = VolumeChange,
				UserID = UserID,
				reserve1 = reserve1,
				InvestUnitID = InvestUnitID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqOrderAction", typeof(DeleReqOrderAction)) as DeleReqOrderAction)(_api, ref pInputOrderAction, this.nRequestID++);
        }

		/// <summary>
		/// 查询最大报单数量请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="Direction"></param>
		/// <param name="OffsetFlag"></param>
		/// <param name="HedgeFlag"></param>
		/// <param name="MaxVolume"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryMaxOrderVolume(string BrokerID = "",string InvestorID = "",string reserve1 = "",TThostFtdcDirectionType Direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy,TThostFtdcOffsetFlagType OffsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open,TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation,int MaxVolume = 0,string ExchangeID = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryMaxOrderVolumeField pQryMaxOrderVolume = new CThostFtdcQryMaxOrderVolumeField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				Direction = Direction,
				OffsetFlag = OffsetFlag,
				HedgeFlag = HedgeFlag,
				MaxVolume = MaxVolume,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryMaxOrderVolume", typeof(DeleReqQryMaxOrderVolume)) as DeleReqQryMaxOrderVolume)(_api, ref pQryMaxOrderVolume, this.nRequestID++);
        }

		/// <summary>
		/// 投资者结算结果确认
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="ConfirmDate"></param>
		/// <param name="ConfirmTime"></param>
		/// <param name="SettlementID"></param>
		/// <param name="AccountID"></param>
		/// <param name="CurrencyID"></param>
		/// <returns></returns>
		public IntPtr ReqSettlementInfoConfirm(string BrokerID = "",string InvestorID = "",string ConfirmDate = "",string ConfirmTime = "",int SettlementID = 0,string AccountID = "",string CurrencyID = "")
        {
			CThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm = new CThostFtdcSettlementInfoConfirmField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ConfirmDate = ConfirmDate,
				ConfirmTime = ConfirmTime,
				SettlementID = SettlementID,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
			};
            return (loader.Invoke( "ReqSettlementInfoConfirm", typeof(DeleReqSettlementInfoConfirm)) as DeleReqSettlementInfoConfirm)(_api, ref pSettlementInfoConfirm, this.nRequestID++);
        }

		/// <summary>
		/// 请求删除预埋单
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="ParkedOrderID"></param>
		/// <param name="InvestUnitID"></param>
		/// <returns></returns>
		public IntPtr ReqRemoveParkedOrder(string BrokerID = "",string InvestorID = "",string ParkedOrderID = "",string InvestUnitID = "")
        {
			CThostFtdcRemoveParkedOrderField pRemoveParkedOrder = new CThostFtdcRemoveParkedOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ParkedOrderID = ParkedOrderID,
				InvestUnitID = InvestUnitID,
			};
            return (loader.Invoke( "ReqRemoveParkedOrder", typeof(DeleReqRemoveParkedOrder)) as DeleReqRemoveParkedOrder)(_api, ref pRemoveParkedOrder, this.nRequestID++);
        }

		/// <summary>
		/// 请求删除预埋撤单
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="ParkedOrderActionID"></param>
		/// <param name="InvestUnitID"></param>
		/// <returns></returns>
		public IntPtr ReqRemoveParkedOrderAction(string BrokerID = "",string InvestorID = "",string ParkedOrderActionID = "",string InvestUnitID = "")
        {
			CThostFtdcRemoveParkedOrderActionField pRemoveParkedOrderAction = new CThostFtdcRemoveParkedOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ParkedOrderActionID = ParkedOrderActionID,
				InvestUnitID = InvestUnitID,
			};
            return (loader.Invoke( "ReqRemoveParkedOrderAction", typeof(DeleReqRemoveParkedOrderAction)) as DeleReqRemoveParkedOrderAction)(_api, ref pRemoveParkedOrderAction, this.nRequestID++);
        }

		/// <summary>
		/// 执行宣告录入请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExecOrderRef"></param>
		/// <param name="UserID"></param>
		/// <param name="Volume"></param>
		/// <param name="RequestID"></param>
		/// <param name="BusinessUnit"></param>
		/// <param name="OffsetFlag"></param>
		/// <param name="HedgeFlag"></param>
		/// <param name="ActionType"></param>
		/// <param name="PosiDirection"></param>
		/// <param name="ReservePositionFlag"></param>
		/// <param name="CloseFlag"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="AccountID"></param>
		/// <param name="CurrencyID"></param>
		/// <param name="ClientID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqExecOrderInsert(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExecOrderRef = "",string UserID = "",int Volume = 0,int RequestID = 0,string BusinessUnit = "",TThostFtdcOffsetFlagType OffsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open,TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation,TThostFtdcActionTypeType ActionType = TThostFtdcActionTypeType.THOST_FTDC_ACTP_Exec,TThostFtdcPosiDirectionType PosiDirection = TThostFtdcPosiDirectionType.THOST_FTDC_PD_Net,TThostFtdcExecOrderPositionFlagType ReservePositionFlag = TThostFtdcExecOrderPositionFlagType.THOST_FTDC_EOPF_Reserve,TThostFtdcExecOrderCloseFlagType CloseFlag = TThostFtdcExecOrderCloseFlagType.THOST_FTDC_EOCF_AutoClose,string ExchangeID = "",string InvestUnitID = "",string AccountID = "",string CurrencyID = "",string ClientID = "",string reserve2 = "",string MacAddress = "",string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcInputExecOrderField pInputExecOrder = new CThostFtdcInputExecOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExecOrderRef = ExecOrderRef,
				UserID = UserID,
				Volume = Volume,
				RequestID = RequestID,
				BusinessUnit = BusinessUnit,
				OffsetFlag = OffsetFlag,
				HedgeFlag = HedgeFlag,
				ActionType = ActionType,
				PosiDirection = PosiDirection,
				ReservePositionFlag = ReservePositionFlag,
				CloseFlag = CloseFlag,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
				ClientID = ClientID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqExecOrderInsert", typeof(DeleReqExecOrderInsert)) as DeleReqExecOrderInsert)(_api, ref pInputExecOrder, this.nRequestID++);
        }

		/// <summary>
		/// 执行宣告操作请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="ExecOrderActionRef"></param>
		/// <param name="ExecOrderRef"></param>
		/// <param name="RequestID"></param>
		/// <param name="FrontID"></param>
		/// <param name="SessionID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="ExecOrderSysID"></param>
		/// <param name="ActionFlag"></param>
		/// <param name="UserID"></param>
		/// <param name="reserve1"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqExecOrderAction(string BrokerID = "",string InvestorID = "",int ExecOrderActionRef = 0,string ExecOrderRef = "",int RequestID = 0,int FrontID = 0,int SessionID = 0,string ExchangeID = "",string ExecOrderSysID = "",TThostFtdcActionFlagType ActionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete,string UserID = "",string reserve1 = "",string InvestUnitID = "",string reserve2 = "",string MacAddress = "",string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcInputExecOrderActionField pInputExecOrderAction = new CThostFtdcInputExecOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ExecOrderActionRef = ExecOrderActionRef,
				ExecOrderRef = ExecOrderRef,
				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,
				ExchangeID = ExchangeID,
				ExecOrderSysID = ExecOrderSysID,
				ActionFlag = ActionFlag,
				UserID = UserID,
				reserve1 = reserve1,
				InvestUnitID = InvestUnitID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqExecOrderAction", typeof(DeleReqExecOrderAction)) as DeleReqExecOrderAction)(_api, ref pInputExecOrderAction, this.nRequestID++);
        }

		/// <summary>
		/// ///询价录入请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ForQuoteRef"></param>
		/// <param name="UserID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqForQuoteInsert(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ForQuoteRef = "",string UserID = "",string ExchangeID = "",string InvestUnitID = "",string reserve2 = "",string MacAddress = "",string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcInputForQuoteField pInputForQuote = new CThostFtdcInputForQuoteField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ForQuoteRef = ForQuoteRef,
				UserID = UserID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqForQuoteInsert", typeof(DeleReqForQuoteInsert)) as DeleReqForQuoteInsert)(_api, ref pInputForQuote, this.nRequestID++);
        }

		/// <summary>
		/// 报价录入请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="QuoteRef"></param>
		/// <param name="UserID"></param>
		/// <param name="AskPrice"></param>
		/// <param name="BidPrice"></param>
		/// <param name="AskVolume"></param>
		/// <param name="BidVolume"></param>
		/// <param name="RequestID"></param>
		/// <param name="BusinessUnit"></param>
		/// <param name="AskOffsetFlag"></param>
		/// <param name="BidOffsetFlag"></param>
		/// <param name="AskHedgeFlag"></param>
		/// <param name="BidHedgeFlag"></param>
		/// <param name="AskOrderRef"></param>
		/// <param name="BidOrderRef"></param>
		/// <param name="ForQuoteSysID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="ClientID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqQuoteInsert(string BrokerID = "",string InvestorID = "",string reserve1 = "",string QuoteRef = "",string UserID = "",double AskPrice = 0.0,double BidPrice = 0.0,int AskVolume = 0,int BidVolume = 0,int RequestID = 0,string BusinessUnit = "",TThostFtdcOffsetFlagType AskOffsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open,TThostFtdcOffsetFlagType BidOffsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open,TThostFtdcHedgeFlagType AskHedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation,TThostFtdcHedgeFlagType BidHedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation,string AskOrderRef = "",string BidOrderRef = "",string ForQuoteSysID = "",string ExchangeID = "",string InvestUnitID = "",string ClientID = "",string reserve2 = "",string MacAddress = "",string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcInputQuoteField pInputQuote = new CThostFtdcInputQuoteField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				QuoteRef = QuoteRef,
				UserID = UserID,
				AskPrice = AskPrice,
				BidPrice = BidPrice,
				AskVolume = AskVolume,
				BidVolume = BidVolume,
				RequestID = RequestID,
				BusinessUnit = BusinessUnit,
				AskOffsetFlag = AskOffsetFlag,
				BidOffsetFlag = BidOffsetFlag,
				AskHedgeFlag = AskHedgeFlag,
				BidHedgeFlag = BidHedgeFlag,
				AskOrderRef = AskOrderRef,
				BidOrderRef = BidOrderRef,
				ForQuoteSysID = ForQuoteSysID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				ClientID = ClientID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqQuoteInsert", typeof(DeleReqQuoteInsert)) as DeleReqQuoteInsert)(_api, ref pInputQuote, this.nRequestID++);
        }

		/// <summary>
		/// 报价操作请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="QuoteActionRef"></param>
		/// <param name="QuoteRef"></param>
		/// <param name="RequestID"></param>
		/// <param name="FrontID"></param>
		/// <param name="SessionID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="QuoteSysID"></param>
		/// <param name="ActionFlag"></param>
		/// <param name="UserID"></param>
		/// <param name="reserve1"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="ClientID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqQuoteAction(string BrokerID = "",string InvestorID = "",int QuoteActionRef = 0,string QuoteRef = "",int RequestID = 0,int FrontID = 0,int SessionID = 0,string ExchangeID = "",string QuoteSysID = "",TThostFtdcActionFlagType ActionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete,string UserID = "",string reserve1 = "",string InvestUnitID = "",string ClientID = "",string reserve2 = "",string MacAddress = "",string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcInputQuoteActionField pInputQuoteAction = new CThostFtdcInputQuoteActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				QuoteActionRef = QuoteActionRef,
				QuoteRef = QuoteRef,
				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,
				ExchangeID = ExchangeID,
				QuoteSysID = QuoteSysID,
				ActionFlag = ActionFlag,
				UserID = UserID,
				reserve1 = reserve1,
				InvestUnitID = InvestUnitID,
				ClientID = ClientID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqQuoteAction", typeof(DeleReqQuoteAction)) as DeleReqQuoteAction)(_api, ref pInputQuoteAction, this.nRequestID++);
        }

		/// <summary>
		/// 批量报单操作请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="OrderActionRef"></param>
		/// <param name="RequestID"></param>
		/// <param name="FrontID"></param>
		/// <param name="SessionID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="UserID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="reserve1"></param>
		/// <param name="MacAddress"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqBatchOrderAction(string BrokerID = "",string InvestorID = "",int OrderActionRef = 0,int RequestID = 0,int FrontID = 0,int SessionID = 0,string ExchangeID = "",string UserID = "",string InvestUnitID = "",string reserve1 = "",string MacAddress = "",string IPAddress = "")
        {
			CThostFtdcInputBatchOrderActionField pInputBatchOrderAction = new CThostFtdcInputBatchOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				OrderActionRef = OrderActionRef,
				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,
				ExchangeID = ExchangeID,
				UserID = UserID,
				InvestUnitID = InvestUnitID,
				reserve1 = reserve1,
				MacAddress = MacAddress,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqBatchOrderAction", typeof(DeleReqBatchOrderAction)) as DeleReqBatchOrderAction)(_api, ref pInputBatchOrderAction, this.nRequestID++);
        }

		/// <summary>
		/// 期权自对冲录入请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="OptionSelfCloseRef"></param>
		/// <param name="UserID"></param>
		/// <param name="Volume"></param>
		/// <param name="RequestID"></param>
		/// <param name="BusinessUnit"></param>
		/// <param name="HedgeFlag"></param>
		/// <param name="OptSelfCloseFlag"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="AccountID"></param>
		/// <param name="CurrencyID"></param>
		/// <param name="ClientID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqOptionSelfCloseInsert(string BrokerID = "",string InvestorID = "",string reserve1 = "",string OptionSelfCloseRef = "",string UserID = "",int Volume = 0,int RequestID = 0,string BusinessUnit = "",TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation,TThostFtdcOptSelfCloseFlagType OptSelfCloseFlag = TThostFtdcOptSelfCloseFlagType.THOST_FTDC_OSCF_CloseSelfOptionPosition,string ExchangeID = "",string InvestUnitID = "",string AccountID = "",string CurrencyID = "",string ClientID = "",string reserve2 = "",string MacAddress = "",string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcInputOptionSelfCloseField pInputOptionSelfClose = new CThostFtdcInputOptionSelfCloseField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				OptionSelfCloseRef = OptionSelfCloseRef,
				UserID = UserID,
				Volume = Volume,
				RequestID = RequestID,
				BusinessUnit = BusinessUnit,
				HedgeFlag = HedgeFlag,
				OptSelfCloseFlag = OptSelfCloseFlag,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
				ClientID = ClientID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqOptionSelfCloseInsert", typeof(DeleReqOptionSelfCloseInsert)) as DeleReqOptionSelfCloseInsert)(_api, ref pInputOptionSelfClose, this.nRequestID++);
        }

		/// <summary>
		/// 期权自对冲操作请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="OptionSelfCloseActionRef"></param>
		/// <param name="OptionSelfCloseRef"></param>
		/// <param name="RequestID"></param>
		/// <param name="FrontID"></param>
		/// <param name="SessionID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="OptionSelfCloseSysID"></param>
		/// <param name="ActionFlag"></param>
		/// <param name="UserID"></param>
		/// <param name="reserve1"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqOptionSelfCloseAction(string BrokerID = "",string InvestorID = "",int OptionSelfCloseActionRef = 0,string OptionSelfCloseRef = "",int RequestID = 0,int FrontID = 0,int SessionID = 0,string ExchangeID = "",string OptionSelfCloseSysID = "",TThostFtdcActionFlagType ActionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete,string UserID = "",string reserve1 = "",string InvestUnitID = "",string reserve2 = "",string MacAddress = "",string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcInputOptionSelfCloseActionField pInputOptionSelfCloseAction = new CThostFtdcInputOptionSelfCloseActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				OptionSelfCloseActionRef = OptionSelfCloseActionRef,
				OptionSelfCloseRef = OptionSelfCloseRef,
				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,
				ExchangeID = ExchangeID,
				OptionSelfCloseSysID = OptionSelfCloseSysID,
				ActionFlag = ActionFlag,
				UserID = UserID,
				reserve1 = reserve1,
				InvestUnitID = InvestUnitID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqOptionSelfCloseAction", typeof(DeleReqOptionSelfCloseAction)) as DeleReqOptionSelfCloseAction)(_api, ref pInputOptionSelfCloseAction, this.nRequestID++);
        }

		/// <summary>
		/// 申请组合录入请求
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="CombActionRef"></param>
		/// <param name="UserID"></param>
		/// <param name="Direction"></param>
		/// <param name="Volume"></param>
		/// <param name="CombDirection"></param>
		/// <param name="HedgeFlag"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="reserve2"></param>
		/// <param name="MacAddress"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="FrontID"></param>
		/// <param name="SessionID"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="IPAddress"></param>
		/// <returns></returns>
		public IntPtr ReqCombActionInsert(string BrokerID = "",string InvestorID = "",string reserve1 = "",string CombActionRef = "",string UserID = "",TThostFtdcDirectionType Direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy,int Volume = 0,TThostFtdcCombDirectionType CombDirection = TThostFtdcCombDirectionType.THOST_FTDC_CMDR_Comb,TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation,string ExchangeID = "",string reserve2 = "",string MacAddress = "",string InvestUnitID = "",int FrontID = 0,int SessionID = 0,string InstrumentID = "",string IPAddress = "")
        {
			CThostFtdcInputCombActionField pInputCombAction = new CThostFtdcInputCombActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				CombActionRef = CombActionRef,
				UserID = UserID,
				Direction = Direction,
				Volume = Volume,
				CombDirection = CombDirection,
				HedgeFlag = HedgeFlag,
				ExchangeID = ExchangeID,
				reserve2 = reserve2,
				MacAddress = MacAddress,
				InvestUnitID = InvestUnitID,
				FrontID = FrontID,
				SessionID = SessionID,
				InstrumentID = InstrumentID,
				IPAddress = IPAddress,
			};
            return (loader.Invoke( "ReqCombActionInsert", typeof(DeleReqCombActionInsert)) as DeleReqCombActionInsert)(_api, ref pInputCombAction, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询报单
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="OrderSysID"></param>
		/// <param name="InsertTimeStart"></param>
		/// <param name="InsertTimeEnd"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryOrder(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string OrderSysID = "",string InsertTimeStart = "",string InsertTimeEnd = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryOrderField pQryOrder = new CThostFtdcQryOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				OrderSysID = OrderSysID,
				InsertTimeStart = InsertTimeStart,
				InsertTimeEnd = InsertTimeEnd,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryOrder", typeof(DeleReqQryOrder)) as DeleReqQryOrder)(_api, ref pQryOrder, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询成交
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="TradeID"></param>
		/// <param name="TradeTimeStart"></param>
		/// <param name="TradeTimeEnd"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryTrade(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string TradeID = "",string TradeTimeStart = "",string TradeTimeEnd = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryTradeField pQryTrade = new CThostFtdcQryTradeField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				TradeID = TradeID,
				TradeTimeStart = TradeTimeStart,
				TradeTimeEnd = TradeTimeEnd,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryTrade", typeof(DeleReqQryTrade)) as DeleReqQryTrade)(_api, ref pQryTrade, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询投资者持仓
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryInvestorPosition(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryInvestorPositionField pQryInvestorPosition = new CThostFtdcQryInvestorPositionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryInvestorPosition", typeof(DeleReqQryInvestorPosition)) as DeleReqQryInvestorPosition)(_api, ref pQryInvestorPosition, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询资金账户
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="CurrencyID"></param>
		/// <param name="BizType"></param>
		/// <param name="AccountID"></param>
		/// <returns></returns>
		public IntPtr ReqQryTradingAccount(string BrokerID = "",string InvestorID = "",string CurrencyID = "",TThostFtdcBizTypeType BizType = TThostFtdcBizTypeType.THOST_FTDC_BZTP_Future,string AccountID = "")
        {
			CThostFtdcQryTradingAccountField pQryTradingAccount = new CThostFtdcQryTradingAccountField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				CurrencyID = CurrencyID,
				BizType = BizType,
				AccountID = AccountID,
			};
            return (loader.Invoke( "ReqQryTradingAccount", typeof(DeleReqQryTradingAccount)) as DeleReqQryTradingAccount)(_api, ref pQryTradingAccount, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询投资者
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <returns></returns>
		public IntPtr ReqQryInvestor(string BrokerID = "",string InvestorID = "")
        {
			CThostFtdcQryInvestorField pQryInvestor = new CThostFtdcQryInvestorField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
			};
            return (loader.Invoke( "ReqQryInvestor", typeof(DeleReqQryInvestor)) as DeleReqQryInvestor)(_api, ref pQryInvestor, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询交易编码
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="ClientID"></param>
		/// <param name="ClientIDType"></param>
		/// <param name="InvestUnitID"></param>
		/// <returns></returns>
		public IntPtr ReqQryTradingCode(string BrokerID = "",string InvestorID = "",string ExchangeID = "",string ClientID = "",TThostFtdcClientIDTypeType ClientIDType = TThostFtdcClientIDTypeType.THOST_FTDC_CIDT_Speculation,string InvestUnitID = "")
        {
			CThostFtdcQryTradingCodeField pQryTradingCode = new CThostFtdcQryTradingCodeField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ExchangeID = ExchangeID,
				ClientID = ClientID,
				ClientIDType = ClientIDType,
				InvestUnitID = InvestUnitID,
			};
            return (loader.Invoke( "ReqQryTradingCode", typeof(DeleReqQryTradingCode)) as DeleReqQryTradingCode)(_api, ref pQryTradingCode, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询合约保证金率
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="HedgeFlag"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryInstrumentMarginRate(string BrokerID = "",string InvestorID = "",string reserve1 = "",TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation,string ExchangeID = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryInstrumentMarginRateField pQryInstrumentMarginRate = new CThostFtdcQryInstrumentMarginRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				HedgeFlag = HedgeFlag,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryInstrumentMarginRate", typeof(DeleReqQryInstrumentMarginRate)) as DeleReqQryInstrumentMarginRate)(_api, ref pQryInstrumentMarginRate, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询合约手续费率
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryInstrumentCommissionRate(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryInstrumentCommissionRateField pQryInstrumentCommissionRate = new CThostFtdcQryInstrumentCommissionRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryInstrumentCommissionRate", typeof(DeleReqQryInstrumentCommissionRate)) as DeleReqQryInstrumentCommissionRate)(_api, ref pQryInstrumentCommissionRate, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询交易所
		/// </summary>
		/// <param name="ExchangeID"></param>
		/// <returns></returns>
		public IntPtr ReqQryExchange(string ExchangeID = "")
        {
			CThostFtdcQryExchangeField pQryExchange = new CThostFtdcQryExchangeField
			{
				ExchangeID = ExchangeID,
			};
            return (loader.Invoke( "ReqQryExchange", typeof(DeleReqQryExchange)) as DeleReqQryExchange)(_api, ref pQryExchange, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询产品
		/// </summary>
		/// <param name="reserve1"></param>
		/// <param name="ProductClass"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="ProductID"></param>
		/// <returns></returns>
		public IntPtr ReqQryProduct(string reserve1 = "",TThostFtdcProductClassType ProductClass = TThostFtdcProductClassType.THOST_FTDC_PC_Futures,string ExchangeID = "",string ProductID = "")
        {
			CThostFtdcQryProductField pQryProduct = new CThostFtdcQryProductField
			{
				reserve1 = reserve1,
				ProductClass = ProductClass,
				ExchangeID = ExchangeID,
				ProductID = ProductID,
			};
            return (loader.Invoke( "ReqQryProduct", typeof(DeleReqQryProduct)) as DeleReqQryProduct)(_api, ref pQryProduct, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询合约
		/// </summary>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="reserve2"></param>
		/// <param name="reserve3"></param>
		/// <param name="InstrumentID"></param>
		/// <param name="ExchangeInstID"></param>
		/// <param name="ProductID"></param>
		/// <returns></returns>
		public IntPtr ReqQryInstrument(string reserve1 = "",string ExchangeID = "",string reserve2 = "",string reserve3 = "",string InstrumentID = "",string ExchangeInstID = "",string ProductID = "")
        {
			CThostFtdcQryInstrumentField pQryInstrument = new CThostFtdcQryInstrumentField
			{
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				reserve2 = reserve2,
				reserve3 = reserve3,
				InstrumentID = InstrumentID,
				ExchangeInstID = ExchangeInstID,
				ProductID = ProductID,
			};
            return (loader.Invoke( "ReqQryInstrument", typeof(DeleReqQryInstrument)) as DeleReqQryInstrument)(_api, ref pQryInstrument, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询行情
		/// </summary>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryDepthMarketData(string reserve1 = "",string ExchangeID = "",string InstrumentID = "")
        {
			CThostFtdcQryDepthMarketDataField pQryDepthMarketData = new CThostFtdcQryDepthMarketDataField
			{
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryDepthMarketData", typeof(DeleReqQryDepthMarketData)) as DeleReqQryDepthMarketData)(_api, ref pQryDepthMarketData, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询投资者结算结果
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="TradingDay"></param>
		/// <param name="AccountID"></param>
		/// <param name="CurrencyID"></param>
		/// <returns></returns>
		public IntPtr ReqQrySettlementInfo(string BrokerID = "",string InvestorID = "",string TradingDay = "",string AccountID = "",string CurrencyID = "")
        {
			CThostFtdcQrySettlementInfoField pQrySettlementInfo = new CThostFtdcQrySettlementInfoField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				TradingDay = TradingDay,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
			};
            return (loader.Invoke( "ReqQrySettlementInfo", typeof(DeleReqQrySettlementInfo)) as DeleReqQrySettlementInfo)(_api, ref pQrySettlementInfo, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询转帐银行
		/// </summary>
		/// <param name="BankID"></param>
		/// <param name="BankBrchID"></param>
		/// <returns></returns>
		public IntPtr ReqQryTransferBank(string BankID = "",string BankBrchID = "")
        {
			CThostFtdcQryTransferBankField pQryTransferBank = new CThostFtdcQryTransferBankField
			{
				BankID = BankID,
				BankBrchID = BankBrchID,
			};
            return (loader.Invoke( "ReqQryTransferBank", typeof(DeleReqQryTransferBank)) as DeleReqQryTransferBank)(_api, ref pQryTransferBank, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询投资者持仓明细
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryInvestorPositionDetail(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryInvestorPositionDetailField pQryInvestorPositionDetail = new CThostFtdcQryInvestorPositionDetailField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryInvestorPositionDetail", typeof(DeleReqQryInvestorPositionDetail)) as DeleReqQryInvestorPositionDetail)(_api, ref pQryInvestorPositionDetail, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询客户通知
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <returns></returns>
		public IntPtr ReqQryNotice(string BrokerID = "")
        {
			CThostFtdcQryNoticeField pQryNotice = new CThostFtdcQryNoticeField
			{
				BrokerID = BrokerID,
			};
            return (loader.Invoke( "ReqQryNotice", typeof(DeleReqQryNotice)) as DeleReqQryNotice)(_api, ref pQryNotice, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询结算信息确认
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="AccountID"></param>
		/// <param name="CurrencyID"></param>
		/// <returns></returns>
		public IntPtr ReqQrySettlementInfoConfirm(string BrokerID = "",string InvestorID = "",string AccountID = "",string CurrencyID = "")
        {
			CThostFtdcQrySettlementInfoConfirmField pQrySettlementInfoConfirm = new CThostFtdcQrySettlementInfoConfirmField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
			};
            return (loader.Invoke( "ReqQrySettlementInfoConfirm", typeof(DeleReqQrySettlementInfoConfirm)) as DeleReqQrySettlementInfoConfirm)(_api, ref pQrySettlementInfoConfirm, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询投资者持仓明细
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="CombInstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryInvestorPositionCombineDetail(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string InvestUnitID = "",string CombInstrumentID = "")
        {
			CThostFtdcQryInvestorPositionCombineDetailField pQryInvestorPositionCombineDetail = new CThostFtdcQryInvestorPositionCombineDetailField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				CombInstrumentID = CombInstrumentID,
			};
            return (loader.Invoke( "ReqQryInvestorPositionCombineDetail", typeof(DeleReqQryInvestorPositionCombineDetail)) as DeleReqQryInvestorPositionCombineDetail)(_api, ref pQryInvestorPositionCombineDetail, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询保证金监管系统经纪公司资金账户密钥
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <returns></returns>
		public IntPtr ReqQryCFMMCTradingAccountKey(string BrokerID = "",string InvestorID = "")
        {
			CThostFtdcQryCFMMCTradingAccountKeyField pQryCFMMCTradingAccountKey = new CThostFtdcQryCFMMCTradingAccountKeyField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
			};
            return (loader.Invoke( "ReqQryCFMMCTradingAccountKey", typeof(DeleReqQryCFMMCTradingAccountKey)) as DeleReqQryCFMMCTradingAccountKey)(_api, ref pQryCFMMCTradingAccountKey, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询仓单折抵信息
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="reserve1"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryEWarrantOffset(string BrokerID = "",string InvestorID = "",string ExchangeID = "",string reserve1 = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryEWarrantOffsetField pQryEWarrantOffset = new CThostFtdcQryEWarrantOffsetField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ExchangeID = ExchangeID,
				reserve1 = reserve1,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryEWarrantOffset", typeof(DeleReqQryEWarrantOffset)) as DeleReqQryEWarrantOffset)(_api, ref pQryEWarrantOffset, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询投资者品种/跨品种保证金
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="HedgeFlag"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="ProductGroupID"></param>
		/// <returns></returns>
		public IntPtr ReqQryInvestorProductGroupMargin(string BrokerID = "",string InvestorID = "",string reserve1 = "",TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation,string ExchangeID = "",string InvestUnitID = "",string ProductGroupID = "")
        {
			CThostFtdcQryInvestorProductGroupMarginField pQryInvestorProductGroupMargin = new CThostFtdcQryInvestorProductGroupMarginField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				HedgeFlag = HedgeFlag,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				ProductGroupID = ProductGroupID,
			};
            return (loader.Invoke( "ReqQryInvestorProductGroupMargin", typeof(DeleReqQryInvestorProductGroupMargin)) as DeleReqQryInvestorProductGroupMargin)(_api, ref pQryInvestorProductGroupMargin, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询交易所保证金率
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="reserve1"></param>
		/// <param name="HedgeFlag"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryExchangeMarginRate(string BrokerID = "",string reserve1 = "",TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation,string ExchangeID = "",string InstrumentID = "")
        {
			CThostFtdcQryExchangeMarginRateField pQryExchangeMarginRate = new CThostFtdcQryExchangeMarginRateField
			{
				BrokerID = BrokerID,
				reserve1 = reserve1,
				HedgeFlag = HedgeFlag,
				ExchangeID = ExchangeID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryExchangeMarginRate", typeof(DeleReqQryExchangeMarginRate)) as DeleReqQryExchangeMarginRate)(_api, ref pQryExchangeMarginRate, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询交易所调整保证金率
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="reserve1"></param>
		/// <param name="HedgeFlag"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryExchangeMarginRateAdjust(string BrokerID = "",string reserve1 = "",TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation,string InstrumentID = "")
        {
			CThostFtdcQryExchangeMarginRateAdjustField pQryExchangeMarginRateAdjust = new CThostFtdcQryExchangeMarginRateAdjustField
			{
				BrokerID = BrokerID,
				reserve1 = reserve1,
				HedgeFlag = HedgeFlag,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryExchangeMarginRateAdjust", typeof(DeleReqQryExchangeMarginRateAdjust)) as DeleReqQryExchangeMarginRateAdjust)(_api, ref pQryExchangeMarginRateAdjust, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询汇率
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="FromCurrencyID"></param>
		/// <param name="ToCurrencyID"></param>
		/// <returns></returns>
		public IntPtr ReqQryExchangeRate(string BrokerID = "",string FromCurrencyID = "",string ToCurrencyID = "")
        {
			CThostFtdcQryExchangeRateField pQryExchangeRate = new CThostFtdcQryExchangeRateField
			{
				BrokerID = BrokerID,
				FromCurrencyID = FromCurrencyID,
				ToCurrencyID = ToCurrencyID,
			};
            return (loader.Invoke( "ReqQryExchangeRate", typeof(DeleReqQryExchangeRate)) as DeleReqQryExchangeRate)(_api, ref pQryExchangeRate, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询二级代理操作员银期权限
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="UserID"></param>
		/// <param name="AccountID"></param>
		/// <param name="CurrencyID"></param>
		/// <returns></returns>
		public IntPtr ReqQrySecAgentACIDMap(string BrokerID = "",string UserID = "",string AccountID = "",string CurrencyID = "")
        {
			CThostFtdcQrySecAgentACIDMapField pQrySecAgentACIDMap = new CThostFtdcQrySecAgentACIDMapField
			{
				BrokerID = BrokerID,
				UserID = UserID,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
			};
            return (loader.Invoke( "ReqQrySecAgentACIDMap", typeof(DeleReqQrySecAgentACIDMap)) as DeleReqQrySecAgentACIDMap)(_api, ref pQrySecAgentACIDMap, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询产品报价汇率
		/// </summary>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="ProductID"></param>
		/// <returns></returns>
		public IntPtr ReqQryProductExchRate(string reserve1 = "",string ExchangeID = "",string ProductID = "")
        {
			CThostFtdcQryProductExchRateField pQryProductExchRate = new CThostFtdcQryProductExchRateField
			{
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				ProductID = ProductID,
			};
            return (loader.Invoke( "ReqQryProductExchRate", typeof(DeleReqQryProductExchRate)) as DeleReqQryProductExchRate)(_api, ref pQryProductExchRate, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询产品组
		/// </summary>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="ProductID"></param>
		/// <returns></returns>
		public IntPtr ReqQryProductGroup(string reserve1 = "",string ExchangeID = "",string ProductID = "")
        {
			CThostFtdcQryProductGroupField pQryProductGroup = new CThostFtdcQryProductGroupField
			{
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				ProductID = ProductID,
			};
            return (loader.Invoke( "ReqQryProductGroup", typeof(DeleReqQryProductGroup)) as DeleReqQryProductGroup)(_api, ref pQryProductGroup, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询做市商合约手续费率
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryMMInstrumentCommissionRate(string BrokerID = "",string InvestorID = "",string reserve1 = "",string InstrumentID = "")
        {
			CThostFtdcQryMMInstrumentCommissionRateField pQryMMInstrumentCommissionRate = new CThostFtdcQryMMInstrumentCommissionRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryMMInstrumentCommissionRate", typeof(DeleReqQryMMInstrumentCommissionRate)) as DeleReqQryMMInstrumentCommissionRate)(_api, ref pQryMMInstrumentCommissionRate, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询做市商期权合约手续费
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryMMOptionInstrCommRate(string BrokerID = "",string InvestorID = "",string reserve1 = "",string InstrumentID = "")
        {
			CThostFtdcQryMMOptionInstrCommRateField pQryMMOptionInstrCommRate = new CThostFtdcQryMMOptionInstrCommRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryMMOptionInstrCommRate", typeof(DeleReqQryMMOptionInstrCommRate)) as DeleReqQryMMOptionInstrCommRate)(_api, ref pQryMMOptionInstrCommRate, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询报单手续费
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryInstrumentOrderCommRate(string BrokerID = "",string InvestorID = "",string reserve1 = "",string InstrumentID = "")
        {
			CThostFtdcQryInstrumentOrderCommRateField pQryInstrumentOrderCommRate = new CThostFtdcQryInstrumentOrderCommRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryInstrumentOrderCommRate", typeof(DeleReqQryInstrumentOrderCommRate)) as DeleReqQryInstrumentOrderCommRate)(_api, ref pQryInstrumentOrderCommRate, this.nRequestID++);
        }

		/// <summary>
		/// 请求二级代理查询资金账户
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="CurrencyID"></param>
		/// <param name="BizType"></param>
		/// <param name="AccountID"></param>
		/// <returns></returns>
		public IntPtr ReqQrySecAgentTradingAccount(string BrokerID = "",string InvestorID = "",string CurrencyID = "",TThostFtdcBizTypeType BizType = TThostFtdcBizTypeType.THOST_FTDC_BZTP_Future,string AccountID = "")
        {
			CThostFtdcQryTradingAccountField pQryTradingAccount = new CThostFtdcQryTradingAccountField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				CurrencyID = CurrencyID,
				BizType = BizType,
				AccountID = AccountID,
			};
            return (loader.Invoke( "ReqQrySecAgentTradingAccount", typeof(DeleReqQrySecAgentTradingAccount)) as DeleReqQrySecAgentTradingAccount)(_api, ref pQryTradingAccount, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询二级代理商资金校验模式
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <returns></returns>
		public IntPtr ReqQrySecAgentCheckMode(string BrokerID = "",string InvestorID = "")
        {
			CThostFtdcQrySecAgentCheckModeField pQrySecAgentCheckMode = new CThostFtdcQrySecAgentCheckModeField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
			};
            return (loader.Invoke( "ReqQrySecAgentCheckMode", typeof(DeleReqQrySecAgentCheckMode)) as DeleReqQrySecAgentCheckMode)(_api, ref pQrySecAgentCheckMode, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询二级代理商信息
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="BrokerSecAgentID"></param>
		/// <returns></returns>
		public IntPtr ReqQrySecAgentTradeInfo(string BrokerID = "",string BrokerSecAgentID = "")
        {
			CThostFtdcQrySecAgentTradeInfoField pQrySecAgentTradeInfo = new CThostFtdcQrySecAgentTradeInfoField
			{
				BrokerID = BrokerID,
				BrokerSecAgentID = BrokerSecAgentID,
			};
            return (loader.Invoke( "ReqQrySecAgentTradeInfo", typeof(DeleReqQrySecAgentTradeInfo)) as DeleReqQrySecAgentTradeInfo)(_api, ref pQrySecAgentTradeInfo, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询期权交易成本
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="HedgeFlag"></param>
		/// <param name="InputPrice"></param>
		/// <param name="UnderlyingPrice"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryOptionInstrTradeCost(string BrokerID = "",string InvestorID = "",string reserve1 = "",TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation,double InputPrice = 0.0,double UnderlyingPrice = 0.0,string ExchangeID = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryOptionInstrTradeCostField pQryOptionInstrTradeCost = new CThostFtdcQryOptionInstrTradeCostField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				HedgeFlag = HedgeFlag,
				InputPrice = InputPrice,
				UnderlyingPrice = UnderlyingPrice,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryOptionInstrTradeCost", typeof(DeleReqQryOptionInstrTradeCost)) as DeleReqQryOptionInstrTradeCost)(_api, ref pQryOptionInstrTradeCost, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询期权合约手续费
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryOptionInstrCommRate(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryOptionInstrCommRateField pQryOptionInstrCommRate = new CThostFtdcQryOptionInstrCommRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryOptionInstrCommRate", typeof(DeleReqQryOptionInstrCommRate)) as DeleReqQryOptionInstrCommRate)(_api, ref pQryOptionInstrCommRate, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询执行宣告
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="ExecOrderSysID"></param>
		/// <param name="InsertTimeStart"></param>
		/// <param name="InsertTimeEnd"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryExecOrder(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string ExecOrderSysID = "",string InsertTimeStart = "",string InsertTimeEnd = "",string InstrumentID = "")
        {
			CThostFtdcQryExecOrderField pQryExecOrder = new CThostFtdcQryExecOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				ExecOrderSysID = ExecOrderSysID,
				InsertTimeStart = InsertTimeStart,
				InsertTimeEnd = InsertTimeEnd,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryExecOrder", typeof(DeleReqQryExecOrder)) as DeleReqQryExecOrder)(_api, ref pQryExecOrder, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询询价
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InsertTimeStart"></param>
		/// <param name="InsertTimeEnd"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryForQuote(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string InsertTimeStart = "",string InsertTimeEnd = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryForQuoteField pQryForQuote = new CThostFtdcQryForQuoteField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				InsertTimeStart = InsertTimeStart,
				InsertTimeEnd = InsertTimeEnd,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryForQuote", typeof(DeleReqQryForQuote)) as DeleReqQryForQuote)(_api, ref pQryForQuote, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询报价
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="QuoteSysID"></param>
		/// <param name="InsertTimeStart"></param>
		/// <param name="InsertTimeEnd"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryQuote(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string QuoteSysID = "",string InsertTimeStart = "",string InsertTimeEnd = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryQuoteField pQryQuote = new CThostFtdcQryQuoteField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				QuoteSysID = QuoteSysID,
				InsertTimeStart = InsertTimeStart,
				InsertTimeEnd = InsertTimeEnd,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryQuote", typeof(DeleReqQryQuote)) as DeleReqQryQuote)(_api, ref pQryQuote, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询期权自对冲
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="OptionSelfCloseSysID"></param>
		/// <param name="InsertTimeStart"></param>
		/// <param name="InsertTimeEnd"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryOptionSelfClose(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string OptionSelfCloseSysID = "",string InsertTimeStart = "",string InsertTimeEnd = "",string InstrumentID = "")
        {
			CThostFtdcQryOptionSelfCloseField pQryOptionSelfClose = new CThostFtdcQryOptionSelfCloseField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				OptionSelfCloseSysID = OptionSelfCloseSysID,
				InsertTimeStart = InsertTimeStart,
				InsertTimeEnd = InsertTimeEnd,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryOptionSelfClose", typeof(DeleReqQryOptionSelfClose)) as DeleReqQryOptionSelfClose)(_api, ref pQryOptionSelfClose, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询投资单元
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="InvestUnitID"></param>
		/// <returns></returns>
		public IntPtr ReqQryInvestUnit(string BrokerID = "",string InvestorID = "",string InvestUnitID = "")
        {
			CThostFtdcQryInvestUnitField pQryInvestUnit = new CThostFtdcQryInvestUnitField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InvestUnitID = InvestUnitID,
			};
            return (loader.Invoke( "ReqQryInvestUnit", typeof(DeleReqQryInvestUnit)) as DeleReqQryInvestUnit)(_api, ref pQryInvestUnit, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询组合合约安全系数
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryCombInstrumentGuard(string BrokerID = "",string reserve1 = "",string ExchangeID = "",string InstrumentID = "")
        {
			CThostFtdcQryCombInstrumentGuardField pQryCombInstrumentGuard = new CThostFtdcQryCombInstrumentGuardField
			{
				BrokerID = BrokerID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryCombInstrumentGuard", typeof(DeleReqQryCombInstrumentGuard)) as DeleReqQryCombInstrumentGuard)(_api, ref pQryCombInstrumentGuard, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询申请组合
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryCombAction(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryCombActionField pQryCombAction = new CThostFtdcQryCombActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryCombAction", typeof(DeleReqQryCombAction)) as DeleReqQryCombAction)(_api, ref pQryCombAction, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询转帐流水
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="AccountID"></param>
		/// <param name="BankID"></param>
		/// <param name="CurrencyID"></param>
		/// <returns></returns>
		public IntPtr ReqQryTransferSerial(string BrokerID = "",string AccountID = "",string BankID = "",string CurrencyID = "")
        {
			CThostFtdcQryTransferSerialField pQryTransferSerial = new CThostFtdcQryTransferSerialField
			{
				BrokerID = BrokerID,
				AccountID = AccountID,
				BankID = BankID,
				CurrencyID = CurrencyID,
			};
            return (loader.Invoke( "ReqQryTransferSerial", typeof(DeleReqQryTransferSerial)) as DeleReqQryTransferSerial)(_api, ref pQryTransferSerial, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询银期签约关系
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="AccountID"></param>
		/// <param name="BankID"></param>
		/// <param name="BankBranchID"></param>
		/// <param name="CurrencyID"></param>
		/// <returns></returns>
		public IntPtr ReqQryAccountregister(string BrokerID = "",string AccountID = "",string BankID = "",string BankBranchID = "",string CurrencyID = "")
        {
			CThostFtdcQryAccountregisterField pQryAccountregister = new CThostFtdcQryAccountregisterField
			{
				BrokerID = BrokerID,
				AccountID = AccountID,
				BankID = BankID,
				BankBranchID = BankBranchID,
				CurrencyID = CurrencyID,
			};
            return (loader.Invoke( "ReqQryAccountregister", typeof(DeleReqQryAccountregister)) as DeleReqQryAccountregister)(_api, ref pQryAccountregister, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询签约银行
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="BankID"></param>
		/// <param name="BankBrchID"></param>
		/// <returns></returns>
		public IntPtr ReqQryContractBank(string BrokerID = "",string BankID = "",string BankBrchID = "")
        {
			CThostFtdcQryContractBankField pQryContractBank = new CThostFtdcQryContractBankField
			{
				BrokerID = BrokerID,
				BankID = BankID,
				BankBrchID = BankBrchID,
			};
            return (loader.Invoke( "ReqQryContractBank", typeof(DeleReqQryContractBank)) as DeleReqQryContractBank)(_api, ref pQryContractBank, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询预埋单
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryParkedOrder(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryParkedOrderField pQryParkedOrder = new CThostFtdcQryParkedOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryParkedOrder", typeof(DeleReqQryParkedOrder)) as DeleReqQryParkedOrder)(_api, ref pQryParkedOrder, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询预埋撤单
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="reserve1"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="InvestUnitID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryParkedOrderAction(string BrokerID = "",string InvestorID = "",string reserve1 = "",string ExchangeID = "",string InvestUnitID = "",string InstrumentID = "")
        {
			CThostFtdcQryParkedOrderActionField pQryParkedOrderAction = new CThostFtdcQryParkedOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				reserve1 = reserve1,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryParkedOrderAction", typeof(DeleReqQryParkedOrderAction)) as DeleReqQryParkedOrderAction)(_api, ref pQryParkedOrderAction, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询交易通知
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="InvestUnitID"></param>
		/// <returns></returns>
		public IntPtr ReqQryTradingNotice(string BrokerID = "",string InvestorID = "",string InvestUnitID = "")
        {
			CThostFtdcQryTradingNoticeField pQryTradingNotice = new CThostFtdcQryTradingNoticeField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InvestUnitID = InvestUnitID,
			};
            return (loader.Invoke( "ReqQryTradingNotice", typeof(DeleReqQryTradingNotice)) as DeleReqQryTradingNotice)(_api, ref pQryTradingNotice, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询经纪公司交易参数
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="CurrencyID"></param>
		/// <param name="AccountID"></param>
		/// <returns></returns>
		public IntPtr ReqQryBrokerTradingParams(string BrokerID = "",string InvestorID = "",string CurrencyID = "",string AccountID = "")
        {
			CThostFtdcQryBrokerTradingParamsField pQryBrokerTradingParams = new CThostFtdcQryBrokerTradingParamsField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				CurrencyID = CurrencyID,
				AccountID = AccountID,
			};
            return (loader.Invoke( "ReqQryBrokerTradingParams", typeof(DeleReqQryBrokerTradingParams)) as DeleReqQryBrokerTradingParams)(_api, ref pQryBrokerTradingParams, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询经纪公司交易算法
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="reserve1"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryBrokerTradingAlgos(string BrokerID = "",string ExchangeID = "",string reserve1 = "",string InstrumentID = "")
        {
			CThostFtdcQryBrokerTradingAlgosField pQryBrokerTradingAlgos = new CThostFtdcQryBrokerTradingAlgosField
			{
				BrokerID = BrokerID,
				ExchangeID = ExchangeID,
				reserve1 = reserve1,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryBrokerTradingAlgos", typeof(DeleReqQryBrokerTradingAlgos)) as DeleReqQryBrokerTradingAlgos)(_api, ref pQryBrokerTradingAlgos, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询监控中心用户令牌
		/// </summary>
		/// <param name="BrokerID"></param>
		/// <param name="InvestorID"></param>
		/// <param name="InvestUnitID"></param>
		/// <returns></returns>
		public IntPtr ReqQueryCFMMCTradingAccountToken(string BrokerID = "",string InvestorID = "",string InvestUnitID = "")
        {
			CThostFtdcQueryCFMMCTradingAccountTokenField pQueryCFMMCTradingAccountToken = new CThostFtdcQueryCFMMCTradingAccountTokenField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InvestUnitID = InvestUnitID,
			};
            return (loader.Invoke( "ReqQueryCFMMCTradingAccountToken", typeof(DeleReqQueryCFMMCTradingAccountToken)) as DeleReqQueryCFMMCTradingAccountToken)(_api, ref pQueryCFMMCTradingAccountToken, this.nRequestID++);
        }

		/// <summary>
		/// 期货发起银行资金转期货请求
		/// </summary>
		/// <param name="TradeCode"></param>
		/// <param name="BankID"></param>
		/// <param name="BankBranchID"></param>
		/// <param name="BrokerID"></param>
		/// <param name="BrokerBranchID"></param>
		/// <param name="TradeDate"></param>
		/// <param name="TradeTime"></param>
		/// <param name="BankSerial"></param>
		/// <param name="TradingDay"></param>
		/// <param name="PlateSerial"></param>
		/// <param name="LastFragment"></param>
		/// <param name="SessionID"></param>
		/// <param name="CustomerName"></param>
		/// <param name="IdCardType"></param>
		/// <param name="IdentifiedCardNo"></param>
		/// <param name="CustType"></param>
		/// <param name="BankAccount"></param>
		/// <param name="BankPassWord"></param>
		/// <param name="AccountID"></param>
		/// <param name="Password"></param>
		/// <param name="InstallID"></param>
		/// <param name="FutureSerial"></param>
		/// <param name="UserID"></param>
		/// <param name="VerifyCertNoFlag"></param>
		/// <param name="CurrencyID"></param>
		/// <param name="TradeAmount"></param>
		/// <param name="FutureFetchAmount"></param>
		/// <param name="FeePayFlag"></param>
		/// <param name="CustFee"></param>
		/// <param name="BrokerFee"></param>
		/// <param name="Message"></param>
		/// <param name="Digest"></param>
		/// <param name="BankAccType"></param>
		/// <param name="DeviceID"></param>
		/// <param name="BankSecuAccType"></param>
		/// <param name="BrokerIDByBank"></param>
		/// <param name="BankSecuAcc"></param>
		/// <param name="BankPwdFlag"></param>
		/// <param name="SecuPwdFlag"></param>
		/// <param name="OperNo"></param>
		/// <param name="RequestID"></param>
		/// <param name="TID"></param>
		/// <param name="TransferStatus"></param>
		/// <param name="LongCustomerName"></param>
		/// <returns></returns>
		public IntPtr ReqFromBankToFutureByFuture(string TradeCode = "",string BankID = "",string BankBranchID = "",string BrokerID = "",string BrokerBranchID = "",string TradeDate = "",string TradeTime = "",string BankSerial = "",string TradingDay = "",int PlateSerial = 0,TThostFtdcLastFragmentType LastFragment = TThostFtdcLastFragmentType.THOST_FTDC_LF_Yes,int SessionID = 0,string CustomerName = "",TThostFtdcIdCardTypeType IdCardType = TThostFtdcIdCardTypeType.THOST_FTDC_ICT_EID,string IdentifiedCardNo = "",TThostFtdcCustTypeType CustType = TThostFtdcCustTypeType.THOST_FTDC_CUSTT_Person,string BankAccount = "",string BankPassWord = "",string AccountID = "",string Password = "",int InstallID = 0,int FutureSerial = 0,string UserID = "",TThostFtdcYesNoIndicatorType VerifyCertNoFlag = TThostFtdcYesNoIndicatorType.THOST_FTDC_YNI_Yes,string CurrencyID = "",double TradeAmount = 0.0,double FutureFetchAmount = 0.0,TThostFtdcFeePayFlagType FeePayFlag = TThostFtdcFeePayFlagType.THOST_FTDC_FPF_BEN,double CustFee = 0.0,double BrokerFee = 0.0,string Message = "",string Digest = "",TThostFtdcBankAccTypeType BankAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook,string DeviceID = "",TThostFtdcBankAccTypeType BankSecuAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook,string BrokerIDByBank = "",string BankSecuAcc = "",TThostFtdcPwdFlagType BankPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck,TThostFtdcPwdFlagType SecuPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck,string OperNo = "",int RequestID = 0,int TID = 0,TThostFtdcTransferStatusType TransferStatus = TThostFtdcTransferStatusType.THOST_FTDC_TRFS_Normal,string LongCustomerName = "")
        {
			CThostFtdcReqTransferField pReqTransfer = new CThostFtdcReqTransferField
			{
				TradeCode = TradeCode,
				BankID = BankID,
				BankBranchID = BankBranchID,
				BrokerID = BrokerID,
				BrokerBranchID = BrokerBranchID,
				TradeDate = TradeDate,
				TradeTime = TradeTime,
				BankSerial = BankSerial,
				TradingDay = TradingDay,
				PlateSerial = PlateSerial,
				LastFragment = LastFragment,
				SessionID = SessionID,
				CustomerName = CustomerName,
				IdCardType = IdCardType,
				IdentifiedCardNo = IdentifiedCardNo,
				CustType = CustType,
				BankAccount = BankAccount,
				BankPassWord = BankPassWord,
				AccountID = AccountID,
				Password = Password,
				InstallID = InstallID,
				FutureSerial = FutureSerial,
				UserID = UserID,
				VerifyCertNoFlag = VerifyCertNoFlag,
				CurrencyID = CurrencyID,
				TradeAmount = TradeAmount,
				FutureFetchAmount = FutureFetchAmount,
				FeePayFlag = FeePayFlag,
				CustFee = CustFee,
				BrokerFee = BrokerFee,
				Message = Message,
				Digest = Digest,
				BankAccType = BankAccType,
				DeviceID = DeviceID,
				BankSecuAccType = BankSecuAccType,
				BrokerIDByBank = BrokerIDByBank,
				BankSecuAcc = BankSecuAcc,
				BankPwdFlag = BankPwdFlag,
				SecuPwdFlag = SecuPwdFlag,
				OperNo = OperNo,
				RequestID = RequestID,
				TID = TID,
				TransferStatus = TransferStatus,
				LongCustomerName = LongCustomerName,
			};
            return (loader.Invoke( "ReqFromBankToFutureByFuture", typeof(DeleReqFromBankToFutureByFuture)) as DeleReqFromBankToFutureByFuture)(_api, ref pReqTransfer, this.nRequestID++);
        }

		/// <summary>
		/// 期货发起期货资金转银行请求
		/// </summary>
		/// <param name="TradeCode"></param>
		/// <param name="BankID"></param>
		/// <param name="BankBranchID"></param>
		/// <param name="BrokerID"></param>
		/// <param name="BrokerBranchID"></param>
		/// <param name="TradeDate"></param>
		/// <param name="TradeTime"></param>
		/// <param name="BankSerial"></param>
		/// <param name="TradingDay"></param>
		/// <param name="PlateSerial"></param>
		/// <param name="LastFragment"></param>
		/// <param name="SessionID"></param>
		/// <param name="CustomerName"></param>
		/// <param name="IdCardType"></param>
		/// <param name="IdentifiedCardNo"></param>
		/// <param name="CustType"></param>
		/// <param name="BankAccount"></param>
		/// <param name="BankPassWord"></param>
		/// <param name="AccountID"></param>
		/// <param name="Password"></param>
		/// <param name="InstallID"></param>
		/// <param name="FutureSerial"></param>
		/// <param name="UserID"></param>
		/// <param name="VerifyCertNoFlag"></param>
		/// <param name="CurrencyID"></param>
		/// <param name="TradeAmount"></param>
		/// <param name="FutureFetchAmount"></param>
		/// <param name="FeePayFlag"></param>
		/// <param name="CustFee"></param>
		/// <param name="BrokerFee"></param>
		/// <param name="Message"></param>
		/// <param name="Digest"></param>
		/// <param name="BankAccType"></param>
		/// <param name="DeviceID"></param>
		/// <param name="BankSecuAccType"></param>
		/// <param name="BrokerIDByBank"></param>
		/// <param name="BankSecuAcc"></param>
		/// <param name="BankPwdFlag"></param>
		/// <param name="SecuPwdFlag"></param>
		/// <param name="OperNo"></param>
		/// <param name="RequestID"></param>
		/// <param name="TID"></param>
		/// <param name="TransferStatus"></param>
		/// <param name="LongCustomerName"></param>
		/// <returns></returns>
		public IntPtr ReqFromFutureToBankByFuture(string TradeCode = "",string BankID = "",string BankBranchID = "",string BrokerID = "",string BrokerBranchID = "",string TradeDate = "",string TradeTime = "",string BankSerial = "",string TradingDay = "",int PlateSerial = 0,TThostFtdcLastFragmentType LastFragment = TThostFtdcLastFragmentType.THOST_FTDC_LF_Yes,int SessionID = 0,string CustomerName = "",TThostFtdcIdCardTypeType IdCardType = TThostFtdcIdCardTypeType.THOST_FTDC_ICT_EID,string IdentifiedCardNo = "",TThostFtdcCustTypeType CustType = TThostFtdcCustTypeType.THOST_FTDC_CUSTT_Person,string BankAccount = "",string BankPassWord = "",string AccountID = "",string Password = "",int InstallID = 0,int FutureSerial = 0,string UserID = "",TThostFtdcYesNoIndicatorType VerifyCertNoFlag = TThostFtdcYesNoIndicatorType.THOST_FTDC_YNI_Yes,string CurrencyID = "",double TradeAmount = 0.0,double FutureFetchAmount = 0.0,TThostFtdcFeePayFlagType FeePayFlag = TThostFtdcFeePayFlagType.THOST_FTDC_FPF_BEN,double CustFee = 0.0,double BrokerFee = 0.0,string Message = "",string Digest = "",TThostFtdcBankAccTypeType BankAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook,string DeviceID = "",TThostFtdcBankAccTypeType BankSecuAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook,string BrokerIDByBank = "",string BankSecuAcc = "",TThostFtdcPwdFlagType BankPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck,TThostFtdcPwdFlagType SecuPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck,string OperNo = "",int RequestID = 0,int TID = 0,TThostFtdcTransferStatusType TransferStatus = TThostFtdcTransferStatusType.THOST_FTDC_TRFS_Normal,string LongCustomerName = "")
        {
			CThostFtdcReqTransferField pReqTransfer = new CThostFtdcReqTransferField
			{
				TradeCode = TradeCode,
				BankID = BankID,
				BankBranchID = BankBranchID,
				BrokerID = BrokerID,
				BrokerBranchID = BrokerBranchID,
				TradeDate = TradeDate,
				TradeTime = TradeTime,
				BankSerial = BankSerial,
				TradingDay = TradingDay,
				PlateSerial = PlateSerial,
				LastFragment = LastFragment,
				SessionID = SessionID,
				CustomerName = CustomerName,
				IdCardType = IdCardType,
				IdentifiedCardNo = IdentifiedCardNo,
				CustType = CustType,
				BankAccount = BankAccount,
				BankPassWord = BankPassWord,
				AccountID = AccountID,
				Password = Password,
				InstallID = InstallID,
				FutureSerial = FutureSerial,
				UserID = UserID,
				VerifyCertNoFlag = VerifyCertNoFlag,
				CurrencyID = CurrencyID,
				TradeAmount = TradeAmount,
				FutureFetchAmount = FutureFetchAmount,
				FeePayFlag = FeePayFlag,
				CustFee = CustFee,
				BrokerFee = BrokerFee,
				Message = Message,
				Digest = Digest,
				BankAccType = BankAccType,
				DeviceID = DeviceID,
				BankSecuAccType = BankSecuAccType,
				BrokerIDByBank = BrokerIDByBank,
				BankSecuAcc = BankSecuAcc,
				BankPwdFlag = BankPwdFlag,
				SecuPwdFlag = SecuPwdFlag,
				OperNo = OperNo,
				RequestID = RequestID,
				TID = TID,
				TransferStatus = TransferStatus,
				LongCustomerName = LongCustomerName,
			};
            return (loader.Invoke( "ReqFromFutureToBankByFuture", typeof(DeleReqFromFutureToBankByFuture)) as DeleReqFromFutureToBankByFuture)(_api, ref pReqTransfer, this.nRequestID++);
        }

		/// <summary>
		/// 期货发起查询银行余额请求
		/// </summary>
		/// <param name="TradeCode"></param>
		/// <param name="BankID"></param>
		/// <param name="BankBranchID"></param>
		/// <param name="BrokerID"></param>
		/// <param name="BrokerBranchID"></param>
		/// <param name="TradeDate"></param>
		/// <param name="TradeTime"></param>
		/// <param name="BankSerial"></param>
		/// <param name="TradingDay"></param>
		/// <param name="PlateSerial"></param>
		/// <param name="LastFragment"></param>
		/// <param name="SessionID"></param>
		/// <param name="CustomerName"></param>
		/// <param name="IdCardType"></param>
		/// <param name="IdentifiedCardNo"></param>
		/// <param name="CustType"></param>
		/// <param name="BankAccount"></param>
		/// <param name="BankPassWord"></param>
		/// <param name="AccountID"></param>
		/// <param name="Password"></param>
		/// <param name="FutureSerial"></param>
		/// <param name="InstallID"></param>
		/// <param name="UserID"></param>
		/// <param name="VerifyCertNoFlag"></param>
		/// <param name="CurrencyID"></param>
		/// <param name="Digest"></param>
		/// <param name="BankAccType"></param>
		/// <param name="DeviceID"></param>
		/// <param name="BankSecuAccType"></param>
		/// <param name="BrokerIDByBank"></param>
		/// <param name="BankSecuAcc"></param>
		/// <param name="BankPwdFlag"></param>
		/// <param name="SecuPwdFlag"></param>
		/// <param name="OperNo"></param>
		/// <param name="RequestID"></param>
		/// <param name="TID"></param>
		/// <param name="LongCustomerName"></param>
		/// <returns></returns>
		public IntPtr ReqQueryBankAccountMoneyByFuture(string TradeCode = "",string BankID = "",string BankBranchID = "",string BrokerID = "",string BrokerBranchID = "",string TradeDate = "",string TradeTime = "",string BankSerial = "",string TradingDay = "",int PlateSerial = 0,TThostFtdcLastFragmentType LastFragment = TThostFtdcLastFragmentType.THOST_FTDC_LF_Yes,int SessionID = 0,string CustomerName = "",TThostFtdcIdCardTypeType IdCardType = TThostFtdcIdCardTypeType.THOST_FTDC_ICT_EID,string IdentifiedCardNo = "",TThostFtdcCustTypeType CustType = TThostFtdcCustTypeType.THOST_FTDC_CUSTT_Person,string BankAccount = "",string BankPassWord = "",string AccountID = "",string Password = "",int FutureSerial = 0,int InstallID = 0,string UserID = "",TThostFtdcYesNoIndicatorType VerifyCertNoFlag = TThostFtdcYesNoIndicatorType.THOST_FTDC_YNI_Yes,string CurrencyID = "",string Digest = "",TThostFtdcBankAccTypeType BankAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook,string DeviceID = "",TThostFtdcBankAccTypeType BankSecuAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook,string BrokerIDByBank = "",string BankSecuAcc = "",TThostFtdcPwdFlagType BankPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck,TThostFtdcPwdFlagType SecuPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck,string OperNo = "",int RequestID = 0,int TID = 0,string LongCustomerName = "")
        {
			CThostFtdcReqQueryAccountField pReqQueryAccount = new CThostFtdcReqQueryAccountField
			{
				TradeCode = TradeCode,
				BankID = BankID,
				BankBranchID = BankBranchID,
				BrokerID = BrokerID,
				BrokerBranchID = BrokerBranchID,
				TradeDate = TradeDate,
				TradeTime = TradeTime,
				BankSerial = BankSerial,
				TradingDay = TradingDay,
				PlateSerial = PlateSerial,
				LastFragment = LastFragment,
				SessionID = SessionID,
				CustomerName = CustomerName,
				IdCardType = IdCardType,
				IdentifiedCardNo = IdentifiedCardNo,
				CustType = CustType,
				BankAccount = BankAccount,
				BankPassWord = BankPassWord,
				AccountID = AccountID,
				Password = Password,
				FutureSerial = FutureSerial,
				InstallID = InstallID,
				UserID = UserID,
				VerifyCertNoFlag = VerifyCertNoFlag,
				CurrencyID = CurrencyID,
				Digest = Digest,
				BankAccType = BankAccType,
				DeviceID = DeviceID,
				BankSecuAccType = BankSecuAccType,
				BrokerIDByBank = BrokerIDByBank,
				BankSecuAcc = BankSecuAcc,
				BankPwdFlag = BankPwdFlag,
				SecuPwdFlag = SecuPwdFlag,
				OperNo = OperNo,
				RequestID = RequestID,
				TID = TID,
				LongCustomerName = LongCustomerName,
			};
            return (loader.Invoke( "ReqQueryBankAccountMoneyByFuture", typeof(DeleReqQueryBankAccountMoneyByFuture)) as DeleReqQueryBankAccountMoneyByFuture)(_api, ref pReqQueryAccount, this.nRequestID++);
        }

		/// <summary>
		/// 请求查询分类合约
		/// </summary>
		/// <param name="InstrumentID"></param>
		/// <param name="ExchangeID"></param>
		/// <param name="ExchangeInstID"></param>
		/// <param name="ProductID"></param>
		/// <param name="TradingType"></param>
		/// <param name="ClassType"></param>
		/// <returns></returns>
		public IntPtr ReqQryClassifiedInstrument(string InstrumentID = "",string ExchangeID = "",string ExchangeInstID = "",string ProductID = "",TThostFtdcTradingTypeType TradingType = TThostFtdcTradingTypeType.THOST_FTDC_TD_ALL,TThostFtdcClassTypeType ClassType = TThostFtdcClassTypeType.THOST_FTDC_INS_ALL)
        {
			CThostFtdcQryClassifiedInstrumentField pQryClassifiedInstrument = new CThostFtdcQryClassifiedInstrumentField
			{
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				ExchangeInstID = ExchangeInstID,
				ProductID = ProductID,
				TradingType = TradingType,
				ClassType = ClassType,
			};
            return (loader.Invoke( "ReqQryClassifiedInstrument", typeof(DeleReqQryClassifiedInstrument)) as DeleReqQryClassifiedInstrument)(_api, ref pQryClassifiedInstrument, this.nRequestID++);
        }

		/// <summary>
		/// 请求组合优惠比例
		/// </summary>
		/// <param name="ExchangeID"></param>
		/// <param name="InstrumentID"></param>
		/// <returns></returns>
		public IntPtr ReqQryCombPromotionParam(string ExchangeID = "",string InstrumentID = "")
        {
			CThostFtdcQryCombPromotionParamField pQryCombPromotionParam = new CThostFtdcQryCombPromotionParamField
			{
				ExchangeID = ExchangeID,
				InstrumentID = InstrumentID,
			};
            return (loader.Invoke( "ReqQryCombPromotionParam", typeof(DeleReqQryCombPromotionParam)) as DeleReqQryCombPromotionParam)(_api, ref pQryCombPromotionParam, this.nRequestID++);
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
		public delegate void DeleOnRspAuthenticate(ref CThostFtdcRspAuthenticateField pRspAuthenticateField,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspUserLogin(ref CThostFtdcRspUserLoginField pRspUserLogin,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspUserLogout(ref CThostFtdcUserLogoutField pUserLogout,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspUserPasswordUpdate(ref CThostFtdcUserPasswordUpdateField pUserPasswordUpdate,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspTradingAccountPasswordUpdate(ref CThostFtdcTradingAccountPasswordUpdateField pTradingAccountPasswordUpdate,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspUserAuthMethod(ref CThostFtdcRspUserAuthMethodField pRspUserAuthMethod,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspGenUserCaptcha(ref CThostFtdcRspGenUserCaptchaField pRspGenUserCaptcha,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspGenUserText(ref CThostFtdcRspGenUserTextField pRspGenUserText,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspOrderInsert(ref CThostFtdcInputOrderField pInputOrder,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspParkedOrderInsert(ref CThostFtdcParkedOrderField pParkedOrder,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspParkedOrderAction(ref CThostFtdcParkedOrderActionField pParkedOrderAction,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspOrderAction(ref CThostFtdcInputOrderActionField pInputOrderAction,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryMaxOrderVolume(ref CThostFtdcQryMaxOrderVolumeField pQryMaxOrderVolume,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspSettlementInfoConfirm(ref CThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspRemoveParkedOrder(ref CThostFtdcRemoveParkedOrderField pRemoveParkedOrder,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspRemoveParkedOrderAction(ref CThostFtdcRemoveParkedOrderActionField pRemoveParkedOrderAction,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspExecOrderInsert(ref CThostFtdcInputExecOrderField pInputExecOrder,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspExecOrderAction(ref CThostFtdcInputExecOrderActionField pInputExecOrderAction,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspForQuoteInsert(ref CThostFtdcInputForQuoteField pInputForQuote,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQuoteInsert(ref CThostFtdcInputQuoteField pInputQuote,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQuoteAction(ref CThostFtdcInputQuoteActionField pInputQuoteAction,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspBatchOrderAction(ref CThostFtdcInputBatchOrderActionField pInputBatchOrderAction,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspOptionSelfCloseInsert(ref CThostFtdcInputOptionSelfCloseField pInputOptionSelfClose,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspOptionSelfCloseAction(ref CThostFtdcInputOptionSelfCloseActionField pInputOptionSelfCloseAction,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspCombActionInsert(ref CThostFtdcInputCombActionField pInputCombAction,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryOrder(ref CThostFtdcOrderField pOrder,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryTrade(ref CThostFtdcTradeField pTrade,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryInvestorPosition(ref CThostFtdcInvestorPositionField pInvestorPosition,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryTradingAccount(ref CThostFtdcTradingAccountField pTradingAccount,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryInvestor(ref CThostFtdcInvestorField pInvestor,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryTradingCode(ref CThostFtdcTradingCodeField pTradingCode,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryInstrumentMarginRate(ref CThostFtdcInstrumentMarginRateField pInstrumentMarginRate,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryInstrumentCommissionRate(ref CThostFtdcInstrumentCommissionRateField pInstrumentCommissionRate,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryExchange(ref CThostFtdcExchangeField pExchange,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryProduct(ref CThostFtdcProductField pProduct,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryInstrument(ref CThostFtdcInstrumentField pInstrument,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryDepthMarketData(ref CThostFtdcDepthMarketDataField pDepthMarketData,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQrySettlementInfo(ref CThostFtdcSettlementInfoField pSettlementInfo,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryTransferBank(ref CThostFtdcTransferBankField pTransferBank,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryInvestorPositionDetail(ref CThostFtdcInvestorPositionDetailField pInvestorPositionDetail,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryNotice(ref CThostFtdcNoticeField pNotice,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQrySettlementInfoConfirm(ref CThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryInvestorPositionCombineDetail(ref CThostFtdcInvestorPositionCombineDetailField pInvestorPositionCombineDetail,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryCFMMCTradingAccountKey(ref CThostFtdcCFMMCTradingAccountKeyField pCFMMCTradingAccountKey,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryEWarrantOffset(ref CThostFtdcEWarrantOffsetField pEWarrantOffset,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryInvestorProductGroupMargin(ref CThostFtdcInvestorProductGroupMarginField pInvestorProductGroupMargin,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryExchangeMarginRate(ref CThostFtdcExchangeMarginRateField pExchangeMarginRate,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryExchangeMarginRateAdjust(ref CThostFtdcExchangeMarginRateAdjustField pExchangeMarginRateAdjust,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryExchangeRate(ref CThostFtdcExchangeRateField pExchangeRate,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQrySecAgentACIDMap(ref CThostFtdcSecAgentACIDMapField pSecAgentACIDMap,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryProductExchRate(ref CThostFtdcProductExchRateField pProductExchRate,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryProductGroup(ref CThostFtdcProductGroupField pProductGroup,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryMMInstrumentCommissionRate(ref CThostFtdcMMInstrumentCommissionRateField pMMInstrumentCommissionRate,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryMMOptionInstrCommRate(ref CThostFtdcMMOptionInstrCommRateField pMMOptionInstrCommRate,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryInstrumentOrderCommRate(ref CThostFtdcInstrumentOrderCommRateField pInstrumentOrderCommRate,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQrySecAgentTradingAccount(ref CThostFtdcTradingAccountField pTradingAccount,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQrySecAgentCheckMode(ref CThostFtdcSecAgentCheckModeField pSecAgentCheckMode,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQrySecAgentTradeInfo(ref CThostFtdcSecAgentTradeInfoField pSecAgentTradeInfo,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryOptionInstrTradeCost(ref CThostFtdcOptionInstrTradeCostField pOptionInstrTradeCost,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryOptionInstrCommRate(ref CThostFtdcOptionInstrCommRateField pOptionInstrCommRate,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryExecOrder(ref CThostFtdcExecOrderField pExecOrder,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryForQuote(ref CThostFtdcForQuoteField pForQuote,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryQuote(ref CThostFtdcQuoteField pQuote,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryOptionSelfClose(ref CThostFtdcOptionSelfCloseField pOptionSelfClose,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryInvestUnit(ref CThostFtdcInvestUnitField pInvestUnit,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryCombInstrumentGuard(ref CThostFtdcCombInstrumentGuardField pCombInstrumentGuard,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryCombAction(ref CThostFtdcCombActionField pCombAction,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryTransferSerial(ref CThostFtdcTransferSerialField pTransferSerial,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryAccountregister(ref CThostFtdcAccountregisterField pAccountregister,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspError(ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnOrder(ref CThostFtdcOrderField pOrder);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnTrade(ref CThostFtdcTradeField pTrade);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnOrderInsert(ref CThostFtdcInputOrderField pInputOrder,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnOrderAction(ref CThostFtdcOrderActionField pOrderAction,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnInstrumentStatus(ref CThostFtdcInstrumentStatusField pInstrumentStatus);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnBulletin(ref CThostFtdcBulletinField pBulletin);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnTradingNotice(ref CThostFtdcTradingNoticeInfoField pTradingNoticeInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnErrorConditionalOrder(ref CThostFtdcErrorConditionalOrderField pErrorConditionalOrder);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnExecOrder(ref CThostFtdcExecOrderField pExecOrder);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnExecOrderInsert(ref CThostFtdcInputExecOrderField pInputExecOrder,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnExecOrderAction(ref CThostFtdcExecOrderActionField pExecOrderAction,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnForQuoteInsert(ref CThostFtdcInputForQuoteField pInputForQuote,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnQuote(ref CThostFtdcQuoteField pQuote);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnQuoteInsert(ref CThostFtdcInputQuoteField pInputQuote,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnQuoteAction(ref CThostFtdcQuoteActionField pQuoteAction,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnForQuoteRsp(ref CThostFtdcForQuoteRspField pForQuoteRsp);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnCFMMCTradingAccountToken(ref CThostFtdcCFMMCTradingAccountTokenField pCFMMCTradingAccountToken);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnBatchOrderAction(ref CThostFtdcBatchOrderActionField pBatchOrderAction,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnOptionSelfClose(ref CThostFtdcOptionSelfCloseField pOptionSelfClose);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnOptionSelfCloseInsert(ref CThostFtdcInputOptionSelfCloseField pInputOptionSelfClose,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnOptionSelfCloseAction(ref CThostFtdcOptionSelfCloseActionField pOptionSelfCloseAction,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnCombAction(ref CThostFtdcCombActionField pCombAction);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnCombActionInsert(ref CThostFtdcInputCombActionField pInputCombAction,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryContractBank(ref CThostFtdcContractBankField pContractBank,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryParkedOrder(ref CThostFtdcParkedOrderField pParkedOrder,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryParkedOrderAction(ref CThostFtdcParkedOrderActionField pParkedOrderAction,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryTradingNotice(ref CThostFtdcTradingNoticeField pTradingNotice,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryBrokerTradingParams(ref CThostFtdcBrokerTradingParamsField pBrokerTradingParams,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryBrokerTradingAlgos(ref CThostFtdcBrokerTradingAlgosField pBrokerTradingAlgos,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQueryCFMMCTradingAccountToken(ref CThostFtdcQueryCFMMCTradingAccountTokenField pQueryCFMMCTradingAccountToken,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnFromBankToFutureByBank(ref CThostFtdcRspTransferField pRspTransfer);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnFromFutureToBankByBank(ref CThostFtdcRspTransferField pRspTransfer);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnRepealFromBankToFutureByBank(ref CThostFtdcRspRepealField pRspRepeal);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnRepealFromFutureToBankByBank(ref CThostFtdcRspRepealField pRspRepeal);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnFromBankToFutureByFuture(ref CThostFtdcRspTransferField pRspTransfer);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnFromFutureToBankByFuture(ref CThostFtdcRspTransferField pRspTransfer);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnRepealFromBankToFutureByFutureManual(ref CThostFtdcRspRepealField pRspRepeal);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnRepealFromFutureToBankByFutureManual(ref CThostFtdcRspRepealField pRspRepeal);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnQueryBankBalanceByFuture(ref CThostFtdcNotifyQueryAccountField pNotifyQueryAccount);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnBankToFutureByFuture(ref CThostFtdcReqTransferField pReqTransfer,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnFutureToBankByFuture(ref CThostFtdcReqTransferField pReqTransfer,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnRepealBankToFutureByFutureManual(ref CThostFtdcReqRepealField pReqRepeal,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnRepealFutureToBankByFutureManual(ref CThostFtdcReqRepealField pReqRepeal,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnErrRtnQueryBankBalanceByFuture(ref CThostFtdcReqQueryAccountField pReqQueryAccount,ref CThostFtdcRspInfoField pRspInfo);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnRepealFromBankToFutureByFuture(ref CThostFtdcRspRepealField pRspRepeal);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnRepealFromFutureToBankByFuture(ref CThostFtdcRspRepealField pRspRepeal);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspFromBankToFutureByFuture(ref CThostFtdcReqTransferField pReqTransfer,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspFromFutureToBankByFuture(ref CThostFtdcReqTransferField pReqTransfer,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQueryBankAccountMoneyByFuture(ref CThostFtdcReqQueryAccountField pReqQueryAccount,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnOpenAccountByBank(ref CThostFtdcOpenAccountField pOpenAccount);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnCancelAccountByBank(ref CThostFtdcCancelAccountField pCancelAccount);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRtnChangeAccountByBank(ref CThostFtdcChangeAccountField pChangeAccount);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryClassifiedInstrument(ref CThostFtdcInstrumentField pInstrument,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
		public delegate void DeleOnRspQryCombPromotionParam(ref CThostFtdcCombPromotionParamField pCombPromotionParam,ref CThostFtdcRspInfoField pRspInfo,int nRequestID,bool bIsLast);
		public void SetOnFrontConnected(DeleOnFrontConnected func) {(loader.Invoke( "SetOnFrontConnected", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnFrontDisconnected(DeleOnFrontDisconnected func) {(loader.Invoke( "SetOnFrontDisconnected", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnHeartBeatWarning(DeleOnHeartBeatWarning func) {(loader.Invoke( "SetOnHeartBeatWarning", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspAuthenticate(DeleOnRspAuthenticate func) {(loader.Invoke( "SetOnRspAuthenticate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspUserLogin(DeleOnRspUserLogin func) {(loader.Invoke( "SetOnRspUserLogin", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspUserLogout(DeleOnRspUserLogout func) {(loader.Invoke( "SetOnRspUserLogout", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspUserPasswordUpdate(DeleOnRspUserPasswordUpdate func) {(loader.Invoke( "SetOnRspUserPasswordUpdate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspTradingAccountPasswordUpdate(DeleOnRspTradingAccountPasswordUpdate func) {(loader.Invoke( "SetOnRspTradingAccountPasswordUpdate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspUserAuthMethod(DeleOnRspUserAuthMethod func) {(loader.Invoke( "SetOnRspUserAuthMethod", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspGenUserCaptcha(DeleOnRspGenUserCaptcha func) {(loader.Invoke( "SetOnRspGenUserCaptcha", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspGenUserText(DeleOnRspGenUserText func) {(loader.Invoke( "SetOnRspGenUserText", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspOrderInsert(DeleOnRspOrderInsert func) {(loader.Invoke( "SetOnRspOrderInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspParkedOrderInsert(DeleOnRspParkedOrderInsert func) {(loader.Invoke( "SetOnRspParkedOrderInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspParkedOrderAction(DeleOnRspParkedOrderAction func) {(loader.Invoke( "SetOnRspParkedOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspOrderAction(DeleOnRspOrderAction func) {(loader.Invoke( "SetOnRspOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryMaxOrderVolume(DeleOnRspQryMaxOrderVolume func) {(loader.Invoke( "SetOnRspQryMaxOrderVolume", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspSettlementInfoConfirm(DeleOnRspSettlementInfoConfirm func) {(loader.Invoke( "SetOnRspSettlementInfoConfirm", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspRemoveParkedOrder(DeleOnRspRemoveParkedOrder func) {(loader.Invoke( "SetOnRspRemoveParkedOrder", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspRemoveParkedOrderAction(DeleOnRspRemoveParkedOrderAction func) {(loader.Invoke( "SetOnRspRemoveParkedOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspExecOrderInsert(DeleOnRspExecOrderInsert func) {(loader.Invoke( "SetOnRspExecOrderInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspExecOrderAction(DeleOnRspExecOrderAction func) {(loader.Invoke( "SetOnRspExecOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspForQuoteInsert(DeleOnRspForQuoteInsert func) {(loader.Invoke( "SetOnRspForQuoteInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQuoteInsert(DeleOnRspQuoteInsert func) {(loader.Invoke( "SetOnRspQuoteInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQuoteAction(DeleOnRspQuoteAction func) {(loader.Invoke( "SetOnRspQuoteAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspBatchOrderAction(DeleOnRspBatchOrderAction func) {(loader.Invoke( "SetOnRspBatchOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspOptionSelfCloseInsert(DeleOnRspOptionSelfCloseInsert func) {(loader.Invoke( "SetOnRspOptionSelfCloseInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspOptionSelfCloseAction(DeleOnRspOptionSelfCloseAction func) {(loader.Invoke( "SetOnRspOptionSelfCloseAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspCombActionInsert(DeleOnRspCombActionInsert func) {(loader.Invoke( "SetOnRspCombActionInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryOrder(DeleOnRspQryOrder func) {(loader.Invoke( "SetOnRspQryOrder", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryTrade(DeleOnRspQryTrade func) {(loader.Invoke( "SetOnRspQryTrade", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryInvestorPosition(DeleOnRspQryInvestorPosition func) {(loader.Invoke( "SetOnRspQryInvestorPosition", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryTradingAccount(DeleOnRspQryTradingAccount func) {(loader.Invoke( "SetOnRspQryTradingAccount", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryInvestor(DeleOnRspQryInvestor func) {(loader.Invoke( "SetOnRspQryInvestor", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryTradingCode(DeleOnRspQryTradingCode func) {(loader.Invoke( "SetOnRspQryTradingCode", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryInstrumentMarginRate(DeleOnRspQryInstrumentMarginRate func) {(loader.Invoke( "SetOnRspQryInstrumentMarginRate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryInstrumentCommissionRate(DeleOnRspQryInstrumentCommissionRate func) {(loader.Invoke( "SetOnRspQryInstrumentCommissionRate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryExchange(DeleOnRspQryExchange func) {(loader.Invoke( "SetOnRspQryExchange", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryProduct(DeleOnRspQryProduct func) {(loader.Invoke( "SetOnRspQryProduct", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryInstrument(DeleOnRspQryInstrument func) {(loader.Invoke( "SetOnRspQryInstrument", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryDepthMarketData(DeleOnRspQryDepthMarketData func) {(loader.Invoke( "SetOnRspQryDepthMarketData", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQrySettlementInfo(DeleOnRspQrySettlementInfo func) {(loader.Invoke( "SetOnRspQrySettlementInfo", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryTransferBank(DeleOnRspQryTransferBank func) {(loader.Invoke( "SetOnRspQryTransferBank", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryInvestorPositionDetail(DeleOnRspQryInvestorPositionDetail func) {(loader.Invoke( "SetOnRspQryInvestorPositionDetail", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryNotice(DeleOnRspQryNotice func) {(loader.Invoke( "SetOnRspQryNotice", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQrySettlementInfoConfirm(DeleOnRspQrySettlementInfoConfirm func) {(loader.Invoke( "SetOnRspQrySettlementInfoConfirm", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryInvestorPositionCombineDetail(DeleOnRspQryInvestorPositionCombineDetail func) {(loader.Invoke( "SetOnRspQryInvestorPositionCombineDetail", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryCFMMCTradingAccountKey(DeleOnRspQryCFMMCTradingAccountKey func) {(loader.Invoke( "SetOnRspQryCFMMCTradingAccountKey", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryEWarrantOffset(DeleOnRspQryEWarrantOffset func) {(loader.Invoke( "SetOnRspQryEWarrantOffset", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryInvestorProductGroupMargin(DeleOnRspQryInvestorProductGroupMargin func) {(loader.Invoke( "SetOnRspQryInvestorProductGroupMargin", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryExchangeMarginRate(DeleOnRspQryExchangeMarginRate func) {(loader.Invoke( "SetOnRspQryExchangeMarginRate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryExchangeMarginRateAdjust(DeleOnRspQryExchangeMarginRateAdjust func) {(loader.Invoke( "SetOnRspQryExchangeMarginRateAdjust", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryExchangeRate(DeleOnRspQryExchangeRate func) {(loader.Invoke( "SetOnRspQryExchangeRate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQrySecAgentACIDMap(DeleOnRspQrySecAgentACIDMap func) {(loader.Invoke( "SetOnRspQrySecAgentACIDMap", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryProductExchRate(DeleOnRspQryProductExchRate func) {(loader.Invoke( "SetOnRspQryProductExchRate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryProductGroup(DeleOnRspQryProductGroup func) {(loader.Invoke( "SetOnRspQryProductGroup", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryMMInstrumentCommissionRate(DeleOnRspQryMMInstrumentCommissionRate func) {(loader.Invoke( "SetOnRspQryMMInstrumentCommissionRate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryMMOptionInstrCommRate(DeleOnRspQryMMOptionInstrCommRate func) {(loader.Invoke( "SetOnRspQryMMOptionInstrCommRate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryInstrumentOrderCommRate(DeleOnRspQryInstrumentOrderCommRate func) {(loader.Invoke( "SetOnRspQryInstrumentOrderCommRate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQrySecAgentTradingAccount(DeleOnRspQrySecAgentTradingAccount func) {(loader.Invoke( "SetOnRspQrySecAgentTradingAccount", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQrySecAgentCheckMode(DeleOnRspQrySecAgentCheckMode func) {(loader.Invoke( "SetOnRspQrySecAgentCheckMode", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQrySecAgentTradeInfo(DeleOnRspQrySecAgentTradeInfo func) {(loader.Invoke( "SetOnRspQrySecAgentTradeInfo", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryOptionInstrTradeCost(DeleOnRspQryOptionInstrTradeCost func) {(loader.Invoke( "SetOnRspQryOptionInstrTradeCost", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryOptionInstrCommRate(DeleOnRspQryOptionInstrCommRate func) {(loader.Invoke( "SetOnRspQryOptionInstrCommRate", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryExecOrder(DeleOnRspQryExecOrder func) {(loader.Invoke( "SetOnRspQryExecOrder", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryForQuote(DeleOnRspQryForQuote func) {(loader.Invoke( "SetOnRspQryForQuote", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryQuote(DeleOnRspQryQuote func) {(loader.Invoke( "SetOnRspQryQuote", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryOptionSelfClose(DeleOnRspQryOptionSelfClose func) {(loader.Invoke( "SetOnRspQryOptionSelfClose", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryInvestUnit(DeleOnRspQryInvestUnit func) {(loader.Invoke( "SetOnRspQryInvestUnit", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryCombInstrumentGuard(DeleOnRspQryCombInstrumentGuard func) {(loader.Invoke( "SetOnRspQryCombInstrumentGuard", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryCombAction(DeleOnRspQryCombAction func) {(loader.Invoke( "SetOnRspQryCombAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryTransferSerial(DeleOnRspQryTransferSerial func) {(loader.Invoke( "SetOnRspQryTransferSerial", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryAccountregister(DeleOnRspQryAccountregister func) {(loader.Invoke( "SetOnRspQryAccountregister", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspError(DeleOnRspError func) {(loader.Invoke( "SetOnRspError", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnOrder(DeleOnRtnOrder func) {(loader.Invoke( "SetOnRtnOrder", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnTrade(DeleOnRtnTrade func) {(loader.Invoke( "SetOnRtnTrade", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnOrderInsert(DeleOnErrRtnOrderInsert func) {(loader.Invoke( "SetOnErrRtnOrderInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnOrderAction(DeleOnErrRtnOrderAction func) {(loader.Invoke( "SetOnErrRtnOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnInstrumentStatus(DeleOnRtnInstrumentStatus func) {(loader.Invoke( "SetOnRtnInstrumentStatus", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnBulletin(DeleOnRtnBulletin func) {(loader.Invoke( "SetOnRtnBulletin", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnTradingNotice(DeleOnRtnTradingNotice func) {(loader.Invoke( "SetOnRtnTradingNotice", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnErrorConditionalOrder(DeleOnRtnErrorConditionalOrder func) {(loader.Invoke( "SetOnRtnErrorConditionalOrder", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnExecOrder(DeleOnRtnExecOrder func) {(loader.Invoke( "SetOnRtnExecOrder", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnExecOrderInsert(DeleOnErrRtnExecOrderInsert func) {(loader.Invoke( "SetOnErrRtnExecOrderInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnExecOrderAction(DeleOnErrRtnExecOrderAction func) {(loader.Invoke( "SetOnErrRtnExecOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnForQuoteInsert(DeleOnErrRtnForQuoteInsert func) {(loader.Invoke( "SetOnErrRtnForQuoteInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnQuote(DeleOnRtnQuote func) {(loader.Invoke( "SetOnRtnQuote", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnQuoteInsert(DeleOnErrRtnQuoteInsert func) {(loader.Invoke( "SetOnErrRtnQuoteInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnQuoteAction(DeleOnErrRtnQuoteAction func) {(loader.Invoke( "SetOnErrRtnQuoteAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnForQuoteRsp(DeleOnRtnForQuoteRsp func) {(loader.Invoke( "SetOnRtnForQuoteRsp", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnCFMMCTradingAccountToken(DeleOnRtnCFMMCTradingAccountToken func) {(loader.Invoke( "SetOnRtnCFMMCTradingAccountToken", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnBatchOrderAction(DeleOnErrRtnBatchOrderAction func) {(loader.Invoke( "SetOnErrRtnBatchOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnOptionSelfClose(DeleOnRtnOptionSelfClose func) {(loader.Invoke( "SetOnRtnOptionSelfClose", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnOptionSelfCloseInsert(DeleOnErrRtnOptionSelfCloseInsert func) {(loader.Invoke( "SetOnErrRtnOptionSelfCloseInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnOptionSelfCloseAction(DeleOnErrRtnOptionSelfCloseAction func) {(loader.Invoke( "SetOnErrRtnOptionSelfCloseAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnCombAction(DeleOnRtnCombAction func) {(loader.Invoke( "SetOnRtnCombAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnCombActionInsert(DeleOnErrRtnCombActionInsert func) {(loader.Invoke( "SetOnErrRtnCombActionInsert", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryContractBank(DeleOnRspQryContractBank func) {(loader.Invoke( "SetOnRspQryContractBank", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryParkedOrder(DeleOnRspQryParkedOrder func) {(loader.Invoke( "SetOnRspQryParkedOrder", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryParkedOrderAction(DeleOnRspQryParkedOrderAction func) {(loader.Invoke( "SetOnRspQryParkedOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryTradingNotice(DeleOnRspQryTradingNotice func) {(loader.Invoke( "SetOnRspQryTradingNotice", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryBrokerTradingParams(DeleOnRspQryBrokerTradingParams func) {(loader.Invoke( "SetOnRspQryBrokerTradingParams", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryBrokerTradingAlgos(DeleOnRspQryBrokerTradingAlgos func) {(loader.Invoke( "SetOnRspQryBrokerTradingAlgos", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQueryCFMMCTradingAccountToken(DeleOnRspQueryCFMMCTradingAccountToken func) {(loader.Invoke( "SetOnRspQueryCFMMCTradingAccountToken", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnFromBankToFutureByBank(DeleOnRtnFromBankToFutureByBank func) {(loader.Invoke( "SetOnRtnFromBankToFutureByBank", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnFromFutureToBankByBank(DeleOnRtnFromFutureToBankByBank func) {(loader.Invoke( "SetOnRtnFromFutureToBankByBank", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnRepealFromBankToFutureByBank(DeleOnRtnRepealFromBankToFutureByBank func) {(loader.Invoke( "SetOnRtnRepealFromBankToFutureByBank", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnRepealFromFutureToBankByBank(DeleOnRtnRepealFromFutureToBankByBank func) {(loader.Invoke( "SetOnRtnRepealFromFutureToBankByBank", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnFromBankToFutureByFuture(DeleOnRtnFromBankToFutureByFuture func) {(loader.Invoke( "SetOnRtnFromBankToFutureByFuture", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnFromFutureToBankByFuture(DeleOnRtnFromFutureToBankByFuture func) {(loader.Invoke( "SetOnRtnFromFutureToBankByFuture", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnRepealFromBankToFutureByFutureManual(DeleOnRtnRepealFromBankToFutureByFutureManual func) {(loader.Invoke( "SetOnRtnRepealFromBankToFutureByFutureManual", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnRepealFromFutureToBankByFutureManual(DeleOnRtnRepealFromFutureToBankByFutureManual func) {(loader.Invoke( "SetOnRtnRepealFromFutureToBankByFutureManual", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnQueryBankBalanceByFuture(DeleOnRtnQueryBankBalanceByFuture func) {(loader.Invoke( "SetOnRtnQueryBankBalanceByFuture", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnBankToFutureByFuture(DeleOnErrRtnBankToFutureByFuture func) {(loader.Invoke( "SetOnErrRtnBankToFutureByFuture", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnFutureToBankByFuture(DeleOnErrRtnFutureToBankByFuture func) {(loader.Invoke( "SetOnErrRtnFutureToBankByFuture", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnRepealBankToFutureByFutureManual(DeleOnErrRtnRepealBankToFutureByFutureManual func) {(loader.Invoke( "SetOnErrRtnRepealBankToFutureByFutureManual", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnRepealFutureToBankByFutureManual(DeleOnErrRtnRepealFutureToBankByFutureManual func) {(loader.Invoke( "SetOnErrRtnRepealFutureToBankByFutureManual", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnErrRtnQueryBankBalanceByFuture(DeleOnErrRtnQueryBankBalanceByFuture func) {(loader.Invoke( "SetOnErrRtnQueryBankBalanceByFuture", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnRepealFromBankToFutureByFuture(DeleOnRtnRepealFromBankToFutureByFuture func) {(loader.Invoke( "SetOnRtnRepealFromBankToFutureByFuture", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnRepealFromFutureToBankByFuture(DeleOnRtnRepealFromFutureToBankByFuture func) {(loader.Invoke( "SetOnRtnRepealFromFutureToBankByFuture", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspFromBankToFutureByFuture(DeleOnRspFromBankToFutureByFuture func) {(loader.Invoke( "SetOnRspFromBankToFutureByFuture", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspFromFutureToBankByFuture(DeleOnRspFromFutureToBankByFuture func) {(loader.Invoke( "SetOnRspFromFutureToBankByFuture", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQueryBankAccountMoneyByFuture(DeleOnRspQueryBankAccountMoneyByFuture func) {(loader.Invoke( "SetOnRspQueryBankAccountMoneyByFuture", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnOpenAccountByBank(DeleOnRtnOpenAccountByBank func) {(loader.Invoke( "SetOnRtnOpenAccountByBank", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnCancelAccountByBank(DeleOnRtnCancelAccountByBank func) {(loader.Invoke( "SetOnRtnCancelAccountByBank", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRtnChangeAccountByBank(DeleOnRtnChangeAccountByBank func) {(loader.Invoke( "SetOnRtnChangeAccountByBank", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryClassifiedInstrument(DeleOnRspQryClassifiedInstrument func) {(loader.Invoke( "SetOnRspQryClassifiedInstrument", typeof(DeleSet)) as DeleSet)(_spi, func);}
		public void SetOnRspQryCombPromotionParam(DeleOnRspQryCombPromotionParam func) {(loader.Invoke( "SetOnRspQryCombPromotionParam", typeof(DeleSet)) as DeleSet)(_spi, func);}
	}
}