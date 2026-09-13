(function () {
    const STORAGE_KEY = 'lthsBpaOfficerEvents';
    const api = window.lthsCalendarApi;
    const calendar = document.querySelector('.calendar-container');
    if (!calendar) return;

    const today = new Date();
    let visibleDate = new Date(today.getFullYear(), today.getMonth(), 1);
    let events = loadEvents();

    function toInputDate(date) {
        return `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, '0')}-${String(date.getDate()).padStart(2, '0')}`;
    }

    function sampleEvents() {
        const year = today.getFullYear();
        const month = today.getMonth();
        const on = (offset, day) => toInputDate(new Date(year, month + offset, day));
        return [
            { id: 'sample-meeting', title: 'Officer planning meeting', date: on(0, 5), time: '16:15', allDay: false, category: 'meeting', description: 'Set priorities for the month.' },
            { id: 'sample-event', title: 'Chapter kickoff', date: on(0, 12), time: '17:30', allDay: false, category: 'event', description: 'Welcome members and share chapter plans.' },
            { id: 'sample-conference', title: 'Fall leadership conference', date: on(0, 19), time: '', allDay: true, category: 'conference', description: 'Officer leadership development day.' },
            { id: 'sample-deadline', title: 'Registration closes', date: on(0, 26), time: '', allDay: true, category: 'deadline', description: 'Final day to submit conference registration.' }
        ];
    }

    function loadEvents() {
        try {
            const saved = JSON.parse(localStorage.getItem(STORAGE_KEY));
            if (Array.isArray(saved)) return saved;
        } catch (error) { console.warn('Unable to load chapter calendar.', error); }
        const seeded = sampleEvents();
        localStorage.setItem(STORAGE_KEY, JSON.stringify(seeded));
        return seeded;
    }

    function formatTime(event) {
        if (event.allDay || !event.time) return '';
        return new Intl.DateTimeFormat('en-US', { hour: 'numeric', minute: '2-digit' })
            .format(new Date(`2000-01-01T${event.time}:00`));
    }

    function updateUpcomingTicket() {
        const ticketContent = document.querySelector('.ticket-content');
        if (!ticketContent) return;

        const todayString = toInputDate(today);
        const upcoming = events
            .filter(e => e.date >= todayString)
            .sort((a, b) => a.date.localeCompare(b.date) || (a.time || '').localeCompare(b.time || ''));

        if (upcoming.length === 0) {
            ticketContent.innerHTML = `
                <div style="display: flex; gap: 20px; align-items: flex-start;">
                    <div class="event-tbd-badge retro-thick-border">
                        <span class="tbd-label">TBD</span>
                        <strong class="tbd-dash">--</strong>
                    </div>
                    <div class="event-tbd-text">
                        <h4>No upcoming events</h4>
                        <p>Check back after the chapter calendar is updated.</p>
                    </div>
                </div>
            `;
            return;
        }

        ticketContent.innerHTML = upcoming.slice(0, 4).map((event, index) => {
            const [year, month, day] = event.date.split('-');
            const dateObj = new Date(year, month - 1, day);
            const monthLabel = new Intl.DateTimeFormat('en-US', { month: 'short' }).format(dateObj).toUpperCase();
            
            return `
                <div style="display: flex; gap: 20px; align-items: flex-start;">
                    <div class="event-tbd-badge retro-thick-border" style="background-color: var(--secondary); min-width: 60px;">
                        <span class="tbd-label">${monthLabel}</span>
                        <strong class="tbd-dash" style="font-size: 1.8rem; line-height: 1;">${day}</strong>
                    </div>
                    <div class="event-tbd-text">
                        <span style="font-size: 0.75rem; font-weight: 800; color: var(--tertiary); opacity: 0.7; text-transform: uppercase; letter-spacing: 1px;">${index === 0 ? 'Next Event' : 'Upcoming'}</span>
                        <h4 style="margin: 4px 0 8px;">${event.title}</h4>
                        <p style="margin: 0;">${formatTime(event) || 'All Day'}</p>
                    </div>
                </div>
            `;
        }).join('');
    }

    function render() {
        const year = visibleDate.getFullYear();
        const month = visibleDate.getMonth();
        const first = new Date(year, month, 1);
        const start = new Date(year, month, 1 - first.getDay());
        const dayCount = first.getDay() + new Date(year, month + 1, 0).getDate() > 35 ? 42 : 35;
        const monthLabel = new Intl.DateTimeFormat('en-US', { month: 'long', year: 'numeric' }).format(visibleDate);
        const headers = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'].map((day) => `<div class="cal-header">${day}</div>`).join('');
        const cells = Array.from({ length: dayCount }, (_, index) => {
            const date = new Date(start.getFullYear(), start.getMonth(), start.getDate() + index);
            const dateString = toInputDate(date);
            const isOutside = date.getMonth() !== month;
            const dayEvents = events.filter((event) => event.date === dateString).sort((a, b) => (a.time || '').localeCompare(b.time || ''));
            const eventButtons = dayEvents.map((event) => `<button class="member-calendar-event calendar-event--${event.category}" type="button" data-event-id="${event.id}">${formatTime(event) ? `<span>${formatTime(event)}</span>` : ''}${event.title}</button>`).join('');
            return `<div class="cal-cell member-calendar-cell ${isOutside ? 'empty' : ''}"><span class="date">${date.getDate()}</span><div class="member-calendar-events">${eventButtons}</div></div>`;
        }).join('');

        calendar.innerHTML = `<div class="calendar-top-bar"><div class="calendar-title"><span class="cal-subtitle">CHAPTER CALENDAR</span><h3>${monthLabel}</h3></div><div class="calendar-controls"><button id="member-previous-month" class="retro-btn btn-icon" type="button" aria-label="Previous month">‹</button><button id="member-today" class="retro-btn btn-text" type="button">Today</button><button id="member-next-month" class="retro-btn btn-icon" type="button" aria-label="Next month">›</button></div></div><div class="calendar-grid member-calendar-grid">${headers}${cells}</div>`;
        calendar.querySelector('#member-previous-month').addEventListener('click', () => { visibleDate = new Date(year, month - 1, 1); render(); });
        calendar.querySelector('#member-next-month').addEventListener('click', () => { visibleDate = new Date(year, month + 1, 1); render(); });
        calendar.querySelector('#member-today').addEventListener('click', () => { visibleDate = new Date(today.getFullYear(), today.getMonth(), 1); render(); });
        calendar.querySelectorAll('[data-event-id]').forEach((button) => button.addEventListener('click', () => {
            const event = events.find((item) => item.id === button.dataset.eventId);
            if (event) window.showCalendarEventPopover?.(event);
        }));

        updateUpcomingTicket();
    }

    window.addEventListener('storage', (event) => { if (event.key === STORAGE_KEY) render(); });
    render();
    if (api?.enabled) {
        const refresh = async () => {
            try { events = await api.events(); render(); } catch (error) { console.warn('Unable to load shared calendar.', error); }
        };
        refresh();
        window.addEventListener('focus', refresh);
        window.setInterval(refresh, 60000);
    }
})();
