<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WriteAbstact.aspx.cs" Inherits="Test.AdminNHA.WriteAbstact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2 style="font-weight: bold">:: บันทึกบทคัดย่อ</h2>
        </div>
    </div>
    <div class="row">
        <%-- <div class="col-md-5">
            <input class="form-contorl" type="file" />
        </div>
        <div class="col-md-2">
            <button>อัพโหลด</button>
        </div>--%>
        <div class="col-md-12">
            
                <asp:TextBox ID="TextBoxForm" TextMode="MultiLine" Rows="15" Columns="20" style="max-width:100%;width:100%"  CssClass="form-control" runat="server" ></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row" align="right">
        <div class="col-md-12">
            <asp:Button   runat="server" ID="MainContent_BtnSave" CssClass="btn btn-info" Text="บันทึก" OnClick="MainContent_BtnSave_Click"></asp:Button>
            <asp:Button runat="server"  ID="MainContent_BtnBack" CssClass="btn btn-default" Text="กลับสู่เมนูหลัก" OnClick="MainContent_BtnBack_Click"></asp:Button>
        </div>
    </div>
</asp:Content>
