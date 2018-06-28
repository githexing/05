<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="CashBuy.aspx.cs" Inherits="Web.user.Cash.CashBuy" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <input type="hidden" class="hduid" value="<%=MyUserID %>"/>
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="card-box">
                        <div class="row form-horizontal">
                            <div class="form-group col-sm-6">
                                <label class="col-sm-3 control-label"><!--云图最新价格--><%=GetLanguage("YTLatestPrice") %></label>
                                <div class="col-sm-9 form-control-static"><span id="latestprice"></span></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
						        <div class="card-box">
               				        <h4 class="header-title col-lg-12"><!--我的资产--><%=GetLanguage("MyAssets") %></h4>
               				        <div class="row">
               					        <div class="col-lg-6">
			                                <div class="card-box widget-user">
			                                    <div class="text-center">
			                                        <h2 class="text-custom"><span id="myyt"></span></h2>
			                                        <h5>YT</h5>
			                                    </div>
			                                </div>
			                            </div>
			                            <div class="col-lg-6">
			                                <div class="card-box widget-user">
			                                    <div class="text-center">
			                                        <h2 class="text-pink"><span id="myyd"></span></h2>
			                                        <h5>YD</h5>
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
            <div class="row">
                <div class="col-sm-12">
					<div class="card-box">
                        <div class="row">
                            <div class="form-horizontal col-sm-12">
                        	    <div class="form-group">
                                    <label class="col-md-2 control-label"><span class="text-danger">*</span> <!--商品数量--><%=GetLanguage("Quantity") %></label>
                                    <div class="col-md-10">
                                        <div class="input-group">
                                            <input type="number" class="form-control" id="txtnum" onkeyup="value=value.replace(/[^\d]/g,'')" oninput="countresult()">
                                        </div>
                                    </div>
                                </div>
                        		<div class="form-group">
                                    <label class="col-md-2 control-label"><span class="text-danger">*</span> <!--商品单价--><%=GetLanguage("CommodityPrices") %></label>
                                    <div class="col-md-10">
                                        <div class="input-group">
                                            <input type="number" class="form-control" id="txtprice" onkeyup="value=value.replace(/[^\d\.]/g,'')" oninput="countresult()">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label"><span class="text-danger">*</span> <!--支付密码--><%=GetLanguage("SecondPassword") %></label>
                                    <div class="col-md-10">
                                        <div class="input-group">
                                            <input type="password" class="form-control" id="txtpaypwd">
                                        </div>
                                    </div>
                                </div>
                        		<div class="form-group">
                                    <label class="col-md-2 control-label"><!--总价--><%=GetLanguage("TotalAmount") %></label>
                                    <div class="col-md-10 form-control-static"><span id="tastemoney">0</span>RMB</div>
                                </div>
                                <div class="form-group m-b-0">
                                    <div class="col-sm-offset-2 col-sm-10">
                                        <a href="javascript:void(0);" class="btn btn-custom waves-effect waves-light" id="abuy"><!--买入YT--><%=GetLanguage("Buy") %>YT</a>
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
               		    <h4 class="header-title col-lg-12">市场挂单</h4>
               			<div class="row">
               			    <div class="col-lg-6">
			                    <div class="table-merge table-responsive">
	                                <table class="table table-condensed m-0">
	                                    <thead>
	                                        <tr>
	                                            <th style="min-width: 80px;"><!--买家--><%=GetLanguage("Buyers") %></th>
	                                            <th style="min-width: 100px;"><!--数量--><%=GetLanguage("Number") %></th>
	                                            <th style="min-width: 100px;"><!--价格--><%=GetLanguage("MachinePrice") %></th>
	                                        </tr>
	                                    </thead>
	                                    <tbody id="tbbuy">

	                                    </tbody>
	                                </table>
	                            </div>
			                </div>
			                <div class="col-lg-6">
			                    <div class="table-merge table-responsive">
	                                <table class="table table-condensed m-0">
	                                    <thead>
	                                        <tr>
	                                            <th style="min-width: 80px;"><!--卖家--><%=GetLanguage("Seller") %></th>
	                                            <th style="min-width: 200px;"><!--数量--><%=GetLanguage("Number") %></th>
	                                            <th style="min-width: 80px;"><!--价格--><%=GetLanguage("MachinePrice") %></th>
	                                        </tr>
	                                    </thead>
	                                    <tbody id="tbsell">

	                                    </tbody>
	                                </table>
	                            </div>
			                </div>
               			</div>
               		</div>
               	</div>
            </div>
        </div>
    </div>
    <script src="/JS/jquery.md5.js"></script>
    <script type="text/javascript">
        //填充
        function AddTable(a, b) {
            var html = "";
            $(a).each(function (i)            //解析json
            {
                var c = i + 1;
                if (b == 1) {
                    html += "<tr id='buy_" + c + "' onclick='clicktr(1," + c + ")'>" //买
                } else {
                    html += "<tr id='sell_" + c + "' onclick='clicktr(2," + c + ")'>" //卖
                }
                html += "<td th-name=''>" + this.UserCode + "</td>";
                if (b == 1) {
                    html += "<td th-name='数量' id='buynum_" + c + "'>" + this.SurplusNum + "</td>";
                } else {
                    html += "<td th-name='数量' id='sellnum_" + c + "'>" + this.SurplusNum + "</td>";
                }
                html += "<td th-name='价格'>";
                if (b == 1) {
                    html += "<span class='text-success' id='buyprice_" + c + "'>" + this.Price + "</span>";
                } else {
                    html += "<span class='text-success' id='sellprice_" + c + "'>" + this.Price + "</span>";
                }
                html += "</td>";
                html += "</tr>";
            });
            if (b == 1) {
                document.getElementById("tbbuy").innerHTML = html;
            } else {
                document.getElementById("tbsell").innerHTML = html;
            }
        }

        function clicktr(a, b) {
            var price;
            var num;
            if (a == 1) {
                price = $("#buyprice_" + b).text();
                num = $("#buynum_" + b).text();
            } else {
                price = $("#sellprice_" + b).text();
                num = $("#sellnum_" + b).text();
            }
            
            $("#txtprice").val(price);
            $("#txtnum").val(num);
            $("#tastemoney").text((price * num).toFixed(4));
        }

        function countresult() {
            var price = $("#txtprice").val();
            var buynum = $("#txtnum").val();
            var a = parseFloat(price * buynum);
            if (a == 0) {
                a = 0;
            } else {
                a = a.toFixed(4);
            }
            $("#tastemoney").text(a);
        }

        $(function () {
            var userid = $(".hduid").val();
            //加载列表
            $.ajax({
                url: "/AppService/Trading.ashx",
                type: "post",
                data: { act: "house", userid: userid },
                success: function (result) {
                    var data = eval('(' + result + ')');
                    $("#latestprice").text(data.data.LatestPrice);
                    $("#myyt").text(data.data.YT);
                    $("#myyd").text(data.data.YD);
                    AddTable(data.data.BuyList, 1);
                    AddTable(data.data.SellList, 2);
                },
                error: function (ex) {
                    alert("Network anomaly");
                }
            })
            //购买动作
            $("#abuy").click(function () {
                $(this).attr("disabled", true);
                var price = $("#txtprice").val();
                var num = $("#txtnum").val();
                var paypwd = $.md5($("#txtpaypwd").val());
                $.ajax({
                    url: "/AppService/Trading.ashx",
                    type: "post",
                    data: { act: "buy", userid: userid, price: price, number: num, paypassword: paypwd },
                    success: function (result) {
                        var data = eval('(' + result + ')');
                        if (data.state == "success") {
                            $("#latestprice").text(data.data.LatestPrice);
                            $("#myyt").text(data.data.YT);
                            $("#myyd").text(data.data.YD);
                            AddTable(data.data.BuyList, 1);
                            AddTable(data.data.SellList, 2);
                            $("#txtprice").val("");
                            $("#txtnum").val("");
                            $("#txtpaypwd").val("");
                        }
                        alert(data.message);
                    },
                    error: function (ex) {
                        alert("Network anomaly");
                    }
                });
                $(this).attr("disabled", true);
            })
        })
    </script>
</asp:content>
