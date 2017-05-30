<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveRecord_2.aspx.cs" Inherits="Test.AdminNHA.ApproveRecord_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container" id="CreatePage">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold">:: บันทึกความเห็นกรรมการ/นักวิจัย/งวดงาน</h2>
            <fieldset>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="TextboxNum" class="control-label col-sm-4">เลขที่สัญญา</label>
                            <%--<input id="num" class="form-control"   type="text">--%>
                            <asp:TextBox ID="TextboxNum" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="TextboxNum" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="TextboxDate" class="control-label col-sm-4">วันลงนามในสัญญา</label>
                            <%--<input id="date" class="form-control" type="text">--%>
                            <asp:TextBox ID="TextboxDate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="TextboxDate" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="budget" class="control-label col-sm-4">งบประมาณตามสัญญาจ้าง</label>
                            <%--<input class="form-control" placeholder="ชื่อ-สกุล" name="ชื่อ" type="text" id="fieldName" autofocus>--%>
                            <asp:TextBox ID="TextboxBudgetCon" class="form-control" AutoPostBack="True" runat="server" OnTextChanged="TextboxDateBudgetCon_TextChanged" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="TextboxBudgetCon" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="period" class="control-label col-sm-4">จำนวนวันตามสัญญาจ้าง</label>
                            <%--<button type="button" class="btn btn-md btn-info " id="btnAdd1">เพิ่ม</button>--%>
                            <asp:TextBox ID="TextboxPeriod" class="form-control" runat="server"  AutoPostBack="True" OnTextChanged="TextboxPeriod_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="TextboxPeriod" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="TextboxEmployee" class="control-label col-sm-4">ผู้รับจ้าง</label>
                            <asp:TextBox ID="TextboxEmployee" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ControlToValidate="TextboxEmployee" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="TextboxComment" class="control-label col-sm-4">ความเห็นกรรมการ</label>
                            <asp:TextBox ID="TextboxComment" CssClass="form-control" TextMode="MultiLine" runat="server" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row" align="right">

                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-info" OnClick="Button1_Click" Text="บันทึกข้อมูลนักวิจัย" />

                </div>

                <div id="row1" style="display: none;" runat="server">
                    <hr>
                    <div class="row">
                        <label align="center">บันทึกประวัตินักวิจัย</label>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="input-group">
                                <%--<input class="form-control" placeholder="ชื่อ-สกุล" name="ชื่อ" type="text" id="fieldName" autofocus>--%>
                                <asp:TextBox ID="search" CssClass="form-control" runat="server"></asp:TextBox>

                                <div class="input-group-btn">
                                    <button class="btn btn-default" type="submit">
                                        <i class="glyphicon glyphicon-search"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <%--<button type="button" class="btn btn-md btn-info " id="btnAdd1">เพิ่ม</button>--%>
                            <asp:Button ID="btnAdd" CssClass="btn btn-info" runat="server" Text="เพิ่ม" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">

                                <asp:GridView ID="tableResearcher" CssClass="table table-bordered table-hover" GridLines="None" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="Rnum" HeaderText="ลำดับ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Rproj" HeaderText="บทบาทหน้าที่ในโครงการ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Rpname" HeaderText="คำนำหน้าชื่อ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Rfname" HeaderText="ชื่อ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Rlname" HeaderText="นามสกุล" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Rposition" HeaderText="ตำแหน่งวิชาการ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Rins" HeaderText="สังกัดหน่วยงาน/บริษัท" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Rid" HeaderText="เลขบัตรประชาชน" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Rbirth" HeaderText="วัน/เดือน/ปีพ.ศ.เกิด" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Psex" HeaderText="เพศ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Plevel" HeaderText="ระดับการศึกษา" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Pb" HeaderText="วุฒิการศึกษา" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Pmj" HeaderText="สาขาวิชาที่จบ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Pbest" HeaderText="ความเชี่ยวชาญและประสบการณ์" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Ppin" HeaderText="เบอร์โทรศัพท์หน่วยงาน" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Pphone" HeaderText="เบอร์โทรสารหน่วยงาน" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Pmb" HeaderText="เบอร์มือถือ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                        <asp:BoundField DataField="Pemail" HeaderText="อีเมล์" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="row2" style="display: none;" runat="server">
                    <hr>
                    <div class="row">
                        <label align="center">บันทึกข้อมูลบริหารโครงการ</label>
                    </div>
                    <a href="#" class="btn btn-lg btn-info " data-toggle="modal" data-target="#myModal" id="period">เพิ่มงวดงาน</a>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">

                                <asp:GridView ID="tablePeriod" CssClass="table table-bordered " runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="Period" HeaderText="งวดงานที่" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Pbudget" HeaderText="เงินงวด" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Percent" HeaderText="%" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Pdate" HeaderText="ระยะเวลา(วัน)" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Psent" HeaderText="วันส่งมอบฃาน" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Pedit" HeaderText="" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
            <div id="row3" style="display: none;" runat="server">
                <hr>
                <div class="row" align="center">
                    <asp:HyperLink ID="hyperlink" NavigateUrl="~/AdminNHA/ViewStateProcess.aspx" class="btn btn-lg btn-info" Text="เสร็จสิ้นบันทึกงวดงาน" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <script>
    </script>
</asp:Content>
