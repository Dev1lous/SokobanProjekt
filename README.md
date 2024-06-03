# Sokoban

Tento projekt je jednoduchá puzzle hra implementovaná v jazyce C# pomocí WPF. Cílem hry je posunout bedny na urèená místa ovládáním postavy hráèe.

## Obsah
- [Funkce](#funkce)
- [Instalace](#instalace)
- [Jak hrát](#jak-hrát)
- [Ovládání](#ovládání)
- [Levely](#levely)

## Funkce
- Více úrovní s postupnì se zvyšující obtíností.
- Jednoduchá a intuitivní hratelnost.
- Základní detekce kolizí a kontrola podmínek vıhry.

## Jak hrát
1. Spuste aplikaci.
2. Pouijte šipky nebo WASD na klávesnici k pohybu postavou hráèe.
3. Tlaèítkem 'R' resetujte aktuální úroveò.

## Ovládání
- **Šipky | WASD **: Pohyb postavou hráèe.
- **R Klávesa**: Resetovat aktuální level.
- **ESC | Q**: Odejít z aktuálního levelu



## Levely
Hra momentálnì obsahuje tøi pøeddefinované levely. Další levely lze snadno pøidat rozšíøením metody `LoadLevel()` v souboru `MainWindow.xaml.cs`. Kadá úroveò je reprezentována møíkou znakù, kde:
- `#`: Reprezentuje zeï, kterou nelze projít.
- `P`: Reprezentuje postavu hráèe.
- `B`: Reprezentuje bednu, která se mùe tlaèit.
- `$`: Reprezentuje cíl, kam je tøeba umístit bedny.

