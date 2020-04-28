//$.notify({
//	title: '<strong>Heads up!</strong>',
//	message: 'You can use any of bootstraps other alert styles as well by default.'
//}, {
//	type: 'success'
//});


    $("#adicionarmembro").click(function () {
		var notify = $.notify('<strong>Saving</strong> Do not close this page...', {
			type: 'success',
			allow_dismiss: false,
			showProgressbar: true
		});

		setTimeout(function () {
			notify.update('message', '<strong>Saving</strong> Page Data.');
		}, 500);

		setTimeout(function () {
			notify.update('message', '<strong>Saving</strong> User Data.');
		}, 500);
    });
