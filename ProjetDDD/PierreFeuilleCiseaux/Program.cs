﻿using PierreFeuilleCiseaux.Application;
using PierreFeuilleCiseaux.Domain.Entities;
using PierreFeuilleCiseaux.Infrastructure;

Player player = new Player("Toto");

Game game = new Game(player);
GameService gameService = new GameService(game);
ConsoleUI consoleUI = new ConsoleUI(gameService);

consoleUI.StartGame();


