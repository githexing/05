<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="CalcPowerList.aspx.cs" Inherits="Web.user.finance.CalcPowerList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-sm-12">
					<div class="card-box">
                        <h4 class="header-title m-b-30"><!--算力记录--><%=GetLanguage("CalcPowerRecord") %></h4>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-merge table-responsive">
	                                <table class="table table-condensed m-0">
	                                    <thead>
	                                        <tr>
	                                            <th style="min-width: 80px;"><%=GetLanguage("Date")%><%--日期--%></th>
                                                <th style="min-width: 100px;"><%=GetLanguage("TypeofTransaction") %><%--交易类型--%></th>
                                                <th style="min-width: 100px;"><%=GetLanguage("Income")%><%--收入--%></th>
                                                <th style="min-width: 100px;"><%=GetLanguage("Expenditure")%><%--支出--%></th>
                                                <th style="min-width: 100px;"><%=GetLanguage("TheBalanceOf")%><%--余额--%></th>
                                                <th style="min-width: 100px;"><%=GetLanguage("BusinessSummary")%><%--业务摘要--%></th>
	                                        </tr>
	                                    </thead>
	                                    <tbody>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td th-name="时间">
                                                            <%#Eval("JoinTime")%>
                                                        </td>
                                                        <td th-name="账户类型">
                                                            <%# GetMoneyTypeName(Eval("MoneyType"))%>
                                                        </td>
                                                        <td th-name="收入">
                                                            <%#Eval("AddAmount")%>
                                                        </td>
                                                        <td th-name="支出">
                                                            <%#Eval("ReduceAmount")%>
                                                        </td>
                                                        <td th-name="余额">
                                                            <%#Eval("SurplusAmount")%>
                                                        </td>
                                                        <td th-name="业务摘要">
                                                            <%#Eval("Remark")%>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <tr runat="server" id="tr1">
	                                            <td colspan="10" class="colspan">
                                                    <div class="form-control-static text-center">
                                                        <i class="fa fa-warning text-warning"></i> 抱歉！目前数据库中暂无记录显示
                                                    </div>
	                                            </td>
	                                        </tr>
	                                    </tbody>
	                                </table>
	                            </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <!--页码-->
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" 
                                    PagingButtonLayoutType="UnorderedList" NumericButtonCount="3" PageSize="12"  
                                    ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false" PagingButtonSpacing="0" 
                                    CurrentPageButtonClass ="active" OnPageChanged="AspNetPager1_PageChanged">
                                </webdiyer:AspNetPager>
                            </div>
                        </div>
                    </div>
				</div>
            </div>
            <!-- End row -->
        </div> <!-- container -->
    </div>
</asp:content>
