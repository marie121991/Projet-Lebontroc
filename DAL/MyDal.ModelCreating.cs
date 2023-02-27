//On n'utilise plus le ModelCreating suite à la création d'un
//  CustomizeModelDelegate et d'un SeedDataDelegate dans la DAL
// Ces deux Delegate sont ensuite appelés dans le serveur et permettent respectivement de 
// CustomizeModelDelegate = définir les noms des tables, des champs, et les relations (le structure de ma BDD)
// SeedDataDelegate = génération des données fictives qui doivent être présentes à l'initialisation de la BDD



// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;

// namespace DAL;

// public partial class MyDal : IdentityDbContext<UserDAO, RoleDAO, Guid>
// {
//     protected override void OnModelCreating(ModelBuilder builder)
//     {
// //Création du constructeur de BDD
// base.OnModelCreating(builder);

//Attribution des propriétés complexes
// ;
//TODO: Faire le lien des propriétés complexes sur Loan
//Voir le seeding de AppUser pour le modèle
// builder.Entity<LoanDAO>().OwnsOne(l => l.OwnerReview);
// builder.Entity<LoanDAO>().OwnsOne(l => l.BorrowerReview);

//Création d'un utilisateur de test 

//Création d'un hasher de mot de passe pour l'utilisateur
// var passHasher = new PasswordHasher<UserDAO>();
// var testAccount = new UserDAO()
// {
//     UserName = "testAccount"
// };
//Hashage du mot de passe "TestPwd"
// var hash = passHasher.HashPassword(testAccount, "TestPwd");
// testAccount.PasswordHash = hash;
// //Création du SecurityStamp (obligatoire avec Identity)
// testAccount.SecurityStamp = DateTime.Now.ToString();
// builder.Entity<UserDAO>().HasData(testAccount);

// //Instanciation du nouvel utilisateur
// var testUser = new AppUserDAO()
// {
//     FirstName = "Test",
//     LastName = "User",
//     Id = testAccount.Id,
// };

//On met l'utilisateur de test créé dansla table AppUserDAO
// builder.Entity<AppUserDAO>().HasData(testUser);
//On lui lie la propriété complexe Adress
// builder.Entity<AppUserDAO>().OwnsOne(c => c.Address).HasData(new
// {
//     AppUserDAOId = testUser.Id,
//     Street = "13 rue de la truie qui file",
//     ZipCode = "33200",
//     City = "Bordeaux"
// });

//Spécifications du modèle de chaque table
//Ici on spécifie pour la table User
// builder.Entity<UserDAO>(entity =>
// {
//     //On indique le nom de la table
//     entity.ToTable("TBL_Users")
//     //On crée un index sur le userName
//     .HasIndex(u => u.UserName);
//     //On précise le nom de colonne pour l'ID
//     entity.Property(u => u.Id)
//     .HasColumnName("PK_User");
// });

// builder.Entity<AppUserDAO>(entity =>
// {
//     entity.HasOne(c => c.User).WithOne().HasForeignKey<AppUserDAO>(c => c.Id);
// });

//OBJETS
//Spécifications pour la table Objets
// builder.Entity<ObjectDAO>(entity =>
// {
//     //Nom de table
//     entity.ToTable("TBL_Objects");
//     //Nom de colonne pour l'ID
//     entity.Property(o => o.Id)
//     .HasColumnName("PK_Object");
//     //Création de la relation one-to-Many avec Objets
//     //L'entité Object a UN SEUL propriétaire (user)
//     entity.HasOne(o => o.Owner)
//     //Le propriétaire (user) a plusieurs objets
//     .WithMany(u => u.Objects)
//     //La clé étrangère dans la table object est IdOwner
//     .HasForeignKey(o => o.IdOwner).OnDelete(DeleteBehavior.NoAction);
//     //Précision du nom de colonne pour la propriété IdOwner
//     entity.Property(o => o.IdOwner)
//     .HasColumnName("FK_User");

//     //Créatioh de la relation many-to-one avec photos
//     //L'entité objet a plusieurs photos
//     entity.HasMany(o => o.Photos)
//     //Une photo a un seul objet associé
//     .WithOne(p => p.Object)
//     //La clé étrangère dans la table photo est IdObject
//     .HasForeignKey(p => p.IdObject).OnDelete(DeleteBehavior.NoAction);

// });

//Instanciation d'un objet
//Avec les accolades on définit les propriétés à l'instanciation
// var testObject = new ObjectDAO()
// {
//     Label = "Mon joli marteau",
//     State = (int)StateObject.BrandNew,
//     Description = "Je prête mon marteau, il est super, c'est le meilleur marteau de la Terre",
//     IdOwner = testUser.Id,
//     Owner = testUser,
//     Value = 22.88,
// };

//PHOTO
// builder.Entity<PhotoDAO>(entity =>
// {
//     entity.ToTable("TBL_Photos");

//     entity.Property(p => p.Id)
//     .HasColumnName("PK_Photo");

// });
//Création d'une photo de test
//Syntaxe différente :
//On instancie la photo puis on déclare les propriétés ensuite
// var testPhoto = new PhotoDAO();
// testPhoto.Url = "https://tinyurl.com/mr43w723";
// testPhoto.Comment = "Photo d'un marteau";
// testPhoto.IdObject = testObject.Id;
// testPhoto.Object = testObject;


// builder.Entity<LoanDAO>(entity =>
// {
//     entity.HasKey(c => c.Id);
//     entity.ToTable("TBL_Emprunt");
//     entity.Property(l => l.Id)
//     .HasColumnName("PK_Emprunt");

//     entity.HasOne(l => l.Borrower)
//     .WithMany(u => u.Loans)
//     .HasForeignKey(l => l.IdBorrower).OnDelete(DeleteBehavior.NoAction);

// });
// }
// }