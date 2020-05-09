// This function should be registered on the form's OnLoad event
function OnLoad(executionContext) {
    // Get formContext
    var formContext = executionContext.getFormContext();

    // Get the web resource control on the form
    var wrCtrl = formContext.getControl("WebResource_sample_web-resource");

    // Get the web resource inner content window
    if (wrCtrl !== null && wrCtrl !== undefined) {
        wrCtrl.getContentWindow().then(function (win) {
            win.InitializeButton(executionContext);
        });
    }
}