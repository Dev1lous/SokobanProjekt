# Sokoban

Tento projekt je implementace jednoduché hry v jazyce C# s využitím WPF (Windows Presentation Foundation). Hráč ovládá postavičku v mřížce a jeho cílem je umístit všechny boxy na vyznačená místa.

## Přehled
Třída MainWindow dědí z Window a představuje hlavní okno aplikace. Obsahuje atributy a metody pro inicializaci a vykreslování herní plochy, pohyb hráče a kontrolu dokončení úrovně.

## Atribuce Grafiky
Tento projekt používá několik grafických prvků, které jsou zdarma k použití, s patřičnou atribucí. Následující grafické prvky jsou kredity příslušným zdrojům:

#### Grafika Destinace:    
#### Grafika Boxu:
    Zdroj: 2D Wooden Box
    Webová stránka: OpenGameArt

#### Grafika Zdi:
    Zdroj: Painted Stone Wall Texture
    Webová stránka: Itch.io (autor Guardian5)


## Atributy kódu

#### Dvourozměrné pole pro reprezentaci herní mapy.
```cs 
private Border[,] gameMap
```

#### Pole, které představuje aktuální level.
```cs
 private string[] levelmap
```
#### Řádek, na kterém se nachází hráč.

```cs
private int playerRow
```
 ### Sloupec, na kterém se nachází hráč.
  ```cs
  private int playerColumn
  ```
  ### Číslo aktuálního levelu.

```cs
private int level
```

### Konstruktor
```cs
public MainWindow(int level).
```
### Inicializuje hlavní okno a načte danou úroveň
```cs
public MainWindow(int level)
{
    InitializeComponent();
    this.level = level;
    LoadLevel();
}
```
## Metody

### Načítá úroveň na základě čísla úrovně (level). Podle čísla úrovně přiřazuje hodnotu atributu levelmap a následně volá metody InitializeGameMap() a DrawLevel(levelmap).
```cs
private void LoadLevel()
```
### Vymaže aktuální herní plochu a znovu načte úroveň.
```cs
private void ResetLevel()
```
### Inicializuje herní mapu jako 10x10 mřížku a přidá ji do hlavního gridu (Maingrid).
```cs
private void InitializeGameMap()
```
###  Vytváří level podle symbolů které jsou v atributu levelmap | // P - HRÁČ ||| # - ZEĎ ||| B - BOX ||| $ - DESTINACE 
```cs
private void DrawLevel(string[] level)
```
### Renderuje zdi na zadaných souřadnicích.
```cs
private void DrawWalls(int row, int column)
```
### Renderuje box na zadaných souřadnicích.
```cs
private void DrawBox(int row, int column)
```
### Renderuje destinaci na zadaných souřadnicích.
```cs
private void DrawDestination(int row, int column)
```
### Pohybuje hráčem na nové souřadnice, pokud je to možné. 
### Pokud je na nové pozici box, pokusí se ho posunout. Kontroluje, zda hráč nevyjede mimo herní plochu a zda nenarazí do zdi nebo jiného boxu.
```cs
private void MovePlayer(int newRow, int newColumn)
```
### Kontroluje, zda jsou všechny boxy na destinacích. Pokud ano, zobrazí zprávu o výhře a zavře aktuální okno.
```cs
private void CheckDestinations()
```
### Zobrazí dialogové okno pro potvrzení ukončení úrovně. Pokud uživatel potvrdí, zavře aktuální okno a otevře okno menu.
```cs
private void QuitLevel()
```
### Reaguje na stisk kláves. Pohybuje hráčem podle stisknutých kláves (Up, Down, Left, Right, W, A, S, D). Klávesou R resetuje úroveň a klávesami Escape nebo Q ukončí úroveň.
```cs
protected override void OnKeyDown(KeyEventArgs e)
```
