# Adatbázis ismeretek

# Az SQL nyelv

## CRUD (Create,Read,Update,Delete)

### Új adat felvitele: INSERT INTO
Adat felvitele a *kutyanevek* táblába:
```sql
INSERT INTO kutyanevek (kutyanev) VALUES ('Bigyóka');
```
Mivel a *kutyanevek* tábla **id** mezője autoincrement tulajdonságú, ezért az értékét nem kell megadni az Insert parancsnál

### Adatok módosítása:UPDATE
```sql
UPDATE kutyanevek
   SET kutyanev = 'Bigyócska'
 WHERE id = 289;
```
Ebben a példában a kutyanevek adattábla kutyanév oszlopának értékét módosítjuk, az érték annál a rekordnál módosul, ahol az id értéke 289.

### Adatok törlése:DELETE

```sql
DELETE FROM kutyanevek WHERE id = 289;
```
A DELETE paranccsal 1 vagy több rekord törölhető az adattáblából.       

## Lekérdezések az adattáblából a SELECT parancs:
A felsorolt példák a kutyak adatbázisra vonatkoznak!

A **kutyak** tábla összes adatának lekérdezése:
```sql
select * from kutyak
```
A **select** után azok az oszlopnevek szerepelnek, amelyeket az eredményben meg akarunk jeleníteni. A **from** után adjuk meg azokat az adattáblákat, amelyekből le akarunk kérdezni.

Csak a két kiválasztott oszlop adata jelenjen meg:
```sql
select eletkor,utolsoell from kutyak
```
**Autoincrement tulajdonságú oszlopok értékeinek a megtekintése**
```sql
select * from sqlite_sequence
```
**Adatok rendezése a lekérdezésben oszlopok értéke szerint**
```sql
select eletkor,utolsoell from kutyak
order by eletkor desc
```
A lekérdezésben az **order by** parancs segítségével lehet az adatokat növekvő vagy csökkenő sorrendbe rendezni. Az order by után meg kell adni azokat a mezőket, amelyek szerint rendezni kell. A **desc** jelenti a csökkenő sorrendet.

#### Adatok lekérdezése feltételek megadásával, a SELECT parancs WHERE része

```sql
select eletkor,utolsoell from kutyak where utolsoell='2017.05.14'
```
Ez a lekérdezés azokat az adatokat jeleníti meg, amelyeknél a dátum 2017.05.14

**Szám típusú adatoknál aritmetikai műveleteket is használhatunk**

pl. A 6 évnél idősebb kutyák utolsó ellenőrzésének adatai, csökkenő sorrendben:
```sql
select eletkor,utolsoell from kutyak
where eletkor>6
order by eletkor desc
```
### Aggregáló (összesítő) függvények
Az összesítések műveleteit a MIN,MAX,SUM,AVG műveletekkel tudjuk elvégezni. A COUNT (megszámlálás) bármilyen típusú oszlopon végrehajtható, a többi csak szám típusokon.
**Egy tábla sorainak megszámlálása**
```sql
select count(*) from kutyak
```

**Egy tábla sorainak megszámlálása, álnévvel**
```sql
select count(*) As 'Bejegyzések száma' from kutyak
```
**Több összesítő föggvény is használható**
```sql
select max(eletkor),
min(eletkor),
avg(eletkor),
count(*) from kutyak
```
**Összesítés csoportosítással, az adatok minden csoportra ki lesznek számolva**

```sql
select avg(eletkor),utolsoell
from kutyak
group by utolsoell
```
**Szűrés csoportokra, HAVING**
```sql
select avg(eletkor),utolsoell
from kutyak
group by utolsoell
having utolsoell='2018.01.01'
```
