<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTOR.aspx.cs" Inherits="Test.AdminNHA.AddTOR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold;">:: จัดเก็บเอกสารการขออนุมัติ</h2>
            <fieldset>
                <legend>จัดเก็บเอกสารการขออนุมัติ</legend>
                <div class="row" align="center">
                    <label>แนบเอกสาร</label>
                    <asp:FileUpload ID="FileUpload" runat="server" />
                    <br />
                    <hr>
                    <div class="row">                      
                        <center>
                        <div class="col-md-offset-2 col-md-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="TextBox1" class="control-label col-sm-3">บันทึกเลขที่: </label>
                                    <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"  ControlToValidate="TextBox1" ForeColor="Red"  ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="TextBox2" class="control-label col-sm-3">เรื่อง: </label>
                                    <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"  ControlToValidate="TextBox2" ForeColor="Red"  ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="TextBox3" class="control-label col-sm-3">วันที่: </label>
                                    <asp:TextBox ID="TextBox3" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"  ControlToValidate="TextBox3" ForeColor="Red"  ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox3" Operator="DataTypeCheck" Type="Date" Display="Dynamic" ForeColor="Red"  ErrorMessage="กรอกวันที่เท่านั้น"></asp:CompareValidator>
                                </div>
                                 <div class="form-group">
                                    <label for="TextBox4" class="control-label col-sm-3">รายละเอียด </label>
                                    <asp:TextBox ID="TextBox4" class="form-control" runat="server" TextMode="MultiLine" Rows="5" ></asp:TextBox>
                                    
                                </div>
                            </div>
                        </div>
                        </center>
                    </div>
                </div>
                <hr>
            </fieldset>

            <div class="row" align="right">
                <asp:Button runat="server" ID="save" CssClass="btn btn-info" Text="บันทึก" OnClick="save_Click" />
                <asp:Button runat="server" ID="cancel" CssClass="btn btn-default" Text="ยกเลิก" OnClick="cancel_Click" CausesValidation="false" />
            </div>
        </div>
    </div>
</asp:Content>
