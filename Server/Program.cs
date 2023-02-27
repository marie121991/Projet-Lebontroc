using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DAL;

//Configuration du mapping entre les DAO et les models
var configMapping = new MapperConfiguration(options =>
{
    options.CreateMap<AppUserDAO, UserModel>().ReverseMap();
    options.CreateMap<LoanDAO, LoanModel>().ReverseMap();
    options.CreateMap<ObjectDAO, ObjectModel>()
    // .ForMember(om => om.Photos, pm => pm.MapFrom(od => od.Photos.Select(c => c.Id).ToArray()))
    .ReverseMap();
    options.CreateMap<PhotoDAO, PhotoModel>().ReverseMap();
});

//Customisation de la Base de données grâce au CustomizeModelDelegate fourni par le DbContext
CustomizeModelDelegate customizeModelDelegate = (modelBuilder) =>
{
    //Spécifications du modèle de chaque table
    //Ici on spécifie pour la table User
    modelBuilder.Entity<UserDAO>(entity =>
        {

            //On indique le nom de la table
            entity.ToTable("TBL_Users");
            //On crée un index sur le userName

            //On précise le nom de colonne pour l'ID
            entity.Property(u => u.Id).HasColumnName("PK_User");
        });

    modelBuilder.Entity<AppUserDAO>(entity =>
   {
       entity.HasKey(c => c.Id);
       entity.HasOne(c => c.User).WithOne().HasForeignKey<AppUserDAO>(c => c.Id);
       entity.ToTable("TBL_AppUsers");
       entity.Property(a => a.Id).HasColumnName("PK_AppUser");
       //    entity.Property(a => a.Address.Street).HasColumnName("Street");
       //    entity.Property(a => a.Address.ZipCode).HasColumnName("ZipCode");
       //    entity.Property(a => a.Address.City).HasColumnName("City");
       //    entity.HasMany(a => a.Objects).WithOne(o => o.Owner).HasForeignKey(o => o.IdOwner).OnDelete(DeleteBehavior.NoAction);
   });

    //OBJETS
    //Spécifications pour la table Objets
    modelBuilder.Entity<ObjectDAO>(entity =>
        {
            entity.HasKey(c => c.Id);
            //Nom de table
            entity.ToTable("TBL_Objects");
            //Nom de colonne pour l'ID
            entity.Property(o => o.Id)
            .HasColumnName("PK_Object");
            //Création de la relation one-to-Many avec Objets
            //L'entité Object a UN SEUL propriétaire (user)
            entity.HasOne(o => o.Owner)
            //Le propriétaire (user) a plusieurs objets
            .WithMany(u => u.Objects)
            //La clé étrangère dans la table object est IdOwner
            .HasForeignKey(o => o.IdOwner).OnDelete(DeleteBehavior.NoAction);
            //Précision du nom de colonne pour la propriété IdOwner
            entity.Property(o => o.IdOwner)
            .HasColumnName("FK_User");

            //Création de la relation many-to-one avec photos
            //L'entité objet a plusieurs photos
            entity.HasMany(o => o.Photos)
            //Une photo a un seul objet associé
            .WithOne(p => p.Object)
            //La clé étrangère dans la table photo est IdObject
            .HasForeignKey(p => p.IdObject).OnDelete(DeleteBehavior.NoAction);

        });

    //PHOTO
    modelBuilder.Entity<PhotoDAO>(entity =>
    {
        entity.HasKey(c => c.Id);
        entity.ToTable("TBL_Photos");

        entity.Property(p => p.Id)
        .HasColumnName("PK_Photo");

    });

    //EMPRUNT
    modelBuilder.Entity<LoanDAO>(entity =>
    {
        entity.HasKey(c => c.Id);
        entity.ToTable("TBL_Emprunt");
        entity.Property(l => l.Id)
        .HasColumnName("PK_Emprunt");
        entity.HasOne(l => l.Borrower)
        .WithMany(u => u.Loans)
        .HasForeignKey(l => l.IdBorrower).OnDelete(DeleteBehavior.NoAction);

    });


};

