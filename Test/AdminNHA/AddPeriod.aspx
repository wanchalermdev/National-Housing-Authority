<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPeriod.aspx.cs" Inherits="Test.AdminNHA.AddPeriod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold">:: การบริหารสัญญา</h2>
            <div class="row">
                <fieldset>
                    <legend>เพิ่มงวดงานตามสัญญา</legend>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                
                                <label for="budget" class="col-sm-4">จำนวนเงิน</label>
                                <asp:TextBox ID="budget" CssClass="form-control" runat="server" AutoPostBack="True" OnTextChanged="budget_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"  ControlToValidate="budget" ForeColor="Red"  ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Double" MinimumValue="1" MaximumValue="99999999999999999999" ControlToValidate="budget" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="budget" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red"  ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                      
                        </div>
                       <%-- <div class="col-md-6">
                            <div class="form-group">
                                <label for="percent" class="col-sm-4">%</label>
                                <asp:TextBox ID="percent" ReadOnly="true" CssClass="form-group" runat="server" OnTextChanged="percent_TextChanged"></asp:TextBox>
                            </div>
                        </div>--%>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label for="day" class="col-sm-4">ระยะเวลา(วัน)</label>
                            <asp:TextBox ID="day" CssClass="form-control" AutoPostBack="True" runat="server" OnTextChanged="day_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"  ControlToValidate="day" ForeColor="Red"  ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" Type="Double" MinimumValue="1" MaximumValue="1000000" ControlToValidate="day" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="day" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red"  ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-6">
                        <label for="textarea" class="col-sm-4">เพิ่มเนื่องาน</label>
                        <asp:TextBox ID="textarea" TextMode="MultiLine" CssClass="form-control"
                            Columns="50" Rows="5" runat="server" Width="550%"></asp:TextBox>
                            </div>
                    </div>
                </fieldset>
            </div>
            <br /><br /><br />
            <div class="row" align="right">
                <asp:Button ID="BtnSave" CssClass="btn btn-info" runat="server" Text="บันทึก" OnClick="BtnSave_Click" />
                <asp:Button ID="BtnCancel" CssClass="btn btn-default" runat="server" Text="ยกเลิก" CausesValidation="False" />
            </div>
        </div>
    </div>
</asp:Content>
