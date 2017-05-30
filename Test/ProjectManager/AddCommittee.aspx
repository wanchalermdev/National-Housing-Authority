<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCommittee.aspx.cs" Inherits="Test.ProjectManager.AddCommittee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold">:: เพิ่มรายชื่อกรรมการ</h2>
            <fieldset>
                <legend>กำหนดรายชื่อกรรมการ</legend>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="search" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
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
                    <div class="col-md-12">
                        <div class="form-group">
                            <h3>รายชื่อกรรมการตรวจการจ้าง</h3>
                            <asp:GridView ID="tablePC" DataKeyNames="user_id" CssClass="table table-bordered table-hover " GridLines="None" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="tablePC_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="user_id" HeaderText="id" Visible="False" />
                                    <asp:BoundField DataField="first_name" HeaderText="ชื่อ" ItemStyle-Width="20%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

                                        <ItemStyle Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="last_name" HeaderText="นามสกุล" ItemStyle-Width="30%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

                                        <ItemStyle Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="position" HeaderText="ตำแหน่ง" ItemStyle-Width="30%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

                                        <ItemStyle Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Committee_type" HeaderText="หน้าที่" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

                                        <ItemStyle Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Button" Text="ลบ" CommandName="Select" ControlStyle-CssClass="btn btn-xs btn-danger" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />


                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <h3>รายชื่อกรรมการจัดจ้าง</h3>
                            <asp:GridView ID="tablePM" DataKeyNames="user_id" CssClass="table table-bordered table-hover" GridLines="None" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="tablePM_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="user_id" HeaderText="id" Visible="False" />
                                    <asp:BoundField DataField="first_name" HeaderText="ชื่อ" ItemStyle-Width="20%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

                                        <ItemStyle Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="last_name" HeaderText="นามสกุล" ItemStyle-Width="30%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

                                        <ItemStyle Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="position" HeaderText="ตำแหน่ง" ItemStyle-Width="30%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

                                        <ItemStyle Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Committee_type" HeaderText="หน้าที่" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

                                        <ItemStyle Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Button" Text="ลบ" CommandName="Select" HeaderStyle-BackColor="#55bc0de" ControlStyle-CssClass="btn btn-xs btn-danger" HeaderStyle-ForeColor="White" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <hr />
            </fieldset>

            <div class="row" align="right">
                <asp:Button ID="save" CssClass="btn btn-info" runat="server" Text="เสร็จสิ้น" OnClick="save_Click" />
                <%--<asp:Button ID="cancel" CssClass="btn btn-default" runat="server" Text="ยกเลิก" />--%>
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
                        url: '<%=ResolveUrl("AddCommittee.aspx/GetCommittees") %>',
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

    <script>

        var def;
        var def2;
        $("#btnAdd").click(function () {

            if ($("#fieldName").val() == "") {
                alert("กรุณากรอกกรอกชื่อ");
            }
            else if ($("#fieldName").val() != "") {
                if ($("#smProject").val().toString() == "null") {
                    alert("กรุณาเลือกกรรมการ");
                }
                else {

                    if ($("#smProject").val().toString() == "ประธานกรรมการจัดจ้าง") {
                        $("#table").append('<tr><td>' + $("#fieldName").val() + '</td><td>ผอ.ผอก</td><td>ประธานกรรมการจัดจ้าง</td</tr>');
                    }
                    else if ($("#smProject").val().toString() == "ประธานกรรมการตรวจการจ้าง") {
                        $("#table2").append('<tr><td>' + $("#fieldName").val() + '</td><td>ผอ.ผอก</td><td>ประธานกรรมการตรวจการจ้าง</td</tr>');
                    }
                    else if ($("#smProject").val().toString() == "กรรมการจัดจ้าง") {
                        $("#table").append('<tr><td>' + $("#fieldName").val() + '</td><td>ผอ.ผอก</td><td>กรรมการจัดจ้าง</td</tr>');
                    }
                    else if ($("#smProject").val().toString() == "กรรมการตรวจการจ้าง") {
                        $("#table2").append('<tr><td>' + $("#fieldName").val() + '</td><td>ผอ.ผอก</td><td>กรรมการตรวจการจ้าง</td</tr>');
                    }
                    else if ($("#smProject").val().toString() == "เลขานุการกรรมการจัดจ้าง") {
                        $("#table").append('<tr><td>' + $("#fieldName").val() + '</td><td>ผอ.ผอก</td><td>เลขานุการกรรมการจัดจ้าง</td</tr>');
                    }
                    else {
                        $("#table2").append('<tr><td>' + $("#fieldName").val() + '</td><td>ผอ.ผอก</td><td>เลขานุการกรรมตรวจการจ้าง</td</tr>');
                    }
                    $("#fieldName").val('');
                }
            }

        });

        $("#btnMore").click(function () {
            def = $("#table").clone();
            def2 = $("#table2").clone();
        });

        $("#cancel").click(function () {
            $("#table").replaceWith(def);
            $("#table2").replaceWith(def2);
        });

        $('#table input').on('change', function () {

        });

        $('#table2 input').on('change', function () {

        });

        $("#save").click(function () {
            $('#myModal').modal('hide');
        });

        $("#btnConfirm").click(function () {

            $("#test").addClass("bg - success");
        });

        $("#searchCommittee").click(function () {
            $.post("../WebService1.asmx/HelloWorld", function (data) {
                console.log(data);
                alert(data);
            });
        });

    </script>
</asp:Content>
