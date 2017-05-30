<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateBudget.aspx.cs" Inherits="Test.SuperPowerAdmin.CreateBudget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold">:: ตั้งและจัดสรรงบประมาณ</h2>
            <fieldset>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-inline">
                            <label for="Txtyear">ปีงบประมาณ:</label>
                            <asp:TextBox ID="TxtYear" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtYear" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" SetFocusOnError="true" runat="server" Type="Integer" MinimumValue="1970" MaximumValue="3000" ControlToValidate="TxtYear" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" SetFocusOnError="true" ControlToValidate="TxtYear" Operator="DataTypeCheck" Type="Integer" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-inline">
                            <label for="TxtBudget">จำนวนงบประมาณ:</label>
                            <asp:TextBox ID="TxtBudget" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="TxtBudget" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" SetFocusOnError="true" Type="Double" MinimumValue="1" MaximumValue="99999999999999999999" ControlToValidate="TxtBudget" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" SetFocusOnError="true" ControlToValidate="TxtBudget" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-inline">
                            <asp:Button ID="BtnAdd" CssClass="btn btn-info" runat="server" Text="เพิ่ม" OnClick="BtnAdd_OnClick" />
                        </div>
                    </div>
                </div>
                <br>
                <hr />
                <div class="row">
                    <asp:GridView ID="gvBudget" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="gvBudget_RowCommand" >
                        <Columns>
                            <asp:BoundField DataField="year" HeaderText="ปีงบประมาณ" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="budget" DataFormatString="{0:N2}" HeaderText="เงินงบประมาณประจำปี" ItemStyle-Width="25%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>
                                <ItemStyle Width="25%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="projectBudget" HeaderText="งบประมาณจัดสรร" DataFormatString="{0:N2}" ItemStyle-Width="25%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White">
                                <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

                                <ItemStyle Width="25%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="projectBalance" HeaderText="งบประมาณคงเหลือ" DataFormatString="{0:N2}" ItemStyle-Width="25%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White">
                                <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

                                <ItemStyle Width="25%"></ItemStyle>
                            </asp:BoundField>
                            <asp:ButtonField Text="แก้ไข" ControlStyle-CssClass="btn btn-xs btn-warning" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" CommandName="edit" ItemStyle-HorizontalAlign="Center" >
                                <ControlStyle CssClass="btn btn-xs btn-warning" ></ControlStyle>
                                <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>
                            </asp:ButtonField>
                            <asp:ButtonField Text="ลบ" ControlStyle-CssClass="btn btn-xs btn-danger" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" CommandName="delete" ItemStyle-HorizontalAlign="Center" >
                                <ControlStyle CssClass="btn btn-xs btn-danger"></ControlStyle>
                                <HeaderStyle BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>
                            </asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                </div>

            </fieldset>
        </div>
        <div class="row">
            <div class="col-md-12" align="right">
            
                <asp:Button ID="BtnPrintOut" CssClass="btn btn-info" runat="server" Text="พิมพ์รายงานสรุปภาพรวมงบประมาณ" OnClick="BtnPrintOut_Click" />
                  <asp:Button ID="BtnBack" CssClass="btn btn-default" runat="server" Text="กลับสู่เมนูหลัก" OnClick="BtnBack_OnClick" CausesValidation="false" />
            
                </div>
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
