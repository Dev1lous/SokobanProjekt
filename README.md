### Projektusamogus
Tento projekt je implementace jednoduché hry v jazyce C# s využitím WPF (Windows Presentation Foundation). Hráč ovládá postavičku v mřížce a jeho cílem je umístit všechny boxy na vyznačená místa.

Přehled
Třída MainWindow dědí z Window a představuje hlavní okno aplikace. Obsahuje atributy a metody pro inicializaci a vykreslování herní plochy, pohyb hráče a kontrolu dokončení úrovně.

Atributy
private Border[,] gameMap: Dvourozměrné pole pro reprezentaci herní mapy.
private string[] levelmap: Pole řetězců, které představují aktuální úroveň.
private int playerRow: Řádek, na kterém se nachází hráč.
private int playerColumn: Sloupec, na kterém se nachází hráč.
private int level: Číslo aktuální úrovně.
Konstruktor
public MainWindow(int level)
Inicializuje hlavní okno a načte danou úroveň.

csharp
Zkopírovat kód
public MainWindow(int level)
{
    InitializeComponent();
    this.level = level;
    LoadLevel();
}
Metody
private void LoadLevel()
Načítá úroveň na základě čísla úrovně (level). Podle čísla úrovně přiřazuje hodnotu atributu levelmap a následně volá metody InitializeGameMap() a DrawLevel(levelmap).

private void ResetLevel()
Vymaže aktuální herní plochu a znovu načte úroveň.

private void InitializeGameMap()
Inicializuje herní mapu jako 10x10 mřížku a přidá ji do hlavního gridu (Maingrid).

private void DrawLevel(string[] level)
Kreslí aktuální úroveň na základě hodnot v levelmap. Každý znak v mapě reprezentuje jiný herní prvek:

'P': Hráč
'#': Zeď
'$': Destinace
'B': Box
private void DrawPlayer()
Kreslí hráče na aktuální pozici (playerRow, playerColumn).

private void DrawWalls(int row, int column)
Kreslí zdi na zadaných souřadnicích.

private void DrawBox(int row, int column)
Kreslí box na zadaných souřadnicích.

private void DrawDestination(int row, int column)
Kreslí destinaci na zadaných souřadnicích.

private void CheckDestinations()
Kontroluje, zda jsou všechny boxy na destinacích. Pokud ano, zobrazí zprávu o výhře a zavře aktuální okno.

private void MovePlayer(int newRow, int newColumn)
Pohybuje hráčem na nové souřadnice, pokud je to možné. Pokud je na nové pozici box, pokusí se ho posunout. Kontroluje, zda hráč nevyjede mimo herní plochu a zda nenarazí do zdi nebo jiného boxu.

private void QuitLevel()
Zobrazí dialogové okno pro potvrzení ukončení úrovně. Pokud uživatel potvrdí, zavře aktuální okno a otevře okno menu.

protected override void OnKeyDown(KeyEventArgs e)
Reaguje na stisk kláves. Pohybuje hráčem podle stisknutých kláves (Up, Down, Left, Right, W, A, S, D). Klávesou R resetuje úroveň a klávesami Escape nebo Q ukončí úroveň.
