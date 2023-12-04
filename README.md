# Isitech-csharp - Cours en c#
## .NET
### Définitions
Net Framework : Ne fonctionne que sur windows  
Net Core : Ne fonctionne que sous windows   
Fusion des 2 pour donner Net  
Net : Fonctionne sur toutes les plateformes (cross plateforme). De plus, il est portable (facilement transportable d'une machine à l'autre).

NuGet (NetCore) : Fonctionnalité libre de droit téléchargable.  
NuGet (NetFramework) : Fonctionnalité venant de microsoft.  
Problème : Les librairies de NetFramework ne sont pas toutes sur NetCore.  

STS : Short Terme Support (une version toute les 6 semaines)  
LTS : Long Terme Support (3 ans de percistance) 
Fork : Création d'une branche dans l'arbre de développement

Librairies CoreFX : Toutes les classes de base de Net Core sous "System.*". Celui-ci est aussi quasi présent dans Net  

Passage par référence : Déplacement de l'allocation de la mémoire et de la valeur dans l'entiéreter du programme.
#

### Fonctionnalité
Net Core :
 - Unification des API et des du Web  
 - Intégration de framework (ang, react, vue)  
 - Facilement intégrable en cloud  
 - Hébergement d'app facile

Paterne MVC :
 - Différentiation entre les couches logiques, métier et présentation
 - Razor page => Création de page web
 - Model binding => Validation de model
#

### Commandes
Voir les templates : ```dotnet new list```  
Créer un projet mvc : ```dotnet new mvc```  
Créer un projet console : ```dotnet new console```  
Afficher le code de façon "complete" correspondatn à l'ancienne syntaxe: ```dotnet new console --use-program-main ```  
Pour lancer le programme : ```dotnet run```  
Restauration des dépendances : ```dotnet restore```  
Pour build le projet : ```dotnet build```  
Test unitaire : ```dotnet test```  
Publier le projet : ```dotnet publish```  
Créer un package NuGet : ```dotnet pack```  
#

### Ressources
Bien nommer sa doc : ```Conventional Commits```  
Doc de .NET : ```https://learn.microsoft.com/en-us/dotnet/api/system?view=net-8.0```  
#

### C#, C'est quoi ?
Language de programmation orienté objet.
Tuple : Une variable qui contient plusieurs valeurs
```cs
//----------------------------------------------
var letters = ("a", "b");
letters.item1;
//----------------------------------------------
(string Bob, string Roger) letters = ("1", "2");
var chiffres = (Bob:"1", Roger:"2");
chiffres.Bob;
//----------------------------------------------
```

Création des accesseurs : ```public string oui {get; set;}```  

On peut aussi créer une séquence de valeurs :
```cs
var myArray = new[] {1,2,3,4,5,6,7,8,9,10};
//Création de la list

var myRange = myArray[4..^2];
//On part après le 4eme item et on enleve les 2 derniers

Console.WriteLine(string.Join(",",myRange));
//Affichage de "MyRange"
``` 
#

### Gestion des fichier
Properties : Parametre de l'application (Option de lancement)

wwwroot : Fichier destiné au projet web en production

Controllers, Views, Models : Permet la gestion du projet

appsettings.json : Parametre qui sont spécific pour un type d'environement (Différentes informations selon l'environement (Dev, Prod, Client, ect)). On met pettre des requetes pour l'API

Program.cs : Configuration du programme

Class de configuration : Gestion de l'injection de service et de dépendance

.CSPROJ : Information sur l'app, sa version
#