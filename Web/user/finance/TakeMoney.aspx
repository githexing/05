<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="TakeMoney.aspx.cs" Inherits="Web.user.finance.TakeMoney" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>

    <div class="content">

        <div id="container">
            <div class="row m-b-20">
                <div class="col-md-12">
                    <div class="card-box">
                        <div class="grid-title">
                            <h4>我要提现</h4>
                        </div>

                        <div class="row">
                            <div class="form-inline col-sm-12">
                                <div class="form-group">
                                    <label>云盾余额：</label>
                                    <div class="input-group">
                                        <%=LoginUser.Emoney.ToString("0.00")  %>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-inline col-sm-12">
                                <div class="form-group">
                                    <label><%=GetLanguage("WithdrawalAmount")%><!--提现金额-->：</label>
                                    <div class="input-group">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <%--<input type="number" id="cashMoney" class="form-control" value="" onchange="$('#cashActual').val(($(this).val()*.95).toFixed(2))" required="required">--%>
                                                <asp:TextBox ID="txtTake" precision="2" class="form-control" runat="server" AutoPostBack="True" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;" OnTextChanged="txtTake_TextChanged"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-inline col-sm-12">
                                <div class="form-group">
                                    <label><%=GetLanguage("WithdrawalFee")%><!--手续费-->：</label>
                                    <div class="input-group">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <%--<input type="number" id="cashMoney" class="form-control" value="" onchange="$('#cashActual').val(($(this).val()*.95).toFixed(2))" required="required">--%>
                                                <asp:Label runat="server" ID="lblFee"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-inline col-sm-12">
                                <div class="form-group">
                                    <label><%=GetLanguage("ActualAmount")%><%--到账金额--%>：</label>
                                    <div class="input-group">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <input name="txtExtMoney" type="text" class="form-control" id="txtExtMoney" runat="server" disabled="disabled" />￥
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-inline col-sm-12">
                                <div class="form-group">
                                    <label></label>
                                    <div class="input-group">
                                        <asp:Label runat="server" ID="ream"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-inline col-sm-12">
                                <div class="form-group">
                                    <label></label>
                                    <div class="input-group">
                                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" class="btn btn-primary" />
                                    </div>
                                </div>
                            </div>
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
                            <asp:Button ID="btnSearch" runat="server" class="btn btn-success waves-effect waves-light btn-md" OnClick="btnSearch_Click" />

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
                                    <thead>
                                        <tr>
                                            <th>提现类型<!--提现金额--></th>
                                            <th><%=GetLanguage("WithdrawalAmount")%><!--提现金额--></th>
                                            <th><%=GetLanguage("WithdrawalFee")%><!--提现手续费--></th>
                                            <th><%=GetLanguage("ActualAmount")%><!--到账金额--></th>
                                            <th><%=GetLanguage("DateWithdrawal")%><!--提现日期--></th>
                                            <th><%=GetLanguage("State")%><!--状态--></th>
                                            <th><%=GetLanguage("Operation")%><!--操作--></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                    <td data-title="提现类型"><%# TakeType(Convert.ToInt32(Eval("Take001")))%></td>
                                                    <td data-title="提现金额"><%#Eval("TakeMoney")%></td>
                                                    <td data-title="提现手续费"><%#Eval("TakePoundage")%></td>
                                                    <td data-title="到账金额"><%#Eval("RealityMoney")%></td>
                                                    <td data-title="提现日期"><%#Eval("TakeTime")%></td>
                                                    <td data-title="状态">
                                                        <% if (Language == "zh-cn")
                                                            { %>
                                                        <span class="text-success"><%#Eval("Flag").ToString() == "0" ? "等待审核..." : "已审核"%></span>
                                                        <% }
                                                            else
                                                            { %>
                                                        <span class="text-success"><%#Eval("Flag").ToString() == "0" ? "Not released" : "Has been released"%></span>
                                                        <% }%>
                                                    </td>
                                                    <td data-title="操作">
                                                        <%--<button class="btn btn-danger btn-sm del-alert" data-toggle="modal" data-target="#myModal">删除</button>--%>
                                                        <asp:LinkButton ID="lbtnCancel" runat="server" class="btn btn-danger btn-sm del-alert" CommandName="change" Visible='<%#Eval("Flag").ToString() == "0" ? true : false%>'
                                                            CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('确认取消提现吗？')"><%=GetLanguage("CancelWithdrawal")%><!--取消提现--></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                    <tr id="tr1" runat="server">
                                        <td colspan="6" class="colspan">
                                            <div class="text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
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
    <!-- ENG PAGE CONTAINER-->
    <script type="text/javascript" src="../../js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //弹出框
            var numDel = -1;
            $(".del-alert").on('click', function () {
                numDel = $(".del-alert").index($(this));
            })
            $("#myModal .btn-sure").on('click', function () {
                $(".del-alert").eq(numDel).parents('tr').remove();
            })
        })
    </script>
    <script type="text/javascript" src="../../js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //选择日期
            $('.input-append.date').datepicker({
                autoclose: true,
                todayHighlight: true,
                format: 'yyyy-mm-dd'
            })
        })
    </script>
    <script type="text/javascript" src="../../JS/Comm.js">
            
    </script>
</asp:Content>
