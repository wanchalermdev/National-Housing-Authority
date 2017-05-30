<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResearchDetail.aspx.cs" Inherits="Test.AdminNHA.ResearchDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold">:: แก้ไขนักวิจัยของโครงการ</h2>
            <legend>ข้อมูลนักวิจัย</legend>
            <div class="row">

                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="control-label col-sm-4">คำนำหน้าชื่อ:</label>
                        <asp:TextBox ID="TextBoxPname" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">ชื่อ:</label>
                        <asp:TextBox ID="TextBoxFname" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">นามสกุล:</label>
                        <asp:TextBox ID="TextBoxLname" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">

                        <label class="control-label col-sm-4">เพศ:</label>
                        <asp:TextBox ID="TextBoxGender" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">เลขบัตรประชาชน:</label>
                        <asp:TextBox ID="TextBoxID" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">วันเดือนปีเกิด:</label>
                        <asp:TextBox ID="TextBoxBirth" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">บทบาทหน้าที่ในโครงการ:</label>
                        <asp:TextBox ID="TextBoxRole" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">ตำแหน่งทางวิชาการ:</label>
                        <asp:TextBox ID="TextBoxPosition" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">สังกัดหน่วยงาน/บริษัท:</label>
                        <asp:TextBox ID="TextBoxIns" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">ระดับการศึกษา:</label>
                        <asp:TextBox ID="TextBoxEduc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">สาขาวิชาที่จบ:</label>
                        <asp:TextBox ID="TextBoxDegree" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">สาขาวิชาที่จบ:</label>
                        <asp:TextBox ID="TextBoxMajor" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">ความเชี่ยวชาญและประสบการณ์:</label>
                        <asp:TextBox ID="TextBoxExp" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">เบอร์โทรศัพท์หน่วยงาน:</label>
                        <asp:TextBox ID="TextBoxTel" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">เบอร์โทรสารหน่วยงาน:</label>
                        <asp:TextBox ID="TextBoxFax" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">เบอร์มือถือ:</label>
                        <asp:TextBox ID="TextBoxPhone" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-4">อีเมลล์:</label>
                        <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

            </div>
        </div>

    </div>

    <div class="row" align="right">
        <asp:Button ID="ButtonEdit" runat="server" CssClass="btn btn-info" Text="แก้ไข" Width="131px" OnClick="ButtonEdit_Click" />
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" OnClick="Button1_Click" Text="กลับ" Width="145px" />
    </div>
</asp:Content>
