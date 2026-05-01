let num1 = document.querySelector('.number1');
let num2 = document.querySelector('.number2');
const result = document.querySelector('.result-input');

const plus = document.querySelector('.plus');
const minus = document.querySelector('.minus');
const multiply = document.querySelector('.mult');
const divide = document.querySelector('.divide');


function GetInputValues() {
    if (num1.value == '' || num2.value == '') {
        alert('Number 1 and Number 2 cannot be empty');
        Reset();
        return false;
    }
    return true;
}

function Reset() {
    num1.value = '';
    num2.value = '';
}


plus.addEventListener('click', () => {
    if (!GetInputValues()) return;

    result.value = Number(num1.value) + Number(num2.value);
    Reset();
});

minus.addEventListener('click', () => {
    if (!GetInputValues()) return;

    result.value = Number(num1.value) - Number(num2.value);
    Reset();
})

multiply.addEventListener('click', () => {
    if (!GetInputValues()) return;

    result.value = Number(num1.value) * Number(num2.value)
    Reset();
});

divide.addEventListener('click', () => {
    if (!GetInputValues()) return;

    if (Number(num2.value) == 0) {
        alert('Cannot divide 0 \nPlease enter a non-zero value for Number 2');
        Reset();
        return;
    }

    result.value = Number(num1.value) / Number(num2.value);
    Reset();

});
