Dokumentace projektu �Projektusamogus�
P�ehled
Tento projekt je implementace jednoduch� hry v jazyce C# s vyu�it�m WPF (Windows Presentation Foundation). Hr�� ovl�d� postavi�ku v m��ce a jeho c�lem je um�stit v�echny boxy na vyzna�en� m�sta.

Struktura t��dy MainWindow
T��da MainWindow d�d� z Window a p�edstavuje hlavn� okno aplikace. Obsahuje n�sleduj�c� atributy a metody:

Atributy
private Border[,] gameMap: Dvourozm�rn� pole pro reprezentaci hern� mapy.
private string[] levelmap: Pole �et�zc�, kter� p�edstavuj� aktu�ln� �rove�.
private int playerRow: ��dek, na kter�m se nach�z� hr��.
private int playerColumn: Sloupec, na kter�m se nach�z� hr��.
private int level: ��slo aktu�ln� �rovn�.
Konstruktor
public MainWindow(int level): Inicializuje hlavn� okno a na�te danou �rove�.
csharp
Zkop�rovat k�d
public MainWindow(int level)
{
    InitializeComponent();
    this.level = level;
    LoadLevel();
}
Metody
private void LoadLevel()
Na��t� �rove� na z�klad� ��sla �rovn� (level). Podle ��sla �rovn� p�i�azuje hodnotu atributu levelmap a n�sledn� vol� metody InitializeGameMap() a DrawLevel(levelmap).

private void ResetLevel()
Vyma�e aktu�ln� hern� plochu a znovu na�te �rove�.

private void InitializeGameMap()
Inicializuje hern� mapu jako 10x10 m��ku a p�id� ji do hlavn�ho gridu (Maingrid).

private void DrawLevel(string[] level)
Kresl� aktu�ln� �rove� na z�klad� hodnot v levelmap. Ka�d� znak v map� reprezentuje jin� hern� prvek:

'P': Hr��
'#': Ze�
'$': Destinace
'B': Box
private void DrawPlayer()
Kresl� hr��e na aktu�ln� pozici (playerRow, playerColumn).

private void DrawWalls(int row, int column)
Kresl� zdi na zadan�ch sou�adnic�ch.

private void DrawBox(int row, int column)
Kresl� box na zadan�ch sou�adnic�ch.

private void DrawDestination(int row, int column)
Kresl� destinaci na zadan�ch sou�adnic�ch.

private void CheckDestinations()
Kontroluje, zda jsou v�echny boxy na destinac�ch. Pokud ano, zobraz� zpr�vu o v�h�e a zav�e aktu�ln� okno.

private void MovePlayer(int newRow, int newColumn)
Pohybuje hr��em na nov� sou�adnice, pokud je to mo�n�. Pokud je na nov� pozici box, pokus� se ho posunout. Kontroluje, zda hr�� nevyjede mimo hern� plochu a zda nenaraz� do zdi nebo jin�ho boxu.

private void QuitLevel()
Zobraz� dialogov� okno pro potvrzen� ukon�en� �rovn�. Pokud u�ivatel potvrd�, zav�e aktu�ln� okno a otev�e okno menu.

protected override void OnKeyDown(KeyEventArgs e)
Reaguje na stisk kl�ves. Pohybuje hr��em podle stisknut�ch kl�ves (Up, Down, Left, Right, W, A, S, D). Kl�vesou R resetuje �rove� a kl�vesami Escape nebo Q ukon�� �rove�.