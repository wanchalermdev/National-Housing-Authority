<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddResearcher.aspx.cs" Inherits="Test.AdminNHA.AddResearcher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="font-weight: bold">:: บันทึกความเห็นกรรมการ/นักวิจัย/งวดงาน(บันทึกความเห็นแล้ว)</h2>
    <br />
    <fieldset>
        <div class="row">
            <h3>บันทึกความเห็นกรรมการ
            </h3>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="num" class="control-label col-sm-4">เลขที่สัญญา</label>
                    <%--<input id="num" class="form-control"   type="text">--%>
                    <asp:Label ID="LabelConNum" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="date" class="control-label col-sm-4">วันลงนามในสัญญา</label>
                    <%--<input id="date" class="form-control" type="text">--%>
                    <asp:Label ID="LabelDateCon" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="date" class="control-label col-sm-4">งบประมาณตามสัญญาจ้าง</label>
                    <%--<input id="date" class="form-control" type="text">--%>
                    <asp:Label ID="LabelBudgetCon" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="date" class="control-label col-sm-4">ผู้รับจ้าง</label>
                    <%--<input id="date" class="form-control" type="text">--%>
                    <asp:Label ID="LabelEmp" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="Textarea1" class="control-label col-sm-4">ความเห็นกรรมการ</label>
                    <%--<input id="num" class="form-control"   type="text">--%>
                    <asp:Label ID="LabelCommit" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="Textarea1" class="control-label col-sm-4">จำนวนวันตามสัญญาจ้าง</label>
                    <asp:Label ID="LabelPeriod" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>

        <div id="row1" runat="server">
            <hr>
            <div class="row">
                <label align="center">
                    <h3>บันทึกประวัตินักวิจัย</h3>
                </label>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="input-group">
                        <%--<input class="form-control" placeholder="ชื่อ-สกุล" name="ชื่อ" type="text" id="fieldName" autofocus>--%>
                        <asp:TextBox ID="search" CssClass="form-control" runat="server" placeholder="ชื่อ-สกุล"></asp:TextBox>
                        <asp:HiddenField ID="hfUserId" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="search" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <div class="input-group-btn">
                            <button class="btn btn-default" type="submit">
                                <i class="glyphicon glyphicon-search"></i>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <%--<button type="button" class="btn btn-md btn-info " id="btnAdd1">เพิ่ม</button>--%>
                    <asp:Button ID="btnAdd" CssClass="btn btn-info" runat="server" Text="เพิ่ม" OnClick="btnAdd_Click" />
                </div>
            </div>
            <br />
            <div class="row">
                <asp:GridView ID="tableResearcher" DataKeyNames="re_id" CssClass="table table-bordered table-hover" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="tableResearcher_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="re_id" HeaderText="ID" Visible="False" />
                        <asp:BoundField DataField="fname" HeaderText="ชื่อ" ItemStyle-Width="40%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="lname" HeaderText="นามสกุล" ItemStyle-Width="40%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="30%"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete1" runat="server" CssClass="btn btn-info" CommandArgument ='<%# Eval("user_id")%>'
                                    OnClientClick="return confirm('คุณต้องการลบใช่ไหม?')" Text="ลบ" OnClick="lnkDelete1_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="role" HeaderText="บทบาทหน้าที่โครงการ" ItemStyle-Width="40%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemStyle Width="40%"></ItemStyle>
                        </asp:BoundField>
                        <asp:ButtonField ButtonType="Button" CommandName="1" ItemStyle-Width="10%" ControlStyle-CssClass="btn btn-xs btn-danger" Text="ลบ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" CausesValidation="false">
                            <ControlStyle CssClass="btn btn-xs btn-danger"></ControlStyle>

                            <HeaderStyle BackColor="#5BC0DE" ForeColor="White" HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="btn btn-xs btn-info" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" CommandName="2" Text="เพิ่มเติม">
                            <ControlStyle CssClass="btn btn-xs btn-info"></ControlStyle>

                            <HeaderStyle BackColor="#5BC0DE" ForeColor="White" HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="row2" runat="server">
            <hr>


            <div class="row">
                <label align="center">
                    <h3>บันทึกข้อมูลบริหารสัญญา</h3>
                </label>
            </div>
            <div class="row">
                <asp:Button ID="Button1" runat="server" Text="เพิ่มงวดงาน" CssClass="btn btn-info" OnClick="Button1_Click" CausesValidation="false" />
            </div>
            <br />
            <div class="row">
                <asp:GridView ID="tablePeriod" DataKeyNames="project_id" CssClass="table table-bordered table-hover" GridLines="None" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="tablePeriod_SelectedIndexChanged" OnRowCommand="tablePeriod_RowCommand">
                    <Columns>
                        <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete1" runat="server" CssClass="btn btn-info" CommandArgument ='<%# Eval("user_id")%>'
                                    OnClientClick="return confirm('คุณต้องการลบใช่ไหม?')" Text="ลบ" OnClick="lnkDelete1_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="project_id" HeaderText="project_id" Visible="False" />
                        <asp:BoundField DataField="period" HeaderText="งวดที่" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" ItemStyle-Width="10%">
                            <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="money" HeaderText="เงิน" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="percent_money" HeaderText="%" ItemStyle-Width="20%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemStyle Width="30%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="day_period" HeaderText="จำนวนวัน" ItemStyle-Width="20%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemStyle Width="30%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="date_period" HeaderText="วันส่งงาน" ItemStyle-Width="20%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemStyle Width="30%"></ItemStyle>
                        </asp:BoundField>
                        <asp:ButtonField Text="เพิ่มเอกสาร" ButtonType="Button" ControlStyle-CssClass="btn btn-xs btn-info" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" CommandName="addDocs">
                            <ControlStyle CssClass="btn btn-xs btn-info"></ControlStyle>

                            <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>
                        </asp:ButtonField>
                        <asp:ButtonField Text="เชิญประชุม ปธ." ButtonType="Button" ControlStyle-CssClass="btn btn-xs btn-info" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" CommandName="a">
                            <ControlStyle CssClass="btn btn-xs btn-info"></ControlStyle>

                            <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>
                        </asp:ButtonField>
                        <asp:ButtonField Text="เชิญประชุม ก." ButtonType="Button" ControlStyle-CssClass="btn btn-xs btn-info" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" CommandName="b">
                            <ControlStyle CssClass="btn btn-xs btn-info"></ControlStyle>

                            <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Button" CommandName="check" Text="แบบตรวจสอบงานวิจัย" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" ControlStyle-CssClass="btn btn-xs btn-info">
                            <ControlStyle CssClass="btn btn-xs btn-info"></ControlStyle>

                            <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Button" CommandName="c" ControlStyle-CssClass="btn btn-xs btn-info" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" Text="เบิกเงินค่าจ้าง">
                            <ControlStyle CssClass="btn btn-xs btn-info"></ControlStyle>

                            <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
                <div class="row" align="right">
                    <asp:Button ID="ButtonCon" Style="margin-right: 15px" runat="server" CssClass="btn btn-info" OnClick="ButtonCon_Click" Text="สรุปแผนการดำเนินงาน" CausesValidation="false" />
                </div>
            </div>
        </div>
    </fieldset>
    <div id="row3" runat="server">
        <br />
        <hr>
        <div class="row" align="center">
            <asp:Button ID="Button2" runat="server" CssClass="btn btn-info" OnClick="Button2_Click" Text="กลับสู่หน้าหลัก" CausesValidation="false" />
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
                        url: '<%=ResolveUrl("AddResearcher.aspx/SearchResearcher") %>',
                        data: "{'prefix': '" + request.term + "'}",
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
                    console.log(i);
                    $("[id$=hfUserId]").val(i.item.val);
                },
                minLength: 1
            });
        });

    </script>
</asp:Content>
