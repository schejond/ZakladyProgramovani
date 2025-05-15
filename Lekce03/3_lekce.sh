# projit si zpusob nastaveni gitu
	# stazeni + instalace
	# prvotni setup (global configs)

# overeni, ze mame git a na jake verzi
git --version

# pouzivame prikaz cd pro prepinani mezi adresari (slozkami)
## cd .. nas vrati o slozku vyse

# pvni pouziti
# musime zadat jmeno, email (and line ending - nepovinne)
git config --global user.name "Ondra Schejbal"
git config --global user.email ondra.schejbal@gmail.com
git config --global core.autocrlf true #(windows) input (mac, unix)
git config --global core.autocrlf input #(mac, unix)
# git config --global -e # pomoci tohoto prikazu jsme schopni upravit 

# vytvoreni git repozitare a prvni commity
mkdir Kurz_test # vytvori slozku
git init # inicializuje git repozitar v aktualni slozce
ls -a # vypise obsah aktualni slozky - muzeme pak videt .git slozku. Kdyz .git smazeme, tak vlastne odpojime (zrusime) git

git status

# zakladní prikazu pro praci v gitu
touch script.js
git add . # da veci do staging faze
git commit -m "Pridani javascript skriptu" # snapshot vasi prace. Zmeny ve staging fazi se napevno zapisi do historie nasi vetve

git log # zobrazime si historii, log naseho projektu
# ruzne varianty vypisu historie
git log --oneline
git log --oneline --reverse

# ukaze detaily nektereho z commitu
git show <commit> # za <commit> doplnte cislo commitu
#git show HEAD~1 # ukaze aktualni verzi, na kterou koukam - 1
#git show HEAD~1:file

# prepnuti na konkretni verzi, branch
git checkout <commit>

# vyjmuti souboru ze staging faze
git restore --staged <nazevSouboru>

# git restore
# obnovi VSECHNY trackovane soubory do puvodni verze - odebere veskere vase zmeny
# soubory, ktere nejsou sledovany gitem nebudou smazany

git status
# git status -s # short

# vypise dostupne branche
git branch

git brach <druha_branch>
# prepneme se na / vytvori novou branch
git checkout <branch>

# prejmenovani - dvou krokova operace. take stagene zmeny
git mv <oldName> <newName>

# .gitignore
# vysvelit k cemu slouzi, ukazat si jak funguje

# vysvetlit si jak funguje git diff
## git diff ukazuje rozdil mezi soubory (aktualni stav vs. posledni git verze)
git diff # pocita jen veci, ktere nejsou ve staging stavu
git diff --staged # zobrazme si detaily (vice nez jen nazvy souboru) jednotlivych zmen, ktere mame pripravene ke commitnuti
# dokaze ukazat pouze "kusy" zmeneneho kodu pro velke soubory s vice zmenami

# ukazat si - upravit slozku, dat do stagingu, upravit znovu, ruzne diffy

# vytvoreni branche, upravy, prepnuti na 3. novou branch, upravy. Megnuti dvou branchi
git checkout master
git merge other_branch
git branch -d other_branch # nebo -D prepinac

# revert posledniho commitu
git revert HEAD

git revert <commit>

# ------------------
# GitHub!
# git clone + git remote add origin

# ukazat, jak se resi pomoci visual studia komplikovane branch merge

# pristup k verejnym a privatnim repozitarum

# vysvetlit si a ukazat, co to je fork - ukaz - ukazeme si pristi hodinu