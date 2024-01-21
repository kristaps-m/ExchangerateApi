const currencyOptions = ["EUR", "GBP", "USD", "AUD", "CAD", "HKD", "NZD"];

function convert() {
    const amount = document.getElementById('amount').value;
    const fromCurrency = document.getElementById('fromValue').value;
    const toCurrency = document.getElementById('toValue').value;

    const apiUrl = `https://localhost:7000/api/Exchangerates/exchange?cFrom=${fromCurrency}&cTo=${toCurrency}&amount=${amount}`;

    // Display "Loading..." while fetching data
    displayLoading();

    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            displayResult(data);
        })
        .catch(error => {
            console.error('Error fetching data:', error);
        });
}

function swapit(){
	var fromValue=document.getElementById("fromValue");
	var toValue=document.getElementById("toValue");
	var temp;
	temp=fromValue.value;
	fromValue.value=toValue.value;
	toValue.value=temp;
}

function displayResult(data) {
    const resultElement = document.getElementById('result');
    const exchangeRateElement = document.getElementById('exchange-rate');
    const amountElement = document.getElementById('amount').value;
    const amountResult = document.getElementById('amountResult');
    const fromValue = document.getElementById("fromValue").value;
    const toValue = document.getElementById("toValue").value;

    if (data.result === 'success') {
        amountResult.textContent = `${amountElement} ${fromValue} =`;
        resultElement.textContent = `${data.conversion_result} ${toValue}`;
        exchangeRateElement.textContent = `1 ${fromValue} = ${data.conversion_rate} ${toValue}`;
    } else {
        resultElement.textContent = 'Conversion failed. Please try again.';
        exchangeRateElement.textContent = '';
    }
}

function displayLoading() {
    const resultElement = document.getElementById('result');
    const exchangeRateElement = document.getElementById('exchange-rate');

    resultElement.innerHTML = '<p class="loading">Loading...</p>';
    exchangeRateElement.textContent = '';
}

