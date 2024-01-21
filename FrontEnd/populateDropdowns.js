
// Function to populate the dropdowns with options
function populateDropdowns() {
    const fromSelect = document.getElementById('fromValue');
    const toSelect = document.getElementById('toValue');

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