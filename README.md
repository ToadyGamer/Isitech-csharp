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

Librairies CoreFX : Toutes les classes de base de Net Core sous "System.*". Celui-ci est aussi quasi présent dans Net

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
#

### Ressources
Bien nommer sa doc : ```Conventional Commits```  
#