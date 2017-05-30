<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PMIndex.aspx.cs" Inherits="Test.ProjectManager.PMIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <h2 style="font-weight: bold">:: รับทราบเอกสารข้ออนุมัติโครงการและเพิ่มรายชื่อกรรมการ</h2>
            <fieldset>
                <hr>
                <asp:GridView ID="gvProject" CssClass="table table-hover" runat="server" GridLines="None" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="project_id" HeaderText="รหัสโครงการ" ItemStyle-Width="10%" />
                        <asp:BoundField DataField="year" HeaderText="ปีงบประมาณ" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="project_name" HeaderText="ชื่อโครงการ" ItemStyle-Width="40%" HeaderStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="project_budget" HeaderText="งบประมาณที่ได้รับจัดสรร" ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="project_budget" HeaderText="จำนวนเงินที่ได้" ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Center" />
                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDetails" runat="server" CssClass="btn btn-xs btn-info" Text="เพิ่มเติม" PostBackUrl='<%# "~/ProjectManager/UpTor.aspx?id=" + DataBinder.Eval(Container.DataItem,"project_id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
               <%-- <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <table class="table table-hover" id="tablePC">
                                <thead>
                                    <tr>
                                        <th>รหัสโครงการ</th>
                                        <th>ปีงบประมาณ</th>
                                        <th>ชื่อโครงการ</th>
                                        <th>งบประมาณที่ได้รับจัดสรร</th>
                                        <th>จำนวนเงินที่ได้</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="test">
                                        <td>P1526</td>
                                        <td>2556</td>
                                        <td>โครงการเพาะถั่วงอกบนคอนโด</td>
                                        <td>1,125,000</td>
                                        <td>125,000</td>
                                        <td>
                                            <asp:HyperLink runat="server" NavigateUrl="~/ProjectManager/UpTor.aspx" ID="btnMore" class="btn btn-xs btn-info btn-block">เพิ่มเติม</asp:HyperLink>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>--%>
            </fieldset>
            <hr>
        </div>
    </div>
     <div class="row" align="right">
                <asp:Button ID="back" CssClass="btn btn-success" runat="server" Text="ย้อนกลับ" OnClick="back_Click" />
               
            </div>
</asp:Content>
