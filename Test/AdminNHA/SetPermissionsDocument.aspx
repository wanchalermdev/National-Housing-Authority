<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetPermissionsDocument.aspx.cs" Inherits="Test.AdminNHA.SetPermissionsDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2 style="font-weight: bold">:: กำหนดสิทธิ์การเผยแพร่</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <h2 style="font-weight: bold">บทคัดย่อ</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="LabelAbstract" runat="server" Text="Label" Font-Bold="true" Font-Size="Large"></asp:Label>
        </div>
    </div>
    <br>
    <div class="row">
        <asp:GridView ID="gridview" DataKeyNames="file_id" CssClass="table table-bordered table-hover" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="gridview_RowCommand" OnRowDataBound="gridview_RowDataBound" OnSelectedIndexChanged="gridview_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="file_id" HeaderText="file_id" Visible="False" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="ลำดับ" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="nameFomTextBox" HeaderText="ชื่อไฟล์" ItemStyle-Width="50%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle Width="20%"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="type" ItemStyle-HorizontalAlign="Center" HeaderText="ชนิดไฟล์" ItemStyle-Width="15%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle Width="15%"></ItemStyle>
                </asp:BoundField>
                <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete1" runat="server" CssClass="btn btn-info" CommandArgument ='<%# Eval("user_id")%>'
                                    OnClientClick="return confirm('คุณต้องการลบใช่ไหม?')" Text="ลบ" OnClick="lnkDelete1_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                <asp:ButtonField ButtonType="Button" CommandName="download" ItemStyle-Width="10%" ControlStyle-CssClass="btn btn-xs btn-danger" Text="ดาวน์โหลด" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" CausesValidation="false">
                    <ControlStyle CssClass="btn btn-xs btn-success"></ControlStyle>

                    <HeaderStyle BackColor="#5BC0DE" ForeColor="White" HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
                <asp:TemplateField HeaderText="กำหนดสิทธิ์" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:DropDownList ID="DrdDatabase" Width="80%" CssClass="custom-select form-control"  runat="server" OnSelectedIndexChanged="DrdDatabase_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="row" align="right">
        <div class="col-md-12">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" OnClick="Button1_Click" Text="กลับสู่เมนูหลัก" />
        </div>
    </div>
</asp:Content>
