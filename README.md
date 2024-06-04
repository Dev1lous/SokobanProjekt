<<<<<<< HEAD
# Sokoban

Tento projekt je implementace jednoduch� hry v jazyce C# s vyu�it�m WPF (Windows Presentation Foundation). Hr�� ovl�d� postavi�ku v m��ce a jeho c�lem je um�stit v�echny boxy na vyzna�en� m�sta.

## P�ehled
T��da MainWindow d�d� z Window a p�edstavuje hlavn� okno aplikace. Obsahuje atributy a metody pro inicializaci a vykreslov�n� hern� plochy, pohyb hr��e a kontrolu dokon�en� �rovn�.

## Atributy

```cs 
private Border[,] gameMap
```
### Dvourozm�rn� pole pro reprezentaci hern� mapy.

```cs
 private string[] levelmap
```
### 2D Pole, kter� p�edstavuj� aktu�ln� �rove�.

```cs
private int playerRow
```
### ��dek, na kter�m se nach�z� hr��.

  ```cs
  private int playerColumn
  ```
  ### Sloupec, na kter�m se nach�z� hr��.

```cs
private int level
```
### ��slo aktu�ln�ho levelu.

### Konstruktor
```cs
public MainWindow(int level).
```
### Inicializuje hlavn� okno a na�te danou �rove�
```cs
public MainWindow(int level)
{
    InitializeComponent();
    this.level = level;
    LoadLevel();
}
```
## Metody

### Na��t� �rove� na z�klad� ��sla �rovn� (level). Podle ��sla �rovn� p�i�azuje hodnotu atributu levelmap a n�sledn� vol� metody InitializeGameMap() a DrawLevel(levelmap).
```cs
private void LoadLevel()
```
### Vyma�e aktu�ln� hern� plochu a znovu na�te �rove�.
```cs
private void ResetLevel()
```
### Inicializuje hern� mapu jako 10x10 m��ku a p�id� ji do hlavn�ho gridu (Maingrid).
```cs
private void InitializeGameMap()
```
###  drawlevel
```cs
private void DrawLevel(string[] level)
```
### Renderuje zdi na zadan�ch sou�adnic�ch.
```cs
private void DrawWalls(int row, int column)
```
### Renderuje box na zadan�ch sou�adnic�ch.
```cs
private void DrawBox(int row, int column)
```
### Renderuje destinaci na zadan�ch sou�adnic�ch.
```cs
private void DrawDestination(int row, int column)
```
### Pohybuje hr��em na nov� sou�adnice, pokud je to mo�n�. Pokud je na nov� pozici box, pokus� se ho posunout. Kontroluje, zda hr�� nevyjede mimo hern� plochu a zda nenaraz� do zdi nebo jin�ho boxu.
```cs
private void MovePlayer(int newRow, int newColumn)
```
### Kontroluje, zda jsou v�echny boxy na destinac�ch. Pokud ano, zobraz� zpr�vu o v�h�e a zav�e aktu�ln� okno.
```cs
private void CheckDestinations()
```
### Zobraz� dialogov� okno pro potvrzen� ukon�en� �rovn�. Pokud u�ivatel potvrd�, zav�e aktu�ln� okno a otev�e okno menu.
```cs
private void QuitLevel()
```
### Reaguje na stisk kl�ves. Pohybuje hr��em podle stisknut�ch kl�ves (Up, Down, Left, Right, W, A, S, D). Kl�vesou R resetuje �rove� a kl�vesami Escape nebo Q ukon�� �rove�.
```cs
protected override void OnKeyDown(KeyEventArgs e)
```