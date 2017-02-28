# Jeu_VassaleSpacial
<html>
<head>
	<title>Jeu vassal des familles</title>
</head>

<body>
<h1>Couches :</h1>
<ul>
	<li>Client
		<ul>
			<li>Main</li>
		</ul>
	</li>
	<li>Business (metier)
		<ul>
			<li>Toutes les fonctions : Tour suivant, les verifs ...</li>
		</ul>
	</li>
	<li>Crud
		<ul>
			<li>Les methodes d'accés aux données (getAll, getOne, Create, Delete, Update)</li>
		</ul>
	</li>
	<li>Fausse DB
		<ul>
			<li>Les listes des objets</li>
		</ul>
	</li>
	<li>Model
		<ul>
			<li>Les classes avec propriétés etc...</li>
		</ul>
	</li>
</ul>
<h1 id = "Classes">Classes</h1>
<table>
	<tr>
		<th><i>Crew</i></th>
		<th><i>Failure</i></th>
		<th><i>Starship</i></th>
	</tr>
	<tr>
		<td>Mechanic</td>
		<td>Small</td>
	</tr>
	<tr>
		<td>Doctor</td>
		<td>Medium</td>
	</tr>
	<tr>
		<td>Captain</td>
		<td>Big</td>
	</tr>
	<tr>
		<td>Commander</td>
		<td></td>
	</tr>
</table>

<h2> Propriété Crew : </h2>
<ul>
	<li>Id</li>
	<li>Name</li>
	<li>Life</li>
	<li>NbRolls</li>
	<li>Skill</li>
	<li>StartRoom</li>
	<li>UsedRolls</li>
</ul>

<h2> Propriété Failure : </h2>
<ul>
	<li>Name</li>
	<li>Damage</li>
	<li>NumberToDo</li>
</ul>

<h2> Propriété Starship : </h2>
<ul>
	<li>Name</li>
	<li>Life</li>
</ul>

<h2> Propriété Rooms : </h2>
<ul>
	<li>Id</li>
	<li>Name</li>
	<li>FailureType(-1:pas de panne,	0:small,1:medium,2:big)</li>
</ul>

<h1>Fonctionnalitées obligatoires</h1>
<ul>
	<li>Voir l'état de son vaisseau
		<ul>
			<li>Nombre de point de vie</li>
			<li>Liste des pannes à résoudre</li>
		</ul>
	<li>Voir l'état des membres d'équipage
		<ul>
			<li>Nombre de points de vie restant</li>
			<li>Nombre de dés restant</li>
			<li>Position dans le vaisseau</li>
		</ul>
	</li>
	<li>Assigner un membre d'équipage à un module</li>
	<li>Lancer jusqu'à 3 fois les dés d'un membre d'équipage par tour, avec possibilité de les stocker
		<ul>
			<li>A la fin de chaque tour, le programme appliquera les régles de fin de tour</li>
			<li>Retirer 1 dés à chaque membre d'équipage</li>
			<li>Déclencher les effets negatifs des pannes non resolues</li>
		</ul>
		</li>
		<li>Si un membre de l'équipage tombe à 0 pdv, il meurs et ne peux plus être utiliser.</li>
		<li>Si les 4 meurs = GAME OVER</li>	
		</ul>
	</li>
</ul>

<h1>Menu</h1>
Tant que nbPerso > 0
<ul>
	<li>1 : Voir l'état du vaisseau -> Affiche PDV + pannes + effet negatifs de ces pannes</li>
	<li>2 : Voir l'état des membres d'équipage -> Affiche Nb de pdv restant de l'équipe + dés + position + capacité spécial</li>
	<li>3 : Choisir un membre de l'équipage
		<ul> Vous controller le {personnage} -> Affiche l'état du personnage en cours (Affiche Nb de pdv restant de l'équipe + dés + position + capacité spécial)
			<li>1 : Deplacer le membre de l'équipage</li> 
			<li>2 : Lancer un dés</li>
			<li>3 : Stocker les dés restant</li>
			<li>4 : Activer la capacité spécial</li>
		</ul>
	</li>
	<li>4 : Tour suivant</li>
	<li>9 : Abandonner la partie</li>
</ul>
Sinon game over 


<h1 id ="fonctions">Fonction</h1>
<h2>Se deplacer</h2>
On affiche la salle où se trouve le personnage.</br>
On affiche toutes les salles du vaisseau.</br>
Le personnage choisis une direction</br>
Si le personnage traverse une panne non corrigé, on demande confirmation.

<h2>Tour suivant</h2>
On instancie une valeur à 1 avant. </br>
Chaque tours on incrémentente cette valeur (=> num semaine)</br>
On a plusieurs verification à faire : </br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Check les pannes existantes</br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Faire les effets négatifs en fonction des pannes existantes (pertes dés vaisseaux / pertes dés equipages / pertes dés)</br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Check pdv du vaisseaux</br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- -1 dès par personnages, en laissant un dès minimum !!!</br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</br>
on affiche un speech disant les nouvelles pannes etc...
</body>
</html>