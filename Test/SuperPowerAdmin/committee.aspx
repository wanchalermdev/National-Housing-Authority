<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="committee.aspx.cs" Inherits="Test.SuperPowerAdmin.committee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold">:: จัดการผู้รับผิดชอบ<asp:Label ID="Pname" runat="server"></asp:Label></h2>
            <div class="row">
                <div class="col-md-4">
                    <div class="input-group">
                        <asp:TextBox ID="search" CssClass="form-control" runat="server" placeholder="ชื่อ-สกุล"></asp:TextBox>
                        <asp:HiddenField ID="hfUserId" runat="server" />
                        <div class="input-group-btn">
                            <div class="btn btn-default">
                                <i class="glyphicon glyphicon-search"></i>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="CommiteeType" CssClass="custom-select form-control" runat="server" AutoPostBack="False">
                        <asp:ListItem Value="0">กรุณาเลือกผู้รับผิดชอบโครงการ</asp:ListItem>
                        <asp:ListItem Value="nha">ผู้ประสานงาน</asp:ListItem>
                        <asp:ListItem Value="pm">ผู้รับผิดชอบโครงการ</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-info" Text="เพิ่ม" OnClick="btnAdd_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <h3>รายชื่อผู้ประสานงาน</h3>
                    <asp:GridView ID="gvCoor" DataKeyNames="user_id" CssClass="table table-bordered table-hover " runat="server" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" AutoGenerateColumns="False" GridLines="None" OnSelectedIndexChanged="gvCoor_SelectedIndexChanged">

                        <Columns>
                            <asp:BoundField DataField="user_id" HeaderText="ID" Visible="False" />
                            <asp:BoundField DataField="first_name" HeaderText="ชื่อ" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle Width="150px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="last_name" HeaderText="นามสกุล">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-xs btn-danger" CommandName="Select" Text="ลบ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:ButtonField>
                        </Columns>
                        <%--<EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>

                        <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>
                    </asp:GridView>
                </div>
                <div class="col-md-6">
                    <h3>รายชื่อผู้รับผิดชอบโครงการ</h3>
                    <asp:GridView ID="gvPM" DataKeyNames="user_id" CssClass="table table-bordered table-hover " runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" GridLines="None" OnSelectedIndexChanged="gvPM_SelectedIndexChanged">

                        <Columns>
                            <asp:BoundField DataField="user_id" HeaderText="ID" Visible="False" />
                            <asp:BoundField DataField="first_name" HeaderText="ชื่อ" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle Width="150px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="last_name" HeaderText="นามสกุล">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-xs btn-danger" CommandName="Select" Text="ลบ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:ButtonField>
                        </Columns>

                        <%--<EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>

                        <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>
                    </asp:GridView>
                </div>
            </div>
            <div class="row" align="right">
                <asp:Button ID="BtnSave" CssClass="btn btn-info" runat="server" Text="บันทึก" OnClick="BtnSave_Click" />
                <asp:Button ID="BtnCancel" CssClass="btn btn-default" runat="server" Text="ยกเลิก" />
            </div>
        </div>
    </div>

    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=search]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("committee.aspx/GetUsers") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0] + " " + item.split('-')[1] + " " + item.split('-')[2],
                                    val: item.split('-')[3]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfUserId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
</asp:Content>
