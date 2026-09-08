(function () {
  const guidebookPath = "guidelines/2025-2026";
  const removed = ["105", "115", "135", "530", "593"];
  const categories = [
    ["finance", "Finance", ["100", "110", "125", "145", "150", "155", "160", "165", "190"]],
    ["business", "Business Administration", ["200", "205", "210", "215", "220", "225", "230", "235", "240", "245", "255", "260", "265", "290"]],
    ["mis", "Management Information Systems", ["300", "305", "310", "315", "320", "325", "330", "335", "340", "345", "350", "355", "390", "391"]],
    ["digital", "Digital Communication and Design", ["400", "405", "410", "415", "420", "425", "430", "435", "440", "445", "450", "455", "460", "490"]],
    ["management", "Management, Marketing and Communication", ["500", "505", "510", "515", "520", "525", "535", "540", "545", "550", "555", "560", "590", "591", "592", "594"]],
    ["health", "Health Administration", ["600", "605", "610", "615", "690"]],
    ["virtual", "Virtual Events", ["V01", "V02", "V03", "V04", "V05", "V06", "V07", "V08", "V09", "V10", "V11", "V12", "V13", "V14", "V15"]]
  ];
  const titleUpdates = {
    V01: "VIRTUAL MULTIMEDIA AND PROMOTION INDIVIDUAL", V02: "VIRTUAL MULTIMEDIA AND PROMOTION TEAM",
    V07: "CYBERSECURITY/DIGITAL FORENSICS", V14: "ETHICAL LEADERSHIP & DECISION-MAKING TEAM", V15: "VIRTUAL INTERVIEW & DIGITAL PORTFOLIO DESIGN",
    190: "FINANCIAL MATH AND ANALYSIS CONCEPTS - OPEN EVENT", 290: "ADMINISTRATIVE SUPPORT CONCEPTS - OPEN EVENT",
    390: "COMPUTER PROGRAMMING CONCEPTS - OPEN EVENT", 391: "INFORMATION TECHNOLOGY CONCEPTS - OPEN EVENT",
    490: "DIGITAL COMMUNICATION AND DESIGN CONCEPTS - OPEN EVENT", 590: "MEETING AND EVENT PLANNING CONCEPTS - OPEN EVENT",
    591: "MANAGEMENT, MARKETING AND HUMAN RESOURCES CONCEPTS - OPEN EVENT", 592: "PARLIAMENTARY PROCEDURE CONCEPTS - OPEN EVENT",
    594: "DIGITAL MARKETING CONCEPTS - OPEN EVENT", 690: "HEALTH ADMINISTRATION CONCEPTS - OPEN EVENT"
  };
  const competencyHighlights = {
    V01: "story development, video production, and digital editing", V02: "collaborative production, story development, and digital editing",
    V03: "software design, programming, and technical presentation", V04: "database design, server-side development, and web application design",
    V05: "mobile application development, interface design, and technical presentation", V06: "camera operation, composition, and image editing",
    V07: "security principles, forensic investigation, and incident response", V08: "business planning, organizational structure, and persuasive presentation",
    V09: "investment analysis, portfolio strategy, and financial decision-making", V10: "brand strategy, digital design, and multimedia communication",
    V11: "animation principles, storyboarding, and digital production", V12: "social media strategy, audience targeting, and campaign development",
    V13: "competitive strategy, teamwork, and esports industry knowledge", V14: "ethical analysis, leadership, and evidence-based decision-making",
    V15: "job-search strategy, portfolio development, and virtual interviewing",
    100: "the accounting cycle, journal entries, and financial statements", 110: "partnership and corporate accounting, financial analysis, and reporting",
    125: "payroll calculation, payroll records, and tax compliance", 145: "banking operations, financial services, and consumer finance",
    150: "financial analysis, problem-solving, and business recommendations", 155: "economic research, written analysis, and oral presentation",
    160: "team research, economic analysis, and formal presentation", 165: "budgeting, investing, and risk management",
    190: "business mathematics, consumer calculations, and financial problem-solving",
    200: "document formatting, keyboarding, and word-processing tools", 205: "advanced document production, editing, and formatting",
    210: "complex document design, mail merge, and word-processing features", 215: "application integration, data transfer, and document production",
    220: "office procedures, records management, and business documents", 225: "advanced office procedures, file management, and document production",
    230: "spreadsheet formulas, data organization, and report formatting", 235: "advanced spreadsheet functions, data analysis, and business solutions",
    240: "database objects, data analysis, and reporting", 245: "legal terminology, legal documents, and law-office procedures",
    255: "team coordination, information management, and business-document production", 260: "research methods, formal writing, and oral presentation",
    265: "business ethics, legal principles, and case analysis", 290: "office procedures, records management, and document production",
    300: "network architecture, protocols, and network security", 305: "device configuration, maintenance, and troubleshooting",
    310: "Windows server administration, network maintenance, and system management", 315: "Cisco networking, network management, and routing concepts",
    320: "security management, Windows and Linux networking, and risk mitigation", 325: "network planning, infrastructure design, and strategic analysis",
    330: "C# syntax, program development, and object-oriented design", 335: "C++ programming, algorithms, and object-oriented methodology",
    340: "Java programming, algorithms, and object-oriented methodology", 345: "database development, SQL scripting, and data management",
    350: "Linux system configuration, scripting, and troubleshooting", 355: "Python programming, program design, and functional concepts",
    390: "programming concepts, logic, and software development", 391: "information technology concepts, hardware, and software systems",
    400: "desktop publishing tools, document design, and layout", 405: "Adobe publishing tools, visual design, and document production",
    410: "promotional design, visual communication, and illustration", 415: "HTML and CSS, web-design principles, and coding syntax",
    420: "digital storytelling, media production, and editing", 425: "3D research, prototyping, and model design",
    430: "video planning, production, and editing", 435: "website planning, design, and development",
    440: "3D animation, storytelling, and digital production", 445: "broadcast planning, news writing, and video production",
    450: "research, audio production, and podcast storytelling", 455: "user experience design, prototyping, and design rationale",
    460: "brand identity, visual communication, and design strategy", 490: "web design, animation, and digital media production",
    500: "marketing strategy, pricing, and promotional planning", 505: "business planning, entrepreneurship, and organizational structure",
    510: "strategic planning, case analysis, and business problem-solving", 515: "job-search preparation, interviewing, and professional communication",
    520: "portfolio development, advanced interviewing, and job-search strategy", 525: "speech organization, oral presentation, and impromptu analysis",
    535: "personnel policies, human-resources practices, and policy interpretation", 540: "ethical frameworks, professional judgment, and business decision-making",
    545: "speech writing, audience engagement, and oral presentation", 550: "parliamentary procedure, meeting management, and leadership",
    555: "multimedia design, presentation delivery, and audience communication", 560: "team presentation, multimedia design, and audience communication",
    590: "meeting management, event planning, and business logistics", 591: "management, marketing, and human-resources principles",
    592: "parliamentary procedure, meeting rules, and formal motions", 594: "digital marketing, online strategy, and audience engagement",
    600: "ICD-10-CM, CPT, and medical terminology", 605: "insurance verification, claims processing, and medical billing",
    610: "medical terminology, document preparation, and office procedures", 615: "health research, multimedia presentation, and oral communication",
    690: "medical terminology, body systems, and health-administration concepts"
  };
  const conciseDescription = (description) => {
    const result = description.split(/(?<=\.)\s+/)
      .filter((sentence) => !/^This (virtual )?event (challenges|is designed|evaluates)|^Competitors will (showcase|demonstrate|apply)|^Participants will showcase|fully online competitive environment/i.test(sentence))
      .map((sentence) => sentence.replace(/^(Participants|Contestants) will /, "").replace(/^Teams of contestants will /, "Teams will "))
      .join(" ");
    return result ? result[0].toUpperCase() + result.slice(1) : "Event details are available in the guidebook.";
  };

  removed.forEach((id) => delete window.bpaEvents[id]);
  Object.values(window.bpaEvents).forEach((event) => {
    event.title = titleUpdates[event.id] || event.title;
    event.description = `${conciseDescription(event.description)} Core competencies assessed include, but are not limited to, ${competencyHighlights[event.id]}.`;
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
