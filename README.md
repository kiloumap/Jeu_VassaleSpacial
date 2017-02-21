# Jeu_VassaleSpacial
<html>
<head>
	<title>Jeu vassal des familles</title>
</head>


<body>
<style>
.tree, .tree ul{
  font: normal normal 14px/20px Helvetica, Arial, sans-serif;  
  list-style-type: none;
  margin-left: 0 0 0 10px;
  padding: 0;
  position: relative;   
  overflow:hidden;    
}

.tree li{
  margin: 0;
  padding: 0 12px;  
  position: relative;   
}
  
.tree li::before, .tree li::after{
  content: '';
  position: absolute;
  left: 0;
}

/* horizontal line on inner list items */
.tree li::before{
  border-top: 1px solid #999;
  top: 10px;
  width: 10px;
  height: 0;    
}

/* vertical line on list items */   
.tree li:after{
  border-left: 1px solid #999;
  height: 100%;
  width: 0px;
  top: -10px; 
}

/* lower line on list items from the first level because they don't have parents */
.tree > li::after{
  top: 10px;
}

/* hide line from the last of the first level list items */
.tree > li:last-child::after{
  display: none;
}
</style>
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

<h2> Methodes Crew : </h2>
<ul>
	<li>Name</li>
	<li>Life</li>
	<li>NbRolls</li>
	<li>Skill</li>
	<li>StartRoom</li>
</ul>

<h2> Methodes Failure : </h2>
<ul>
	<li>Name</li>
	<li>Damage</li>
	<li>NumberToDo</li>
</ul>

<h2> Methodes Starship : </h2>
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
	</li>
	<li>9 : Abandonner la partie</li>
</ul>
</body>
</html>