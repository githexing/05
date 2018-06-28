<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="CashBuyList.aspx.cs" Inherits="Web.user.Cash.CashBuyList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
    <input type="hidden" class="hduid" value="<%=MyUserID %>"/>
    <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-sm-12">
					<div class="card-box">
                        <h4 class="header-title m-b-30"><!--买入记录--><%=GetLanguage("BuyRecords") %></h4>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-merge table-responsive">
	                                <table class="table table-condensed m-0">
	                                    <thead>
	                                        <tr>
	                                            <th style="min-width: 80px;"><!--订单时间--><%=GetLanguage("OrderTimes") %></th>
	                                            <th style="min-width: 80px;"><!--会员编号--><%=GetLanguage("MembershipNumber") %></th>
	                                            <th style="min-width: 100px;"><!--订单编号--><%=GetLanguage("OrderNumber") %></th>
	                                            <%--<th style="min-width: 100px;">交易类型</th>--%>
	                                            <th style="min-width: 100px;"><!--价格--><%=GetLanguage("MachinePrice") %></th>
	                                            <th style="min-width: 80px;"><!--总数量--><%=GetLanguage("TotalQuantity") %></th>
	                                            <th style="min-width: 80px;"><!--已购数量--><%=GetLanguage("HQuantity") %></th>
                                                <th style="min-width: 80px;"><!--剩余数量--><%=GetLanguage("SurplusQuantity") %></th>
                                                <th style="min-width: 100px;"><!--总金额--><%=GetLanguage("TheTotalAmount") %></th>
                                                <th style="min-width: 80px;"><!--状态--><%=GetLanguage("State") %></th>
	                                        </tr>
	                                    </thead>
	                                    <tbody id="tbdata">

	                                    </tbody>
	                                </table>
	                            </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <!--页码-->
                                <ul class="pagination pagination-split pull-right pagination-sm" id="ulpage">

                                </ul>
                            </div>
                        </div>
                    </div>
				</div>
            </div>
            <!-- End row -->
        </div> <!-- container -->
    </div>
    <script type="text/javascript">

        $(function () {
            var pageindex = 1;
            var pagesize = 15;
            AjaxGetData(pageindex, pagesize);
            //Ajax获取数据
        });

        function AjaxGetData(index, size) {
            var userid = $(".hduid").val();
            $.ajax({
                url: "/AppService/Trading.ashx",
                type: "post",
                data: { act: "buylist", userid: userid, pageindex: index, pagesize: size, fromwhere: "pc" },
                success: function (result) {
                    var data = eval("(" + result + ")")
                    //console.log(data);
                    if (data.state = "success") {
                        var htmlStr = "";
                        var list = data.data.list;
                        var length = list.length;
                        //console.log(length);
                        if (length <= 0) {
                            htmlStr += "<tr>";
                            htmlStr += "<td colspan='10' class='colspan'><div class='form-control-static text-center'><i class='fa fa-warning text-warning'></i>  No Data. </div></td>"
                            htmlStr += "</tr>";
                        } else {
                            for (var i = 0; i < length; i++) {
                                htmlStr += "<tr>";
                                htmlStr += "<td th-name='创建时间'>" + list[i].BuyDate + "</td>";
                                htmlStr += "<td th-name='会员编号'>" + list[i].UserCode + "</td>";
                                htmlStr += "<td th-name='订单编号'>" + list[i].OrderCode + "</td>";
                                //htmlStr += "<td th-name='交易类型'>" + list[i].TypeIDName + "</td>";
                                htmlStr += "<td th-name='价格'>" + list[i].Price.toFixed(4) + "</td>";
                                htmlStr += "<td th-name='购买总量'>" + list[i].Number + "</td>";
                                htmlStr += "<td th-name='已购数量'>" + list[i].BuyNum + "</td>";
                                htmlStr += "<td th-name='等购数量'>" + list[i].SurplusNum + "</td>";
                                htmlStr += "<td th-name='总金额'>" + list[i].Amount.toFixed(4) + "</td>";
                                htmlStr += "<td th-name='状态'>" + list[i].StatusText + "</td>";
                                htmlStr += "</tr>";
                            }
                        }
                        $("#tbdata").html(htmlStr);
                        var pageStr = "";
                        if (data.data.totalcount > 0) {
                            if (data.data.pageindex > 1) {
                                pageStr += "<li><a href='javascript:void(0);' onclick='AjaxGetData(" + (data.data.pageindex - 1) + "," + size + ")'><i class='fa fa-angle-left'></i></a>&nbsp;&nbsp;</li>";
                            }
                            var i = 0;
                            var a = data.data.pageindex - 2;
                            while (i < 2) {
                                i++;
                                if (a > 0) {
                                    pageStr += "<li><a href='javascript:void(0);' onclick='AjaxGetData(" + a + "," + size + ")'>" + a + "</a></li>";
                                }
                                a += 1;
                            }
                            pageStr += "<li class='active'><a href='javascript:void(0);'>" + data.data.pageindex + "</a></li>";
                            if (data.data.pageindex < data.data.pagecount) {
                                i = 0;
                                var b = data.data.pageindex + 1;
                                console.log(data.data.pagecount);
                                console.log(b);
                                while (i < 2 && b <= data.data.pagecount) {
                                    console.log(b);
                                    i++;
                                    pageStr += "<li><a href='javascript:void(0);' onclick='AjaxGetData(" + b + "," + size + ")'>" + b + "</a></li>";
                                    b += 1;
                                }
                                pageStr += "<li><a href='javascript:void(0);' onclick='AjaxGetData(" + (data.data.pageindex + 1) + "," + size + ")'><i class='fa fa-angle-right'></i></a></li>";
                            }
                            //pageStr += "<li>共" + data.data.totalcount + "条记录&nbsp;&nbsp;共" + data.data.pagecount + "页</li>";
                        }
                        else {
                            pageStr += "";
                        }
                        $("#ulpage").html(pageStr);
                    } else {
                        alert(data.message);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //alert(XMLHttpRequest);
                    //alert(textStatus);
                    //alert(errorThrown);
                    alert("Network anomaly");
                }
            });
        };

    </script>

</asp:content>
