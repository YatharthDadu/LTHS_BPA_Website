(function () {
    const categoryNames = { meeting: 'Meeting', event: 'Event', conference: 'Conference', deadline: 'Deadline' };

    function formatTime(event) {
        if (event.allDay) return 'All day';
        if (!event.time) return 'Time not set';
        return new Intl.DateTimeFormat('en-US', { hour: 'numeric', minute: '2-digit' })
            .format(new Date(`2000-01-01T${event.time}:00`));
    }

    function formatDate(date) {
        return new Intl.DateTimeFormat('en-US', { weekday: 'short', month: 'short', day: 'numeric' })
            .format(new Date(`${date}T12:00:00`));
    }

    window.showCalendarEventPopover = function (event) {
        document.querySelector('.calendar-event-popover')?.remove();
        const popover = document.createElement('section');
        popover.className = `calendar-event-popover calendar-event-popover--${event.category}`;
        popover.setAttribute('role', 'dialog');
        popover.setAttribute('aria-label', `${event.title} details`);

        const duration = event.duration ? ` · ${event.duration} min` : '';
        popover.innerHTML = '<button type="button" class="calendar-popover-close" aria-label="Close event details">×</button><span class="calendar-popover-category"></span><h2></h2><p class="calendar-popover-meta"></p><p class="calendar-popover-description"></p>';
        popover.querySelector('.calendar-popover-category').textContent = categoryNames[event.category] || 'Calendar item';
        popover.querySelector('h2').textContent = event.title;
        popover.querySelector('.calendar-popover-meta').textContent = `${formatDate(event.date)} · ${formatTime(event)}${duration}`;
        const description = popover.querySelector('.calendar-popover-description');
        description.textContent = event.description || 'No additional details.';
        popover.querySelector('.calendar-popover-close').addEventListener('click', function () { popover.remove(); });
        document.body.appendChild(popover);
    };
})();
