/************* Travail de l'équipe TeamWhite *************/
DomainLayer -> Entities :
    - Crush.cs
    - Ignored.cs
    - Mood.cs
    - Publication.cs
    - Tinder.cs
    - User.cs (complété par toutes les équipes)
    
InfrastructureLayer -> Database
    - Tous les IRepository
    - Tous les Repository
    - Transverse -> les données bouchons
    - EfContext.cs -> Ajout de nos DbSet 


PresentationLayer -> WebAPI
    - CrushController.cs
    - IgnoredController.cs
    - MoodController.cs
    - PublicationController.cs
    - TinderController.cs
    - UserController.cs

Nous nous sommes également occupés de la fusion de tous les projets pour le réunir en un seul, 
pouvoir taper sur une base de données commune, et la résolution de conflits présents dans la solution.
