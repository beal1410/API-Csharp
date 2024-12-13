# README.md pour C# API

## C# API avec Entity Framework

### Prérequis pour lancer l'API

Il faut une base de données postrgres qui roule sur le port local 5432
Simplement lancer le docker de base fourni par postgres marche.

Il faut aussi avoir dotnet 

### Commandes 

- **Ajouter une migration:**
  ```bash
  dotnet ef migrations add [MigrationName]
  ```

- **Mettre à jour la base de données:**
  ```bash
  dotnet ef database update
  ```

- **Lancer l'application :**
  ```bash
  dotnet run
  ```

- **Enlever une migration:**
  ```bash
  dotnet ef migrations remove
  ```

