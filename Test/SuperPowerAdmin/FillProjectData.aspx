<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FillProjectData.aspx.cs" Inherits="Test.SuperPowerAdmin.FillProjectData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="customTopMargin">
        <div class="container customBorder">

            <div class="col-xs-12 col-sm-12 col-lg-12">
                <div class="page-header">
                    <h2 style="font-weight: bold">:: ป้อนข้อมูลจัดสรรโครงการกิจกรรม และกำหนดผู้ประสานงาน หรือผู้รับผิดชอบโครงการ</h2>
                </div>

                <fieldset>
                    <legend>ข้อมูลโครงการ</legend>
                    <div class="row">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="TxtProjectName" class="control-label col-sm-4">ชื่อโครงการ/กิจกรรม:</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="TxtProjectName" CssClass="form-control" runat="server" Width="100%">โครงการเพาะปลูกมะเขือเทศบนที่ราบสูง</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="TxtProjectName" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">ปีที่ดำเนินงาน:</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="TxtProcessYear" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" Display="Dynamic" ControlToValidate="TxtProcessYear" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">ปีของงบประมาณที่นำมาจัดสรร:</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="DDbudgetYear1" CssClass="custom-select form-control" runat="server" AutoPostBack="False" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" InitialValue="-1" ControlToValidate="DDbudgetYear1" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="TbBudget1" CssClass="form-control text-budget sum" runat="server">1000000</asp:TextBox>
                                </div>

                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">ปีของงบประมาณที่นำมาจัดสรร:</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="DDbudgetYear2" CssClass="custom-select form-control" runat="server" AutoPostBack="False" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" Display="Dynamic" InitialValue="-1" ControlToValidate="DDbudgetYear2" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="TbBudget2" CssClass="form-control text-budget sum" runat="server">1000000</asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">ปีของงบประมาณที่นำมาจัดสรร:</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="DDbudgetYear3" CssClass="custom-select form-control" runat="server" AutoPostBack="False" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" Display="Dynamic" InitialValue="-1" ControlToValidate="DDbudgetYear3" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="TbBudget3" CssClass="form-control text-budget sum" runat="server">1000000</asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">ปีของงบประมาณที่นำมาจัดสรร:</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="DDbudgetYear4" CssClass="custom-select form-control" runat="server" AutoPostBack="False" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" Display="Dynamic" InitialValue="-1" ControlToValidate="DDbudgetYear4" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="TbBudget4" CssClass="form-control text-budget sum" runat="server">1000000</asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-sm-4">ระยะเวลาดำเนินการ:</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="TxtPeroid" CssClass="form-control" runat="server">30</asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtPeroid" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </div>

                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">งบประมาณรวม:</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="TxtBudget" CssClass="form-control" DataFormatString="{0:N2}" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>แผนการใช้งบประมาณ</legend>
                    <div class="row">
                        <div class="form-horizontal">
                            <div class="form-group">

                                <label class="control-label col-sm-4">ตุลาคม <span id="october"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text10" CssClass="form-control textbox-month" runat="server">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Text10" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator2" runat="server" Type="Double" MinimumValue="0" MaximumValue="99999999999999999999" ControlToValidate="Text10" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="Text10" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">พฤศจิกายน <span id="november"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text11" CssClass="form-control textbox-month" runat="server">200000</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Text11" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator3" runat="server" Type="Double" ControlToValidate="Text11" MinimumValue="0" MaximumValue="99999999999999999999" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="Text11" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>
                            <div class="form-group">

                                <label class="control-label col-sm-4">ธันวาคม <span id="december"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text12" CssClass="form-control textbox-month" runat="server">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Text12" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator4" runat="server" Type="Double" ControlToValidate="Text12" MinimumValue="0" MaximumValue="99999999999999999999" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="Text12" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>
                            <div class="form-group">

                                <label class="control-label col-sm-4">มกราคม <span id="january"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text1" CssClass="form-control textbox-month" runat="server">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Text1" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator5" runat="server" Type="Double" ControlToValidate="Text1" MinimumValue="0" MaximumValue="99999999999999999999" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="Text1" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>
                            <div class="form-group">

                                <label class="control-label col-sm-4">กุมภาพันธ์ <span id="febuary"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text2" CssClass="form-control  textbox-month" runat="server">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Text2" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator6" runat="server" Type="Double" ControlToValidate="Text2" MinimumValue="0" MaximumValue="99999999999999999999" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="Text2" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>
                            <div class="form-group">

                                <label class="control-label col-sm-4">มีนาคม <span id="march"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text3" CssClass="form-control textbox-month" runat="server">500000</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Text3" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator7" runat="server" Type="Double" ControlToValidate="Text3" MinimumValue="0" MaximumValue="99999999999999999999" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="Text3" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-sm-4">เมษายน <span id="april"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text4" CssClass="form-control textbox-month" runat="server">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="Text4" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator8" runat="server" Type="Double" ControlToValidate="Text4" MinimumValue="0" MaximumValue="99999999999999999999" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="Text4" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-sm-4">พฤษภาคม <span id="may"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text5" CssClass="form-control textbox-month" runat="server">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="Text5" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator9" runat="server" Type="Double" ControlToValidate="Text5" MinimumValue="0" MaximumValue="99999999999999999999" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="Text5" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">มิถุนายน <span id="june"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text6" CssClass="form-control textbox-month" runat="server">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="Text6" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator10" runat="server" Type="Double" ControlToValidate="Text6" MinimumValue="0" MaximumValue="99999999999999999999" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="Text6" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">กรกฎาคม <span id="july"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text7" CssClass="form-control textbox-month" runat="server">100000</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="Text7" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator11" runat="server" Type="Double" ControlToValidate="Text7" MinimumValue="0" MaximumValue="99999999999999999999" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="Text7" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">สิงหาคม <span id="august"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text8" CssClass="form-control textbox-month" runat="server">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="Text8" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator12" runat="server" Type="Double" ControlToValidate="Text8" MinimumValue="0" MaximumValue="99999999999999999999" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="Text8" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">กันยายน <span id="september"></span>: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Text9" CssClass="form-control textbox-month" runat="server">200000</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="Text9" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator13" runat="server" Type="Double" ControlToValidate="Text9" MinimumValue="0" MaximumValue="99999999999999999999" Display="Dynamic" ForeColor="Red" ErrorMessage="ข้อมูลไม่ถูกต้อง"></asp:RangeValidator>
                                    <asp:CompareValidator ID="CompareValidator13" runat="server" ControlToValidate="Text9" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ForeColor="Red" ErrorMessage="กรอกตัวเลขเท่านั้น"></asp:CompareValidator>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">ยอดเงินรวม: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Total" CssClass="form-control" DataFormatString="{0:N2}" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>


                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-4">จำนวนงวดงาน: </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" ReadOnly="true">3</asp:TextBox>
                                </div>

                            </div>
                        </div>
                    </div>
                </fieldset>

                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10" align="right">
                        <asp:Button ID="btnSubmit" CssClass="btn btn-info" runat="server" Text="กำหนดผู้รับผิดชอบและผู้ประสานงาน"
                            OnClick="btnSubmit_Click"></asp:Button>
                        <asp:Button ID="BtnCancel" CssClass="btn btn-default" runat="server" Text="กลับสู่เมนูหลัก" OnClick="BtnCancel_OnClick" CausesValidation="false" />
                    </div>
                </div>
            </div>




            <!--scripts show year and adding-->
            <script>
                function DisplayYear() {
                    var year = parseInt($("#MainContent_budgetYear option:selected").text());
                    var yearVal = $("#MainContent_budgetYear").val();
                    //var yearVal1 = $("#YearList").val()+1;
                    if (yearVal == "") {
                        //$("#october").css("display", "none");
                    } else {
                        $("#october").html(year);
                        $("#november").html(year);
                        $("#december").html(year);
                        $("#january").html(year + 1);
                        $("#febuary").html(year + 1);
                        $("#march").html(year + 1);
                        $("#april").html(year + 1);
                        $("#may").html(year + 1);
                        $("#june").html(year + 1);
                        $("#july").html(year + 1);
                        $("#august").html(year + 1);
                        $("#september").html(year + 1);
                    }
                    //$("#october").html(yearVal);
                    console.log(yearVal);
                }

                $("select").change(DisplayYear);
                DisplayYear();
            </script>

            <script>
                var sumBudgetYear = parseInt($("#MainContent_TbBudget1").val()) + parseInt($("#MainContent_TbBudget2").val()) + parseInt($("#MainContent_TbBudget3").val()) + parseInt($("#MainContent_TbBudget4").val());
                $("#MainContent_TxtBudget").val(sumBudgetYear);
                $('.sum').keyup(function () {
                    var sum = 0;
                    $('.sum').each(function () {
                        sum += Number($(this).val());
                    });
                    $("#MainContent_TxtBudget").val(sum);
                });
                //$(".text-budget").change(function () {
                //    if ()
                //});
            </script>

            <script>
                var sumBudget = AddTotal();
                $("#MainContent_Total").val(sumBudget);
                $("#MainContent_TextBox3").val(Period());
                $(".textbox-month").change(function () {
                    var sumBudget = AddTotal();
                    if (sumBudget > parseInt($("#MainContent_TxtBudget").val())) {
                        alert("ยอดเงินรวมเกินจำนวนที่กำหนด");
                        $("#MainContent_BtnSave").addClass("disabled");
                        $("#MainContent_TextBox3").val(Period());
                        $("#MainContent_Total").val(sumBudget);
                    } else {
                        $("#MainContent_Total").val(sumBudget);
                        $("#MainContent_TextBox3").val(Period());
                        $("#MainContent_BtnSave").removeClass("disabled");
                    }
                });

            </script>
        </div>

    </section>


    <!-- Modal -->

    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h3 class="modal-title" style="color: red">ตรวจสอบข้อมูล</h3>
                        </div>
                        <div class="modal-body">
                            <div class="col-xs-8 col-sm-12 col-lg-12">
                                <fieldset>
                                    <legend>ข้อมูลโครงการ</legend>
                                    <div class="row">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">ชื่อโครงการ/กิจกรรม:</label>
                                                <label class="control-label col-sm-4" id="lbProjectName" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">ปีที่ดำเนินงาน:</label>
                                                <label class="control-label col-sm-4" id="lbProcessYear" runat="server"></label>

                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">ปีของงบประมาณที่นำมาจัดสรร:</label>
                                                <label class="control-label col-sm-2" id="lbBudgetYear1" runat="server"></label>
                                                <label class="control-label col-sm-2" id="lbTextBox1" runat="server"></label>

                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">ปีของงบประมาณที่นำมาจัดสรร:</label>
                                                <label class="control-label col-sm-2" id="lbBudgetYear2" runat="server"></label>
                                                <label class="control-label col-sm-2" id="lbTextBox2" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">ปีของงบประมาณที่นำมาจัดสรร:</label>
                                                <label class="control-label col-sm-2" id="lbBudgetYear3" runat="server"></label>
                                                <label class="control-label col-sm-2" id="lbTextBox3" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">ปีของงบประมาณที่นำมาจัดสรร:</label>
                                                <label class="control-label col-sm-2" id="lbBudgetYear4" runat="server"></label>
                                                <label class="control-label col-sm-2" id="lbTextBox4" runat="server"></label>
                                            </div>

                                            <div class="form-group">
                                                <label class="control-label col-sm-4">ระยะเวลาดำเนินการ:</label>
                                                <label class="control-label col-sm-4" id="lbPeriod" runat="server"></label>

                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">งบประมาณรวม:</label>
                                                <label class="control-label col-sm-4" id="lbTxtBudget" runat="server"></label>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                                <fieldset>
                                    <legend>แผนการใช้งบประมาณ</legend>
                                    <div class="row">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">ตุลาคม</label>
                                                <label class="control-label col-sm-4" id="Tb10" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">พฤศจิกายน</label>
                                                <label class="control-label col-sm-4" id="Tb11" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">ธันวาคม</label>
                                                <label class="control-label col-sm-4" id="Tb12" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">มกราคม</label>
                                                <label class="control-label col-sm-4" id="Tb1" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">กุมภาพันธ์</label>
                                                <label class="control-label col-sm-4" id="Tb2" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">มีนาคม</label>
                                                <label class="control-label col-sm-4" id="Tb3" runat="server"></label>
                                            </div>

                                            <div class="form-group">
                                                <label class="control-label col-sm-4">เมษายน</label>
                                                <label class="control-label col-sm-4" id="Tb4" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">พฤษภาคม</label>
                                                <label class="control-label col-sm-4" id="Tb5" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">มิถุนายน</label>
                                                <label class="control-label col-sm-4" id="Tb6" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">กรกฎาคม</label>
                                                <label class="control-label col-sm-4" id="Tb7" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">สิงหาคม</label>
                                                <label class="control-label col-sm-4" id="Tb8" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">กันยายน</label>
                                                <label class="control-label col-sm-4" id="Tb9" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">ยอดเงินรวม: </label>
                                                <label class="control-label col-sm-4" id="TbTotalMoney" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-sm-4">จำนวนงวดงาน: </label>
                                                <label class="control-label col-sm-4" id="TbTotalPeroid" runat="server"></label>
                                            </div>

                                        </div>
                                    </div>
                                </fieldset>

                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-info" Text="ตกลง" OnClick="BtnOk_OnClick" />
                                <button type="button" class="btn btn-default" data-dismiss="modal">ยกเลิก</button>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script>

        function numberWithCommas(x) {
            return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }
    </script>

</asp:Content>
