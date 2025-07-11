var connection = new signalR.HubConnectionBuilder()
	.withUrl("https://localhost:7295/SignalRHub")
	.build();
document.getElementById("sendmessage").disabled = true;
connection.on("ReceiveMessage", function (user, message) {
	var currentTime = new Date();
    var formattedTime = currentTime.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
	var li = document.createElement("li");
	var span = document.createElement("span");
	span.style.fontWeight = "bold";
	span.textContent = user;
	li.appendChild(span);
	li.innerHTML += `:${message} | ${currentTime}`
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
	document.getElementById("sendmessage").disabled = false;
}).catch(function (err) {
	return console.error(err.toString());
});

document.getElementById("sendmessage").addEventListener("click", function (event) {
	var user = document.getElementById("userinput").value;
	var message = document.getElementById("messageinput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
});
