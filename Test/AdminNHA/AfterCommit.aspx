<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AfterCommit.aspx.cs" Inherits="Test.AdminNHA.AfterCommit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <br>
            <asp:Label ID="headForm" Style="font-weight: bold" runat="server" Font-Size="Larger"></asp:Label>
            <div class="panel-body" align="center">
                <fieldset>
                    <div class="row">
                        <div class="col-md-6 col-md-offset-3">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <%--<input id="pyear" class="form-control" placeholder="ที่" name="ปีที่ดำเนินโครงการ" type="text" value="">--%>
                                    <asp:Label for="TextApprove" runat="server" class="control-label col-xs-4">จาก: </asp:Label>
                                    <asp:TextBox ID="TextBoxForm" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="TextBoxForm" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <%--<input class="form-control" id="datePick" name="datePick" placeholder="เมษายน 2560"/>--%>
                                    <asp:Label for="TextApprove" runat="server" class="control-label col-xs-4">ถึง: </asp:Label>
                                    <asp:TextBox ID="TextBoxTo" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="TextBoxTo" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <%--<input id="pyear" class="form-control" placeholder="ที่" name="ปีที่ดำเนินโครงการ" type="text" value="">--%>
                                    <asp:Label for="TextApprove" runat="server" class="control-label col-xs-4">ที่: </asp:Label>
                                    <asp:TextBox ID="TextBoxAt" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="TextBoxAt" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <%--<input class="form-control" id="datePick" name="datePick" placeholder="เมษายน 2560"/>--%>
                                    <asp:Label for="TextApprove" runat="server" class="control-label col-xs-4">วันที่: </asp:Label>
                                    <asp:TextBox ID="TextBoxDate" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="TextBoxDate" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="approve" for="TextApprove" runat="server" class="control-label col-xs-4">ผู้อนุมัติ: </asp:Label>
                                    <asp:TextBox ID="TextApprove" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" SetFocusOnError="true" ControlToValidate="TextBoxDate" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
            <hr />
            <div class="row" align="right">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-info" OnClick="Button1_Click" Text="พิมพ์ขออนุมัติข้อกำหนดโครงการ" />
                <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-default" Text="กลับหน้าหลัก" PostBackUrl="~/AdminNHA/ViewStateProcess.aspx" CausesValidation="false" />
            </div>
        </div>
    </div>
</asp:Content>
