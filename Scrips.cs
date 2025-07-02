document.getElementById('emailForm').addEventListener('submit', function(e) {
    e.preventDefault();
    
    const emailInput = this.elements.email;
    const messageDiv = document.getElementById('message');
    
    // Reset previous messages
    messageDiv.textContent = '';
    messageDiv.style.color = '';
    
    // Email validation
    if (!emailInput.value || !/^\S+@\S+\.\S+$/.test(emailInput.value)) {
        messageDiv.textContent = 'Please enter a valid email address';
        messageDiv.style.color = '#e74c3c';
        return;
    }
    
    // Form submission
    fetch(this.action, {
        method: 'POST',
        body: new FormData(this),
        headers: {
            'Accept': 'application/json'
        }
    })
    .then(response => {
        if (response.ok) {
            messageDiv.textContent = 'Thank you! You have been added to the list.';
            messageDiv.style.color = '#27ae60';
            this.reset();
        } else {
            throw new Error('Form submission failed');
        }
    })
    .catch(error => {
        messageDiv.textContent = 'Error occurred. Please try again later.';
        messageDiv.style.color = '#e74c3c';
    });
});
