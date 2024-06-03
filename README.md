# Sokoban

Tento projekt je jednoduch� puzzle hra implementovan� v jazyce C# pomoc� WPF. C�lem hry je posunout bedny na ur�en� m�sta ovl�d�n�m postavy hr��e.

## Obsah
- [Funkce](#funkce)
- [Instalace](#instalace)
- [Jak hr�t](#jak-hr�t)
- [Ovl�d�n�](#ovl�d�n�)
- [Levely](#levely)

## Funkce
- V�ce �rovn� s postupn� se zvy�uj�c� obt�nost�.
- Jednoduch� a intuitivn� hratelnost.
- Z�kladn� detekce koliz� a kontrola podm�nek v�hry.

## Jak hr�t
1. Spus�te aplikaci.
2. Pou�ijte �ipky nebo WASD na kl�vesnici k pohybu postavou hr��e.
3. Tla��tkem 'R' resetujte aktu�ln� �rove�.

## Ovl�d�n�
- **�ipky | WASD **: Pohyb postavou hr��e.
- **R Kl�vesa**: Resetovat aktu�ln� level.
- **ESC | Q**: Odej�t z aktu�ln�ho levelu



## Levely
Hra moment�ln� obsahuje t�i p�eddefinovan� levely. Dal�� levely lze snadno p�idat roz���en�m metody `LoadLevel()` v souboru `MainWindow.xaml.cs`. Ka�d� �rove� je reprezentov�na m��kou znak�, kde:
- `#`: Reprezentuje ze�, kterou nelze proj�t.
- `P`: Reprezentuje postavu hr��e.
- `B`: Reprezentuje bednu, kter� se m��e tla�it.
- `$`: Reprezentuje c�l, kam je t�eba um�stit bedny.

