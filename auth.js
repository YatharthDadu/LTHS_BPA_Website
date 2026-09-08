(function () {
    const TEST_USERNAME = 'officer';
    const TEST_PASSWORD = 'BPA2026';
    const SESSION_KEY = 'lthsBpaOfficerSession';
    const loginForm = document.getElementById('login-form');
    const api = window.lthsCalendarApi;

    if (!loginForm) return;

    const usernameInput = document.getElementById('username');
    const passwordInput = document.getElementById('password');
    const message = document.getElementById('login-message');

    if (api?.enabled) document.querySelector('.testing-access')?.remove();

    loginForm.addEventListener('submit', async function (event) {
        event.preventDefault();
        const username = usernameInput.value.trim().toLowerCase();
        const password = passwordInput.value;

        if (api?.enabled) {
            try {
                await api.login(username, password);
                window.location.assign('dashboard.html');
            } catch (error) {
                message.textContent = error.message;
                passwordInput.value = '';
                passwordInput.focus();
            }
            return;
        }

        if (username === TEST_USERNAME && password === TEST_PASSWORD) {
            sessionStorage.setItem(SESSION_KEY, JSON.stringify({ username: TEST_USERNAME }));
            window.location.assign('dashboard.html');
            return;
        }

        message.textContent = 'That username or password does not match the testing access shown below.';
        passwordInput.value = '';
        passwordInput.focus();
    });
})();
