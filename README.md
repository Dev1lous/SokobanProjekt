<<<<<<< HEAD
# Sokoban

Tento projekt je implementace jednoduché hry v jazyce C# s využitím WPF (Windows Presentation Foundation). Hráè ovládá postavièku v møížce a jeho cílem je umístit všechny boxy na vyznaèená místa.

## Pøehled
Tøída MainWindow dìdí z Window a pøedstavuje hlavní okno aplikace. Obsahuje atributy a metody pro inicializaci a vykreslování herní plochy, pohyb hráèe a kontrolu dokonèení úrovnì.

## Atributy

```cs 
private Border[,] gameMap
```
### Dvourozmìrné pole pro reprezentaci herní mapy.

```cs
 private string[] levelmap
```
### 2D Pole, které pøedstavují aktuální úroveò.

```cs
private int playerRow
```
### Øádek, na kterém se nachází hráè.

  ```cs
  private int playerColumn
  ```
  ### Sloupec, na kterém se nachází hráè.

```cs
private int level
```
### Èíslo aktuálního levelu.

### Konstruktor
```cs
public MainWindow(int level).
```
### Inicializuje hlavní okno a naète danou úroveò
```cs
public MainWindow(int level)
{
    InitializeComponent();
    this.level = level;
    LoadLevel();
}
```
## Metody

### Naèítá úroveò na základì èísla úrovnì (level). Podle èísla úrovnì pøiøazuje hodnotu atributu levelmap a následnì volá metody InitializeGameMap() a DrawLevel(levelmap).
```cs
private void LoadLevel()
```
### Vymaže aktuální herní plochu a znovu naète úroveò.
```cs
private void ResetLevel()
```
### Inicializuje herní mapu jako 10x10 møížku a pøidá ji do hlavního gridu (Maingrid).
```cs
private void InitializeGameMap()
```
###  drawlevel
```cs
private void DrawLevel(string[] level)
```
### Renderuje zdi na zadaných souøadnicích.
```cs
private void DrawWalls(int row, int column)
```
### Renderuje box na zadaných souøadnicích.
```cs
private void DrawBox(int row, int column)
```
### Renderuje destinaci na zadaných souøadnicích.
```cs
private void DrawDestination(int row, int column)
```
### Pohybuje hráèem na nové souøadnice, pokud je to možné. Pokud je na nové pozici box, pokusí se ho posunout. Kontroluje, zda hráè nevyjede mimo herní plochu a zda nenarazí do zdi nebo jiného boxu.
```cs
private void MovePlayer(int newRow, int newColumn)
```
### Kontroluje, zda jsou všechny boxy na destinacích. Pokud ano, zobrazí zprávu o výhøe a zavøe aktuální okno.
```cs
private void CheckDestinations()
```
### Zobrazí dialogové okno pro potvrzení ukonèení úrovnì. Pokud uživatel potvrdí, zavøe aktuální okno a otevøe okno menu.
```cs
private void QuitLevel()
```
### Reaguje na stisk kláves. Pohybuje hráèem podle stisknutých kláves (Up, Down, Left, Right, W, A, S, D). Klávesou R resetuje úroveò a klávesami Escape nebo Q ukonèí úroveò.
```cs
protected override void OnKeyDown(KeyEventArgs e)
```