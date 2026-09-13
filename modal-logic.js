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

    const quizList = document.querySelector(".quiz-list");
    quizList.replaceChildren();
    
    // Remove padding/bullets for the top-level list so accordions sit flush
    quizList.style.listStyle = "none";
    quizList.style.paddingLeft = "0";
    quizList.style.display = "block"; // Override the CSS grid on parent

    if (eventData.practiceTests?.length) {
      const groups = { National: [], State: [], Regional: [], Other: [] };
      eventData.practiceTests.forEach((quiz) => {
        const raw = quiz.name.replace(/\.pdf$/i, "");
        const isMatch = (str, pattern) => (new RegExp(`(?:[_\\s\\-]|^)(${pattern})(?:[_\\s\\-]|$)`, 'i')).test(str);
        
        let level = "Other";
        if (isMatch(raw, 'N|National')) level = "National";
        else if (isMatch(raw, 'S|State')) level = "State";
        else if (isMatch(raw, 'R|Regional')) level = "Regional";

        const yearMatch = raw.match(/(20\d{2})/);
        const year = yearMatch ? yearMatch[1] : "";
        
        let round = "";
        if (raw.match(/prelim/i)) round = "Prelim";
        else if (raw.match(/final/i)) round = "Final";
        
        if (raw.match(/rubric/i)) {
            round = round ? round + " Rubric" : "Rubric";
        }
        
        let displayName = [year, round].filter(Boolean).join(" · ");
        if (!displayName) displayName = raw.slice(0, 50);

        groups[level].push({ quiz, displayName, raw });
      });

      ["National", "State", "Regional", "Other"].forEach(level => {
        if (groups[level].length === 0) return;
        
        const details = document.createElement("details");
        details.style.marginBottom = "8px";
        
        const summary = document.createElement("summary");
        summary.textContent = level;
        summary.style.fontWeight = "600";
        summary.style.cursor = "pointer";
        summary.style.padding = "4px 0";
        details.appendChild(summary);
        
        const ul = document.createElement("ul");
        ul.style.marginTop = "8px";
        ul.style.paddingLeft = "0";
        ul.style.listStyle = "none";
        ul.style.display = "grid";
        ul.style.gridTemplateColumns = "repeat(auto-fill, minmax(280px, 1fr))";
        ul.style.gap = "12px";
        
        groups[level].forEach(item => {
          const link = document.createElement("a");
          link.href = item.quiz.url;
          link.target = "_blank";
          link.rel = "noopener";
          
          link.textContent = item.displayName + " ↗";
          link.title = item.quiz.name;
          
          const li = document.createElement("li");
          li.appendChild(link);
          ul.appendChild(li);
        });
        
        details.appendChild(ul);
        const wrapperLi = document.createElement("li");
        wrapperLi.appendChild(details);
        quizList.appendChild(wrapperLi);
      });
    } else {
      const item = document.createElement("li");
      item.textContent = "No practice tests available yet.";
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
