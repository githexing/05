<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderProduct.aspx.cs" Inherits="web.admin.product.OrderProduct" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>激活</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <style>
        .red {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">查询</h4>
                </div>
                <div class="panel-body">
                    <div class="form-group mt10">
                        <a href="OrderProduct.aspx?type=1" iconcls="icon-search" class="btn btn-primary mr5"><i class="fa fa-bar-chart-o"></i>所有记录</a>
                        <a href="OrderProduct.aspx?type=2" iconcls="icon-search" class="btn btn-primary mr5"><i class="fa fa-ban"></i>未付款</a>
                        <a href="OrderProduct.aspx?type=3" iconcls="icon-search" class="btn btn-primary mr5"><i class="fa fa-send-o"></i>待发货</a>
                        <a href="OrderProduct.aspx?type=4" iconcls="icon-search" class="btn btn-primary mr5"><i class="fa fa-send"></i>已发货</a>
                        <a href="OrderProduct.aspx?type=5" iconcls="icon-search" class="btn btn-primary mr5"><i class="fa fa-check"></i>已完成</a>
                    </div>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <input name="txtInput" id="txtInput" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">结算日期:</label>
                                <asp:TextBox ID="txtStar" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="btnSearch2_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-print" OnClick="daochu_Click"><i class="fa fa-download"></i> 导 出 </asp:LinkButton>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">时间</th>
                                <th style="min-width: 80px;">订单号</th>
                                <th style="min-width: 70px;">会员编号</th>
                                <th style="min-width: 70px;">购买数量</th>
                                <th style="min-width: 80px;">总金额/总积分</th>
                                <th style="min-width: 80px;">收货人姓名</th>
                                <th style="min-width: 80px;">收货地址</th>
                                <th style="min-width: 80px;">联系电话</th>
                                <th style="min-width: 70px;">快递公司</th>
                                <th style="min-width: 80px;">快递单号</th>
                                <th style="min-width: 80px;">支付类型</th>
                                <th style="min-width: 60px;">状态</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rptOrder" runat="server" OnItemCommand="rptOrder_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Convert.ToDateTime(Eval("OrderDate")).ToString("yyyy-MM-dd HH:mm:ss")%>
                                    </td>
                                    <td>
                                        <%#Eval("OrderCode")%>
                                    </td>
                                    <td>
                                        <%#Eval("UserCode")%>
                                    </td>
                                    <td>
                                        <%#Eval("OrderSum")%>
                                    </td>
                                    <td>
                                        <%#Eval("OrderTotal")%>
                                    </td>
                                    <td>
                                        <%#Eval("order7")%>
                                    </td>
                                    <td>
                                        <%#Eval("UserAddr")%>
                                    </td>
                                    <td>
                                        <%#Eval("order6")%>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGongsi" runat="server" Text='<%#Eval("order3")%>' style="min-width: 70px;"></asp:TextBox>
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDanhao" runat="server" Text='<%#Eval("order4")%>' style="min-width: 80px;"></asp:TextBox>
                                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <%#Eval("OrderType").ToString()=="0"?"购物币":Eval("OrderType").ToString() =="1"?"购物币":Eval("OrderType").ToString() =="2"?"购物币":"购物币"%>
                                    </td>
                                    <td align="center">
                                        <%#GetState(Eval("IsSend").ToString(),Eval("IsDel").ToString())%>
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hft" runat="server" Value='<%# Eval("IsSend") %>' />
                                        <asp:LinkButton ID="lbtnEnter" runat="server" CommandName="enter" CommandArgument='<%# Eval("OrderCode") %>'
                                            class="btn btn-primary mb5" iconcls="icon-ok" Visible='<%#Convert.ToInt32(Eval("IsDel"))>0 ? false: Convert.ToInt32(Eval("IsSend"))==1?true:false%>'
                                            OnClientClick="javascript:return confirm('仔细核对快递公司及单号，确认要发货？')"><i class="fa fa-send"></i>确认发货</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                            class="btn btn-info" iconcls="icon-search" CommandName="show"><i class="fa fa-pencil mb5"></i>查看明细</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="lbtnCancel" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                    class="btn btn-info" iconcls="icon-cancel" CommandName="cancel" OnClientClick="javascript:return confirm('确定取消订单？')"
                                    Visible='<%#(Convert.ToInt32(Eval("IsDel")) == 1)?true:false%>'>确认取消</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                            class="btn btn-info" iconcls="icon-undo" CommandName="revoke" OnClientClick="javascript:return confirm('确定撤销申请吗？')"
                                            Visible='<%#(Convert.ToInt32(Eval("IsDel")) == 1)?true:false%>'>撤销申请</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr runat="server" id="trNull" class="none">
                            <td colspan="13" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                            PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                            UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
                            textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
