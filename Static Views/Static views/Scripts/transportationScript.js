$(document).ready(function () {

    //on click of the modal button
    $('#buttonConfirmTransport').click(function () {
        //if you just need the ids as CSV in any action jst set the action name in the form in Area.cshtml
        $('#vehicleForm').submit();
        //$('#employeeModalDiv').toggle();
        //$("#bonusSelectedEmployeeDiv").toggle();
        
    });

    $('#buttonConfirmEmployee').click(function () {
        //if you just need the ids as CSV in any action jst set the action name in the form in Area.cshtml
        $('#employeeForm').submit();
        //$('#employeeModalDiv').toggle();
        //$("#bonusSelectedEmployeeDiv").toggle();

    });
});