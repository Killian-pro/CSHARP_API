dotnet new console -o consoleApp -f net7.0 pour créé une app
dotnet run
dotnet build

pour gérer les packages utilisés (nouvelle méthode)
<ItemGroup>
<Using Remove="System">
<Using Include="System.Numerics">
<Using Include="EFCore.Shared"/>
</ItemGroup>

gestion de variables syntaxe différente
private camelCase
public Pascalcase

""" pour garder le formattage idéal XML et html

var student = new {Name = "John" , Age = 18}

entitity framework core est un ORM

sqlite3 Northwind.db -init Northwind4SQLite.sql

créa d'un champ productName de 40
[Required]
[StringLength(40)]
public string ProductName [get; set;]

on peut utiliser la fluent API a la place des annotations ou en complement de ces dernieres

public class Categorie
{
public int CategoryId { get; set; }
public required string CategoryName { get; set; }
public required string Description { get; set; }
}

donet-ef tool est une extension .net cli qui permert d'apporter des fonctionnalités supp lorqu'on travail avec EFcore comme le design et migration de BDD.

dotnet tool list --global
dotnet tool uninstall --global <NOM>

procédé qui permet de créer des classes qui represente modele de BDD => 'reverse engineering'
L>installer Microsoft.EntityFrameworkCore.Design

pour crée la base
dotnet ef migrations add InitialCreate
dotnet ef database update
