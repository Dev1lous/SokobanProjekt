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
=======
# Sokoban

Tento projekt je implementace jednoduchÃ© hry v jazyce C# s vyuÅ¾itÃ­m WPF (Windows Presentation Foundation). HrÃ¡Ä ovlÃ¡dÃ¡ postaviÄku v mÅ™Ã­Å¾ce a jeho cÃ­lem je umÃ­stit vÅ¡echny boxy na vyznaÄenÃ¡ mÃ­sta.

## PÅ™ehled
TÅ™Ã­da MainWindow dÄ›dÃ­ z Window a pÅ™edstavuje hlavnÃ­ okno aplikace. Obsahuje atributy a metody pro inicializaci a vykreslovÃ¡nÃ­ hernÃ­ plochy, pohyb hrÃ¡Äe a kontrolu dokonÄenÃ­ ÃºrovnÄ›.

### Atributy
- private Border[,] gameMap: DvourozmÄ›rnÃ© pole pro reprezentaci hernÃ­ mapy.
- private string[] levelmap: 2D Pole, kterÃ© pÅ™edstavujÃ­ aktuÃ¡lnÃ­ ÃºroveÅˆ.
- private int playerRow: Å˜Ã¡dek, na kterÃ©m se nachÃ¡zÃ­ hrÃ¡Ä.
- private int playerColumn: Sloupec, na kterÃ©m se nachÃ¡zÃ­ hrÃ¡Ä.
- private int level: ÄŒÃ­slo aktuÃ¡lnÃ­ho levelu.
###Konstruktor
- public MainWindow(int level): Inicializuje hlavnÃ­ okno a naÄte danou ÃºroveÅˆ.

public MainWindow(int level)
{
    InitializeComponent();
    this.level = level;
    LoadLevel();
}
Metody
private void LoadLevel()
NaÄÃ­tÃ¡ ÃºroveÅˆ na zÃ¡kladÄ› ÄÃ­sla ÃºrovnÄ› (level). Podle ÄÃ­sla ÃºrovnÄ› pÅ™iÅ™azuje hodnotu atributu levelmap a nÃ¡slednÄ› volÃ¡ metody InitializeGameMap() a DrawLevel(levelmap).

private void ResetLevel()
VymaÅ¾e aktuÃ¡lnÃ­ hernÃ­ plochu a znovu naÄte ÃºroveÅˆ.

private void InitializeGameMap()
Inicializuje hernÃ­ mapu jako 10x10 mÅ™Ã­Å¾ku a pÅ™idÃ¡ ji do hlavnÃ­ho gridu (Maingrid).

private void DrawLevel(string[] level)
KreslÃ­ aktuÃ¡lnÃ­ ÃºroveÅˆ na zÃ¡kladÄ› hodnot v levelmap. KaÅ¾dÃ½ znak v mapÄ› reprezentuje jinÃ½ hernÃ­ prvek:

'P': HrÃ¡Ä
'#': ZeÄ
'$': Destinace
'B': Box
private void DrawPlayer()
KreslÃ­ hrÃ¡Äe na aktuÃ¡lnÃ­ pozici (playerRow, playerColumn).

private void DrawWalls(int row, int column)
KreslÃ­ zdi na zadanÃ½ch souÅ™adnicÃ­ch.

private void DrawBox(int row, int column)
KreslÃ­ box na zadanÃ½ch souÅ™adnicÃ­ch.

private void DrawDestination(int row, int column)
KreslÃ­ destinaci na zadanÃ½ch souÅ™adnicÃ­ch.

private void CheckDestinations()
Kontroluje, zda jsou vÅ¡echny boxy na destinacÃ­ch. Pokud ano, zobrazÃ­ zprÃ¡vu o vÃ½hÅ™e a zavÅ™e aktuÃ¡lnÃ­ okno.

private void MovePlayer(int newRow, int newColumn)
Pohybuje hrÃ¡Äem na novÃ© souÅ™adnice, pokud je to moÅ¾nÃ©. Pokud je na novÃ© pozici box, pokusÃ­ se ho posunout. Kontroluje, zda hrÃ¡Ä nevyjede mimo hernÃ­ plochu a zda nenarazÃ­ do zdi nebo jinÃ©ho boxu.

private void QuitLevel()
ZobrazÃ­ dialogovÃ© okno pro potvrzenÃ­ ukonÄenÃ­ ÃºrovnÄ›. Pokud uÅ¾ivatel potvrdÃ­, zavÅ™e aktuÃ¡lnÃ­ okno a otevÅ™e okno menu.

protected override void OnKeyDown(KeyEventArgs e)
Reaguje na stisk klÃ¡ves. Pohybuje hrÃ¡Äem podle stisknutÃ½ch klÃ¡ves (Up, Down, Left, Right, W, A, S, D). KlÃ¡vesou R resetuje ÃºroveÅˆ a klÃ¡vesami Escape nebo Q ukonÄÃ­ ÃºroveÅˆ.
>>>>>>> db7ef7cfe766162b18d5fc0b1efa1bcbbf435d43
