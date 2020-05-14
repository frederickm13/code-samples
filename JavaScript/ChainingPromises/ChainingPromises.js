/***************************/
// Using the .then() method
/***************************/

// In this example, 'prom' is a Promise object
prom.then(function (successResult) {
    // Execute some code if the promise succeeds
}, function (errorResult) {
    // Execute some code if the promise fails
});


/***************************/
// Using the .catch() method
/***************************/

// In this example, 'prom' is a Promise object
prom.catch(function (errorResult) {
    // Execute some code if the promise fails
});


/***************************/
// Chaining promises using the .then() and .catch() methods
/***************************/

// In this example, 'prom' is a Promise object
prom.then(function (successResult) {
    if (successResult) {
        return true;
    } else {
        return false;
    }
}).then(function (tfVal) {
    // This function will build a message string using the value
    // returned from the previous Promise
    let message = "The previous Promise returned: " + tfVal;
    return message;
}).then(function(msg) {
    // This function will log the message returned from the 
    // previous Promise to the console
    console.log(msg);
   
    // It is good practice to always return a value from a Promise
    return true;
}).catch(function (e) {
    // One .catch() function at the end of the chain will handle 
    // any previously uncaught failures within the chain
    console.log("An error occurred somewhere in the Promise pipeline: " + e.message);
});