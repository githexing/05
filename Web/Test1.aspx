<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="Web.Test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="JS/jquery-1.11.3.min.js"></script>
    <script src="JS/jquery.cookie.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="text" id="txtPhoneNum" />
            <input type="button" id="btnSendsms" value="submit" />
        </div>

        <div>
            <input type="button" id="btnhall" value="交易大厅"/>
            <br />
            <input type="button" id="yuntulist" value="yuntulist"/>
            <br />
            <input type="button" id="buy" value="买入"/>
            <br />
            <input type="button" id="sell" value="卖出"/>
            <br />
            <input type="button" id="tradingorder" value="交易记录"/>
            <br />
            <input type="button" id="buyandsell" value="买卖列表"/>
            <br />
            订单ID：<input type="text" id="a" />
            <input type="button" id="cancel" value="撤销"/>
            <br />
            <input type="button" id="login" value="登录"/><input type="button" id="token" value="验证授权码"/>
            <br />
            <input type="button" id="rank" value="Rank排名"/>
            <br />
            身份证<input type="text" id="idcard"/>姓名<input type="text" id="realname"/><input type="button" id="btnidcard" value="验证身份证"/>
        </div>
        <script type="text/javascript">
            var userid = 1;
            var pageindex = 1;
            var pagesize = 5;
            var paypassword = 'C4CA4238A0B923820DCC509A6F75849B';
            
            $(function () {
                $("#btnhall").click(function () {
                    
                    $.ajax({
                        url: "/AppService/Trading.ashx",
                        type: "post",
                        data: { act: "house", userid: userid, top: 10 },
                        success: function (data) {
                            console.log(data);
                        },
                        error: function () {
                            alert("网络错误");
                        }
                    })
                })

                $("#yuntulist").click(function () {
                    $.ajax({
                        url: "/AppService/YunTu_List.ashx",
                        type: "post",
                        data: { act: "house", userid: userid, top: 10 },
                        success: function (data) {
                            console.log(data);
                        },
                        error: function () {
                            alert("网络错误");
                        }
                    })
                })
                //买入
                $("#buy").click(function () {
                    $.ajax({
                        url: "/AppService/Trading.ashx",
                        type: "post",
                        data: { act: "buy", userid: userid, price: 1, number:10, paypassword:paypassword },
                        success: function (data) {
                            console.log(data);
                        },
                        error: function () {
                            alert("网络错误");
                        }
                    })
                })
                //卖出
                $("#sell").click(function () {
                    $.ajax({
                        url: "/AppService/Trading.ashx",
                        type: "post",
                        data: { act: "sell", userid: userid, price: 1, number:10, paypassword:paypassword },
                        success: function (data) {
                            console.log(data);
                        },
                        error: function () {
                            alert("网络错误");
                        }
                    })
                })
                //交易列表
                $("#tradingorder").click(function () {
                    var orderid = document.getElementById("a").value;
                    console.log("d:"+orderid);
                    $.ajax({
                        url: "/AppService/Trading.ashx",
                        type: "post",
                        data: { act: "tradeorder", orderid: orderid, userid: userid, typeid:1,pageindex:pageindex,pagesize:pagesize },
                        success: function (data) {
                            console.log(data);
                        },
                        error: function () {
                            alert("网络错误");
                        }
                    })
                })
                //买卖列表
                $("#buyandsell").click(function () {
                    $.ajax({
                        url: "/AppService/Trading.ashx",
                        type: "post",
                        data: { act: "buyandsell", userid: userid,pageindex:pageindex,pagesize:pagesize},
                        success: function (data) {
                            console.log(data);
                        },
                        error: function () {
                            alert("网络错误");
                        }
                    })
                })
                //撤销
                $("#cancel").click(function () {
                    var orderid = document.getElementById("a").value;
                    console.log("d:"+orderid);
                    $.ajax({
                        url: "/AppService/Trading.ashx",
                        type: "post",
                        data: { act: "ordercancel", orderid: orderid, userid: userid, typeid: 1 },
                        success: function (data) {
                            console.log(data);
                        },
                        error: function () {
                            alert("网络错误");
                        }
                    })
                })
                //登录
                $("#login").click(function () {
                    $.ajax({
                        url: "/AppService/User.ashx",
                        type: "post",
                        data: { act: "login", username: 'system', password: paypassword },
                        success: function (data) {
                            console.log(data);
                        },
                        error: function () {
                            alert("网络错误");
                        }
                    })
                })
                //验证
                $("#token").click(function () {
                    $.ajax({
                        url: "/AppService/User.ashx",
                        type: "post",
                        data: { act: "validtoken", tokencode: "1"},
                        success: function (data) {
                            console.log(data);
                        },
                        error: function () {
                            alert("网络错误");
                        }
                    })
                })
                //验证
                $("#rank").click(function () {
                    $.ajax({
                        url: "/AppService/YunTu_Rank.ashx",
                        type: "post",
                        data: { act: "validtoken", Page: "1", Mumber: '10'},
                        success: function (data) {
                            console.log(data);
                        },
                        error: function () {
                            alert("网络错误");
                        }
                    })
                })
                //身份证验证
                $("#btnidcard").click(function () {
                    $.ajax({
                        url: "/AppService/YunTu_Rank.ashx",
                        type: "post",
                        data: { act: "validtoken", Page: "1", Mumber: '10' },
                        datatype : "json",
                        success: function (data) {
                            console.log(data);
                        },
                        error: function () {
                            alert("网络错误");
                        }
                    })
                })
            })

        </script>
    </form>
</body>
<%--<script src="JS/sendsms.js"></script>--%>
</html>
