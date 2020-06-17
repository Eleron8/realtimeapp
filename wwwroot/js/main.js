function modal() {
  const modalTrigger = document.querySelector("button.room__link--btn");
  const modalWrapper = document.querySelector(".modal");

  modalTrigger.onclick = () => {
    const closeBtn = modalWrapper.querySelector(".btn--close");
    modalWrapper.classList.add("show");
    closeBtn.onclick = () => {
      modalWrapper.classList.remove("show");
    };
  };
}

function init() {
  modal();
}

document.addEventListener("DOMContentLoaded", init);
