function chat() {
  if (typeof signalR === "undefined" || typeof axios === "undefined") {
    console.error("Libs are not loaded", "SignalR", signalR, "axios", axios);
    return;
  }

  const conntection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

  let connectionId = null;

  conntection.on("RecieveMessage", function (data) {
    console.log("RecieveMessage", data);
  });

  const joinRomm = function () {
    const URL = `/Chat/JoinRoom/${connectionId}/@Model.Name`;

    axios
      .post(URL, null)
      .then((res) => {
          console.log('Joined to room')
      })
      .catch((e) => {
        console.error(e);
      });
  };
}

document.addEventListener("DOMContentLoaded", chat);
