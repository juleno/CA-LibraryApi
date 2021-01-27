
# LibraryApi (solution)

## LibraryApi (projet)

Permet de gérer les livres et les auteurs

En BDD :

 - Book (Id, Title, PublicationDate, Price) 
 - Author (Id, Firstname, Lastname)

## CartApi 

Permet de créer des paniers et récupère le prix des articles (livres) en intérogeant la LibraryApi

En BDD :

 - Cart (Id, TotalPrice) 
 - Article (BookId, Quantity)
