<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/user/index.Master"   CodeBehind="Mining_Records.aspx.cs" Inherits="Web.user.finance.Mining_Records" %> 
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %> 
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <!-- Start content -->
    <div class="content">
        <div class="container">
           
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box">
                                <h4 class="header-title m-t-0 m-b-30"><%--挖矿记录--%><%=GetLanguage("Mining_JR") %></h4>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="table-merge table-responsive">

                                            <table class="table table-condensed m-0" id="table">
                                                <thead>
                                                    <tr>
                                                        <th><%--时间--%><%=GetLanguage("Mining_Time") %></th>
                                                        <th><%--类型--%><%=GetLanguage("Mining_Type") %></th>
                                                        <th><%--收入--%><%=GetLanguage("Mining_Number") %></th> 

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="Repeater1" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td th-name="时间"><%#Eval("GiveTime")%></td>
                                                                <td th-name="类型"><%=GetLanguage("Mining_SR") %></td>
                                                                <td th-name="收入"><%#decimal.Parse(Eval("RandMoney").ToString()).ToString("0.000")%></td> 
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <tr id="tr1" runat="server">
                                                        <td colspan="3" class="colspan">
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
            
            <!-- End row -->

        </div>
        <!-- container -->

    </div>
    <!-- content -->
    <%--<script>
        function calctotal()
        {
            num = $('.num').val();
            price = <%=getParamAmount("InvestPrice") %>;
            if (num != "") {
                amount = price * num;
                $('.amount').text(amount);
            }
        }
    </script>--%>
</asp:Content>
