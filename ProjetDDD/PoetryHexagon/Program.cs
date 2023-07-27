using PoetryHexagon.Interfaces;
using PoetryHexagon;
using PoetryHexagon.Controller;
using PoetryHexagon.Adapters;

IObtainPoems poemRepository = new PoemMemoryRepository();
IWriteLines consoleWriter = new ConsoleWriter();

IWritePoem writePoemUseCase = new WritePoemUseCase(poemRepository, consoleWriter);

PoemController poemController = new PoemController(writePoemUseCase);

poemController.Execute();

Console.ReadLine();