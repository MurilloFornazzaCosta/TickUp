document.addEventListener('DOMContentLoaded', function () {
    const minusButton = document.getElementById('minus');
    const plusButton = document.getElementById('plus');
    const valueDisplay = document.getElementById('value');
    const quantidadeIngressoInput = document.getElementById('quantidadeIngresso');
    const valor = document.getElementById('preco');

    let currentValue = 1;
    let precoBase = parseFloat(valor.innerHTML);

    function updateDisplay() {
        valueDisplay.textContent = currentValue;
        quantidadeIngressoInput.value = currentValue;
        valor.innerHTML = (currentValue * precoBase).toFixed(2);
    }

    minusButton.addEventListener('click', function () {
        if (currentValue > 1) {
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