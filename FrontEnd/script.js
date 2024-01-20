const currencyOptions = ["EUR", "GBP", "USD", "AUD", "CAD", "HKD", "NZD"];

function convert() {
    const amount = document.getElementById('amount').value;
    const fromCurrency = document.getElementById('fromValue').value;
    const toCurrency = document.getElementById('toValue').value;

    const apiUrl = `https://localhost:7137/api/Exchangerates/exchange?cFrom=${fromCurrency}&cTo=${toCurrency}&amount=${amount}`;

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

// Function to populate the dropdowns with options
function populateDropdowns() {
    const fromSelect = document.getElementById('fromValue');
    const toSelect = document.getElementById('toValue');

    // Clear existing options
    fromSelect.innerHTML = '';
    toSelect.innerHTML = '';

    // Add options to the dropdowns
    currencyOptions.forEach(currency => {
        const option = document.createElement('option');
        option.value = currency;
        option.textContent = currency;

        fromSelect.appendChild(option);
        toSelect.appendChild(option.cloneNode(true));
    });
}

// Run the populateDropdowns function when the page loads
window.onload = populateDropdowns;
