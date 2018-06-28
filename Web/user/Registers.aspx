<%@ Page Language="C#" MasterPageFile="/user/index.Master" AutoEventWireup="true" CodeBehind="Registers.aspx.cs" Inherits="Web.user.Registers" %>



<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

 
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%--登录资料--%><%=GetLanguage("LoginInformation") %></h4>
                            <div class="row form-horizontal">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span><%=GetLanguage("ContactPhone") %> <%--手机号码--%>：</label>
                                        <div class="col-sm-5 m-b-5">
                                            <input type="text" id="txtUserCode" runat="server" class="form-control" maxlength="11"/>
                                        </div>
                                        <div class="col-sm-5 m-b-5" style="display:none">
                                            <asp:Button ID="btnCreateUser" CssClass="btn btn-info" runat="server" Text="生成编号" OnClick="btnCreateUser_Click" />
                                            <asp:Button ID="btnValidate" CssClass="btn btn-success" runat="server" Text="检测账号" OnClick="btnValidate_Click" />

                                        </div>
                                    </div>
                                </div>
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label"><span class="text-danger">*</span> 验证码：</label>
                                            <div class="col-sm-2 m-b-5">
                                                  <input type="text" class="form-control" id="Text1" maxlength="4" runat="server" placeholder="验证码" />
                                            </div>
                                             <div class="col-sm-5 m-b-5">
                                        <asp:ImageButton ID="ImageButton2" runat="server" Style="width: 80px; height: 38px; border: 0px; cursor: pointer;" ImageUrl="~/ValidatedCode.aspx" />
                                             </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label"><span class="text-danger">*</span> 短信验证码：</label>
                                            <div class="col-sm-2 m-b-5">
                                                  <input type="text" class="form-control" id="Text2" maxlength="6" runat="server" placeholder="短信验证码" />
                                                </div>
                                            <div class="col-sm-5 m-b-5">
                                                 <asp:Button ID="Button1" runat="server" CssClass="btn btn-success"  OnClick="DX_btnLogin_Click"   Text="获取短信" />
                                                 
                                            </div>
                                        </div>
                                    </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%--密码--%><%=GetLanguage("LoginPassword") %>：<br/><span style="color:darkgrey;"><%=GetLanguage("PasswordDefault") %></span></label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" id="txtPassword" runat="server" class="form-control"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%--确认密码--%><%=GetLanguage("ConfirmPass") %>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" id="txtRegPassword" runat="server" class="form-control"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%--二级密码--%><%=GetLanguage("SecondPassword") %>：<br/><span style="color:darkgrey;"><%=GetLanguage("PasswordDefault") %></span></label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" id="txtSecondPassword" runat="server" class="form-control"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%=GetLanguage("ConfirmPass") %><%--确认密码--%>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" class="form-control" id="txtRegSecondPassword" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                               

                                <hr />
                                <h4 class="header-title m-t-0 m-b-30"><%--会员资料--%><%=GetLanguage("NetworkInformation") %></h4>

                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span><%=GetLanguage("MemberNickname") %> <%--昵称--%>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input name="txtNiceName" type="text" id="txtNiceName" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span><%=GetLanguage("ReferenceNumber") %> <%--推荐人编号--%>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input name="txtRecommendCode" type="text" id="txtRecommendCode" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                              <%--  <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span><%=GetLanguage("AliPay") %> <!--支付宝账号-->：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="text" class="form-control" id="txtAlipay" runat="server" />
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="col-sm-12" style="display:none">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span><%=GetLanguage("ContactPhone") %> <!--手机号码-->：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="text" class="form-control" id="txtPhoneNum" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12" style="display:none">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span><%=GetLanguage("IDNumber") %> <!--身份证号-->：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="text" class="form-control" id="txtIDNumber" runat="server" />
                                        </div>
                                    </div>
                                </div>
                               <%-- <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger"></span><%=GetLanguage("Agent") %> <!--商务中心-->：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="text" class="form-control" id="txtAgent" runat="server" />
                                        </div>
                                    </div>
                                </div>--%>
                               <%-- <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span><%=GetLanguage("Secret") %> <!--密保问题-->：</label>
                                        <div class="col-sm-5 m-b-5">
                                            <asp:DropDownList ID="dropQuestion" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%=GetLanguage("answer") %><!--密保密码-->：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <asp:TextBox ID="txtAnswer" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                        <hr />
                        <div class="card-box">
                           <%-- <h4 class="header-title m-t-0 m-b-30"><!--银行资料--><%=GetLanguage("Banking") %></h4>
                            <div class="row form-horizontal">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <!--开户银行--><%=GetLanguage("Depositary") %>：</label>
                                        <div >
                                            
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <div class="col-sm-5 m-b-5"> <asp:DropDownList ID="dropBank" runat="server" class="form-control">
                                                        </asp:DropDownList></div>
                                                       <div class="col-sm-5 m-b-5">
                                                        <asp:DropDownList ID="dropProvince" runat="server" class="form-control">
                                                        </asp:DropDownList></div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <!--银行支行--><%=GetLanguage("BankBranch") %>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="form-control" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <!--银行账户--><%=GetLanguage("BankAccount") %>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input name="txtBankAccount" type="text" id="txtBankAccount" maxlength="19" class="form-control" runat="server" value="" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <!--开户姓名--><%=GetLanguage("AccountName") %>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="text" class="form-control" id="txtBankAccountUser" runat="server" value=""/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        --%>
                              
                            <div class="row">
                                <div class="form-group m-b-0 m-b-5">
                                    <div class="col-sm-offset-2 col-sm-10">
                                        <asp:Button ID="btnSubmit" runat="server" Text="提 交" CssClass="btn btn-custom " OnClientClick="javascript:return confirmex()" OnClick="btnSubmit_Click" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End row -->

        </div>
        <!-- container -->
 <script>

     $(document).ready(function () {
        $('#<%=txtPassword.ClientID%>').val('111111');
        $('#<%=txtRegPassword.ClientID%>').val('111111');
        $('#<%=txtSecondPassword.ClientID%>').val('111111');
        $('#<%=txtRegSecondPassword.ClientID%>').val('111111');
     });
 </script>
    
</asp:Content>


