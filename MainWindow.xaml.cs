using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

using System.Media;

using System.Windows.Media.Media3D;
using System.Data.Common;

namespace Projektusamogus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Border[,] gameMap;
        private string[] levelmap;
        private int playerRow;
        private int playerColumn;
        private int level;
        public MainWindow(int level)
        {
            InitializeComponent();
            this.level = level;
            LoadLevel();
        }
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
        private void ResetLevel()
        {
            Maingrid.Children.Clear();
            InitializeGameMap();
            LoadLevel();
        }
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
        private void DrawLevel(string[] level)
        {
            // P - HRÁČ ||| # - ZEĎ ||| B - BOX ||| $ - DESTINACE 
            for (int row = 0; row < level.Length; row++)
            {
                for (int column = 0; column < level.Length; column++)
                {
                    char symbol = level[row][column]; // symbol bere symbol z level row column a co se tam nazachi switch nastaví
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
        private void CheckDestinations()
        {
            //SoundPlayer winsound = new SoundPlayer("./sounds/winsound.wav");
            Style boxStyle = FindResource("Box") as Style;

            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    Border cell = gameMap[row, column];         
                    // pokud je na ty lokaci box tak se koukne jestli tam je symbol $ tak je box v destinaci a hledá dal
                    if (cell.Style == boxStyle)
                    {
                        if (levelmap[row][column] != '$')
                        {                            
                            return;
                        }
                    }
                }
            }
            //winsound.Play();
            MessageBoxResult result = MessageBox.Show("Vyhrál jsi!");
            if (result == MessageBoxResult.OK)
            {
                StartWindow startWindow = new StartWindow();
                startWindow.Show();
                this.Close();
            }
        }
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
                
                gameMap[newBoxRow, newBoxColumn] = gameMap[newRow, newColumn]; //vezme kontent z toho boxu a da to na novy misto // bez tohohle by ten content se ztratil protože by zustal na miste a tam dam border a timpadem tam content není
                gameMap[newRow, newColumn] = new Border
                {
                    Background = Brushes.Transparent
                };
            }
            Grid.SetRow(gameMap[playerRow, playerColumn], newRow);
            Grid.SetColumn(gameMap[playerRow, playerColumn], newColumn);
            gameMap[newRow, newColumn] = gameMap[playerRow, playerColumn]; // to stejny lol
            gameMap[playerRow, playerColumn] = new Border
            {
                Background = Brushes.Transparent
            };
            playerRow = newRow;
            playerColumn = newColumn;
            movesound.Play();
            CheckDestinations();
        }

        private void QuitLevel()
        {
            MessageBoxResult result = MessageBox.Show("Chceš opustit level?", "Potvrzení že jsi špatnej a neumíš to", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                MenuWindow menuwindow = new MenuWindow();
                menuwindow.Show();
                this.Close();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.Key)
            {
                case Key.Up:
                    MovePlayer(playerRow - 1, playerColumn);
                    break;
                case Key.Down:                  
                    MovePlayer(playerRow + 1, playerColumn);
                    break;
                case Key.Left:
                    MovePlayer(playerRow, playerColumn - 1);
                    break;
                case Key.Right:
                    MovePlayer(playerRow, playerColumn + 1);
                    break;
                case Key.W:
                    MovePlayer(playerRow - 1, playerColumn);
                    break;
                case Key.S:
                    MovePlayer(playerRow + 1, playerColumn);
                    break;
                case Key.A:
                    MovePlayer(playerRow, playerColumn - 1);
                    break;
                case Key.D:
                    MovePlayer(playerRow, playerColumn + 1);
                    break;
                case Key.R:
                    ResetLevel();
                    break;
                case Key.Escape:
                    QuitLevel();
                    break;
                case Key.Q:
                    QuitLevel();
                    break;
            }
        }
    }
}