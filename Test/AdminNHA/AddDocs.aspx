<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDocs.aspx.cs" Inherits="Test.AdminNHA.AddDocs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="font-weight: bold">:: เพิ่มเอกสารของงวดงาน</h2>
    <fieldset>
        <div class="row">
                        <label for="">เพิ่มเอกสาร</label>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:TextBox ID="nameDoc" CssClass="form-control" placeholder="ชื่อ" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"  ControlToValidate="nameDoc" ForeColor="Red"  ErrorMessage="*"></asp:RequiredFieldValidator>
                                  
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <div class="btn-group">
                                        <asp:DropDownList ID="DocType" CssClass="custom-select form-control" runat="server"  >
                                            <asp:ListItem Value="0">กรุณาเลือกประเภทเอกสาร</asp:ListItem>
                                            <asp:ListItem Value="หนังสือนำส่ง .doc">หนังสือนำส่ง .doc</asp:ListItem>
                                            <asp:ListItem Value="หนังสือนำส่ง .pdf">หนังสือนำส่ง .pdf</asp:ListItem>
                                            <asp:ListItem Value="เล่มรายงานเบื้องต้น .doc">เล่มรายงานเบื้องต้น .doc</asp:ListItem>
                                            <asp:ListItem Value="เล่มรายงานเบื้องต้น .pdf">เล่มรายงานเบื้องต้น .pdf</asp:ListItem>
                                            <asp:ListItem Value="เอกสารนำเสนอ .doc">เอกสารนำเสนอ .doc</asp:ListItem>
                                            <asp:ListItem Value="เอกสารนำเสนอ .pdf">เอกสารนำเสนอ .pdf</asp:ListItem>
                                            <asp:ListItem Value="CD">CD</asp:ListItem>
                                            <asp:ListItem Value="DVD">DVD</asp:ListItem>
                                            <asp:ListItem Value="อุปกรณ์บันทึกข้อมูล">อุปกรณ์บันทึกข้อมูล</asp:ListItem>
                                            <asp:ListItem Value="อื่นๆ">อื่นๆ</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" InitialValue="0"  ControlToValidate="DocType" ForeColor="Red"  ErrorMessage="*"></asp:RequiredFieldValidator>
                                      
                                      <%--  <asp:TextBox ID="typeOther" CssClass="form-control" Visible="true" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"  ControlToValidate="typeOther" ForeColor="Red"  ErrorMessage="*"></asp:RequiredFieldValidator>
                                        --%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="numDoc" CssClass="form-control" runat="server" placeholder="จำนวน"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"  ControlToValidate="numDoc" ForeColor="Red"  ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Integer" MinimumValue="1" MaximumValue="1000" ControlToValidate="numDoc" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="numDoc" Operator="DataTypeCheck" Type="Integer" Display="Dynamic" ForeColor="Red"  ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnAdd" CssClass="btn btn-info" runat="server" Text="เพิ่ม" OnClick="btnAdd_Click" />
                            </div>
                        </div>
                        <div class="row">
                            <asp:GridView DataKeyNames="" ID="gvDoc" CssClass="table table-bordered table-hover " GridLines="None"  runat="server" AutoGenerateColumns="False" OnRowCommand="gvDoc_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="doc" HeaderText="ชื่อเอกสาร" ItemStyle-Width="40%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" >
<HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

<ItemStyle Width="40%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="type" HeaderText="ประเภท" ItemStyle-Width="30%"  HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" >
<HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

<ItemStyle Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="number" HeaderText="จำนวน" ItemStyle-Width="10%" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" >
<HeaderStyle HorizontalAlign="Center" BackColor="#5BC0DE" ForeColor="White"></HeaderStyle>

<ItemStyle Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                   <%-- <asp:BoundField DataField="Dedit" HeaderText="" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" />--%>
                                    <asp:ButtonField CommandName="delete" ButtonType="Button" Text="ลบ" HeaderStyle-BackColor="#55bc0de" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" />
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="ย้อนกลับ" CausesValidation="false" />
                        </div>
                    </div>
</fieldset>
</asp:Content>
