"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44328/notificationMessageHub").build();
var connection = new signalR.HubConnectionBuilder().withUrl("https://hub.syslinknetwork.com/notificationMessageHub").build();


//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;


connection.on("ReceiveNotificationMessage", function (topic,_DateTime, customerId, customerName, messageCategory, message) {
    // if (topic == "API") {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = topic +" : DateTime "+_DateTime + " :  Customer Id : " + customerId + " Customer Name : " + customerName + " Message Category " + messageCategory + " Message " + message;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
    //}
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendNotificationMessage", "Notification","2021-05-24", "1", "ABC", "Category", "Test").catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});