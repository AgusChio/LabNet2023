let secretNumber;
let score;
let highscore;
let gameOver = false;
let timer;
let timeLeft = 60;

function generateRandomNumber() {
    return Math.floor(Math.random() * 100) + 1;
}

function updateTimerDisplay() {
    const timerDisplay = document.getElementById('timer');
    timerDisplay.textContent = timeLeft;
}

function disableInput() {
    document.getElementById('guess').disabled = true;
    document.querySelector('.guess-button').disabled = true;
}

function enableInput() {
    document.getElementById('guess').disabled = false;
    document.querySelector('.guess-button').disabled = false;
}

function startTimer() {
    updateTimerDisplay();
    timer = setInterval(() => {
        timeLeft--;

        if (timeLeft < 0) {
            timeLeft = 0;
        }

        updateTimerDisplay();

        if (timeLeft === 0) {
            clearInterval(timer);

            if (!gameOver) {
                gameOver = true;
                disableInput();
                const message = document.getElementById('message');
                const secretNumberDisplay = document.querySelector('.container-secret-number p');
                const secretNumberContainer = document.querySelector('.container-number');

                message.textContent = `¡Tiempo agotado! El número era ${secretNumber}.`;
                secretNumberDisplay.textContent = secretNumber;
                secretNumberContainer.style.backgroundColor = 'red';
            }
        }
    }, 1000);
}

function resetTimer() {
    clearInterval(timer);
    timeLeft = 60;
    updateTimerDisplay();
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
        disableInput();
        document.querySelector('.timer-container').style.display = 'none';
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
            disableInput();
            document.querySelector('.timer-container').style.display = 'none';
        }
    }
    guessInput.value = '';
}

function resetGame() {
    secretNumber = generateRandomNumber();
    score = 100;
    gameOver = false;
    document.getElementById('score').textContent = score;
    document.getElementById('message').textContent = '';
    document.querySelector('.container-secret-number p').textContent = '¿?';
    document.querySelector('.container-number').style.backgroundColor = '#111318';
    enableInput();
}

function newGame() {
    clearInterval(timer);
    secretNumber = generateRandomNumber();
    gameOver = false;
    document.getElementById('message').textContent = '';
    document.querySelector('.container-secret-number p').textContent = '¿?';
    document.querySelector('.container-number').style.backgroundColor = '#111318';
    document.querySelector('.timer-container').style.display = 'block';
    enableInput();
    resetTimer();
    startTimer();
}
    function startGame() {
        document.getElementById('rules-section').style.display = 'none';
        document.getElementById('game-section').style.display = 'block';
    
        secretNumber = generateRandomNumber();
        score = 100;
        highscore = 0;
        gameOver = false;
        newGame();
    }
