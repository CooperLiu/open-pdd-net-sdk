using Microsoft.Extensions.Options;
using PddOpenSdk.Services;
using PddOpenSdk.Services.PddApi;

namespace PddOpenSdk.AspNetCore
{
    /// <summary>
    /// 批多多服务
    /// </summary>
    public class PddService
    {
        /// <summary>
        /// 授权验证
        /// </summary>
        public AuthApi AuthApi { get; set; } = new AuthApi();
        /// <summary>
        /// 推广API
        /// </summary>
        public AdApi AdApi { get; set; } = new AdApi();
        /// <summary>
        /// 多多客户API
        /// </summary>
        public DdkApi DdkApi { get; set; } = new DdkApi();
        /// <summary>
        /// 多多客户工具API
        /// </summary>
        public DdkOauthApi DdkOauthApi { get; set; } = new DdkOauthApi();
        /// <summary>
        /// 订单API
        /// </summary>
        public ErpApi ErpApi { get; set; } = new ErpApi();
        /// <summary>
        /// 订单API
        /// </summary>
        public ErpApi OrderApi { get; set; } = new ErpApi();
        /// <summary>
        /// 商品API
        /// </summary>
        public GoodsApi GoodsApi { get; set; } = new GoodsApi();
        /// <summary>
        /// 发票API
        /// </summary>
        public InvoiceApi InvoiceApi { get; set; } = new InvoiceApi();
        /// <summary>
        /// 物流API
        /// </summary>
        public LogisticsApi LogisticsApi { get; set; } = new LogisticsApi();
        /// <summary>
        /// 物流商API
        /// </summary>
        public LogisticscsApi LogisticsCsApi { get; set; } = new LogisticscsApi();
        /// <summary>
        /// 店铺API
        /// </summary>
        public MallApi MallApi { get; set; } = new MallApi();
        /// <summary>
        /// 营销API
        /// </summary>
        public PromotionApi PromotionApi { get; set; } = new PromotionApi();
        /// <summary>
        /// 售后API
        /// </summary>
        public RefundApi RefundApi { get; set; } = new RefundApi();
        /// <summary>
        /// 营销短信API
        /// </summary>
        public SmsApi SmsApi { get; set; } = new SmsApi();
        /// <summary>
        /// 工具API
        /// </summary>
        public TimeApi TimeApi { get; set; } = new TimeApi();
        /// <summary>
        /// 虚拟类目API
        /// </summary>
        public VirtualApi VirtualApi { get; set; } = new VirtualApi();
        /// <summary>
        /// 卡券API
        /// </summary>
        public VoucherApi VoucherApi { get; set; } = new VoucherApi();
        /// <summary>
        /// 仓储API
        /// </summary>
        public StockApi StockApi { get; set; } = new StockApi();

        private readonly IOptions<PddOptions> _options;

        public PddService(IOptions<PddOptions> options)
        {
            _options = options;
        }

    }
}
