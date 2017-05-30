<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Test.Authentication.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <div class="container">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <div class="login-panel panel panel-default">
                <br />
                <div class="panel-body">
                        <fieldset>
                            <legend align="center"> กรุณาลงชื่อเข้าสู่ระบบ</legend>
                            <div class="row">
                                <div class="col-md-4" style="text-align: right;">
                                    <label>ขื่อผู้ใช้งาน: </label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="กรอกชื่อผู้ใช้งาน"
                                    ForeColor="Red" Font-Italic="true" ControlToValidate="UserName"></asp:RequiredFieldValidator>
                                </div>
                                </div>
                            <div class="row">
                                <div class="col-md-4" style="text-align: right;">
                                    <label>รหัสผ่าน: </label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="กรอกรหัสผ่าน"
                                    ForeColor="Red" Font-Italic="true" ControlToValidate="Password"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div align="center">
                                    <%--<input class="btn btn-info" type="submit" value="ลงชื่อเข้าใช้" />--%>
                                    <asp:Button ID="btSubmit" class="btn btn-info" runat="server" Text="ลงชื่อเข้าใช้" OnClick="Button1_Click"/>
                            </div>
                        </fieldset>
                </div>
            </div>
        </div>
    </div>
</div>
    <%--</form>--%>
</asp:Content>