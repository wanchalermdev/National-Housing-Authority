<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewStateProcess.aspx.cs" Inherits="Test.ViewStateProcess1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 style="font-weight: bold">:: ขั้นตอนตรวจสอบโครงการวิจัย</h2>
    <div class="row" id="CreatePage">
        <div class="col-xs-8 col-sm-10 col-lg-12">
            <div class="panel-body">
                <fieldset>
                    <ul class="nav nav-tabs disabled" id="tabs">
                        <li id="tab1" class="active"><a id="a1" data-toggle="tab" href="#home">ขั้นตอนสร้างโครงการวิจัย</a></li>
                        <li id="tab2" class=""><a id="a2" data-toggle="tab" href="#menu1">ขั้นตอนการขออนุมัติโครงการวิจัย</a></li>
                        <li id="tab3" class=""><a id="a3" data-toggle="tab" href="#menu2">ขั้นตอนการเผยแพร่โครงการวิจัย</a></li>
                    </ul>
                    <div class="tab-content">
                        <div id="home" class="tab-pane fade in active">
                            <div class="row">
                                <div id="displayTableOfMyProject" class="col-md-12">

                                </div>
                            </div>
                        </div>

                        <div id="menu1" class="tab-pane fade">
                            <div class="row">
                                <div id="displayTableOfMyProject2" class="col-md-12">

                                </div>
                            </div>
                        </div>

                        <div id="menu2" class="tab-pane fade">
                            <div id="displayTableOfMyProject3" class="col-md-12">

                                </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "/AdminNHA/ViewStateProcess.aspx/getMyProjectTable",
                data: '{user_id: "<%=Session["USER"]%>" }',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //console.log(data);
                    $("#displayTableOfMyProject").html(data.d);
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        });

        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "/AdminNHA/ViewStateProcess.aspx/getMyProjectTable2",
                data: '{user_id: "<%=Session["USER"]%>" }',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //console.log(data);
                    $("#displayTableOfMyProject2").html(data.d);
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        });

        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "/AdminNHA/ViewStateProcess.aspx/getMyProjectTable3",
                data: '{user_id: "<%=Session["USER"]%>" }',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //console.log(data);
                    $("#displayTableOfMyProject3").html(data.d);
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        });
    </script>
</asp:Content>
