
# LibraryApi (solution)

![sequanceLibrary](https://user-images.githubusercontent.com/11867356/110629968-17928f80-81a5-11eb-8e20-4b9c08a2e2c9.png)

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

## FrontLibrary

API gateway + SPA Angular
