<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrintDoc.aspx.cs" Inherits="Test.SuperPowerAdmin.PrintDoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold">:: พิมพ์เอกสารรายงาน</h2>
            <div class="row">
                <asp:DropDownList ID="DdYear" AutoPostBack="true" CssClass="custom-select form-control" runat="server" OnSelectedIndexChanged="DdYear_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <br />
            <hr />
            <div class="row">
                <%-- gridview --%>
                <asp:GridView ID="gvDoc" CssClass="table table-bordered table-hover " GridLines="None" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="project_id" HeaderText="รหัสโครงการ" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Project_name" HeaderText="ชื่อโครงการ" ItemStyle-Width="60%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="year" HeaderText="ปีงบประมาณ" ItemStyle-Width="15%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="project_budget" HeaderText="งบประมาณ" ItemStyle-Width="15%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
            </div>
            <div class="row" align="center">
                <%--<asp:Button ID="ButtonDownload1" runat="server" CssClass="btn btn-info"  Text="พิมพ์รายงาน" OnClick="ButtonDownload1_Click" />--%>
                <%--<asp:ImageButton  ID="ImgB" runat="server" ImageUrl="~/Images/dw_excel.png" />--%>
                <a class="btn btn-default btn-lg" runat="server" onserverclick="ButtonDownload1_Click"><img src="../Images/dw_excel.png" /> พิมพ์รายงาน</a>
            </div>
               <div class="row" align="right">
                <a href="../SuperPowerAdmin/HomeCreateProject" class="btn btn-default">กลับสู่เมนูหลัก</a>
            </div>
        </div>
    </div>
</asp:Content>
