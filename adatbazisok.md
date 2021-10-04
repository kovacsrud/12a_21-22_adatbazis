# Adatbázis ismeretek

CRUD (Create,Read,Update,Delete)

Új adat felvitele: INSERT INTO

Az SQL nyelv

Lekérdezések az adattáblából a SELECT parancs:
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
