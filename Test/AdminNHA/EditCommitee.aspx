<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCommitee.aspx.cs" Inherits="Test.AdminNHA.EditCommitee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-xs-8 xol-sm-10 col-lg-12">
            <h2 style="font-weight: bold">:: แก้ไขรายชื่อกรรมการ</h2>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <div class="input-group">
                            <%--<input class="form-control" placeholder="ชื่อ-สกุล" name="ชื่อ" type="text" id="fieldName">--%>
                            <asp:TextBox ID="search" CssClass="form-control" runat="server" placeholder="ชื่อ-สกุล"></asp:TextBox>
                            <asp:HiddenField ID="hfUserId" runat="server" />
                            <div class="input-group-btn">
                                <button class="btn btn-default" type="submit" id="searchCommittee">
                                    <i class="glyphicon glyphicon-search"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="btn-group">
                        <asp:DropDownList ID="CommiteeType" CssClass="custom-select form-control" runat="server" AutoPostBack="false">
                            <asp:ListItem Value="0">-- กรุณาเลือกกรรมการ --</asp:ListItem>
                            <asp:ListItem Value="ประธานกรรมการจัดจ้าง">ประธานกรรมการจัดจ้าง</asp:ListItem>
                            <asp:ListItem Value="ประธานกรรมการตรวจการจ้าง">ประธานกรรมการตรวจการจ้าง</asp:ListItem>
                            <asp:ListItem Value="กรรมการจัดจ้าง">กรรมการจัดจ้าง</asp:ListItem>
                            <asp:ListItem Value="กรรมการตรวจการจ้าง">กรรมการตรวจการจ้าง</asp:ListItem>
                            <asp:ListItem Value="เลขานุการกรรมการจัดจ้าง">เลขานุการกรรมการจัดจ้าง</asp:ListItem>
                            <asp:ListItem Value="เลขานุการกรรมการตรวจการจ้าง">เลขานุการกรรมการตรวจการจ้าง</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4">
                    <%--<button type="button" class="btn btn-md btn-info " id="btnAdd">เพิ่ม</button>--%>
                    <asp:Button ID="btnAdd" CssClass="btn btn-info" runat="server" Text="เพิ่ม" OnClick="btnAdd_Click"></asp:Button>
                </div>
            </div>
            <div class="row">
                <h3>รายชื่อกรรมการตรวจการจ้าง</h3>
                <asp:GridView ID="tablePC" DataKeyNames="user_id" CssClass="table table-bordered  table-hover" runat="server" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="tablePC_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="user_id" HeaderText="ID" Visible="False" />
                        <asp:BoundField DataField="first_name" HeaderText="ชื่อ" ItemStyle-Width="50%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="last_name" HeaderText="นามสกุล" ItemStyle-Width="50%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="position" HeaderText="ตำแหน่ง" ItemStyle-Width="30%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="30%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Committee_type" HeaderText="หน้าที่" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete1" runat="server" CssClass="btn btn-info" CommandArgument ='<%# Eval("user_id")%>'
                                    OnClientClick="return confirm('คุณต้องการลบใช่ไหม?')" Text="ลบ" OnClick="lnkDelete1_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-xs btn-danger" CommandName="Select" Text="ลบ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="row">
                <h3>รายชื่อกรรมการจัดจ้าง</h3>
                <asp:GridView ID="tablePM" DataKeyNames="user_id" CssClass="table table-bordered " GridLines="None" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="tablePM_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="user_id" HeaderText="ID" Visible="False" />
                        <asp:BoundField DataField="first_name" HeaderText="ชื่อ" ItemStyle-Width="50%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="20%"></ItemStyle>

                        </asp:BoundField>
                        <asp:BoundField DataField="last_name" HeaderText="นามสกุล" ItemStyle-Width="50%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="position" HeaderText="ตำแหน่ง" ItemStyle-Width="30%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="30%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Committee_type" HeaderText="หน้าที่" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete2" runat="server" CssClass="btn btn-info" CommandArgument='<%# Eval("user_id")%>'
                                    OnClientClick="return confirm('คุณต้องการลบใช่ไหม?')" Text="ลบ" OnClick="lnkDelete2_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-xs btn-danger" CommandName="Select" Text="ลบ" HeaderStyle-BackColor="#55bc0de">
                            <%--<ControlStyle CssClass="btn btn-xs btn-danger"></ControlStyle>--%>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="row" align="right">
                <%--<asp:button type="button" id="save" class="btn btn-info">บันทึก</asp:button>--%>
                <a href="ViewStateProcess.aspx" type="button" id="cancel" class="btn btn-info">เสร็จสิ้น</a>
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
                        url: '<%=ResolveUrl("EditCommitee.aspx/GetCommittees") %>',
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
        function removeCommitee(id) {
            if (confirm("คุณต้องการลบกรรมการใช่หรือไม่")) {
                var url = '<%=ResolveUrl("EditCommitee.aspx/GetCommittees") %>';
                $.post(url, { prefix: "hahaha" }, function (data) {
                    alert(data);
                    //location.reload();
                });
            }
        }
    </script>
</asp:Content>
