<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpTor.aspx.cs" Inherits="Test.ProjectManager.UpTor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold;">:: รับทราบเอกสารขออนุมัติโครงการ</h2>

            <fieldset>
                <legend>รายละเอียดโครงการ</legend>
                <div class="row">
                    <div class="col-md-5 ">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="pid" class="control-label col-sm-4">รหัสโครงการ: </label>
                                <asp:TextBox runat="server" ID="pid" class="form-control" placeholder="รหัสโครงการ" name="รหัสโครงการ" type="text" ReadOnly="true" />
                            </div>
                            <div class="form-group">
                                <label for="pname" class="control-label col-sm-4">ชื่อโครงการ: </label>
                                <asp:TextBox runat="server" ID="pname" class="form-control" placeholder="ชื่อโครงการ" name="ชื่อโครงการ" type="text" ReadOnly="true" />
                            </div>
                            <div class="form-group">
                                <label for="pyear" class="control-label col-sm-4">ปีที่ดำเนินโครงการ: </label>
                                <asp:TextBox runat="server" ID="pyear" class="form-control" placeholder="ปีที่ดำเนินโครงการ" name="ปีที่ดำเนินโครงการ" type="text" ReadOnly="true" />
                            </div>
                        </div>
                    </div>


                    <div class="col-md-7 ">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="pbg" class="control-label col-sm-4">จำนวนเงินที่ได้รับอนุมัติจัดสรร: </label>
                                <asp:TextBox runat="server" ID="pbg" class="form-control" placeholder="จำนวนเงินที่ได้รับอนุมัติจัดสรร" name="จำนวนเงินที่ได้รับอนุมัติจัดสรร" type="text" ReadOnly="true" />
                            </div>
                            <div class="form-group">
                                <label for="py" class="control-label col-sm-4">ปีของงบประมาณที่นำมาจัดสรร: </label>
                                <asp:TextBox runat="server" ID="py" class="form-control" placeholder="ปีของงบประมาณที่นำมาจัดสรรตามสัญญา" name="ปีของงบประมาณที่นำมาจัดสรรตามสัญญา" type="text" ReadOnly="true" />
                            </div>
                            <div class="form-group">
                                <label for="pbg2" class="control-label col-sm-4">จำนวนเงินตามสัญญาจ้าง: </label>
                                <asp:TextBox runat="server" ID="pbg2" class="form-control" placeholder="จำนวนเงินตามสัญญาจ้าง" name="จำนวนเงินตามสัญญาจ้าง" type="text" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                </div>

                <hr>

                <div class="row">
                    <div class="col-md-4 col-md-offset-1">
                        <div class="form-group">
                            <asp:GridView ID="gvCoor" CssClass="table table-bordered table-hover" GridLines="None" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="first_name" HeaderText="ผู้ประสานงาน" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="col-md-4 col-md-offset-1">
                        <div class="form-group">
                            <asp:GridView ID="gvPM" CssClass="table table-bordered table-hover " GridLines="None" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="first_name" HeaderText="ผู้รับผิดชอบโครงการ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <hr />
            </fieldset>
            <fieldset>
                <legend>นำเข้าข้อกำหนดโครงการ</legend>
                <div class="row">
                    <div class="col-md-6 col-md-offset-3">
                        <label>นำเข้าข้อกำหนดโครงการ(TOR)</label>
                        
                        <asp:FileUpload ID="FileUpload" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"  ControlToValidate="FileUpload" ForeColor="Red"  ErrorMessage="กรุณาเลือกไฟล์"></asp:RequiredFieldValidator>
                      
                        <%--<input type="file" accept=".xls,.xlsx">--%>
                        
                    </div>
                </div>
            </fieldset>
            <div class="row" align="right">
                <asp:Button ID="save" CssClass="btn btn-info" runat="server" Text="เพิ่มรายชื่อกรรมการ" OnClick="save_Click" />
                <asp:Button ID="cancel" CssClass="btn btn-default" runat="server" Text="ยกเลิก" PostBackUrl="~/AdminNHA/ViewStateProcess.aspx" CausesValidation="False" />
            </div>
        </div>
    </div>
</asp:Content>
