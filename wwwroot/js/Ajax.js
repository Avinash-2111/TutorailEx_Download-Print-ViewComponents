function editTutorial(Id) {
    $.ajax({
        url: '@Url.Action("EditTutorial","Tutorial")' + Id,
        type: 'GET',
        data: { Id: Id },
        success: function (response)
        {
            console.log(response);
        },
        error: function (xhr, status, error)
        {
            console.error(error);
        }
    })
}