<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="Invest.aspx.cs" Inherits="Web.user.finance.Invest" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <!-- Start content -->
    <div class="content">
        <div class="container">
            <div class="row m-b-20">
                <div class="col-md-12">
                    <div class="card-box">
                         <h4 class="header-title m-t-0 m-b-30"><%--购买矿机--%><%=GetLanguage("Investments") %></h4>
                        <div class="row">
                            <div class="form-horizontal col-sm-12">
                                <div class="form-group">
                                    <label class="col-md-2 control-label"><%--云盾--%><%=GetLanguage("ZCJF") %>：</label>
                                    <div class="col-md-10">
                                        <span class="text-danger"><%=LoginUser.Emoney%></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label"><%--矿机价格--%><%=GetLanguage("InvestmentMode") %>：</label>
                                    <div class="col-md-10">
                                        <asp:Label ID="lblPrice" runat="server"></asp:Label>/台
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label"><%--购买数量--%><%=GetLanguage("InvestmentNum") %>：</label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtNum" runat="server" class="form-control num" onkeyup="calctotal()"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label"><%--投资金额--%><%=GetLanguage("InvestmentAmount") %>：</label>
                                    <div class="col-md-10">
                                        <asp:Label ID="lblAmount" class="amount" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label"></label>
                                    <div class="col-md-10">
                                        <asp:Button ID="btnInvest" runat="server" class="btn btn-custom btn-md" OnClick="btnInvest_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box">
                                <h4 class="header-title m-t-0 m-b-30"><%--投资记录--%><%=GetLanguage("InvestmentRecord") %></h4>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="table-merge table-responsive">

                                            <table class="table table-condensed m-0" id="table">
                                                <thead>
                                                    <tr>
                                                        <th><%--价格--%><%=GetLanguage("MachinePrice") %></th>
                                                        <th><%--数量--%><%=GetLanguage("MachineNumber") %></th>
                                                        <th><%--金额--%><%=GetLanguage("TotalAmount") %></th>
                                                        <th><%--购买时间--%><%=GetLanguage("PurchaseTime") %></th>
                                                        <th><%--算力--%><%=GetLanguage("MachineCalc") %></th>


                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="Repeater1" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td th-name="价格"><%#Eval("Price")%></td>
                                                                <td th-name="数量"><%#Eval("Num")%></td>
                                                                <td th-name="金额"><%#decimal.Parse(Eval("Amount").ToString()).ToString("0.00")%></td>
                                                                <td th-name="购买时间"><%#Eval("BuyTime")%></td>
                                                                <td th-name="算力"><%#Eval("CalcPower")%></td>

                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <tr id="tr1" runat="server">
                                                        <td colspan="6" class="colspan">
                                                            <div class="form-control-static text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%></div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList"
                                                NumericButtonCount="3" PageSize="12"
                                                ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                                                OnPageChanged="AspNetPager1_PageChanged">
                                            </webdiyer:AspNetPager>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <!-- End row -->

        </div>
        <!-- container -->

    </div>
    <!-- content -->
    <script>
        function calctotal()
        {
            num = $('.num').val();
            price = <%=getParamAmount("InvestPrice") %>;
            if (num != "") {
                amount = price * num;
                $('.amount').text(amount);
            }
        }
    </script>
</asp:Content>
