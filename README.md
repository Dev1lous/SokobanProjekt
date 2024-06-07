# Sokoban

## Přehled

Namespace `Projektusamogus` obsahuje hru implementovanou v jazyce C#. Hra je strukturována ve třídě `MainWindow`. Hra spočívá v logickém řešení hádanek posouváním boxů na určené destinace.

## Třídy a Metody

### Třída `MainWindow`

Hlavní třída aplikace, `MainWindow`, spravuje stav hry, inicializuje herní mřížku, zpracovává uživatelský vstup a definuje logiku pro načítání a resetování úrovní. Klíčové metody zahrnují:

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
    - Resetuje aktuální úroveň a načte ji znovu.
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
    - Vykresluje úroveň na základě pole řetězců level, kde každý znak představuje různé herní objekty.
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
- **Metoda DrawPlayer()**
    - Vykresluje hráče na aktuální pozici playerRow a playerColumn.
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
    -Vykresluje box na specifikovaném řádku a sloupci.
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
    -Vykresluje destinaci na specifikovaném řádku a sloupci.
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
    - Kontroluje, zda jsou všechny boxy na destinacích, přehraje zvuk vítězství a zobrazí zprávu, pokud hráč vyhrál.
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
    SoundPlayer movesound = new SoundPlayer("./sounds/movesound.wav");
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
