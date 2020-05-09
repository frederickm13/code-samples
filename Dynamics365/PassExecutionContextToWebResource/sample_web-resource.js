window.parentExecutionContext = null;
window.parentFormContext = null;

function InitializeButton(executionContext) {
    // Assign executionContext and formContext to global variables within the web resource
    window.parentExecutionContext = executionContext;
    window.parentFormContext = executionContext.getFormContext();
}

function ToggleLock() {
    var fieldName = "name";

    // Get the "name" control from the Dynamics 365 form
    var control = window.parentFormContext.getControl(fieldName);

    // Check if the control is currently locked
    var isLocked = control.getDisabled();
    
    // Toggle the lock on the control
    control.setDisabled(!isLocked);
}