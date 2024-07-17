window.addMouseEvents = function (dotNetHelper) {
    let isResizing = false;

    document.addEventListener('mousedown', function (e) {
        if (e.target.closest('th')) {
            isResizing = true;
        }
    });

    document.addEventListener('mousemove', function (e) {
        if (isResizing) {
            dotNetHelper.invokeMethodAsync('OnMouseMoveJS', {
                clientX: e.clientX
            });
        }
    });

    document.addEventListener('mouseup', function (e) {
        if (isResizing) {
            dotNetHelper.invokeMethodAsync('OnMouseUpJS', {
                clientX: e.clientX
            });
            isResizing = false;
        }
    });
};