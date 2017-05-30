<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Accept.aspx.cs" Inherits="Test.AdminNHA.Accept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold;">:: รายละเอียดโครงการวิจัย</h2>
            <div class="panel-body">
                <fieldset>
                    <div class="row">
                        <div class="col-md-5 ">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="TextBox1" class="control-label col-sm-4">รหัสโครงการ: </label>
                                    <asp:TextBox ID="pid" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="TextBox2" class="control-label col-sm-4">ชื่อโครงการ: </label>
                                    <asp:TextBox ID="pname" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="pyear" class="control-label col-sm-4">ปีที่ดำเนินโครงการ: </label>
                                    <asp:TextBox ID="pyear" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-7 ">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="TextBox4" class="control-label col-sm-6">จำนวนเงินที่ได้รับอนุมัติจัดสรร: </label>
                                    <asp:TextBox ID="pbg" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="TextBox5" class="control-label col-sm-6">ปีของงบประมาณที่นำมาจัดสรรตามสัญญา: </label>
                                    <asp:TextBox ID="py" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="TextBox6" class="control-label col-sm-6">จำนวนเงินตามสัญญาจ้าง: </label>
                                    <asp:TextBox ID="pbg2" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <hr>

                    <div class="row">
                        <div class="col-md-4 col-md-offset-1">
                            <div class="form-group">
                                <asp:GridView ID="gvCoor" CssClass="table table-hover disabled" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="Cname" HeaderText="ผู้ประสานงาน" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="col-md-4 col-md-offset-1">
                            <div class="form-group">
                                <asp:GridView ID="gvPM" CssClass="table table-hover disabled" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="PMname" HeaderText="ผู้รับผิดชอบโครงการ" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <hr>
                <div class="row" align="center">
                    <asp:Button ID="btn" runat="server" OnClick="btnSave_Click" CssClass="btn btn-lg btn-success" Style="max-width: 400px;" Text="รับทราบและแจ้งอีเมล์ขอข้อกำหนดโครงการ(TOR)" />
                </div>

            </div>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" id="btnClose" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">แจ้งเตือน</h4>
                    </div>
                    <div class="modal-body">
                        <p>ขณะนี้ระบบกำลังดำเนินการส่งอีเมล์เเจ้งเตือนไปยัง Project manager ของหน่วยงาน เพื่อขอข้อกำหนดโครงการ(TOR)</p>
                    </div>
                    <div class="modal-footer">
                        <a href="../AdminNHA/ViewStateProcess.aspx" class="btn btn-default">กลับหน้าหลัก</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function showModal() {
            $("#myModal").modal('show');
        }

        $(function () {
            $("#btnShow").click(function () {
                showModal();
            });
        });
    </script>

    <script>
        $('#btnClose').click(function () {
            $.get("/AdminNHA/ViewStage", function () { });
        });
    </script>

    <%--  <script>
        $('#btnAccept').click(function () {
            $.get("/AdminNHA/updateAccept", function () { });
        });
    </script>--%>
</asp:Content>
