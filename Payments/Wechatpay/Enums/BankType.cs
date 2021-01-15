using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Payments.WechatPay.Enums
{
    /// <summary>
    /// 银行种类
    /// </summary>
    public enum BankType
    {
        /// <summary> 
        /// 工商银行(借记卡) 
        /// </summary> 
        [Description("工商银行(借记卡)")]
        ICBC_DEBIT,
        /// <summary> 
        /// 工商银行(信用卡) 
        /// </summary> 
        [Description("工商银行(信用卡)")]
        ICBC_CREDIT,
        /// <summary> 
        /// 农业银行(借记卡) 
        /// </summary> 
        [Description("农业银行(借记卡)")]
        ABC_DEBIT,
        /// <summary> 
        /// 农业银行(信用卡) 
        /// </summary> 
        [Description("农业银行(信用卡)")]
        ABC_CREDIT,
        /// <summary> 
        /// 邮政储蓄银行(借记卡) 
        /// </summary> 
        [Description("邮政储蓄银行(借记卡)")]
        PSBC_DEBIT,
        /// <summary> 
        /// 邮政储蓄银行(信用卡) 
        /// </summary> 
        [Description("邮政储蓄银行(信用卡)")]
        PSBC_CREDIT,
        /// <summary> 
        /// 建设银行(借记卡) 
        /// </summary> 
        [Description("建设银行(借记卡)")]
        CCB_DEBIT,
        /// <summary> 
        /// 建设银行(信用卡) 
        /// </summary> 
        [Description("建设银行(信用卡)")]
        CCB_CREDIT,
        /// <summary> 
        /// 招商银行(借记卡) 
        /// </summary> 
        [Description("招商银行(借记卡)")]
        CMB_DEBIT,
        /// <summary> 
        /// 招商银行(信用卡) 
        /// </summary> 
        [Description("招商银行(信用卡)")]
        CMB_CREDIT,
        /// <summary> 
        /// 中国银行(借记卡) 
        /// </summary> 
        [Description("中国银行(借记卡)")]
        BOC_DEBIT,
        /// <summary> 
        /// 中国银行(信用卡) 
        /// </summary> 
        [Description("中国银行(信用卡)")]
        BOC_CREDIT,
        /// <summary> 
        /// 交通银行(借记卡) 
        /// </summary> 
        [Description("交通银行(借记卡)")]
        COMM_DEBIT,
        /// <summary> 
        /// 交通银行(信用卡) 
        /// </summary> 
        [Description("交通银行(信用卡)")]
        COMM_CREDIT,
        /// <summary> 
        /// 浦发银行(借记卡) 
        /// </summary> 
        [Description("浦发银行(借记卡)")]
        SPDB_DEBIT,
        /// <summary> 
        /// 浦发银行(信用卡) 
        /// </summary> 
        [Description("浦发银行(信用卡)")]
        SPDB_CREDIT,
        /// <summary> 
        /// 广发银行(借记卡) 
        /// </summary> 
        [Description("广发银行(借记卡)")]
        GDB_DEBIT,
        /// <summary> 
        /// 广发银行(信用卡) 
        /// </summary> 
        [Description("广发银行(信用卡)")]
        GDB_CREDIT,
        /// <summary> 
        /// 民生银行(借记卡) 
        /// </summary> 
        [Description("民生银行(借记卡)")]
        CMBC_DEBIT,
        /// <summary> 
        /// 民生银行(信用卡) 
        /// </summary> 
        [Description("民生银行(信用卡)")]
        CMBC_CREDIT,
        /// <summary> 
        /// 平安银行(借记卡) 
        /// </summary> 
        [Description("平安银行(借记卡)")]
        PAB_DEBIT,
        /// <summary> 
        /// 平安银行(信用卡) 
        /// </summary> 
        [Description("平安银行(信用卡)")]
        PAB_CREDIT,
        /// <summary> 
        /// 光大银行(借记卡) 
        /// </summary> 
        [Description("光大银行(借记卡)")]
        CEB_DEBIT,
        /// <summary> 
        /// 光大银行(信用卡) 
        /// </summary> 
        [Description("光大银行(信用卡)")]
        CEB_CREDIT,
        /// <summary> 
        /// 兴业银行(借记卡) 
        /// </summary> 
        [Description("兴业银行(借记卡)")]
        CIB_DEBIT,
        /// <summary> 
        /// 兴业银行(信用卡) 
        /// </summary> 
        [Description("兴业银行(信用卡)")]
        CIB_CREDIT,
        /// <summary> 
        /// 中信银行(借记卡) 
        /// </summary> 
        [Description("中信银行(借记卡)")]
        CITIC_DEBIT,
        /// <summary> 
        /// 中信银行(信用卡) 
        /// </summary> 
        [Description("中信银行(信用卡)")]
        CITIC_CREDIT,
        /// <summary> 
        /// 上海银行(借记卡) 
        /// </summary> 
        [Description("上海银行(借记卡)")]
        BOSH_DEBIT,
        /// <summary> 
        /// 上海银行(信用卡) 
        /// </summary> 
        [Description("上海银行(信用卡)")]
        BOSH_CREDIT,
        /// <summary> 
        /// 华润银行(借记卡) 
        /// </summary> 
        [Description("华润银行(借记卡)")]
        CRB_DEBIT,
        /// <summary> 
        /// 杭州银行(借记卡) 
        /// </summary> 
        [Description("杭州银行(借记卡)")]
        HZB_DEBIT,
        /// <summary> 
        /// 杭州银行(信用卡) 
        /// </summary> 
        [Description("杭州银行(信用卡)")]
        HZB_CREDIT,
        /// <summary> 
        /// 包商银行(借记卡) 
        /// </summary> 
        [Description("包商银行(借记卡)")]
        BSB_DEBIT,
        /// <summary> 
        /// 包商银行(信用卡) 
        /// </summary> 
        [Description("包商银行(信用卡)")]
        BSB_CREDIT,
        /// <summary> 
        /// 重庆银行(借记卡) 
        /// </summary> 
        [Description("重庆银行(借记卡)")]
        CQB_DEBIT,
        /// <summary> 
        /// 顺德农商行(借记卡) 
        /// </summary> 
        [Description("顺德农商行(借记卡)")]
        SDEB_DEBIT,
        /// <summary> 
        /// 深圳农商银行(借记卡) 
        /// </summary> 
        [Description("深圳农商银行(借记卡)")]
        SZRCB_DEBIT,
        /// <summary> 
        /// 深圳农商银行(信用卡) 
        /// </summary> 
        [Description("深圳农商银行(信用卡)")]
        SZRCB_CREDIT,
        /// <summary> 
        /// 哈尔滨银行(借记卡) 
        /// </summary> 
        [Description("哈尔滨银行(借记卡)")]
        HRBB_DEBIT,
        /// <summary> 
        /// 成都银行(借记卡) 
        /// </summary> 
        [Description("成都银行(借记卡)")]
        BOCD_DEBIT,
        /// <summary> 
        /// 南粤银行(借记卡) 
        /// </summary> 
        [Description("南粤银行(借记卡)")]
        GDNYB_DEBIT,
        /// <summary> 
        /// 南粤银行(信用卡) 
        /// </summary> 
        [Description("南粤银行(信用卡)")]
        GDNYB_CREDIT,
        /// <summary> 
        /// 广州银行(借记卡) 
        /// </summary> 
        [Description("广州银行(借记卡)")]
        GZCB_DEBIT,
        /// <summary> 
        /// 广州银行(信用卡) 
        /// </summary> 
        [Description("广州银行(信用卡)")]
        GZCB_CREDIT,
        /// <summary> 
        /// 江苏银行(借记卡) 
        /// </summary> 
        [Description("江苏银行(借记卡)")]
        JSB_DEBIT,
        /// <summary> 
        /// 江苏银行(信用卡) 
        /// </summary> 
        [Description("江苏银行(信用卡)")]
        JSB_CREDIT,
        /// <summary> 
        /// 宁波银行(借记卡) 
        /// </summary> 
        [Description("宁波银行(借记卡)")]
        NBCB_DEBIT,
        /// <summary> 
        /// 宁波银行(信用卡) 
        /// </summary> 
        [Description("宁波银行(信用卡)")]
        NBCB_CREDIT,
        /// <summary> 
        /// 南京银行(借记卡) 
        /// </summary> 
        [Description("南京银行(借记卡)")]
        NJCB_DEBIT,
        /// <summary> 
        /// 青海农信(借记卡) 
        /// </summary> 
        [Description("青海农信(借记卡)")]
        QHNX_DEBIT,
        /// <summary> 
        /// 鄂尔多斯银行(信用卡) 
        /// </summary> 
        [Description("鄂尔多斯银行(信用卡)")]
        ORDOSB_CREDIT,
        /// <summary> 
        /// 鄂尔多斯银行(借记卡) 
        /// </summary> 
        [Description("鄂尔多斯银行(借记卡)")]
        ORDOSB_DEBIT,
        /// <summary> 
        /// 北京农商(信用卡) 
        /// </summary> 
        [Description("北京农商(信用卡)")]
        BJRCB_CREDIT,
        /// <summary> 
        /// 河北银行(借记卡) 
        /// </summary> 
        [Description("河北银行(借记卡)")]
        BHB_DEBIT,
        /// <summary> 
        /// 贵州银行(借记卡) 
        /// </summary> 
        [Description("贵州银行(借记卡)")]
        BGZB_DEBIT,
        /// <summary> 
        /// 鄞州银行(借记卡) 
        /// </summary> 
        [Description("鄞州银行(借记卡)")]
        BEEB_DEBIT,
        /// <summary> 
        /// 攀枝花银行(借记卡) 
        /// </summary> 
        [Description("攀枝花银行(借记卡)")]
        PZHCCB_DEBIT,
        /// <summary> 
        /// 青岛银行(信用卡) 
        /// </summary> 
        [Description("青岛银行(信用卡)")]
        QDCCB_CREDIT,
        /// <summary> 
        /// 青岛银行(借记卡) 
        /// </summary> 
        [Description("青岛银行(借记卡)")]
        QDCCB_DEBIT,
        /// <summary> 
        /// 新韩银行(借记卡) 
        /// </summary> 
        [Description("新韩银行(借记卡)")]
        SHINHAN_DEBIT,
        /// <summary> 
        /// 齐鲁银行(借记卡) 
        /// </summary> 
        [Description("齐鲁银行(借记卡)")]
        QLB_DEBIT,
        /// <summary> 
        /// 齐商银行(借记卡) 
        /// </summary> 
        [Description("齐商银行(借记卡)")]
        QSB_DEBIT,
        /// <summary> 
        /// 郑州银行(借记卡) 
        /// </summary> 
        [Description("郑州银行(借记卡)")]
        ZZB_DEBIT,
        /// <summary> 
        /// 长安银行(借记卡) 
        /// </summary> 
        [Description("长安银行(借记卡)")]
        CCAB_DEBIT,
        /// <summary> 
        /// 日照银行(借记卡) 
        /// </summary> 
        [Description("日照银行(借记卡)")]
        RZB_DEBIT,
        /// <summary> 
        /// 四川农信(借记卡) 
        /// </summary> 
        [Description("四川农信(借记卡)")]
        SCNX_DEBIT,
        /// <summary> 
        /// 鄞州银行(信用卡) 
        /// </summary> 
        [Description("鄞州银行(信用卡)")]
        BEEB_CREDIT,
        /// <summary> 
        /// 山东农信(借记卡) 
        /// </summary> 
        [Description("山东农信(借记卡)")]
        SDRCU_DEBIT,
        /// <summary> 
        /// 沧州银行(借记卡) 
        /// </summary> 
        [Description("沧州银行(借记卡)")]
        BCZ_DEBIT,
        /// <summary> 
        /// 盛京银行(借记卡) 
        /// </summary> 
        [Description("盛京银行(借记卡)")]
        SJB_DEBIT,
        /// <summary> 
        /// 辽宁农信(借记卡) 
        /// </summary> 
        [Description("辽宁农信(借记卡)")]
        LNNX_DEBIT,
        /// <summary> 
        /// 临朐聚丰村镇银行(借记卡) 
        /// </summary> 
        [Description("临朐聚丰村镇银行(借记卡)")]
        JUFENGB_DEBIT,
        /// <summary> 
        /// 郑州银行(信用卡) 
        /// </summary> 
        [Description("郑州银行(信用卡)")]
        ZZB_CREDIT,
        /// <summary> 
        /// 江西农信(借记卡) 
        /// </summary> 
        [Description("江西农信(借记卡)")]
        JXNXB_DEBIT,
        /// <summary> 
        /// 晋中银行(借记卡) 
        /// </summary> 
        [Description("晋中银行(借记卡)")]
        JZB_DEBIT,
        /// <summary> 
        /// 锦州银行(信用卡) 
        /// </summary> 
        [Description("锦州银行(信用卡)")]
        JZCB_CREDIT,
        /// <summary> 
        /// 锦州银行(借记卡) 
        /// </summary> 
        [Description("锦州银行(借记卡)")]
        JZCB_DEBIT,
        /// <summary> 
        /// 昆仑银行(借记卡) 
        /// </summary> 
        [Description("昆仑银行(借记卡)")]
        KLB_DEBIT,
        /// <summary> 
        /// 昆山农商(借记卡) 
        /// </summary> 
        [Description("昆山农商(借记卡)")]
        KRCB_DEBIT,
        /// <summary> 
        /// 库尔勒市商业银行(借记卡) 
        /// </summary> 
        [Description("库尔勒市商业银行(借记卡)")]
        KUERLECB_DEBIT,
        /// <summary> 
        /// 龙江银行(借记卡) 
        /// </summary> 
        [Description("龙江银行(借记卡)")]
        LJB_DEBIT,
        /// <summary> 
        /// 南阳村镇银行(借记卡) 
        /// </summary> 
        [Description("南阳村镇银行(借记卡)")]
        NYCCB_DEBIT,
        /// <summary> 
        /// 乐山市商业银行(借记卡) 
        /// </summary> 
        [Description("乐山市商业银行(借记卡)")]
        LSCCB_DEBIT,
        /// <summary> 
        /// 柳州银行(借记卡) 
        /// </summary> 
        [Description("柳州银行(借记卡)")]
        LUZB_DEBIT,
        /// <summary> 
        /// 莱商银行(借记卡) 
        /// </summary> 
        [Description("莱商银行(借记卡)")]
        LWB_DEBIT,
        /// <summary> 
        /// 辽阳银行(借记卡) 
        /// </summary> 
        [Description("辽阳银行(借记卡)")]
        LYYHB_DEBIT,
        /// <summary> 
        /// 兰州银行(借记卡) 
        /// </summary> 
        [Description("兰州银行(借记卡)")]
        LZB_DEBIT,
        /// <summary> 
        /// 民泰银行(信用卡) 
        /// </summary> 
        [Description("民泰银行(信用卡)")]
        MINTAIB_CREDIT,
        /// <summary> 
        /// 民泰银行(借记卡) 
        /// </summary> 
        [Description("民泰银行(借记卡)")]
        MINTAIB_DEBIT,
        /// <summary> 
        /// 宁波通商银行(借记卡) 
        /// </summary> 
        [Description("宁波通商银行(借记卡)")]
        NCB_DEBIT,
        /// <summary> 
        /// 内蒙古农信(借记卡) 
        /// </summary> 
        [Description("内蒙古农信(借记卡)")]
        NMGNX_DEBIT,
        /// <summary> 
        /// 西安银行(借记卡) 
        /// </summary> 
        [Description("西安银行(借记卡)")]
        XAB_DEBIT,
        /// <summary> 
        /// 潍坊银行(信用卡) 
        /// </summary> 
        [Description("潍坊银行(信用卡)")]
        WFB_CREDIT,
        /// <summary> 
        /// 潍坊银行(借记卡) 
        /// </summary> 
        [Description("潍坊银行(借记卡)")]
        WFB_DEBIT,
        /// <summary> 
        /// 威海商业银行(信用卡) 
        /// </summary> 
        [Description("威海商业银行(信用卡)")]
        WHB_CREDIT,
        /// <summary> 
        /// 威海市商业银行(借记卡) 
        /// </summary> 
        [Description("威海市商业银行(借记卡)")]
        WHB_DEBIT,
        /// <summary> 
        /// 武汉农商(信用卡) 
        /// </summary> 
        [Description("武汉农商(信用卡)")]
        WHRC_CREDIT,
        /// <summary> 
        /// 武汉农商行(借记卡) 
        /// </summary> 
        [Description("武汉农商行(借记卡)")]
        WHRC_DEBIT,
        /// <summary> 
        /// 吴江农商行(借记卡) 
        /// </summary> 
        [Description("吴江农商行(借记卡)")]
        WJRCB_DEBIT,
        /// <summary> 
        /// 乌鲁木齐银行(借记卡) 
        /// </summary> 
        [Description("乌鲁木齐银行(借记卡)")]
        WLMQB_DEBIT,
        /// <summary> 
        /// 无锡农商(借记卡) 
        /// </summary> 
        [Description("无锡农商(借记卡)")]
        WRCB_DEBIT,
        /// <summary> 
        /// 温州银行(借记卡) 
        /// </summary> 
        [Description("温州银行(借记卡)")]
        WZB_DEBIT,
        /// <summary> 
        /// 西安银行(信用卡) 
        /// </summary> 
        [Description("西安银行(信用卡)")]
        XAB_CREDIT,
        /// <summary> 
        /// 微众银行(借记卡) 
        /// </summary> 
        [Description("微众银行(借记卡)")]
        WEB_DEBIT,
        /// <summary> 
        /// 厦门国际银行(借记卡) 
        /// </summary> 
        [Description("厦门国际银行(借记卡)")]
        XIB_DEBIT,
        /// <summary> 
        /// 新疆农信银行(借记卡) 
        /// </summary> 
        [Description("新疆农信银行(借记卡)")]
        XJRCCB_DEBIT,
        /// <summary> 
        /// 厦门银行(借记卡) 
        /// </summary> 
        [Description("厦门银行(借记卡)")]
        XMCCB_DEBIT,
        /// <summary> 
        /// 云南农信(借记卡) 
        /// </summary> 
        [Description("云南农信(借记卡)")]
        YNRCCB_DEBIT,
        /// <summary> 
        /// 黄河农商银行(信用卡) 
        /// </summary> 
        [Description("黄河农商银行(信用卡)")]
        YRRCB_CREDIT,
        /// <summary> 
        /// 黄河农商银行(借记卡) 
        /// </summary> 
        [Description("黄河农商银行(借记卡)")]
        YRRCB_DEBIT,
        /// <summary> 
        /// 烟台银行(借记卡) 
        /// </summary> 
        [Description("烟台银行(借记卡)")]
        YTB_DEBIT,
        /// <summary> 
        /// 紫金农商银行(借记卡) 
        /// </summary> 
        [Description("紫金农商银行(借记卡)")]
        ZJB_DEBIT,
        /// <summary> 
        /// 兰溪越商银行(借记卡) 
        /// </summary> 
        [Description("兰溪越商银行(借记卡)")]
        ZJLXRB_DEBIT,
        /// <summary> 
        /// 浙江农信(信用卡) 
        /// </summary> 
        [Description("浙江农信(信用卡)")]
        ZJRCUB_CREDIT,
        /// <summary> 
        /// 安徽省农村信用社联合社(借记卡) 
        /// </summary> 
        [Description("安徽省农村信用社联合社(借记卡)")]
        AHRCUB_DEBIT,
        /// <summary> 
        /// 沧州银行(信用卡) 
        /// </summary> 
        [Description("沧州银行(信用卡)")]
        BCZ_CREDIT,
        /// <summary> 
        /// 上饶银行(借记卡) 
        /// </summary> 
        [Description("上饶银行(借记卡)")]
        SRB_DEBIT,
        /// <summary> 
        /// 中原银行(借记卡) 
        /// </summary> 
        [Description("中原银行(借记卡)")]
        ZYB_DEBIT,
        /// <summary> 
        /// 张家港农商行(借记卡) 
        /// </summary> 
        [Description("张家港农商行(借记卡)")]
        ZRCB_DEBIT,
        /// <summary> 
        /// 上海农商银行(信用卡) 
        /// </summary> 
        [Description("上海农商银行(信用卡)")]
        SRCB_CREDIT,
        /// <summary> 
        /// 上海农商银行(借记卡) 
        /// </summary> 
        [Description("上海农商银行(借记卡)")]
        SRCB_DEBIT,
        /// <summary> 
        /// 浙江泰隆银行(借记卡) 
        /// </summary> 
        [Description("浙江泰隆银行(借记卡)")]
        ZJTLCB_DEBIT,
        /// <summary> 
        /// 苏州银行(借记卡) 
        /// </summary> 
        [Description("苏州银行(借记卡)")]
        SUZB_DEBIT,
        /// <summary> 
        /// 山西农信(借记卡) 
        /// </summary> 
        [Description("山西农信(借记卡)")]
        SXNX_DEBIT,
        /// <summary> 
        /// 陕西信合(借记卡) 
        /// </summary> 
        [Description("陕西信合(借记卡)")]
        SXXH_DEBIT,
        /// <summary> 
        /// 浙江农信(借记卡) 
        /// </summary> 
        [Description("浙江农信(借记卡)")]
        ZJRCUB_DEBIT,
        /// <summary> 
        /// AE(信用卡) 
        /// </summary> 
        [Description("AE(信用卡)")]
        AE_CREDIT,
        /// <summary> 
        /// 泰安银行(信用卡) 
        /// </summary> 
        [Description("泰安银行(信用卡)")]
        TACCB_CREDIT,
        /// <summary> 
        /// 泰安银行(借记卡) 
        /// </summary> 
        [Description("泰安银行(借记卡)")]
        TACCB_DEBIT,
        /// <summary> 
        /// 太仓农商行(借记卡) 
        /// </summary> 
        [Description("太仓农商行(借记卡)")]
        TCRCB_DEBIT,
        /// <summary> 
        /// 天津滨海农商行(信用卡) 
        /// </summary> 
        [Description("天津滨海农商行(信用卡)")]
        TJBHB_CREDIT,
        /// <summary> 
        /// 天津滨海农商行(借记卡) 
        /// </summary> 
        [Description("天津滨海农商行(借记卡)")]
        TJBHB_DEBIT,
        /// <summary> 
        /// 天津银行(借记卡) 
        /// </summary> 
        [Description("天津银行(借记卡)")]
        TJB_DEBIT,
        /// <summary> 
        /// 天津农商(借记卡) 
        /// </summary> 
        [Description("天津农商(借记卡)")]
        TRCB_DEBIT,
        /// <summary> 
        /// 台州银行(借记卡) 
        /// </summary> 
        [Description("台州银行(借记卡)")]
        TZB_DEBIT,
        /// <summary> 
        /// 联合村镇银行(借记卡) 
        /// </summary> 
        [Description("联合村镇银行(借记卡)")]
        URB_DEBIT,
        /// <summary> 
        /// 东营银行(信用卡) 
        /// </summary> 
        [Description("东营银行(信用卡)")]
        DYB_CREDIT,
        /// <summary> 
        /// 常熟农商银行(借记卡) 
        /// </summary> 
        [Description("常熟农商银行(借记卡)")]
        CSRCB_DEBIT,
        /// <summary> 
        /// 浙商银行(信用卡) 
        /// </summary> 
        [Description("浙商银行(信用卡)")]
        CZB_CREDIT,
        /// <summary> 
        /// 浙商银行(借记卡) 
        /// </summary> 
        [Description("浙商银行(借记卡)")]
        CZB_DEBIT,
        /// <summary> 
        /// 稠州银行(信用卡) 
        /// </summary> 
        [Description("稠州银行(信用卡)")]
        CZCB_CREDIT,
        /// <summary> 
        /// 稠州银行(借记卡) 
        /// </summary> 
        [Description("稠州银行(借记卡)")]
        CZCB_DEBIT,
        /// <summary> 
        /// 丹东银行(信用卡) 
        /// </summary> 
        [Description("丹东银行(信用卡)")]
        DANDONGB_CREDIT,
        /// <summary> 
        /// 丹东银行(借记卡) 
        /// </summary> 
        [Description("丹东银行(借记卡)")]
        DANDONGB_DEBIT,
        /// <summary> 
        /// 大连银行(信用卡) 
        /// </summary> 
        [Description("大连银行(信用卡)")]
        DLB_CREDIT,
        /// <summary> 
        /// 大连银行(借记卡) 
        /// </summary> 
        [Description("大连银行(借记卡)")]
        DLB_DEBIT,
        /// <summary> 
        /// 东莞农商银行(信用卡) 
        /// </summary> 
        [Description("东莞农商银行(信用卡)")]
        DRCB_CREDIT,
        /// <summary> 
        /// 东莞农商银行(借记卡) 
        /// </summary> 
        [Description("东莞农商银行(借记卡)")]
        DRCB_DEBIT,
        /// <summary> 
        /// 常熟农商银行(信用卡) 
        /// </summary> 
        [Description("常熟农商银行(信用卡)")]
        CSRCB_CREDIT,
        /// <summary> 
        /// 东营银行(借记卡) 
        /// </summary> 
        [Description("东营银行(借记卡)")]
        DYB_DEBIT,
        /// <summary> 
        /// 德阳银行(借记卡) 
        /// </summary> 
        [Description("德阳银行(借记卡)")]
        DYCCB_DEBIT,
        /// <summary> 
        /// 富邦华一银行(借记卡) 
        /// </summary> 
        [Description("富邦华一银行(借记卡)")]
        FBB_DEBIT,
        /// <summary> 
        /// 富滇银行(借记卡) 
        /// </summary> 
        [Description("富滇银行(借记卡)")]
        FDB_DEBIT,
        /// <summary> 
        /// 福建海峡银行(信用卡) 
        /// </summary> 
        [Description("福建海峡银行(信用卡)")]
        FJHXB_CREDIT,
        /// <summary> 
        /// 福建海峡银行(借记卡) 
        /// </summary> 
        [Description("福建海峡银行(借记卡)")]
        FJHXB_DEBIT,
        /// <summary> 
        /// 福建农信银行(借记卡) 
        /// </summary> 
        [Description("福建农信银行(借记卡)")]
        FJNX_DEBIT,
        /// <summary> 
        /// 阜新银行(借记卡) 
        /// </summary> 
        [Description("阜新银行(借记卡)")]
        FUXINB_DEBIT,
        /// <summary> 
        /// 承德银行(借记卡) 
        /// </summary> 
        [Description("承德银行(借记卡)")]
        BOCDB_DEBIT,
        /// <summary> 
        /// 江苏农商行(借记卡) 
        /// </summary> 
        [Description("江苏农商行(借记卡)")]
        JSNX_DEBIT,
        /// <summary> 
        /// 廊坊银行(借记卡) 
        /// </summary> 
        [Description("廊坊银行(借记卡)")]
        BOLFB_DEBIT,
        /// <summary> 
        /// 长安银行(信用卡) 
        /// </summary> 
        [Description("长安银行(信用卡)")]
        CCAB_CREDIT,
        /// <summary> 
        /// 渤海银行(借记卡) 
        /// </summary> 
        [Description("渤海银行(借记卡)")]
        CBHB_DEBIT,
        /// <summary> 
        /// 成都农商银行(借记卡) 
        /// </summary> 
        [Description("成都农商银行(借记卡)")]
        CDRCB_DEBIT,
        /// <summary> 
        /// 营口银行(借记卡) 
        /// </summary> 
        [Description("营口银行(借记卡)")]
        BYK_DEBIT,
        /// <summary> 
        /// 张家口市商业银行(借记卡) 
        /// </summary> 
        [Description("张家口市商业银行(借记卡)")]
        BOZ_DEBIT,
        /// <summary> 
        /// 零钱 
        /// </summary> 
        [Description("零钱")]
        CFT,
        /// <summary> 
        /// 唐山银行(借记卡) 
        /// </summary> 
        [Description("唐山银行(借记卡)")]
        BOTSB_DEBIT,
        /// <summary> 
        /// 石嘴山银行(借记卡) 
        /// </summary> 
        [Description("石嘴山银行(借记卡)")]
        BOSZS_DEBIT,
        /// <summary> 
        /// 绍兴银行(借记卡) 
        /// </summary> 
        [Description("绍兴银行(借记卡)")]
        BOSXB_DEBIT,
        /// <summary> 
        /// 宁夏银行(借记卡) 
        /// </summary> 
        [Description("宁夏银行(借记卡)")]
        BONX_DEBIT,
        /// <summary> 
        /// 宁夏银行(信用卡) 
        /// </summary> 
        [Description("宁夏银行(信用卡)")]
        BONX_CREDIT,
        /// <summary> 
        /// 广东华兴银行(借记卡) 
        /// </summary> 
        [Description("广东华兴银行(借记卡)")]
        GDHX_DEBIT,
        /// <summary> 
        /// 洛阳银行(借记卡) 
        /// </summary> 
        [Description("洛阳银行(借记卡)")]
        BOLB_DEBIT,
        /// <summary> 
        /// 嘉兴银行(借记卡) 
        /// </summary> 
        [Description("嘉兴银行(借记卡)")]
        BOJX_DEBIT,
        /// <summary> 
        /// 内蒙古银行(借记卡) 
        /// </summary> 
        [Description("内蒙古银行(借记卡)")]
        BOIMCB_DEBIT,
        /// <summary> 
        /// 海南银行(借记卡) 
        /// </summary> 
        [Description("海南银行(借记卡)")]
        BOHN_DEBIT,
        /// <summary> 
        /// 东莞银行(借记卡) 
        /// </summary> 
        [Description("东莞银行(借记卡)")]
        BOD_DEBIT,
        /// <summary> 
        /// 重庆农商银行(信用卡) 
        /// </summary> 
        [Description("重庆农商银行(信用卡)")]
        CQRCB_CREDIT,
        /// <summary> 
        /// 重庆农商银行(借记卡) 
        /// </summary> 
        [Description("重庆农商银行(借记卡)")]
        CQRCB_DEBIT,
        /// <summary> 
        /// 重庆三峡银行(借记卡) 
        /// </summary> 
        [Description("重庆三峡银行(借记卡)")]
        CQTGB_DEBIT,
        /// <summary> 
        /// 东莞银行(信用卡) 
        /// </summary> 
        [Description("东莞银行(信用卡)")]
        BOD_CREDIT,
        /// <summary> 
        /// 长沙银行(借记卡) 
        /// </summary> 
        [Description("长沙银行(借记卡)")]
        CSCB_DEBIT,
        /// <summary> 
        /// 北京银行(信用卡) 
        /// </summary> 
        [Description("北京银行(信用卡)")]
        BOB_CREDIT,
        /// <summary> 
        /// 广东农信银行(借记卡) 
        /// </summary> 
        [Description("广东农信银行(借记卡)")]
        GDRCU_DEBIT,
        /// <summary> 
        /// 北京银行(借记卡) 
        /// </summary> 
        [Description("北京银行(借记卡)")]
        BOB_DEBIT,
        /// <summary> 
        /// 华融湘江银行(借记卡) 
        /// </summary> 
        [Description("华融湘江银行(借记卡)")]
        HRXJB_DEBIT,
        /// <summary> 
        /// 恒生银行(借记卡) 
        /// </summary> 
        [Description("恒生银行(借记卡)")]
        HSBC_DEBIT,
        /// <summary> 
        /// 徽商银行(信用卡) 
        /// </summary> 
        [Description("徽商银行(信用卡)")]
        HSB_CREDIT,
        /// <summary> 
        /// 徽商银行(借记卡) 
        /// </summary> 
        [Description("徽商银行(借记卡)")]
        HSB_DEBIT,
        /// <summary> 
        /// 湖南农信(借记卡) 
        /// </summary> 
        [Description("湖南农信(借记卡)")]
        HUNNX_DEBIT,
        /// <summary> 
        /// 湖商村镇银行(借记卡) 
        /// </summary> 
        [Description("湖商村镇银行(借记卡)")]
        HUSRB_DEBIT,
        /// <summary> 
        /// 华夏银行(信用卡) 
        /// </summary> 
        [Description("华夏银行(信用卡)")]
        HXB_CREDIT,
        /// <summary> 
        /// 华夏银行(借记卡) 
        /// </summary> 
        [Description("华夏银行(借记卡)")]
        HXB_DEBIT,
        /// <summary> 
        /// 河南农信(借记卡) 
        /// </summary> 
        [Description("河南农信(借记卡)")]
        HNNX_DEBIT,
        /// <summary> 
        /// 江西银行(借记卡) 
        /// </summary> 
        [Description("江西银行(借记卡)")]
        BNC_DEBIT,
        /// <summary> 
        /// 江西银行(信用卡) 
        /// </summary> 
        [Description("江西银行(信用卡)")]
        BNC_CREDIT,
        /// <summary> 
        /// 北京农商行(借记卡) 
        /// </summary> 
        [Description("北京农商行(借记卡)")]
        BJRCB_DEBIT,
        /// <summary> 
        /// 晋城银行(借记卡) 
        /// </summary> 
        [Description("晋城银行(借记卡)")]
        JCB_DEBIT,
        /// <summary> 
        /// 九江银行(借记卡) 
        /// </summary> 
        [Description("九江银行(借记卡)")]
        JJCCB_DEBIT,
        /// <summary> 
        /// 吉林银行(借记卡) 
        /// </summary> 
        [Description("吉林银行(借记卡)")]
        JLB_DEBIT,
        /// <summary> 
        /// 吉林农信(借记卡) 
        /// </summary> 
        [Description("吉林农信(借记卡)")]
        JLNX_DEBIT,
        /// <summary> 
        /// 江南农商(借记卡) 
        /// </summary> 
        [Description("江南农商(借记卡)")]
        JNRCB_DEBIT,
        /// <summary> 
        /// 江阴农商行(借记卡) 
        /// </summary> 
        [Description("江阴农商行(借记卡)")]
        JRCB_DEBIT,
        /// <summary> 
        /// 晋商银行(借记卡) 
        /// </summary> 
        [Description("晋商银行(借记卡)")]
        JSHB_DEBIT,
        /// <summary> 
        /// 海南农信(借记卡) 
        /// </summary> 
        [Description("海南农信(借记卡)")]
        HAINNX_DEBIT,
        /// <summary> 
        /// 桂林银行(借记卡) 
        /// </summary> 
        [Description("桂林银行(借记卡)")]
        GLB_DEBIT,
        /// <summary> 
        /// 广州农商银行(信用卡) 
        /// </summary> 
        [Description("广州农商银行(信用卡)")]
        GRCB_CREDIT,
        /// <summary> 
        /// 广州农商银行(借记卡) 
        /// </summary> 
        [Description("广州农商银行(借记卡)")]
        GRCB_DEBIT,
        /// <summary> 
        /// 甘肃银行(借记卡) 
        /// </summary> 
        [Description("甘肃银行(借记卡)")]
        GSB_DEBIT,
        /// <summary> 
        /// 甘肃农信(借记卡) 
        /// </summary> 
        [Description("甘肃农信(借记卡)")]
        GSNX_DEBIT,
        /// <summary> 
        /// 广西农信(借记卡) 
        /// </summary> 
        [Description("广西农信(借记卡)")]
        GXNX_DEBIT,
        /// <summary> 
        /// 贵阳银行(信用卡) 
        /// </summary> 
        [Description("贵阳银行(信用卡)")]
        GYCB_CREDIT,
        /// <summary> 
        /// 贵阳银行(借记卡) 
        /// </summary> 
        [Description("贵阳银行(借记卡)")]
        GYCB_DEBIT,
        /// <summary> 
        /// 贵州农信(借记卡) 
        /// </summary> 
        [Description("贵州农信(借记卡)")]
        GZNX_DEBIT,
        /// <summary> 
        /// 海南农信(信用卡) 
        /// </summary> 
        [Description("海南农信(信用卡)")]
        HAINNX_CREDIT,
        /// <summary> 
        /// 汉口银行(借记卡) 
        /// </summary> 
        [Description("汉口银行(借记卡)")]
        HKB_DEBIT,
        /// <summary> 
        /// 韩亚银行(借记卡) 
        /// </summary> 
        [Description("韩亚银行(借记卡)")]
        HANAB_DEBIT,
        /// <summary> 
        /// 湖北银行(信用卡) 
        /// </summary> 
        [Description("湖北银行(信用卡)")]
        HBCB_CREDIT,
        /// <summary> 
        /// 湖北银行(借记卡) 
        /// </summary> 
        [Description("湖北银行(借记卡)")]
        HBCB_DEBIT,
        /// <summary> 
        /// 湖北农信(信用卡) 
        /// </summary> 
        [Description("湖北农信(信用卡)")]
        HBNX_CREDIT,
        /// <summary> 
        /// 湖北农信(借记卡) 
        /// </summary> 
        [Description("湖北农信(借记卡)")]
        HBNX_DEBIT,
        /// <summary> 
        /// 邯郸银行(借记卡) 
        /// </summary> 
        [Description("邯郸银行(借记卡)")]
        HDCB_DEBIT,
        /// <summary> 
        /// 河北农信(借记卡) 
        /// </summary> 
        [Description("河北农信(借记卡)")]
        HEBNX_DEBIT,
        /// <summary> 
        /// 恒丰银行(借记卡) 
        /// </summary> 
        [Description("恒丰银行(借记卡)")]
        HFB_DEBIT,
        /// <summary> 
        /// 东亚银行(借记卡) 
        /// </summary> 
        [Description("东亚银行(借记卡)")]
        HKBEA_DEBIT,
        /// <summary> 
        /// JCB(信用卡) 
        /// </summary> 
        [Description("JCB(信用卡)")]
        JCB_CREDIT,
        /// <summary> 
        /// MASTERCARD(信用卡) 
        /// </summary> 
        [Description("MASTERCARD(信用卡)")]
        MASTERCARD_CREDIT,
        /// <summary> 
        /// VISA(信用卡) 
        /// </summary> 
        [Description("VISA(信用卡)")]
        VISA_CREDIT,
        /// <summary> 
        /// 零钱通 
        /// </summary> 
        [Description("零钱通")]
        LQT,
    }
 
}
