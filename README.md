# DevoirCRUDLivre

## Description du Projet
Ce projet est une application de bureau simple développée en **C# WinForms** qui permet de gérer une collection de livres. Il implémente les fonctionnalités de base du **CRUD (Create, Read, Update, Delete)** pour la gestion des données de livres, stockées dans une base de données **SQLite**.

L'objectif principal de ce projet est de démontrer la capacité à :
* Créer une interface utilisateur graphique (GUI) avec WinForms.
* Interagir avec une base de données locale SQLite.
* Effectuer des opérations de base de données (ajout, modification, suppression, lecture).

## Fonctionnalités
* **Ajouter** un nouveau livre à la base de données.
* **Modifier** les informations d'un livre existant.
* **Supprimer** un livre de la base de données.
* **Afficher** la liste des livres (impliqué par la fonctionnalité CRUD et l'interface).
* **Réinitialiser** les champs de saisie du formulaire.

## Technologies Utilisées
* **Langage :** C#
* **Framework :** .NET (WinForms)
* **Base de données :** SQLite
* **IDE :** Visual Studio

## Structure de la Base de Données
Le projet utilise une base de données SQLite avec une table `Livres`. Voici le schéma de la table :

| Champ           | Type     | Description                                     |
|-----------------|----------|-------------------------------------------------|
| `Id`            | INTEGER  | Clé primaire, auto-incrémentée.                 |
| `Titre`         | TEXT     | Titre du livre (NON NULL).                      |
| `Auteur`        | TEXT     | Nom de l'auteur.                                |
| `ISBN`          | TEXT     | Numéro ISBN (UNIQUE).                           |
| `DatePublication` | TEXT     | Date de publication du livre.                   |
| `Disponible`    | INTEGER  | Indique si le livre est disponible (0 ou 1, DEFAULT 1). |
| `Genre`         | TEXT     | Genre du livre.                                 |
| `Editeur`       | TEXT     | Nom de l'éditeur.                               |
| `Resume`        | TEXT     | Résumé du livre.                                |


## Comment Exécuter le Projet

1.  **Cloner le dépôt :**
    ```bash
    git clone [https://github.com/KennyMDGCoder/DevoirCRUDLivre.git](https://github.com/KennyMDGCoder/DevoirCRUDLivre.git)
    ```
2.  **Ouvrir avec Visual Studio :**
    * Ouvre le fichier `DevoirCRUDLivre.sln` avec Visual Studio 2019 ou une version plus récente.
3.  **Restaurer les packages NuGet :**
    * Assure-toi que les packages NuGet sont restaurés. Visual Studio devrait le faire automatiquement, sinon clique droit sur la solution dans l'Explorateur de solutions et sélectionne "Restaurer les packages NuGet".
4.  **Exécuter l'application :**
    * Lance l'application en mode Debug (F5) ou en mode Release depuis Visual Studio.

## Aperçu de l'Application

Voici un aperçu de l'interface utilisateur de l'application :

![Interface d'ajout de livre](https://raw.githubusercontent.com/KennyMDGCoder/DevoirCRUDLivre/main/screenshots/form_ajouter_livre.png)
*(Remarque : Tu devras créer un dossier `screenshots` dans ton dépôt et y ajouter la capture d'écran de `Form1` si tu veux que cette image s'affiche.)*

---
