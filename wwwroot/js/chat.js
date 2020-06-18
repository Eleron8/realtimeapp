function chat() {
  if (typeof signalR === "undefined" || typeof axios === "undefined") {
    console.error("Libs are not loaded", "SignalR", signalR, "axios", axios);
    return;
  }

  let connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

  let _connectionId = '';

  connection.on("ReceiveMessage", function (data){
      console.log(data);
  });

  connection.start().then(function(){
      connection.invoke('getConnectionId').then(function(connectionId){
          _connectionId = connectionId
          // debugger;
          joinRoom();
      })
  })
  .catch(function(err){
      console.log(err);
  });

  let joinRoom = function() {
      const URL = '/Chat/JoinRoom/' + _connectionId + '/@Model.Name'
      axios.post(URL, null).then(res => {
          console.log("Joined in room", res);
      })
      .catch(err => {
          console.error("Failed to join in room", err);
      })
  }

  // connection.start().then(function(){
  //     connection.invoke('getConnectionId').then(function(connectionId){
  //         _connectionId = connectionId
  //         joinRoom();
  //     })
  // })
  // .catch(function(err){
  //     console.log(err);
  // })
}

document.addEventListener("DOMContentLoaded", chat);
