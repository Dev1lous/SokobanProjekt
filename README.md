# Sokoban

## Přehled

Hra je strukturována ve třídě `MainWindow`. Hra spočívá v logickém řešení hádanek posouváním boxů na určené destinace.

## Atribuce grafiky
Následující grafické prvky byly použity v projektu:

### Grafika zdi:

  - Zdroj: [Painted Stone Wall Texture](https://guardian5.itch.io/painted-stone-wall-texture?download)
  - Autor: Guardian5

### Grafika boxu:

  - Zdroj: [2D Wooden Box](https://opengameart.org/content/2d-wooden-box)
  - Autor: Gaurav Kumar (gdaksh)

## Atribuce zvuku
Následující muzika byla použita v projektu:

### Muzika při hraní

  - Zdroj: [Pixabay](https://pixabay.com/sound-effects/026491-pixel-song-8-72675/)
  - Autor: Pixabay
  
## Třídy a Metody

### Třída `StartWindow`
Startovní okno aplikace, které slouží k uvítání uživatele. Obsahuje tlačítko, které uživatele přesměruje na menu okno.
.
### Třída `MenuWindow`

Menu okno, ve kterém si uživatel vybírá level. Po výběru úrovně dojde k přesměrování na hlavní okno aplikace `MainWindow`.

### Třída `MainWindow`

Hlavní třída aplikace, `MainWindow`, spravuje stav hry, inicializuje herní mřížku, zpracovává uživatelský vstup a definuje logiku pro načítání a resetování úrovní. Klíčové metody zahrnují:

Atributy třídy MainWindow
  - `private Border[,] gameMap`
      - Dvourozměrné pole reprezentující herní mřížku, kde každý prvek je instance třídy Border.

  - `private string[] levelmap`
    - Pole kde reprezentuji mapu ve stringu.

  - `private int playerRow`
    - Pozice hráče na řádku v herní mřížce.

  - `private int playerColumn`
    - Pozice hráče ve sloupci v herní mřížce.

  - `private int level`
    - Aktuální úroveň hry.
## Metody a konstruktor
- **Konstruktor: `MainWindow(int level)`**
  - Inicializuje herní okno a načte specifikovanou úroveň.

```cs
public MainWindow(int level)
{
    InitializeComponent();
    this.level = level;
    LoadLevel();
}
```

- **Metoda LoadLevel()**
    - Načítá úroveň na základě hodnoty level a volá metody pro inicializaci herní mřížky a vykreslení úrovně.

```cs
private void LoadLevel()
{
    switch (this.level)
    {
        case 1:
            levelmap = new string[]
            {
                "##########",
                "##########",
                "###$######",
                "###....$.#",
                "##..###B.#",
                "##P$.....#",
                "#####....#",
                "#####.BB.#",
                "#####..###",
                "##########"
            };
            InitializeGameMap();
            DrawLevel(levelmap);
            break;

        case 2:
            levelmap = new string[]
            {
                "##########",
                "####..####",
                "#...P..B.#",
                "#.B....#.#",
                "####$B.#.#",
                "#####.$..#",
                "####$.$B.#",
                "##########",
                "##########",
                "##########"
            };
            InitializeGameMap();
            DrawLevel(levelmap);
            break;

        case 3:
            levelmap = new string[]
            {
                "##########",
                "##########",
                "###$...$##",
                "###$P..###",
                "###$.B.###",
                "#####...##",
                "#.B...B..#",
                "#....B...#",
                "#####..###",
                "##########"
            };
            InitializeGameMap();
            DrawLevel(levelmap);
            break;
        default:
            break;
    }
}

```

- **Metoda ResetLevel()**
    - Resetuje aktuální level a načte ho znovu
```cs
private void ResetLevel()
{
    Maingrid.Children.Clear();
    InitializeGameMap();
    LoadLevel();
}
```

- **Metoda InitializeGameMap()**
    - Inicializuje herní mřížku s prázdnými buňkami.
```cs
private void InitializeGameMap()
{
    gameMap = new Border[10, 10];
    for (int row = 0; row < 10; row++)
    {
        for (int column = 0; column < 10; column++)
        {
            Border border = new Border
            {
                Background = Brushes.Transparent
            };
            Grid.SetRow(border, row);
            Grid.SetColumn(border, column);
            Maingrid.Children.Add(border);
            gameMap[row, column] = border;
        }
    }
}
```
- **Metoda DrawLevel(string[] level)**
    - Vykresluje level na základě pole řetězců level, kde každý znak představuje různé herní objekty.
    - Použité symboly:
        - P: Hráč
        - #: Zeď
        - B: Box
        - $: Destinace
```cs
private void DrawLevel(string[] level)
{
    for (int row = 0; row < level.Length; row++)
    {
        for (int column = 0; column < level.Length; column++)
        {
            char symbol = level[row][column];
            switch (symbol)
            {
                case 'P':
                    playerRow = row;
                    playerColumn = column;
                    DrawPlayer();
                    break;
                case '#':
                    DrawWalls(row, column);
                    break;
                case '$':
                    DrawDestination(row, column);
                    break;
                case 'B':
                    DrawBox(row, column);
                    break;
            }
        }
    }
}
```
- **Metoda DrawWalls()**
    - Vykresluje zdi v `gameMap` podle symbolu `#` v atributu `levelmap`
    - Styl `WallStyle` je definován v XAML souboru.
```cs
private void DrawWalls(int row, int column)
{
    Style style = FindResource("WallStyle") as Style;
    Border wall = new Border
    {
        Style = style,
    };
    Grid.SetRow(wall, row);
    Grid.SetColumn(wall, column);
    Maingrid.Children.Add(wall);
    gameMap[row, column] = wall;
}
```
- **Metoda DrawPlayer()**
    - Vykresluje hráče v `gameMap` podle symbolu `P` v atributu `levelmap`
    - Styl `Player` je definován v XAML souboru.
```cs
private void DrawPlayer()
{
    Style style = FindResource("Player") as Style;
    Border player = new Border
    {
        Style = style,
    };
    Panel.SetZIndex(player, 2);
    Grid.SetRow(player, playerRow);
    Grid.SetColumn(player, playerColumn);
    Maingrid.Children.Add(player);
    gameMap[playerRow, playerColumn] = player;
}
```
- **Metoda DrawBox(int row, int column)**
    - Vykresluje box v `gameMap` podle symbolu `B` v atributu `levelmap`
    - Styl `box` je definován v XAML souboru.
```cs
private void DrawBox(int row, int column)
{
    Style style = FindResource("Box") as Style;
    Border box = new Border
    {
        Style = style,
    };
    Panel.SetZIndex(box, 1);
    Grid.SetRow(box, row);
    Grid.SetColumn(box, column);
    Maingrid.Children.Add(box);
    gameMap[row, column] = box;
}
```
- **Metoda DrawDestination(int row, int column)**
    - Vykresluje destinaci v `gameMap` podle symbolu `$` v atributu `levelmap`
    - Styl `Destination` je definován v XAML souboru.
```cs
private void DrawDestination(int row, int column)
{
    Style style = FindResource("Destination") as Style;
    Border destination = new Border
    {
        Style = style,
    };
    Grid.SetRow(destination, row);
    Grid.SetColumn(destination, column);
    Maingrid.Children.Add(destination);
    gameMap[row, column] = destination;
}
```
- **Metoda CheckDestinations()**
    - Kontroluje, zda jsou všechny boxy na destinacích, pokuď ano tak zobrazí zprávu že hráč vyhrál.
```cs
private void CheckDestinations()
{
    Style boxStyle = FindResource("Box") as Style;

    for (int row = 0; row < 10; row++)
    {
        for (int column = 0; column < 10; column++)
        {
            Border cell = gameMap[row, column];
            if (cell.Style == boxStyle)
            {
                if (levelmap[row][column] != '$')
                {
                    return;
                }
            }
        }
    }
    MessageBoxResult result = MessageBox.Show("Vyhrál jsi!");
    if (result == MessageBoxResult.OK)
    {
        StartWindow startWindow = new StartWindow();
        startWindow.Show();
        this.Close();
    }
}
```
- **Metoda MovePlayer(int newRow, int newColumn)**
    - Přesouvá hráče na nové pozice newRow a newColumn, pokud je to možné. Pokud je na nové pozici box, posune box na další volné místo.
```cs
private void MovePlayer(int newRow, int newColumn)
{
    Style walls = FindResource("WallStyle") as Style;
    Style box = FindResource("Box") as Style;

    if (newRow < 0 || newRow >= 10 || newColumn < 0 || newColumn >= 10)
        return;

    Border newCell = gameMap[newRow, newColumn];

    if (newCell.Style == walls)
    {
        return;
    }
    else if (newCell.Style == box)
    {
        int newBoxRow = newRow + (newRow - playerRow);
        int newBoxColumn = newColumn + (newColumn - playerColumn);

        if (newBoxRow < 0 || newBoxRow >= 10 || newBoxColumn < 0 || newBoxColumn >= 10)
            return;

        Border newBoxCell = gameMap[newBoxRow, newBoxColumn];
        if (newBoxCell.Style == walls || newBoxCell.Style == box)
            return;

        Grid.SetRow(gameMap[newRow, newColumn], newBoxRow);
        Grid.SetColumn(gameMap[newRow, newColumn], newBoxColumn);

        gameMap[newBoxRow, newBoxColumn] = gameMap[newRow, newColumn];
        gameMap[newRow, newColumn] = new Border
        {
            Background = Brushes.Transparent
        };
    }
}
   
```
