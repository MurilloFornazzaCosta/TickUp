document.addEventListener('DOMContentLoaded', function () {
    const minusButton = document.getElementById('minus');
    const plusButton = document.getElementById('plus');
    const valueDisplay = document.getElementById('value');
    const quantidadeIngressoInput = document.getElementById('quantidadeIngresso');

    let currentValue = 0;

    function updateDisplay() {
        valueDisplay.textContent = currentValue;
        quantidadeIngressoInput.value = currentValue;
    }

    minusButton.addEventListener('click', function () {
        if (currentValue > 0) {
            currentValue--;
            updateDisplay();
        }
    });

    plusButton.addEventListener('click', function () {
        currentValue++;
        updateDisplay();
    });

    // Initialize input value
    updateDisplay();
});