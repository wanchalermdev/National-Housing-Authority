function testAlert() {
    alert("Hello, World");
}

function AddTotal() {
    var total = parseInt($("#MainContent_Text10").val()) + parseInt($("#MainContent_Text11").val()) + parseInt($("#MainContent_Text12").val()) + parseInt($("#MainContent_Text1").val()) +
        parseInt($("#MainContent_Text2").val()) + parseInt($("#MainContent_Text3").val()) + parseInt($("#MainContent_Text4").val()) + parseInt($("#MainContent_Text5").val()) +
        parseInt($("#MainContent_Text6").val()) + parseInt($("#MainContent_Text7").val()) + parseInt($("#MainContent_Text8").val()) + parseInt($("#MainContent_Text9").val());
    //console.log(total);
    return total;
}

function AddBudgetYear() {
    var total = parseInt($("#MainContent_TextBox1").val()) + parseInt($("#MainContent_TextBox2").val()) + parseInt($("#MainContent_TextBox4").val()) + parseInt($("#MainContent_TextBox5").val());
    return total;
}

function Period() {
    var period = 0;

    if ($("#MainContent_Text10").val() != 0) {
        period ++;
    }
    if ($("#MainContent_Text11").val() != 0) {
        period ++;
    }
    if ($("#MainContent_Text12").val() != 0) {
        period ++;
    }
    if ($("#MainContent_Text1").val() != 0) {
        period ++;
    }
    if ($("#MainContent_Text2").val() != 0) {
        period ++;
    }
    if ($("#MainContent_Text3").val() != 0) {
        period ++;
    }
    if ($("#MainContent_Text4").val() != 0) {
        period ++;
    }
    if ($("#MainContent_Text5").val() != 0) {
        period ++;
    }
    if ($("#MainContent_Text6").val() != 0) {
        period ++;
    }
    if ($("#MainContent_Text7").val() != 0) {
        period ++;
    }
    if ($("#MainContent_Text8").val() != 0) {
        period ++;
    }
    if ($("#MainContent_Text9").val() != 0) {
        period ++;
    }

    console.log(period);
    return period;
}