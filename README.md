# Jeu_VassaleSpacial
<html>
<head>
	<title>Jeu vassal des familles</title>
</head>

<body>

<h1>Classes</h1>
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
	<li>ListRoom</li>
</ul>

<h1>Fonctionnalitées obligatoires</h1>
<ul class="tree">
	<li>Voir l'état de son vaisseau
		<ul>
			<li>Nombre de point de vie</li>
			<li class="last">Liste des pannes à résoudre</li>
		</ul>
	<li>Voir l'état des membres d'équipage
		<ul>
			<li>Nombre de points de vie restant</li>
			<li>Nombre de dés restant</li>
			<li class="last">Position dans le vaisseau</li>
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
		<li class="last">Si les 4 meurs = GAME OVER</li>	
		</ul>
	</li>
</ul>

<h1>Menu</h1>
<ul class="tree">
	<li>1 : Voir l'état du vaisseau -> Affiche PDV + pannes</li>
	<li>2 : Voir l'état des membres d'équipage -> Affiche Nb de pdv restant de l'équipe + dés + position + capacité spécial</li>
	<li>3 : Choisir un membre de l'équipage
		<ul> Vous controller le {personnage} -> Affiche l'état du personnage en cours (Affiche Nb de pdv restant de l'équipe + dés + position + capacité spécial)
			<li>1 : Deplacer le membre de l'équipage</li> 
			<li>2 : Lancer un dés</li>
			<li>3 : Stocker les dés restant</li>
			<li>4 : Activer la capacité spécial</li>
		</ul>
	<li>4 : Tour suivant</li>
	</li>
	<li>9 : Abandonner la partie</li>
</ul>

<h1>Fonction</h1>
<h2>Se deplacer</h2>
On affiche la salle où se trouve le personnage.
On affiche toutes les salles du vaisseau.
Si le personnage traverse une panne non corrigé, on demande confirmation
</body>
</html>