//Seeding de la base de données grâce au seedDelegate fourni par le DbContext
SeedDataDelegate seedData = (modelBuilder) =>
{
    //USER
    //Création d'un utilisateur de test 
    //Création d'un hasher de mot de passe pour l'utilisateur
    var passHasher = new PasswordHasher<UserDAO>();
    var jeanAccount = new UserDAO()
    {
        UserName = "JeanBen10",
        Email = "ben@yahoo.fr"
    };
    //Hashage du mot de passe "TestPwd"
    var hash = passHasher.HashPassword(jeanAccount, "MdpJean");
    jeanAccount.PasswordHash = hash;
    //Création du SecurityStamp (obligatoire avec Identity)
    jeanAccount.SecurityStamp = DateTime.Now.ToString();
    modelBuilder.Entity<UserDAO>().HasData(jeanAccount);

    var marieAccount = new UserDAO() { UserName = "MarieP", Email = "pegnie_marie@gmail.com" };
    var passHasher2 = new PasswordHasher<UserDAO>();
    var hash2 = passHasher.HashPassword(marieAccount, "MdpMarie");
    marieAccount.PasswordHash = hash2;
    marieAccount.SecurityStamp = DateTime.Now.ToString();
    modelBuilder.Entity<UserDAO>().HasData(marieAccount);

    var soniaAccount = new UserDAO() { UserName = "SoniaL", Email = "sonialefevre@live.fr" };
    var passHasher3 = new PasswordHasher<UserDAO>();
    var hash3 = passHasher.HashPassword(soniaAccount, "MdpSonia");
    soniaAccount.PasswordHash = hash3;
    soniaAccount.SecurityStamp = DateTime.Now.ToString();
    modelBuilder.Entity<UserDAO>().HasData(soniaAccount);


    //Instanciation du nouvel utilisateur
    var userJean = new AppUserDAO()
    {
        UserName = jeanAccount.UserName,
        FirstName = "Jean",
        LastName = "Alou",
        Id = jeanAccount.Id,
    };
    modelBuilder.Entity<AppUserDAO>().OwnsOne(c => c.Address).HasData(new
    {
        AppUserDAOId = userJean.Id,
        Street = "13 rue de la truie qui file",
        ZipCode = "33200",
        City = "Bordeaux"
    });
    modelBuilder.Entity<AppUserDAO>().HasData(userJean);

    var userMarie = new AppUserDAO()
    {
        UserName = marieAccount.UserName,
        FirstName = "Marie",
        LastName = "Pegnie",
        Id = marieAccount.Id,
    };
    modelBuilder.Entity<AppUserDAO>().OwnsOne(c => c.Address).HasData(new
    {
        AppUserDAOId = userMarie.Id,
        Street = "12 rue des cieux",
        ZipCode = "33000",
        City = "Bordeaux"
    });
    modelBuilder.Entity<AppUserDAO>().HasData(userMarie);

    var userSonia = new AppUserDAO()
    {
        UserName = soniaAccount.UserName,
        FirstName = "Sonia",
        LastName = "Lefevre",
        Id = soniaAccount.Id,
    };
    modelBuilder.Entity<AppUserDAO>().OwnsOne(c => c.Address).HasData(new
    {
        AppUserDAOId = userSonia.Id,
        Street = "80 rue de Lacanau",
        ZipCode = "33200",
        City = "Bordeaux"
    });
    modelBuilder.Entity<AppUserDAO>().HasData(userSonia);


    //OBJET
    var objectMarteau = new ObjectDAO()
    {
        Label = "Mon joli marteau",
        State = (int)StateObject.BrandNew,
        Description = "Je prête mon marteau, il est super, c'est le meilleur marteau de la Terre",
        IdOwner = userJean.Id,
        Value = 22.88,
    };
    modelBuilder.Entity<ObjectDAO>().HasData(objectMarteau);

    var objectSmartphone = new ObjectDAO()
    {
        Label = "Un smartphone performant !",
        State = (int)StateObject.MediumState,
        Description = "Je prête mon Smartphone car je suis très gentil. Son état est moyen, il y a quelques rayures.",
        IdOwner = userJean.Id,
        Value = 199.99,
    };
    modelBuilder.Entity<ObjectDAO>().HasData(objectSmartphone);

    var objectVisseuseElec = new ObjectDAO()
    {
        Label = "Visseuse électrique",
        State = (int)StateObject.GoodState,
        Description = "Je prête ma visseuse électrique. Elle est en bon état et est très pratique pour monter des meubles",
        IdOwner = userMarie.Id,
        Value = 80,
    };
    modelBuilder.Entity<ObjectDAO>().HasData(objectVisseuseElec);

    var caisseTransportChien = new ObjectDAO()
    {
        Label = "Caisse de transport pour petit chien",
        State = (int)StateObject.GoodState,
        Description = "Je prête ma caisse de transport pour chien. De type Vary Kennel, elle peut transporter un chien jusqu'à 17kg.",
        IdOwner = userSonia.Id,
        Value = 120,
    };
    modelBuilder.Entity<ObjectDAO>().HasData(caisseTransportChien);


    //PHOTO
    var photoMarteau1 = new PhotoDAO();
    using (var streamMarteau1 = File.OpenRead(@"C:\Users\MARIE PEGNIE\Desktop\Nouveau dossier (3)\Photos\marteau1.jpg"))
    {
        var reader = new BinaryReader(streamMarteau1);
        photoMarteau1.File = reader.ReadBytes((int)streamMarteau1.Length);
    }
    photoMarteau1.Comment = "Photo d'un marteau 1";
    photoMarteau1.IdObject = objectMarteau.Id;
    modelBuilder.Entity<PhotoDAO>().HasData(photoMarteau1);

    var photoMarteau2 = new PhotoDAO();
    using (var streamMarteau2 = File.OpenRead(@"C:\Users\MARIE PEGNIE\Desktop\Nouveau dossier (3)\Photos\marteau2.jpg"))
    {
        var reader = new BinaryReader(streamMarteau2);
        photoMarteau2.File = reader.ReadBytes((int)streamMarteau2.Length);
    }
    photoMarteau2.Comment = "Photo d'un marteau 2";
    photoMarteau2.IdObject = objectMarteau.Id;
    modelBuilder.Entity<PhotoDAO>().HasData(photoMarteau2);

    var photoSmartphone = new PhotoDAO();
    using (var streamSmartphone = File.OpenRead(@"C:\Users\MARIE PEGNIE\Desktop\Nouveau dossier (3)\Photos\smartphone.jpg"))
    {
        var reader = new BinaryReader(streamSmartphone);
        photoSmartphone.File = reader.ReadBytes((int)streamSmartphone.Length);
    }
    photoSmartphone.Comment = "Photo d'un smartphone";
    photoSmartphone.IdObject = objectSmartphone.Id;
    modelBuilder.Entity<PhotoDAO>().HasData(photoSmartphone);

    var photoVisseuse = new PhotoDAO();
    using (var streamVisseuse = File.OpenRead(@"C:\Users\MARIE PEGNIE\Desktop\Nouveau dossier (3)\Photos\visseuse.jpg"))
    {
        var reader = new BinaryReader(streamVisseuse);
        photoVisseuse.File = reader.ReadBytes((int)streamVisseuse.Length);
    }
    photoVisseuse.Comment = "Photo d'une visseuse électrique";
    photoVisseuse.IdObject = objectVisseuseElec.Id;
    modelBuilder.Entity<PhotoDAO>().HasData(photoVisseuse);

    var photoCaisseChien = new PhotoDAO();
    using (var streamCaisseChien = File.OpenRead(@"C:\Users\MARIE PEGNIE\Desktop\Nouveau dossier (3)\Photos\caisse_chien.jpg"))
    {
        var reader = new BinaryReader(streamCaisseChien);
        photoCaisseChien.File = reader.ReadBytes((int)streamCaisseChien.Length);
    }
    photoCaisseChien.Comment = "Photo d'une caisse de transport pour chien";
    photoCaisseChien.IdObject = caisseTransportChien.Id;
    modelBuilder.Entity<PhotoDAO>().HasData(photoCaisseChien);
};


var builder = WebApplication.CreateBuilder(args);

//Ajout de l'injection de dépendance à MyDal
builder.Services.AddDbContext<MyDal>(options =>
{
    options.UseSqlServer("name=TROCBDD");
});
//Ajout des controlleurs
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<SeedDataDelegate>(seedData);
builder.Services.AddSingleton<CustomizeModelDelegate>(customizeModelDelegate);

//Ajout des services d'authentification avec Json Web Tokens
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
//Ajout des services liés à l'authentification
builder.Services.AddIdentity<UserDAO, RoleDAO>()
    .AddEntityFrameworkStores<MyDal>();

//Ajout du service de mapping
builder.Services.AddSingleton<IMapper>(configMapping.CreateMapper());

var app = builder.Build();

//Ajout des headers nécessaires pour pouvoir requêter depuis l'extérieur
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employe}/{action=Index}/{id?}");
app.Run();
