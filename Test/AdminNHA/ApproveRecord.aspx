<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveRecord.aspx.cs" Inherits="Test.AdminNHA.ApproveRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 style="font-weight: bold">:: จัดเก็บเอกสารการขออนุมัติ</h2>


    <div class="row" id="CreatePage">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <div class="panel-body">
                <fieldset>
                    <div class="row" align="center">
                        <asp:Button ID="BtnClick" OnClick="BtnClick_Click" class="btn btn-lg btn-info" Text="จัดเก็บเอกสารการขออนุมัติ" runat="server" />
                    </div>
                    <hr>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:GridView ID="tableDoc" CssClass="table table-bordered table-hover" GridLines="None" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="number" HeaderText="บันทึกเลขที่" ItemStyle-Width="20%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="topic" HeaderText="เรื่อง" ItemStyle-Width="50%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="dateupload" HeaderText="วันที่" ItemStyle-Width="15%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                        <%--<asp:BoundField DataField="Dedit" HeaderText="" ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Center" />--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <hr>
            </div>
        </div>
    </div>

    <div class="row" align="right">
        <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-success" Text="กลับหน้าหลัก" PostBackUrl="~/AdminNHA/ViewStateProcess.aspx" CausesValidation="false" />
    </div>

</asp:Content>
