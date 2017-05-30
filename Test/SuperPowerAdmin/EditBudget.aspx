<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBudget.aspx.cs" Inherits="Test.SuperPowerAdmin.EditBudget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold">:: แก้ไขเงินงบประมาณประจำปี</h2>
            <br>
            <fieldset>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-inline">
                            <label for="Txtyear">ปีงบประมาณ:</label>
                            <asp:TextBox ID="TxtYear" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtYear" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" SetFocusOnError="true" runat="server" Type="Integer" MinimumValue="1970" MaximumValue="3000" ControlToValidate="TxtYear" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" SetFocusOnError="true" ControlToValidate="TxtYear" Operator="DataTypeCheck" Type="Integer" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-inline">
                            <label for="TxtBudget">จำนวนงบประมาณ:</label>
                            <asp:TextBox ID="TxtBudget" CssClass="form-control" runat="server" Dataformating="{0:N2}" ></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TxtBudget" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>--%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="TxtBudget" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" SetFocusOnError="true" Type="Double" MinimumValue="1" MaximumValue="99999999999999999999" ControlToValidate="TxtBudget" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" SetFocusOnError="true" ControlToValidate="TxtBudget" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-inline">
                            <asp:Button ID="BtnAdd" CssClass="btn btn-warning" runat="server" Text="แก้ไข" OnClick="BtnAdd_Click" />
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>

     <script>
        function Comma(Num) { //function to add commas to textboxes
            Num += '';
            Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
            Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
            x = Num.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1))
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            return x1 + x2;
        }
    </script>
</asp:Content>
