"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44328/emailHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveEmailMessage", function (Topic, CustomerName, SendTo, Subject, Body) {
   // if (topic == "API") {
        //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg = Topic + " : " + CustomerName + " Send To " + SendTo+ " Subject "+Subject+" Body "+Body;
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
    connection.invoke("SendEmail", "Email", user,"Send To","Subject", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});