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
=======
# Sokoban

Tento projekt je implementace jednoduché hry v jazyce C# s využitím WPF (Windows Presentation Foundation). Hráč ovládá postavičku v mřížce a jeho cílem je umístit všechny boxy na vyznačená místa.

## Přehled
Třída MainWindow dědí z Window a představuje hlavní okno aplikace. Obsahuje atributy a metody pro inicializaci a vykreslování herní plochy, pohyb hráče a kontrolu dokončení úrovně.

### Atributy
- private Border[,] gameMap: Dvourozměrné pole pro reprezentaci herní mapy.
- private string[] levelmap: 2D Pole, které představují aktuální úroveň.
- private int playerRow: Řádek, na kterém se nachází hráč.
- private int playerColumn: Sloupec, na kterém se nachází hráč.
- private int level: Číslo aktuálního levelu.
###Konstruktor
- public MainWindow(int level): Inicializuje hlavní okno a načte danou úroveň.

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
>>>>>>> db7ef7cfe766162b18d5fc0b1efa1bcbbf435d43
