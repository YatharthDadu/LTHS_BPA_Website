(function () {
  const guidebookPath = "guidelines/2026-2027";
  const categories = [
    ["finance", "Financial Services", ["100", "110", "125", "145", "150", "155", "160", "165", "190"]],
    ["business", "Management and Entrepreneurship", ["200", "205", "210", "215", "220", "225", "230", "235", "240", "245", "250", "290", "291", "292", "293"]],
    ["mis", "Digital Technology", ["300", "305", "310", "315", "320", "325", "330", "335", "340", "345", "350", "355", "360", "365", "390", "391"]],
    ["digital", "Arts, Entertainment and Design", ["400", "405", "410", "420", "425", "430", "440", "445", "450", "455", "460", "490"]],
    ["management", "Marketing and Sales", ["500", "505", "510", "590"]],
    ["health", "Healthcare and Human Services", ["600", "605", "610", "615", "690"]],
    ["career", "Career Ready Skills", ["700", "705", "710", "715", "720", "725", "730", "735", "740", "745", "750", "755", "760", "790"]],
    ["virtual", "Virtual Events", ["V01", "V02", "V03", "V04", "V05", "V06", "V07", "V08", "V09", "V10", "V11", "V12", "V13", "V14", "V15", "V16"]]
  ];

  Object.values(window.bpaEvents).forEach((event) => {
    event.wsapLink = `${guidebookPath}/${event.id}.pdf`;
  });

  const catalog = document.getElementById("competition-catalog");
  const colors = ["bg-gold", "bg-slate", "bg-light"];
  categories.forEach(([id, heading, ids], categoryIndex) => {
    const section = document.createElement("section");
    section.id = id;
    section.className = "category-section" + (categoryIndex ? "" : " active");
    section.hidden = Boolean(categoryIndex);
    const title = document.createElement("h2");
    title.className = "category-title";
    title.textContent = heading;
    const grid = document.createElement("div");
    grid.className = "events-grid";
    ids.forEach((eventId, index) => {
      const event = window.bpaEvents[eventId];
      if (!event) return;
      const ticket = document.createElement("a");
      ticket.href = "#event-details";
      ticket.className = `event-ticket ${colors[index % colors.length]}`;
      ticket.dataset.eventId = event.id;
      ticket.innerHTML = '<div class="ticket-stub"><span class="ticket-serial"></span><span class="ticket-zig-zag"></span></div><div class="ticket-main"><div class="ticket-content"><h3></h3><p></p></div><div class="ticket-footer"><span class="guidelines-pill">WSAP Guidelines</span></div></div>';
      ticket.querySelector(".ticket-serial").textContent = event.id;
      ticket.querySelector("h3").textContent = event.title;
      ticket.querySelector("p").textContent = event.description;
      grid.appendChild(ticket);
    });
    section.append(title, grid);
    catalog.appendChild(section);
  });

  document.querySelectorAll(".switch-tab").forEach((tab) => tab.addEventListener("click", (event) => {
    event.preventDefault();
    const target = tab.getAttribute("href").slice(1);
    document.querySelectorAll(".switch-tab").forEach((item) => item.classList.toggle("active", item === tab));
    document.querySelectorAll(".category-section").forEach((section) => {
      const active = section.id === target;
      section.hidden = !active;
      section.classList.toggle("active", active);
    });
  }));
})();
