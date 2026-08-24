(function() {
    console.log("Modal logic initialized.");
    const modal = document.getElementById("event-modal");
    if (!modal) return;
    
    const closeBtn = document.querySelector(".modal-close-btn");
    
    // Modal fields
    const modalNum = document.querySelector(".modal-event-num");
    const modalTitle = document.querySelector(".modal-event-title");
    const modalDesc = document.querySelector(".modal-desc-text");
    const modalWsapBtn = document.querySelector(".btn-wsap");
    const modalQuizList = document.querySelector(".quiz-list");
    const modalGenBtn = document.querySelector(".btn-generator");

    // Add click listeners to all tickets
    document.querySelectorAll(".event-ticket").forEach(ticket => {
        ticket.addEventListener("click", (e) => {
            e.preventDefault();
            
            // Extract the event ID from the stub
            const eventIdElement = ticket.querySelector(".ticket-serial, .stub-number, .stub-number-small");
            if (!eventIdElement) {
                console.warn("Could not find event ID for ticket:", ticket);
                return;
            }
            
            const eventId = eventIdElement.textContent.trim();
            const eventData = window.bpaEvents ? window.bpaEvents[eventId] : null;

            if (eventData) {
                // Populate modal
                modalNum.textContent = eventData.id;
                modalTitle.textContent = eventData.title;
                modalDesc.textContent = eventData.description || "Description coming soon.";
                
                modalWsapBtn.href = eventData.wsapLink || "#";
                modalGenBtn.href = eventData.generatorLink || "#";

                // Populate quizzes
                modalQuizList.innerHTML = "";
                if (eventData.quizzes && eventData.quizzes.length > 0) {
                    eventData.quizzes.forEach(quiz => {
                        const li = document.createElement("li");
                        const a = document.createElement("a");
                        a.href = quiz.url;
                        a.textContent = quiz.name + " ↗";
                        a.target = "_blank";
                        li.appendChild(a);
                        modalQuizList.appendChild(li);
                    });
                } else {
                    modalQuizList.innerHTML = "<li><span style='padding: 12px 16px; display: block; color: var(--tertiary); font-weight: bold;'>No quizzes available yet.</span></li>";
                }
            } else {
                console.warn("No data found for event ID:", eventId);
                // Fallback for missing data
                modalNum.textContent = eventId;
                const titleEl = ticket.querySelector(".ticket-content h3");
                modalTitle.textContent = titleEl ? titleEl.textContent : "Event Title";
                modalDesc.textContent = "Detailed information for this event has not been added yet.";
                modalWsapBtn.href = "#";
                modalGenBtn.href = "#";
                modalQuizList.innerHTML = "<li><span style='padding: 12px 16px; display: block; color: var(--tertiary); font-weight: bold;'>No quizzes available yet.</span></li>";
            }
            
            // Show modal
            modal.style.display = "flex";
            document.body.style.overflow = "hidden"; // Prevent scrolling behind modal
        });
    });

    // Close modal logic
    const closeModal = () => {
        modal.style.display = "none";
        document.body.style.overflow = "auto"; // Restore scrolling
    };

    if (closeBtn) {
        closeBtn.addEventListener("click", closeModal);
    }
    
    // Close on clicking outside the modal content
    modal.addEventListener("click", (e) => {
        if (e.target === modal) {
            closeModal();
        }
    });
    
    // Close on escape key
    document.addEventListener("keydown", (e) => {
        if (e.key === "Escape" && modal.style.display === "flex") {
            closeModal();
        }
    });
})();
