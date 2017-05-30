<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeCreateProject.aspx.cs" Inherits="Test.SuperPowerAdmin.HomeCreateProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div >
    <div class="row" style="margin-top:20px">
        <h2 style="font-weight:bold">:: สร้างโครงการวิจัย</h2>
     </div>
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <fieldset>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            <%--<asp:Button ID="ButtonCreate" CssClass="btn btn-info btn-lg btn-block" runat="server" OnClick="ButtonCreate_Click" Text="ตั้งงบประมาณโครงการ" />--%>
                            <a  href="../SuperPowerAdmin/CreateBudget.aspx" class="btn btn-info btn-lg btn-block"><i class="glyphicon glyphicon-usd" style="font-size:2.5rem;"></i><br>ตั้งงบประมาณโครงการ</a>
                        </div>
                        <div class="col-md-3">
                            <%--<asp:Button ID="ButtonFillData" CssClass="btn btn-info btn-lg btn-block" runat="server" Text="ป้อนข้อมูลโครงการ" OnClick="ButtonFillData_Click" />--%>
                            <a  href="../SuperPowerAdmin/FillProjectData.aspx" class="btn btn-info btn-lg btn-block"><i class="glyphicon glyphicon-pencil" style="font-size:2.5rem;"></i><br>ป้อนข้อมูลโครงการ</a>
                        </div>
                        <div class="col-md-3">
                            <%--<asp:Button ID="ButtonPrint" CssClass="btn btn-info btn-lg btn-block" runat="server" Text="พิมพ์เอกสารรายงาน" OnClick="ButtonPrint_Click" />--%>
                            <a  href="../SuperPowerAdmin/PrintDoc.aspx" class="btn btn-info btn-lg btn-block"><i class="glyphicon glyphicon-print" style="font-size:2.5rem;"></i><br>พิมพ์เอกสารรายงาน</a>
                        </div>
                        <div class="col-md-3">
                            <%--<asp:Button ID="ButtonEditForm" CssClass="btn btn-info btn-lg btn-block" runat="server" Text="กำหนดรูปแบบเอกสาร" OnClick="ButtonEditForm_Click" />--%>
                            <a  href="../SuperPowerAdmin/EditForm.aspx" class="btn btn-info btn-lg btn-block"><i class="glyphicon glyphicon-cog" style="font-size:2.5rem;"></i><br>กำหนดรูปแบบเอกสาร</a>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
     </div>
</asp:Content>
