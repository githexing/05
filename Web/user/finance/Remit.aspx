<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="Remit.aspx.cs" Inherits="Web.user.finance.Remit" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="content">
        <div class="container">
            <div class="row m-b-20">
                <div class="col-md-12">
                    <div class="card-box">
                        <div class="grid-title">
                            <h4>充值</h4>
                        </div>
                        <div class="row">
                            <div class="form-horizontal col-sm-12">
                                <div class="form-group">
                                    <label class="col-md-2 control-label">汇入银行：</label>
                                    <div class="col-md-10">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="dropBank" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="dropBank_SelectedIndexChanged"></asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label class="col-md-2 control-label">汇入账户：</label>
                                    <div class="col-md-10">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lblBankAccount" runat="server" Text=""></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label class="col-md-2 control-label">开户名：</label>
                                    <div class="col-md-10">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lblBankAccountUser" runat="server" Text=""></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label class="col-md-2 control-label">汇款金额：</label>
                                    <div class="col-md-10">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <input name="jd" type="text" id="txtMoney" runat="server" onkeydown="if(event.keyCode==13)event.keyCode=9"
                                                    onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"
                                                    class="form-control" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-2 control-label">汇款具体时间：</label>
                                    <div class="col-md-10">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtTime" runat="server" class="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-2 control-label">汇出银行：</label>
                                    <div class="col-md-10">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <input type="text" id="txtOutBank" runat="server" class="form-control" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-2 control-label">汇出账户：</label>
                                    <div class="col-md-10">
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtOutAccount" type="text" runat="server" class="form-control" MaxLength="60"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-2 control-label">汇款备注：</label>
                                    <div class="col-md-10">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtRemark" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-2 control-label"></label>
                                    <div class="col-md-10">
                                        <asp:Button ID="btnSubmit" runat="server" Style="margin: 0px;" Text="提 交" class="btn btn-custom " OnClick="btnSubmit_Click" OnClientClick="javascript:return confirm('确定要充值吗？')" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" Style="margin: 0px;" Text="重 置" class="btn" OnClick="btnReset_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box">
                                <h4 class="header-title m-t-0 m-b-30">
                                    <!--查询-->
                                    <%=GetLanguage("Query") %></h4>
                                <div class="row">
                                    <div class="form-inline col-sm-12">

                                        <div class="form-group">
                                            <label><%=GetLanguage("DateTransfer") %><!--转账日期--></label>
                                            <div class="input-daterange input-group" id="date-range">
                                                <%if (GetLanguage("LoginLable") == "zh-cn")
                                                    {%>
                                                <asp:TextBox ID="txtStart" runat="server" class="form-control" name="start" onfocus="WdatePicker()"></asp:TextBox>
                                                <%}
                                                    else
                                                    {%>
                                                <asp:TextBox ID="txtStartEn" runat="server" class="form-control" name="start" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                                <%} %>
                                                <span class="input-group-addon bg-inverse b-0 text-white"><%=GetLanguage("To")%><!--至--></span>
                                                <%if (GetLanguage("LoginLable") == "zh-cn")
                                                    {%>
                                                <asp:TextBox ID="txtEnd" runat="server" class="form-control" name="end" onfocus="WdatePicker()"></asp:TextBox>
                                                <%}
                                                    else
                                                    {%>
                                                <asp:TextBox ID="txtEndEn" runat="server" class="form-control" name="end" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                                <%} %>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-success btn-md" OnClick="btnSearch_Click" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="table-merge table-responsive">

                                            <table class="table table-condensed m-0">
                                                <tr>
                                                    <th align="center">汇款金额
                                                    </th>
                                                    <th align="center">汇款具体时间
                                                    </th>
                                                    <th align="center">汇出银行
                                                    </th>
                                                    <th align="center">汇出账户
                                                    </th>
                                                    <th align="center">汇款备注
                                                    </th>
                                                    <th align="center">申请日期
                                                    </th>
                                                    <th align="center">状态
                                                    </th>
                                                </tr>
                                                <asp:Repeater ID="rpTake" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <%#Eval("RemitMoney")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("RechargeableDate")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Remit003")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Remit004")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Remark")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("AddDate")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("State").ToString() == "0" ?"未审" : "已审"%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr>
                                                    <td colspan="7">
                                                        <div id="divno" runat="server" class="NoData">
                                                            <span class="cBlack">
                                                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                                                <%=GetLanguage("Manager")%></span>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="text-right">

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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
