<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agent.aspx.cs" Inherits="Web.user.team.Agent" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>申请服务中心</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />

    <link rel="stylesheet" type="text/css" href="../../css/font-awesome.css" />
    <link rel="stylesheet" type="text/css" href="../../css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../../css/animate.min.css" />
    <link rel="stylesheet" type="text/css" href="../../css/style.css" />
</head>
<body>
    <form id="form1" runat="server" class="stdform">
        <div class="page-container row-fluid">
            <!-- BEGIN PAGE CONTAINER-->
            <div class="page-content">
                <div class="content">
                    <div class="page-title">
                        <h3><%=GetLanguage("ApplyCentre")%><%--申请报单中心--%></h3>
                    </div>
                    <div id="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="grid simple vertical green">
                                    <div class="grid-title no-border">
                                        <h4>报单信息</h4>
                                    </div>
                                    <div class="grid-body no-border">
                                        <div class="row-fluid ">
                                            <div class="col-md-6">
                                                <address class="margin-bottom-20 margin-top-10">
                                                    <strong>
                                                        <asp:Literal ID="ltAgent" runat="server"></asp:Literal><%--报单中心编号--%>：</strong> <span>
                                                            <asp:Literal ID="LitAgentCode" runat="server"></asp:Literal> <%--<input id="txtAgentCode" name="txtAgentCode" runat="server" type="text" disabled="disabled" />--%></span>
                                                </address>
                                            </div>
                                        </div>
                                        <div class="row-fluid ">
                                            <div class="col-md-6">
                                                <asp:Literal ID="ltAudit" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                        <div class="row-fluid ">
                                            <div class="col-md-6">
                                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" OnClick="btnSubmit_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
            <!-- ENG PAGE CONTAINER-->
        </div>
    </form>
</body>
</html>
