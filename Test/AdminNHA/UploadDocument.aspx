<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadDocument.aspx.cs" Inherits="Test.AdminNHA.UploadDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2 style="font-weight: bold">:: อัพโหลดเอกสารเกี่ยวกับโครงการ</h2>
        </div>
    </div>
    <br>
    <div class="row">
        <div class="col-md-3">
            <div class="form-inline">
                <label for="TextBoxName">ชื่อไฟล์:</label>
                <asp:TextBox ID="TextBoxName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-4">
            <div class="form-group">
                <label class="control-label col-sm-4" for="DropDownList1">ประเภทไฟล์:</label>
                <asp:DropDownList ID="DropDownList1" CssClass="custom-select form-control" runat="server" Width="180px">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-2">
            <asp:FileUpload ID="fiUpload" runat="server" Width="330px"></asp:FileUpload>
        </div>
        <div class="col-md-3">
            <input id="btnUpload" type="button" class="btn btn-success" onserverclick="btnUpload_OnClick" value="Upload" runat="server" />
        </div>
    </div>
    <br>
    <div class="row">
        <asp:GridView ID="gridview" DataKeyNames="file_id" CssClass="table table-bordered table-hover" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="gridview_RowCommand">
            <Columns>
                <asp:BoundField DataField="file_id" HeaderText="file_id" Visible="False" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="ลำดับ" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White">
                    <ItemTemplate >
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="nameFomTextBox" HeaderText="ชื่อไฟล์" ItemStyle-Width="40%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle Width="40%"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="type" ItemStyle-HorizontalAlign="Center" HeaderText="ชนิดไฟล์" ItemStyle-Width="20%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle Width="20%"></ItemStyle>
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
                <asp:ButtonField ButtonType="Button" ItemStyle-Width="10%" ControlStyle-CssClass="btn btn-xs btn-info" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" CommandName="delete" Text="ลบ">
                    <ControlStyle CssClass="btn btn-xs btn-danger"></ControlStyle>

                    <HeaderStyle BackColor="#5BC0DE" ForeColor="White" HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
    </div>

    <div class="row" align="right">
        <div class="col-md-12">
            &nbsp;
        </div>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" OnClick="Button1_Click" Text="กลับสู่เมนูหลัก" />
    </div>
</asp:Content>
