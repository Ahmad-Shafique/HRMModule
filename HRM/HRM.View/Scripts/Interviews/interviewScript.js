$(document).ready(function () {
	console.log('Document ready !');

    //on click of the modal button
    $('#buttonCandidateAddition').click(function () {

	 console.log('Entered button candidate addition');

        //an arraay for containing checkbox values
	    var resultString = '';
        var checkBox = $('input[name = "EnabledCandidates"]');
        $.each(checkBox, function () {
            if ($(this).is(":checked")) {
               	resultString.append($(this).val() + ',');
		console.log('appended !');
            }
        });


	console.log(resultString);

    });


    $('#CreateInterview').click(function () {
	
	console.log('Entered button confim transport');

    //var resultString = '';


    var schedule = $('#scheduleText').val();
    console.log('Schedule is: ' + schedule); 


	//console.log(resultString);

    });


});
