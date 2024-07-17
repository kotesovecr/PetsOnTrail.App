window.initializeNumpad = (dotNetHelper) => {
    document.querySelectorAll('input.simple-datetime').forEach(input => {
        input.addEventListener('focus', () => {
            const rect = input.getBoundingClientRect();
            const numpadOverlay = document.querySelector('.numpad-overlay');
            numpadOverlay.style.display = 'block';
            numpadOverlay.style.top = `${rect.bottom}px`;
            numpadOverlay.style.left = '0';
            numpadOverlay.style.right = '0';

            dotNetHelper.invokeMethodAsync('ShowNumpad', input.id);
        });
    });
};

window.updateInputValue = (inputId, value) => {
    const input = document.getElementById(inputId);
    if (input) {
        input.value = value;
        const event = new Event('input', { bubbles: true });
        input.dispatchEvent(event);
    }
};

window.submitInputValue = (inputId) => {
    const input = document.getElementById(inputId);
    if (input) {
        var event = new Event('change');
        input.dispatchEvent(event);
    }
}

window.hideNumpad = () => {
    document.querySelector('.numpad-overlay').style.display = 'none';
};