let currentPlayer = "X";
const cells = document.querySelectorAll(".cell");
let boardState = "---------"; // Initial board state
let gameId; // Variable globale pour stocker l'ID du jeu
let player1id = 0;
let player2id = 0;
let player1name = "";
let player2name = "";

function updatePlayerTurn(playerName) {
  const playerTurnElement = document.querySelector(".playerTurn");
  playerTurnElement.innerHTML = ""; // Effacer le contenu précédent

  const playerNameElement = document.createElement("strong");
  playerNameElement.style.fontSize = "24px";

  if (playerName === player1name) {
    playerNameElement.textContent = `Au tour de : ${player1name}`;
  } else {
    playerNameElement.textContent = `Au tour de : ${player2name}`;
  }

  playerTurnElement.appendChild(playerNameElement);
}

function startGame() {
  player1name = document.getElementById("player1name").value;
  player2name = document.getElementById("player2name").value;

  if (player1name.trim() === "" || player2name.trim() === "") {
    alert("Veuillez renseigner les noms des joueurs.");
    return;
  }

  const namePLayer1 = {
    id: 0,
    name: player1name,
  };

  const namePLayer2 = {
    id: 0,
    name: player2name,
  };

  // Création du joueur 1
  fetch("http://localhost:5256/api/Players", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(namePLayer1),
  })
    .then((response) => response.json())
    .then((data) => {
      player1id = data.id;
      // Création du joueur 2 après avoir créé le joueur 1
      return fetch("http://localhost:5256/api/Players", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(namePLayer2),
      });
    })
    .then((response) => response.json())
    .then((data) => {
      player2id = data.id;
      // Création du jeu après avoir créé les joueurs
      const gameData = {
        player1id: player1id,
        player2id: player2id,
        boardState: "", // Remplace avec l'état du plateau de jeu
      };
      return fetch("http://localhost:5256/api/games", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(gameData),
      });
    })
    .then((response) => response.json())
    .then((data) => {
      gameId = data.id; // Récupère l'ID du jeu créé
      console.log(data);

      // Cacher la section des joueurs et afficher la grille de jeu
      document.getElementById("players").style.display = "none";
      document.querySelector(".board").style.display = "grid";
    })
    .catch((error) => {
      console.log("False", error);
    });
  const playerTurnElement = document.querySelector(".playerTurn");
  playerTurnElement.innerHTML = ""; // Effacer le contenu précédent

  const playerNameElement = document.createElement("strong");
  playerNameElement.style.fontSize = "24px";
  playerNameElement.textContent = `${
    currentPlayer === "X" ? player1name : player2name
  } tu commences`;
  playerTurnElement.appendChild(playerNameElement);
}

function makeMove(cellIndex) {
  const cell = cells[cellIndex];

  if (!cell.innerHTML) {
    cell.innerHTML = currentPlayer;
    cell.classList.add(currentPlayer);
    boardState =
      boardState.substring(0, cellIndex) +
      currentPlayer +
      boardState.substring(cellIndex + 1);

    if (checkWin()) {
      alert(
        `Player ${currentPlayer === "X" ? player1name : player2name} wins!`
      );
      updateBoardState(
        boardState,
        currentPlayer === "X" ? player1id : player2id
      ); // Appel de la fonction updateBoardState
      resetBoard();
      return;
    }
    currentPlayer = currentPlayer === "X" ? "O" : "X";

    updatePlayerTurn(currentPlayer === "X" ? player1name : player2name);
  }

  if (boardState.indexOf("-") === -1) {
    alert("Match NULL");
    updateBoardState(boardState, -1);
    resetBoard();
  }
}

function checkWin() {
  const winCombinations = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8], // Rows
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8], // Columns
    [0, 4, 8],
    [2, 4, 6], // Diagonals
  ];

  for (let combination of winCombinations) {
    const [a, b, c] = combination;
    if (
      cells[a].innerHTML &&
      cells[a].innerHTML === cells[b].innerHTML &&
      cells[a].innerHTML === cells[c].innerHTML
    ) {
      return true;
    }
  }

  return false;
}

function resetBoard() {
  startGame();
  ShowScore();
  cells.forEach((cell) => {
    cell.innerHTML = "";
    cell.classList.remove("X", "O");
  });
  boardState = "---------";
}

function updateBoardState(boardState, currentPlayer) {
  const gameData = {
    player1id: 1,
    player2id: 2,
    boardState: boardState,
    idPlayerWin: currentPlayer,
  };

  fetch(`http://localhost:5256/api/games/${gameId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(gameData),
  })
    .then((response) => response.json())
    .then((data) => {
      console.log(data);
      // Ajoute ici le code pour effectuer des actions supplémentaires après la mise à jour du boardState
    })
    .catch((error) => {
      console.log("False", error);
    });
}

function updatePlayersList(players) {
  const playersUl = document.getElementById("playersUl");
  playersUl.innerHTML = ""; // Effacer la liste des joueurs précédente

  // Parcourir la liste des joueurs et créer les éléments <li> pour chaque joueur
  players.forEach((player) => {
    if (player.playerName) {
      const playerLi = document.createElement("li");
      playerLi.textContent =
        player.playerName + " => SCORE : " + player.scoreNumber;
      playersUl.appendChild(playerLi);
    }
  });

  // Afficher la section des joueurs
  document.getElementById("playersList").style.display = "block";
}

function ShowScore() {
  fetch("http://localhost:5256/api/Scores", {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  })
    .then((response) => response.json())
    .then((data) => {
      // Mettre à jour la liste des joueurs
      updatePlayersList(data);
    })
    .catch((error) => {
      console.log("Erreur lors de la récupération des joueurs :", error);
    });
}
// Appeler les fonctions pour récupérer les jeux et les joueurs lors du chargement de la page
document.addEventListener("DOMContentLoaded", () => {
  ShowScore();
});
