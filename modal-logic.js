(function () {
  const modal = document.getElementById("event-modal");
  if (!modal) return;

  const closeModal = () => {
    modal.style.display = "none";
    modal.setAttribute("aria-hidden", "true");
    document.body.style.overflow = "";
  };

  document.addEventListener("click", (event) => {
    const ticket = event.target.closest(".event-ticket");
    if (!ticket) return;
    event.preventDefault();
    const eventData = window.bpaEvents?.[ticket.dataset.eventId];
    if (!eventData) return;

    document.querySelector(".modal-event-num").textContent = eventData.id;
    document.querySelector(".modal-event-title").textContent = eventData.title;
    document.querySelector(".modal-desc-text").textContent = eventData.description;
    document.querySelector(".btn-wsap").href = eventData.wsapLink;
    document.querySelector(".btn-generator").href = eventData.generatorLink || "#";

    const quizList = document.querySelector(".quiz-list");
    quizList.replaceChildren();
    if (eventData.quizzes?.length) {
      eventData.quizzes.forEach((quiz) => {
        const link = document.createElement("a");
        link.href = quiz.url;
        link.target = "_blank";
        link.rel = "noopener";
        link.textContent = `${quiz.name} ↗`;
        const item = document.createElement("li");
        item.appendChild(link);
        quizList.appendChild(item);
      });
    } else {
      const item = document.createElement("li");
      item.textContent = "No quizzes available yet.";
      quizList.appendChild(item);
    }

    modal.style.display = "flex";
    modal.setAttribute("aria-hidden", "false");
    document.body.style.overflow = "hidden";
  });

  document.querySelector(".modal-close-btn")?.addEventListener("click", closeModal);
  modal.addEventListener("click", (event) => { if (event.target === modal) closeModal(); });
  document.addEventListener("keydown", (event) => { if (event.key === "Escape") closeModal(); });
})();
