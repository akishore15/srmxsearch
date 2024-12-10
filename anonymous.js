document.getElementById('searchForm').addEventListener('submit', function(event) {
    event.preventDefault();
    const query = document.getElementById('query').value;
    fetchResults(query);
});

function fetchResults(query) {
    fetch(`/search?q=${encodeURIComponent(query)}`)
        .then(response => response.json())
        .then(data => {
            const filteredResults = data.filter(result => !result.startsWith('http://') && !result.startsWith('http://www'));
            displayResults(filteredResults);
        })
        .catch(error => {
            console.error('Error fetching search results:', error);
        });
}

function displayResults(results) {
    const resultsDiv = document.getElementById('results');
    resultsDiv.innerHTML = '';
    results.forEach(result => {
        const resultItem = document.createElement('div');
        resultItem.textContent = result;
        resultsDiv.appendChild(resultItem);
    });
}
