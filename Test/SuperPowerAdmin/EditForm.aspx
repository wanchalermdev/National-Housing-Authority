<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditForm.aspx.cs" Inherits="Test.SuperPowerAdmin.EditForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold">:: กำหนดรูปแบบเอกสาร</h2>
            <div class="row">
                <table class="table table-hover table-bordered">
                    <thead>
                        <tr>
                            <th style="background-color:#5bc0de; color:white;">รายชื่อเอกสาร</th>
                            <th style="background-color:#5bc0de; color:white;" width="10%">เอกสาร</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>แบบฟอร์มขออนุมัติข้อกำหนดโครงการ
                            </td>
                            <td>
                                <asp:Button ID="ButtonDownload1" runat="server" CssClass="btn btn-xs btn-success" OnClick="ButtonDownload1_Click" Text="ดาวน์โหลด" />
                            </td>
                        </tr>
                        <tr>
                            <td>แบบฟอร์มแจ้งได้รับอนุมัติโครงการ</td>
                            <td>
                                <asp:Button ID="ButtonDownload2" runat="server" CssClass="btn btn-xs btn-success" OnClick="ButtonDownload2_Click" Text="ดาวน์โหลด" />
                            </td>
                        </tr>
                        <tr>
                            <td>แบบฟอร์มขอเชิญเป็นประธานประชุมตรวจรับงาน</td>
                            <td>
                                <asp:Button ID="ButtonDownload3" runat="server" CssClass="btn btn-xs btn-success" OnClick="ButtonDownload3_Click" Text="ดาวน์โหลด" />
                            </td>
                        </tr>
                        <tr>
                            <td>แบบฟอร์มขอเชิญประชุมตรวจรับงาน</td>
                            <td>
                                <asp:Button ID="ButtonDownload4" runat="server" CssClass="btn btn-xs btn-success" OnClick="ButtonDownload4_Click"  Text="ดาวน์โหลด" />
                            </td>
                        </tr>
                        <tr>
                            <td>แบบฟอร์มขออนุมัติเบิกค่าจ้าง</td>
                            <td>
                                <asp:Button ID="ButtonDownload5" runat="server" CssClass="btn btn-xs btn-success" OnClick="ButtonDownload5_Click" Text="ดาวน์โหลด" />
                            </td>
                        </tr>
                        <tr>
                            <td>แบบพิมพ์ตรวจสอบงานวิจัย</td>
                            <td>
                                <asp:Button ID="ButtonDownload6" runat="server" CssClass="btn btn-xs btn-success" OnClick="ButtonDownload6_Click" Text="ดาวน์โหลด" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br>
                <hr />
            </div>
            <div class="row" align="center">
                <h3>นำเอกสารที่แก้ไขเข้าระบบ</h3>
                <asp:FileUpload ID="fiUpload"  runat="server" Width="330px"></asp:FileUpload>
                 <br>
                <input id="btnUpload" type="button" class="btn btn-lg btn-success btn-block" onserverclick="btnUpload_OnClick" value="Upload" runat="server" />
            </div>
        </div>
    </div>
    <div class="row" align="right">
                <a href="../SuperPowerAdmin/HomeCreateProject" class="btn btn-default">กลับสู่เมนูหลัก</a>
            </div>

</asp:Content>
