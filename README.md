Dokumentace projektu „Projektusamogus“
Pøehled
Tento projekt je implementace jednoduché hry v jazyce C# s využitím WPF (Windows Presentation Foundation). Hráè ovládá postavièku v møížce a jeho cílem je umístit všechny boxy na vyznaèená místa.

Struktura tøídy MainWindow
Tøída MainWindow dìdí z Window a pøedstavuje hlavní okno aplikace. Obsahuje následující atributy a metody:

Atributy
private Border[,] gameMap: Dvourozmìrné pole pro reprezentaci herní mapy.
private string[] levelmap: Pole øetìzcù, které pøedstavují aktuální úroveò.
private int playerRow: Øádek, na kterém se nachází hráè.
private int playerColumn: Sloupec, na kterém se nachází hráè.
private int level: Èíslo aktuální úrovnì.
Konstruktor
public MainWindow(int level): Inicializuje hlavní okno a naète danou úroveò.
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
Naèítá úroveò na základì èísla úrovnì (level). Podle èísla úrovnì pøiøazuje hodnotu atributu levelmap a následnì volá metody InitializeGameMap() a DrawLevel(levelmap).

private void ResetLevel()
Vymaže aktuální herní plochu a znovu naète úroveò.

private void InitializeGameMap()
Inicializuje herní mapu jako 10x10 møížku a pøidá ji do hlavního gridu (Maingrid).

private void DrawLevel(string[] level)
Kreslí aktuální úroveò na základì hodnot v levelmap. Každý znak v mapì reprezentuje jiný herní prvek:

'P': Hráè
'#': Zeï
'$': Destinace
'B': Box
private void DrawPlayer()
Kreslí hráèe na aktuální pozici (playerRow, playerColumn).

private void DrawWalls(int row, int column)
Kreslí zdi na zadaných souøadnicích.

private void DrawBox(int row, int column)
Kreslí box na zadaných souøadnicích.

private void DrawDestination(int row, int column)
Kreslí destinaci na zadaných souøadnicích.

private void CheckDestinations()
Kontroluje, zda jsou všechny boxy na destinacích. Pokud ano, zobrazí zprávu o výhøe a zavøe aktuální okno.

private void MovePlayer(int newRow, int newColumn)
Pohybuje hráèem na nové souøadnice, pokud je to možné. Pokud je na nové pozici box, pokusí se ho posunout. Kontroluje, zda hráè nevyjede mimo herní plochu a zda nenarazí do zdi nebo jiného boxu.

private void QuitLevel()
Zobrazí dialogové okno pro potvrzení ukonèení úrovnì. Pokud uživatel potvrdí, zavøe aktuální okno a otevøe okno menu.

protected override void OnKeyDown(KeyEventArgs e)
Reaguje na stisk kláves. Pohybuje hráèem podle stisknutých kláves (Up, Down, Left, Right, W, A, S, D). Klávesou R resetuje úroveò a klávesami Escape nebo Q ukonèí úroveò.