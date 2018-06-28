<%@ Page Language="C#" MasterPageFile="~/user/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.user.index" %>

<%@ Register Src="~/userControl/Right.ascx" TagPrefix="uc2" TagName="Right" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %> 
<asp:content contentplaceholderid="ContentPlaceHolder1"  runat="server">
     
     <script type="text/javascript">
         $(function () {
             $.ajax({
                 url: "/APPService/YunTu_List.ashx?UserID=<%=getLoginID()%>",
                type:"POST",
                success: function (data1) { 
                    var data = eval('(' + data1 + ')') 
                    if (data.state == "success") {
                        var dates ="["; 
                        for (var i = 0; i < data.data.List.length; i++) {
                            if (i == data.data.List.length - 1) {
                                dates += "{ID:" + data.data.List[i].ID + ",Money:" + data.data.List[i].Money + "}"
                                continue;
                            }
                            if (i>0) {
                                dates += "{ID:" + data.data.List[i].ID + ",Money:" + data.data.List[i].Money + "},"
                            } 
                        }
                        dates+="]"
                        dates = eval('(' + dates + ')') 
                        game(dates,<%=getLoginID()%>); 
                    } 
                } 
            }) 
        })
         <%--$(function () {
             $(".NLQ").click(function () {
                 alert(1)
                 var ID = this.id;
                 alert(ID)
                 $ajax({
                     url: "/APPService/YunTu_IDSub.ashx?UserID=<%=getLoginID()%>&&ID=" + ID + "",
                     type: "POST",
                     success: function () {
                         Touch();
                     } 
                 }) 
             })
         })--%>
    </script>
   
        <div class="content">
            <div class="container">

                <div class="row" style="display:none">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <div class="row" style="display:none">
                                <div class="form-inline col-sm-6" >
                                    <div class="form-group">
                                        <label><%--请选择语言--%><%=GetLanguage("Language") %></label>
                                        <select name="" class="form-control" id="LangType" runat="server">
                                            <%--<option value="0">-请选择-</option>--%>
                                            <option value="1">中文</option>
                                            <option value="2">English</option>
                                        </select>
                                    </div>
                                    <asp:Button id="btnSubmit" runat="server" class="btn btn-custom btn-md" OnClick="btnSubmit_Click"/>
                                 
                                </div>

                                <div class="form-inline col-sm-6">
                                    <div class="form-group">
                                        <label><%=GetLanguage("MembershipNumber") %><%--会员编号--%></label>
                                        <label class="text-success"><%=LoginUser.UserCode%></label>
                                    </div>
                                    <%--<div class="form-group">
                                        <label><%=GetLanguage("State") %><!--状态--></label>
                                        <label class="<%=LoginUser.IsLock == 1 ?"text-danger":LoginUser.IsOpend == 2 ?"text-success":"text-danger"%>" ><%=LoginUser.IsLock == 1 ?"账号已冻结":LoginUser.IsOpend == 2 ?"已激活":"未激活"%></label>
                                    </div>--%>
                                    <asp:Button id="btnActive" runat="server" class="btn btn-success waves-effect waves-light btn-md" OnClick="btnActive_Click"/>
                                 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                
                
                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
							
                            <div id="game" class="energy-game">
				            <div class="energy-game-bg"></div>
				            <div class="energy-cart" id="gameCart"></div>
				            <div class="energy-game-ball" id="gameBall"></div>
				            <div class="energy-game-btn">
					        <a href="member/GetCalcPower.aspx" class="btn-left">获取算力</a>
					    	<a href="finance/Mining_Records.aspx" class="btn-right">挖矿记录</a>
				</div>
			</div>
							<audio src="/music/abc.mp3" id="collectMusic"></audio>
                        </div>
                    </div>
                    <div class="col-lg-8 col-md-6">
                        <div class="card-box widget-user">
                            <h4 class="header-title m-t-0 m-b-30">
                            	<span>排行榜</span>
                            	<span class="pull-right" style="font-weight: normal; font-size: 14px;">排行2小时更新一次</span>
                            </h4>
                        	<table class="table table-condensed m-0">
                                <thead>
                                    <tr>
                                        <th>名次</th>
                                        <th>矿机台数</th>
                                        <th>算力</th>
                                    </tr>
                                </thead>
                                <tbody>
                                 <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                           <td th-name="名次"><%#Eval("RankID").ToString()  %>  &nbsp;  <%#Eval("Name").ToString()  %> </td>
                                           <td th-name="矿机台数"><%# Eval("Kuangji").ToString()%></a></td>
                                           <td th-name="算力"><%#decimal.Parse(Eval("Total_Suanli").ToString()).ToString("0")%></td> 
                                             </tr>
                                               </ItemTemplate>
                                                </asp:Repeater>
                                                <tr id="tr2" runat="server">
                                                    <td colspan="3" class="colspan">
                                                        <div class="form-control-static text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                 
                            </table>
                              <div class="row">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList"
                                                NumericButtonCount="3" PageSize="6"
                                                ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                                                OnPageChanged="AspNetPager1_PageChanged">
                                            </webdiyer:AspNetPager>
                                        </div>
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-success"><%=LoginUser.Emoney%></h2>
                                <h5><%=GetLanguage("ZCJF") %><%--云盾--%></h5>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-pink"><%=LoginUser.BonusAccount%></h2>
                                <h5><%=GetLanguage("Cash") %><%--云图--%></h5>
                            </div>
                        </div>
                    </div>
                    <%--<div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-info"><%=LoginUser.StockAccount%></h2>
                                <h5><%=GetLanguage("Multiple") %><!--复投积分--></h5>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-warning"><%=LoginUser.StockMoney%></h2>
                                <h5><%=GetLanguage("Investment") %><!--投资积分--></h5>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-purple"><%=LoginUser.ShopAccount%></h2>
                                <h5><%=GetLanguage("Transaction") %><!--云图--></h5>
                            </div>
                        </div>
                    </div>--%>
                   <%-- <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-info"><!--推广链接--><%=GetLanguage("PromotionLink") %></h2>
                                <h5>
                                    <a href='<%=rem_url %>' target="_brank" class="tga" style="background: none; background-color: transparent; border: none; font-size: inherit; outline: none; color: #06f; float: left;"><%=rem_url %></a>
                                </h5>
                            </div>
                        </div>
                    </div>--%>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%--新闻中心--%><%=GetLanguage("NewsInformation") %></h4>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-merge table-responsive">
                                        <table class="table table-condensed m-0">
                                            <thead>
                                                <tr>
                                                    <th><%--序号--%><%=GetLanguage("SerialNumber") %></th>
                                                    <th><%--标题--%><%=GetLanguage("Title") %></th>
                                                    <th><%--时间--%><%=GetLanguage("Time") %></th>
                                                    <th><%--操作--%><%=GetLanguage("Operation") %></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                            <td th-name="序号"><%# this.Repeater1.Items.Count + 1%></td>
                                                            <td th-name="标题"><%# getstring(Language,Eval("NewsTitle").ToString(),18)%></a></td>
                                                            <td th-name="时间"><%#Convert.ToDateTime(Eval("PublishTime")).ToString("")%></td>
                                                            <td th-name="操作"><a href="/user/member/NoticeDetail.aspx?ID=<%#Eval("ID") %>" class="btn btn-info btn-sm"><%--查看--%><%=GetLanguage("check") %></a></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr id="tr1" runat="server">
                                                    <td colspan="4" class="colspan">
                                                        <div class="form-control-static text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
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


</asp:content>
