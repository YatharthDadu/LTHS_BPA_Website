(function () {
    const SESSION_KEY = 'lthsBpaOfficerSession';
    const STORAGE_KEY = 'lthsBpaOfficerEvents';
    const categoryNames = {
        meeting: 'Meeting',
        event: 'Event',
        conference: 'Conference',
        deadline: 'Deadline'
    };
    const calendarGrid = document.getElementById('calendar-grid');
    const monthLabel = document.getElementById('calendar-month');
    const selectedDateLabel = document.getElementById('selected-date-label');
    const eventForm = document.getElementById('event-form');
    const dateInput = document.getElementById('event-date');
    const timeInput = document.getElementById('event-time');
    const durationInput = document.getElementById('event-duration');
    const allDayInput = document.getElementById('event-all-day');
    const timeField = document.getElementById('time-field');
    const durationField = document.getElementById('duration-field');
    const formMessage = document.getElementById('form-message');
    const api = window.lthsCalendarApi;

    if (!api?.enabled && !sessionStorage.getItem(SESSION_KEY)) {
        window.location.replace('login.html');
        return;
    }

    const today = new Date();
    let visibleDate = new Date(today.getFullYear(), today.getMonth(), 1);
    let selectedDate = toInputDate(today);
    let events = loadEvents();

    function toInputDate(date) {
        const year = date.getFullYear();
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const day = String(date.getDate()).padStart(2, '0');
        return `${year}-${month}-${day}`;
    }

    function createSampleEvents() {
        const year = today.getFullYear();
        const month = today.getMonth();
        const dateFor = function (monthOffset, day) {
            return toInputDate(new Date(year, month + monthOffset, day));
        };

        return [
            { id: 'sample-meeting', title: 'Officer planning meeting', date: dateFor(0, 5), time: '16:15', allDay: false, category: 'meeting', description: 'Set priorities for the month.' },
            { id: 'sample-event', title: 'Chapter kickoff', date: dateFor(0, 12), time: '17:30', allDay: false, category: 'event', description: 'Welcome members and share chapter plans.' },
            { id: 'sample-conference', title: 'Fall leadership conference', date: dateFor(0, 19), time: '', allDay: true, category: 'conference', description: 'Officer leadership development day.' },
            { id: 'sample-deadline', title: 'Registration closes', date: dateFor(0, 26), time: '', allDay: true, category: 'deadline', description: 'Final day to submit conference registration.' }
        ];
    }

    function loadEvents() {
        try {
            const savedEvents = JSON.parse(localStorage.getItem(STORAGE_KEY));
            if (Array.isArray(savedEvents)) return savedEvents;
        } catch (error) {
            console.warn('Unable to load saved calendar events.', error);
        }

        const sampleEvents = createSampleEvents();
        localStorage.setItem(STORAGE_KEY, JSON.stringify(sampleEvents));
        return sampleEvents;
    }

    function saveEvents() {
        localStorage.setItem(STORAGE_KEY, JSON.stringify(events));
    }

    async function refreshRemoteEvents() {
        if (!api?.enabled) return;
        events = await api.events();
        renderCalendar();
    }

    function formatLongDate(dateString) {
        const date = new Date(`${dateString}T12:00:00`);
        return new Intl.DateTimeFormat('en-US', { weekday: 'long', month: 'long', day: 'numeric' }).format(date);
    }

    function formatTime(event) {
        if (event.allDay) return 'All day';
        if (!event.time) return 'No time set';
        const date = new Date(`2000-01-01T${event.time}:00`);
        return new Intl.DateTimeFormat('en-US', { hour: 'numeric', minute: '2-digit' }).format(date);
    }

    function eventsForDate(dateString) {
        return events
            .filter(function (event) { return event.date === dateString; })
            .sort(function (first, second) {
                if (first.allDay !== second.allDay) return first.allDay ? -1 : 1;
                return (first.time || '').localeCompare(second.time || '');
            });
    }

    function renderCalendar() {
        const year = visibleDate.getFullYear();
        const month = visibleDate.getMonth();
        const firstDay = new Date(year, month, 1);
        const startDate = new Date(year, month, 1 - firstDay.getDay());
        const daysInMonth = new Date(year, month + 1, 0).getDate();
        const totalCells = firstDay.getDay() + daysInMonth > 35 ? 42 : 35;
        const dayNames = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
        const monthText = new Intl.DateTimeFormat('en-US', { month: 'long', year: 'numeric' }).format(visibleDate);

        monthLabel.textContent = monthText;
        selectedDateLabel.textContent = `Selected: ${formatLongDate(selectedDate)}`;
        dateInput.value = selectedDate;

        const headers = dayNames.map(function (day) {
            return `<div class="officer-cal-header" role="columnheader">${day}</div>`;
        }).join('');

        const dayCells = Array.from({ length: totalCells }, function (_, index) {
            const cellDate = new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDate() + index);
            const cellDateString = toInputDate(cellDate);
            const inCurrentMonth = cellDate.getMonth() === month;
            const isToday = cellDateString === toInputDate(today);
            const isSelected = cellDateString === selectedDate;
            const cellEvents = eventsForDate(cellDateString);
            const classes = ['officer-calendar-day'];
            if (!inCurrentMonth) classes.push('outside-month');
            if (isToday) classes.push('today');
            if (isSelected) classes.push('selected-day');

            const eventMarkup = cellEvents.map(function (event) {
                const time = event.allDay || !event.time ? '' : `<span>${formatTime(event)}</span>`;
                return `<button type="button" class="calendar-event calendar-event--${event.category}" data-event-id="${event.id}" aria-label="${categoryNames[event.category]}: ${event.title}, ${formatTime(event)}">${time}${event.title}</button>`;
            }).join('');

            return `<div class="${classes.join(' ')}" role="gridcell" aria-selected="${isSelected}" data-date="${cellDateString}">
                <button type="button" class="calendar-date-button" data-date="${cellDateString}" aria-label="${formatLongDate(cellDateString)}">${cellDate.getDate()}</button>
                <div class="calendar-events">${eventMarkup}</div>
            </div>`;
        }).join('');

        calendarGrid.innerHTML = headers + dayCells;
    }

    function selectDate(dateString) {
        selectedDate = dateString;
        const selected = new Date(`${dateString}T12:00:00`);
        visibleDate = new Date(selected.getFullYear(), selected.getMonth(), 1);
        formMessage.textContent = '';
        renderCalendar();
    }

    function updateTimeField() {
        const isAllDay = allDayInput.checked;
        timeInput.disabled = isAllDay;
        durationInput.disabled = isAllDay;
        timeField.classList.toggle('field-disabled', isAllDay);
        durationField.classList.toggle('field-disabled', isAllDay);
        if (isAllDay) {
            timeInput.value = '';
            durationInput.value = '';
        }
    }

    document.getElementById('previous-month').addEventListener('click', function () {
        visibleDate = new Date(visibleDate.getFullYear(), visibleDate.getMonth() - 1, 1);
        renderCalendar();
    });

    document.getElementById('next-month').addEventListener('click', function () {
        visibleDate = new Date(visibleDate.getFullYear(), visibleDate.getMonth() + 1, 1);
        renderCalendar();
    });

    document.getElementById('today-button').addEventListener('click', function () {
        selectDate(toInputDate(today));
    });

    document.getElementById('sign-out').addEventListener('click', async function () {
        if (api?.enabled) await api.logout();
        sessionStorage.removeItem(SESSION_KEY);
        window.location.assign('login.html');
    });

    let editingEventId = null;
    const saveEventButton = document.getElementById('save-event-button');
    const deleteEventButton = document.getElementById('delete-event-button');
    const cancelEditButton = document.getElementById('cancel-edit-button');

    function editEvent(selectedEvent) {
        editingEventId = selectedEvent.id;
        document.getElementById('event-title').value = selectedEvent.title;
        document.getElementById('event-category').value = selectedEvent.category;
        dateInput.value = selectedEvent.date;
        allDayInput.checked = selectedEvent.allDay;
        timeInput.value = selectedEvent.time || '';
        durationInput.value = selectedEvent.duration || '';
        document.getElementById('event-description').value = selectedEvent.description || '';
        updateTimeField();

        saveEventButton.textContent = 'Update event';
        deleteEventButton.style.display = 'block';
        cancelEditButton.style.display = 'block';
        formMessage.textContent = 'Editing event...';
    }

    function cancelEdit() {
        editingEventId = null;
        eventForm.reset();
        allDayInput.checked = false;
        updateTimeField();
        saveEventButton.textContent = 'Add to calendar';
        deleteEventButton.style.display = 'none';
        cancelEditButton.style.display = 'none';
        formMessage.textContent = '';
    }

    cancelEditButton.addEventListener('click', cancelEdit);

    deleteEventButton.addEventListener('click', async function () {
        if (!editingEventId) return;
        if (!confirm('Are you sure you want to delete this event?')) return;

        try {
            if (api?.enabled) {
                await api.deleteEvent(editingEventId);
                events = await api.events();
            } else {
                events = events.filter(e => e.id !== editingEventId);
                saveEvents();
            }
        } catch (error) {
            formMessage.textContent = error.message;
            return;
        }

        formMessage.textContent = 'Event deleted.';
        cancelEdit();
        renderCalendar();
    });

    calendarGrid.addEventListener('click', function (event) {
        const eventButton = event.target.closest('[data-event-id]');
        if (eventButton) {
            const selectedEvent = events.find(function (item) { return item.id === eventButton.dataset.eventId; });
            if (selectedEvent) {
                editEvent(selectedEvent);
            }
            return;
        }
        const dayCell = event.target.closest('.officer-calendar-day[data-date]');
        if (dayCell) selectDate(dayCell.dataset.date);
    });

    allDayInput.addEventListener('change', updateTimeField);

    dateInput.addEventListener('change', function () {
        if (dateInput.value) selectDate(dateInput.value);
    });

    eventForm.addEventListener('submit', async function (event) {
        event.preventDefault();
        const formData = new FormData(eventForm);
        const title = formData.get('title').trim();
        const date = formData.get('date');

        if (!title || !date) {
            formMessage.textContent = 'Add a title and date before saving the event.';
            return;
        }

        const newEvent = {
            id: editingEventId || `event-${Date.now()}`,
            title: title,
            date: date,
            time: allDayInput.checked ? '' : formData.get('time'),
            duration: allDayInput.checked ? null : Number(formData.get('duration')) || null,
            allDay: allDayInput.checked,
            category: formData.get('category'),
            description: formData.get('description').trim()
        };

        try {
            if (api?.enabled) {
                if (editingEventId) {
                    await api.updateEvent(editingEventId, newEvent);
                } else {
                    await api.createEvent(newEvent);
                }
                events = await api.events();
            } else {
                if (editingEventId) {
                    const index = events.findIndex(e => e.id === editingEventId);
                    if (index !== -1) events[index] = newEvent;
                } else {
                    events.push(newEvent);
                }
                saveEvents();
            }
        } catch (error) {
            formMessage.textContent = error.message;
            return;
        }
        
        const actionText = editingEventId ? 'updated' : 'added';
        cancelEdit();
        selectedDate = date;
        const selected = new Date(`${date}T12:00:00`);
        visibleDate = new Date(selected.getFullYear(), selected.getMonth(), 1);
        formMessage.textContent = `${categoryNames[newEvent.category]} ${actionText} for ${formatLongDate(date)}.`;
        renderCalendar();
        document.getElementById('event-title').focus();
    });

    updateTimeField();
    renderCalendar();
    if (api?.enabled) {
        api.session().then(function (session) {
            if (!session.authenticated) window.location.replace('login.html');
            else refreshRemoteEvents().catch(function () { formMessage.textContent = 'The shared calendar could not be loaded.'; });
        }).catch(function () { window.location.replace('login.html'); });
    }
})();
