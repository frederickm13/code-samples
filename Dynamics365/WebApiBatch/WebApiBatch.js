/*
 * Please note, this sample code is provided to the community as-is, and for learning/demonstration purposes only.  
 * This code is not certified for production use without further review and testing by your organization.
*/

/////////////////////////
// Build request object
/////////////////////////

function BatchPostAccounts() {
    this.apiUrl = Xrm.Utility.getGlobalContext().getClientUrl() + "/api/data/v9.1/";
    this.uniqueId = "batch_" + (new Date().getTime());
    this.batchItemHeader = "--" + this.uniqueId + "\nContent-Type: application/http\nContent-Transfer-Encoding:binary";
    this.content = [];
}

BatchPostAccounts.prototype.addRequestItem = function(entity) {
    this.content.push(this.batchItemHeader);
    this.content.push("");
    this.content.push("POST " + this.apiUrl + "accounts" + " HTTP/1.1");
    this.content.push("Content-Type: application/json;type=entry");
    this.content.push("");
    this.content.push(JSON.stringify(entity));
}

BatchPostAccounts.prototype.sendRequest = function() {
    this.content.push("");
    this.content.push("--" + this.uniqueId + "--");
    this.content.push(" ");

    var xhr = new XMLHttpRequest();
    xhr.open("POST", encodeURI(this.apiUrl + "$batch"));
    xhr.setRequestHeader("Content-Type", "multipart/mixed;boundary=" + this.uniqueId);
    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("OData-MaxVersion", "4.0");
    xhr.setRequestHeader("OData-Version", "4.0");
    xhr.addEventListener("load", function() { console.log("Batch request response code: " + xhr.status); });

    xhr.send(this.content.join("\n"));
}



/////////////////////////
// Create entity objects
/////////////////////////

var firstAccount = {
    name: "Test Account 1"
}

var secondAccount = {
    name: "Test Account 2"
}

var thirdAccount = {
    name: "Test Account 3"
}



/////////////////////////
// Send batch request
/////////////////////////

var batchRequest = new BatchPostAccounts();
batchRequest.addRequestItem(firstAccount);
batchRequest.addRequestItem(secondAccount);
batchRequest.addRequestItem(thirdAccount);
batchRequest.sendRequest();