# Projet Fruit Slicer du Trio d'Hommes Forts

Bienvenue sur le github du Projet GameProg du Trio d'Hommes Forts: le Fruit Slicer.


## Répartition des taches

Les taches étaient équitablement réparties entre les trois membres du group :
Nolan Zelphati, Axel Sevenet, Guillaume Pham;

### Nolan

La création de la scene de base, le setup de caméras;
Le design des objets découpables;
Le design des différentes difficultés;
L'implémentation des objets;
L'apparition des objets bonus/malus.

### Axel

L'apparition des objets simples;
le système de découpage des objets;
L'implémentation du système de score ainsi que son interface;
L'implémentation des points de vie + l'interface;
L'implémentation des différentes difficultés.

### Guillaume

La destruction des objets hors-champ;
Les effets visuels ainsi que recherche des effets sonores;
Les menus de Pause, Volume, GameOver et Fin de Partie;
Les boutons de l'interface.


## Mécaniques de gameplay
Lorsque l'on démarre le jeu, on est présenté avec les trois différentes difficultés qu'offre le jeu :
Facile, Moyen et Difficile.

Un menu de pause est disponible lorsqu'une partie est en cours, en haut à gauche de l'écran.

Pour choisir sa difficulté et démarrer la partie, il suffit de "slicer" l'option correspondante.

Pour "slicer" is suffit de maintenir n'importe quel clic de la souris appuyé et de bouger sa souris.

Le "slicer" s'arrête tous seul après avoir traversé une certaine distance, et ne peux pas découper d'objets avant avoir traversé une petite distance.

Le Joueur possède trois points de vie,
Certaines erreurs lui en déduiront;
Après avoir perdu trois points de vie, la partie prend fin.

Lorsque tous les objets de la partie ont été usés, la partie prend fin.

A la fin de la partie, le score de la partie est affiché.


### Les objets découpables

Dans le jeu, trois types d'objets coupables "simples" apparaissent de façon garantie :
- Le *Bamboo sec*
	-Lorsque coupé, donne 5 points de score au joueur
	-Lorsqu'il disparait, il retire 2 points de score au joueur

- Le *Negi*
	-Lorsque coupé, donne 10 points de score au joueur
	-Lorsqu'il disparait, il retire 4 points de score au joueur, ainsi qu'un point de vie
	
- L'*Aubergine*
	-Lorsque coupé, donne 15 points de score au joueur
	-Lorsqu'il disparait, il retire 5 points de score au joueur, ainsi qu'un point de vie

Il existe aussi deux types d'objets spéciaux (bonus/mallus) qui apparaissent à l'aléatoire :
- Le Ninja
	-**Ne doit pas être coupé**, il met fin à la partie instantanément lorsque coupé,
	-Son apparition est prédite par de la fumée rouge
	
- Le pinceau
	-Lorsque coupé, il découpe tous les objets présent dans le jeu, sans inclure les mallus
	-Son apparition est prédite par de la fumée verte

## Menus

Les menus sont construit sous la forme d'un système de Modals archaïque et est par conséquent plutôt robuste.

Le menu de pause ainsi que le menu principal donnent accès au menu d'options sonores, qui permet d'ajuster le son global, le son de la musique et le son des effets sonores, séparément.


## Les limites du jeu

Chaque difficulté a un nombre limité de points de score obtenables;
Une grande maîtrise du jeu permettrait d'atteindre un score parfait.

Ce score parfait varie en fonction de la difficulté de la partie:
- Facile : 375
- Moyen : 775
- Difficile : 1175 points de score

Bien sûr une partie parfaite n'aurait pas perdu de points de vie non plus.
