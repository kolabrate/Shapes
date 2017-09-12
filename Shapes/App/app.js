$(function() {
	$.ajax({
		url: '/shape/draw/',
		type: 'POST',
		contentType: 'application/json',
	    data: {userExpression: $('#txtUserExpression').val()}

	})
	.done(function(data) {
		console.log(data);
		console.log("success");
	})
	.fail(function() {
		console.log("error");
	})
	.always(function() {
		console.log("complete");
	});
	
});