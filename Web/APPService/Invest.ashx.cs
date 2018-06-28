using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Invest 的摘要说明
    /// </summary>
    public class Invest : ServiceHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;

            string act = context.Request["act"];
            if (string.IsNullOrEmpty(act) || act.Trim() == string.Empty)
            {
                return;
            }
            switch (act.ToLower())
            {
                case "buymachine"://购买
                    result = Investment(context);
                    break;
                case "list"://报单记录
                    result = InvestList(context);
                    break;
                case "getprice"://获取价格
                    result = GetMachinePrice();
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常", "Invest");
                    break;
            }
            context.Response.Write(result);
        }
        //投资
        private string Investment(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string num = context.Request["num"] ?? "";
            string paypassword = context.Request["paypassword"] ?? "";
            string message = string.Empty;

            int _num = 0;
            long _userid = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入投资人用户ID", "");
            }

            if (string.IsNullOrEmpty(num))
            {
                return ResultJson(ResultType.error, "请输入购买数量", "");
            }

            if (string.IsNullOrEmpty(paypassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            }

            int.TryParse(num,out _num);
            if (_num<=0)
            {
                return ResultJson(ResultType.error, "购买数量必须大于零", "");
            }
            long.TryParse(userid, out _userid);
            InvestService svc = new InvestService();
            bool result = svc.Invest(_userid, _num, paypassword.ToUpper(), out message);
            if (result)
            {
                return ResultJson(ResultType.success, message, "");
            }
            else
            {
                return ResultJson(ResultType.error, message, "");
            }
            
        }

        //购买记录
        private string InvestList(HttpContext context)
        {
            int pageSize = 10; //默认每页返回记录数
            int _pageindex;

            string userid = context.Request["userid"] ?? "";
            string pageindex = context.Request["pageindex"] ?? "";//页索引
            string findkey = context.Request["findkey"] ?? "";//搜索关键字

            string message = string.Empty;

            long _userid = 0;
            int.TryParse(pageindex, out _pageindex);

            if (_pageindex <= 0) _pageindex = 1;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!string.IsNullOrEmpty(findkey))
            {
                findkey = SafeHelper.GetSafeSql(findkey);
            }

            long.TryParse(userid, out _userid);
            InvestService svc = new InvestService();
            var result = svc.InvestList(_userid, _pageindex, pageSize, findkey);

            return ResultJson(ResultType.success, message, result);
        }

        private string GetMachinePrice()
        {
            InvestService svc = new InvestService();
            decimal price = svc.GetMachinePrice();
         
            SortedDictionary<string, object> value = new SortedDictionary<string, object>();
            value.Add("price", price);

            return ResultJson(ResultType.success, "ok", value);
        }
    }
}