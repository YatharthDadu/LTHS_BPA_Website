(function () {
    const baseUrl = (window.LTHS_CALENDAR_API_URL || '').replace(/\/$/, '');
    const localKey = 'lthsBpaOfficerEvents';
    const tokenKey = 'lthsBpaOfficerToken';

    async function request(path, options) {
        const response = await fetch(`${baseUrl}${path}`, {
            credentials: 'include',
            headers: { 'Content-Type': 'application/json', ...(sessionStorage.getItem(tokenKey) ? { Authorization: `Bearer ${sessionStorage.getItem(tokenKey)}` } : {}), ...(options?.headers || {}) },
            ...options
        });
        if (!response.ok) {
            const body = await response.json().catch(() => ({}));
            throw new Error(body.error || 'The calendar service could not complete that request.');
        }
        return response.status === 204 ? null : response.json();
    }

    window.lthsCalendarApi = {
        enabled: Boolean(baseUrl),
        async events() { return request('/api/events'); },
        async session() { return request('/api/session'); },
        async login(username, password) { const result = await request('/api/login', { method: 'POST', body: JSON.stringify({ username, password }) }); sessionStorage.setItem(tokenKey, result.token); return result; },
        async logout() { sessionStorage.removeItem(tokenKey); return request('/api/logout', { method: 'POST' }); },
        async createEvent(event) { return request('/api/events', { method: 'POST', body: JSON.stringify(event) }); },
        localEvents() {
            try { const events = JSON.parse(localStorage.getItem(localKey)); return Array.isArray(events) ? events : null; } catch (_) { return null; }
        },
        saveLocalEvents(events) { localStorage.setItem(localKey, JSON.stringify(events)); }
    };
})();
