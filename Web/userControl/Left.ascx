<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Left.ascx.cs" Inherits="Web.userControl.Left" %>
<div class="left side-menu">
    <div id="particles-js" class="side-menu-bg" style="position: absolute; bottom: 0; right: 0; left: 0; top: 0;"></div>

    <div class="sidebar-inner slimscrollleft">

        <!-- User -->
        <div class="user-box">
            <%--<div class="user-img">
                <img src="/images/avatar-1.jpg" alt="user-img" title="Mat Helme" class="img-circle img-thumbnail img-responsive">
                <div class="user-status offline"><i class="zmdi zmdi-dot-circle"></i></div>
            </div>--%>
            <h5><a href="/user/member/PersonalInfo.aspx"><%=LoginUser.UserCode %></a> </h5>
            <ul class="list-inline">
                <li>
                    <a href="/user/member/ModifyPassWord.aspx">
                        <i class="zmdi zmdi-settings"></i>
                    </a>
                </li>

                <li>
                    <a href="../../loginout.aspx" class="text-custom">
                        <i class="zmdi zmdi-power"></i>
                    </a>
                </li>

            </ul>
        </div>
        <!-- End User -->
        <div id="sidebar-menu">
            <ul>
                <li class="text-muted menu-title"><%--菜单--%><%=GetLanguage("Menu") %></li>

                <li>
                    <a href="/user/index.aspx" class="waves-effect"><i class="zmdi zmdi-home"></i><span><%--首页--%><%=GetLanguage("index") %> </span></a>
                </li>

                <li class="has_sub">
                    <a href="javascript:void(0);" class="waves-effect"><i class="fa fa-user"></i><span><%--用户中心--%><%=GetLanguage("UserCenter") %> </span><span class="menu-arrow"></span></a>
                    <ul class="list-unstyled">
                        <li><a href="/user/member/PersonalInfo.aspx"><%--会员资料--%><%=GetLanguage("MemberInformation") %></a></li>
                        <li><a href="/user/member/ModifyPassWord.aspx"><%--修改密码--%><%=GetLanguage("ModifyPassword") %></a></li>
                        <li><a href="/user/member/GetCalcPower.aspx"><%--获取算力--%><%=GetLanguage("GetCalcPower") %></a></li>
                        <%--<li><a href="/user/team/agent.aspx"><!--商务中心--><%=GetLanguage("Agent") %></a></li>--%>
                        <%-- <li><a href="/user/member/PopLink.aspx">推广链接</a></li>--%>
                    </ul>
                </li>

                <li class="has_sub">
                    <a href="javascript:void(0);" class="waves-effect"><i class="zmdi zmdi-view-list"></i><span><%--帐号管理--%><%=GetLanguage("AccountManagement") %> </span><span class="menu-arrow"></span></a>
                    <ul class="list-unstyled">
                        <li><a href="/user/Registers.aspx"><%--会员注册--%><%=GetLanguage("Register") %></a></li>
                        <%--<li><a href="/user/team/MemberList.aspx"><!--我的市场--><%=GetLanguage("MyMarket") %></a></li>--%>
                        <li><a href="/user/team/TableTree.aspx"><%--会员列表--%><%=GetLanguage("MemberList") %></a></li>
                        <li><a href="/user/team/RecommendTree.aspx"><%--直接推荐图--%><%=GetLanguage("ThisFigure") %></a></li>

                    </ul>
                </li>

                <li class="has_sub">
                    <a href="javascript:void(0);" class="waves-effect"><i class="zmdi zmdi-chart"></i><span><%--财务中心--%><%=GetLanguage("FinanceCenter") %> </span><span class="menu-arrow"></span></a>
                    <ul class="list-unstyled">
                        <li><a href="/user/finance/Remit.aspx"><%--充值--%><%=GetLanguage("Rechargemanagement") %></a></li>
                        <li><a href="/user/finance/Bonus.aspx"><%--奖金明细--%><%=GetLanguage("MemberBonus") %></a></li>
                        <li><a href="/user/finance/dl_JournalAccount.aspx"><%--个人账户--%><%=GetLanguage("PersonalAccount") %></a></li>
                        <li><a href="/user/finance/TransferToEmoney.aspx"><%--转账管理--%><%=GetLanguage("TransferManagement") %></a></li>
                        <%--<li><a href="/user/finance/TransRemit.aspx"><!--云图--><%=GetLanguage("Transaction") %></a></li>--%>
                        <li><a href="/user/finance/Invest.aspx"><%--购买矿机--%><%=GetLanguage("Investments") %></a></li>
                        <%--<li><a href="/user/finance/TakeMoney.aspx"><!--提现--><%=GetLanguage("MembershipWithdrawal") %></a></li>--%>
                        <li><a href="/user/finance/Mining_Records.aspx"><%--挖矿记录--%><%=GetLanguage("Mining_JR") %></a></li>
                        <li><a href="/user/finance/CalcPowerList.aspx"><%--算力记录--%><%=GetLanguage("CalcPowerRecord") %></a></li>
                    </ul>
                </li>

                <li class="has_sub">
                    <a href="javascript:void(0);" class="waves-effect"><i class="zmdi zmdi-collection-item"></i><span><%--交易大厅--%><%=GetLanguage("TradingFloor") %> </span><span class="menu-arrow"></span></a>
                    <ul class="list-unstyled">
                        <li><a href="/user/Cash/CashBuy.aspx"><%--委托买入--%><%=GetLanguage("CommissionedBuy") %> </a></li>
                        <li><a href="/user/Cash/CashSell.aspx"><%--委托卖出--%><%=GetLanguage("CommissionedSell") %> </a></li>
                        <li><a href="/user/Cash/CashBuyList.aspx"><%--买入记录--%><%=GetLanguage("BuyRecords") %></a></li>
                        <li><a href="/user/Cash/CashSellList.aspx"><%--卖出记录--%><%=GetLanguage("SellRecords") %></a></li>
                        <li><a href="/user/Cash/CashOrderList.aspx"><%--我的订单--%><%=GetLanguage("MyOrder") %></a></li>
                    </ul>
                </li>

                <li class="has_sub">
                    <a href="javascript:void(0);" class="waves-effect"><i class="zmdi zmdi-sort-amount-desc"></i><span><%--信息管理--%><%=GetLanguage("InformationManaget") %> </span><span class="menu-arrow"></span></a>
                    <ul class="list-unstyled">
                        <li><a href="/user/member/NoticeList.aspx"><%--新闻中心--%><%=GetLanguage("NewsInformation") %></a></li>
                        <li><a href="/user/member/Leavewords.aspx"><%--我要留言--%><%=GetLanguage("Sendmail") %></a></li>
                        <li><a href="/user/member/LeaveMsg.aspx"><%--收取邮件--%><%=GetLanguage("Receivemail") %></a></li>
                        <li><a href="/user/member/LeaveOut.aspx"><%--已发信件--%><%=GetLanguage("HaveEmail") %></a></li>

                    </ul>
                </li>
                <%-- <li class="has_sub">
                    <a href="javascript:void(0);" class="waves-effect"><i class="zmdi zmdi-sort-amount-desc"></i><span><%=GetLanguage("ShoppingMall")%><!--购物商城--> </span><span class="menu-arrow"></span></a>
                    
                </li>--%>
            </ul>
            <div class="clearfix"></div>
        </div>
        <!-- Sidebar -->
        <div class="clearfix"></div>
    </div>
</div>
