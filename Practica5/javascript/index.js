let secretNumber = generateRandomNumber();
let score = 100;
let highscore = 0;
let gameOver = false;

function generateRandomNumber() {
    return Math.floor(Math.random() * 100) + 1;
}

function checkGuess() {

    const guessInput = document.getElementById('guess');
    const message = document.getElementById('message');
    const scoreDisplay = document.getElementById('score');
    const highscoreDisplay = document.getElementById('highscore');
    const secretNumberDisplay = document.querySelector('.container-secret-number p');
    const secretNumberContainer = document.querySelector('.container-number');

    const guess = parseInt(guessInput.value);

    if (gameOver) {
        return; 
    } 

    if (isNaN(guess) || guess < 1 || guess > 100) {
        message.textContent = 'Ingresa un número válido entre 1 y 100.';
    } else if (guess === secretNumber) {
        message.textContent = `¡Correcto! El número era ${secretNumber}. ¡Ganaste!`;
        secretNumberDisplay.textContent = secretNumber;
        secretNumberContainer.style.backgroundColor = 'green';
        if (score > highscore) {
            highscore = score;
            highscoreDisplay.textContent = highscore;
        }
        gameOver = true;
    } else {
        if (guess < secretNumber) {
            message.textContent = 'Demasiado bajo. Intenta de nuevo.';
        } else {
            message.textContent = 'Demasiado alto. Intenta de nuevo.';
        }
        score -= 10;
        scoreDisplay.textContent = score;

        if (score === 0) {
            message.textContent = `¡Perdiste! El número era ${secretNumber}.`;
            secretNumberDisplay.textContent = secretNumber;
            secretNumberContainer.style.backgroundColor = 'red';
            gameOver = true;
        }
    }
    guessInput.value = '';
}

function resetGame() {
    secretNumber = generateRandomNumber();
    score = 100;
    document.getElementById('score').textContent = score;
    document.getElementById('message').textContent = '';
    document.querySelector('.container-secret-number p').textContent = '¿?';
}