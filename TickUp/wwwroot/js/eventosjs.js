const value = document.getElementById('value');
const plusButton = document.getElementById('plus');
const minusButton = document.getElementById('minus');
const precoElement = document.getElementById('preco');

const updateValue = () => {
    value.innerHTML = count;
    precoElement.innerHTML = (count * precoBase).toFixed(2)
}

let precoBase = parseFloat(precoElement.innerHTML);;
let count = 1;
let intervalId = 0;


plusButton.addEventListener('mousedown', () => {
    intervalId = setInterval(() => {
        count += 1;
        updateValue();
    }, 100);
})

minusButton.addEventListener('mousedown', () => {
    intervalId = setInterval(() => {
        //count -= 1;
        if (value.innerHTML > 1) {
            count = count !== 0 ? --count : 0;
        }

        updateValue();
    }, 100);
})


document.addEventListener('mouseup', () => clearInterval(intervalId));




 



/*buttonIncrement.addEventListener('click', () => {
    value = value++;
    count.value = value;
});

buttonDecrement.addEventListener('click', () => {
    value = value !== 0 ? --value : 0
    counter.value = value;
}); */