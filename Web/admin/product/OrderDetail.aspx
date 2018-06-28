<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="web.admin.product.OrderDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>激活</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contentpanel">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:LinkButton ID="btn_s1" runat="server" class="btn btn-primary btn-bordered" iconcls="icon-back"> 返回 </asp:LinkButton>
                    <h4 class="panel-title mt10">订单信息</h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-2 mb10">订单号：<span class="inline-block"><asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"></asp:Label></span></div>
                        <div class="col-md-2 mb10">会员编号：<span class="inline-block"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></span> </div>
                        <div class="col-md-2 mb10">收货人姓名：<span class="inline-block"><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></span> </div>
                        <div class="col-md-2 mb10">
                            收货地址： <span class="inline-block">
                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></span>
                        </div>
                        <div class="col-md-2 mb10">快递公司：<span class="inline-block"><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></span></div>
                        <div class="col-md-2 mb10">快递单号：<span class="inline-block"><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></span></div>
                    </div>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">商品图片</th>
                                <th style="min-width: 80px;">商品编号</th>
                                <th style="min-width: 80px;">商品名称</th>
                                <th style="min-width: 80px;">市场价格</th>
                                <th style="min-width: 80px;">本站价格</th>
                                <th style="min-width: 80px;">购买数量</th>
                                <th style="min-width: 80px;">总金额</th>
                                <th style="min-width: 80px;">购买日期</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr >
                                    <td><a href='#' target="_blank">
                                        <img alt="" src='../../Upload/<%# Eval("Pic1") %>' width="100" height="100" /></a>
                                    </td>
                                    <td>
                                        <%#Eval("GoodsCode")%>
                                    </td>
                                    <td>
                                        <%#Eval("GoodsName")%>
                                    </td>
                                    <td>
                                        <%#Eval("Price")%>
                                    </td>
                                    <td>
                                        <%#Eval("ShopPrice")%>
                                    </td>
                                    <td>
                                        <%#Eval("OrderSum")%>
                                    </td>
                                    <td>
                                        <%#Eval("OrderTotal")%>
                                    </td>
                                    <td>
                                        <%#Eval("OrderDate")%>
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
