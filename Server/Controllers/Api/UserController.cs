using DAL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("{controller}")]
public class UserController : ControllerBase
{
    private readonly MyDal db;
    private readonly IMapper mapper;

    public UserController(MyDal db, IMapper mapper)
    {
        this.db = db;
        this.mapper = mapper;
    }

    //Correspondra sur Postman ou sur le navigateur à l'url
    // http://localhost:5160/user
    //ATTENTION - vérifier le numéro de port dans le terminal
    [HttpGet("")]
    public SearchResultModel[] GetUsers()
    {
        var daos = db.Users;
        var models = daos.Select(dao => new SearchResultModel()
        {
            Id = dao.Id,
            Label = dao.UserName,
            Indication = (dao.FirstName + " " + dao.LastName),
            ShortDescription = String.Format("Inscrit depuis le {0:dd MMMM yyyy}", dao.DateInscription)

        }).ToArray();
        return models;
    }

    //Correspondra sur Postman ou sur le navigateur à l'url
    // http://localhost:5160/user/48ae1f88-2019-4105-83a2-3a4267ebdf67
    //ATTENTION - vérifier le numéro de port dans le terminal
    //ATTENTION - récupérer le guid depuis la route /user
    [HttpGet("{id:guid}")]
    public UserModel GetOneUser(Guid id)
    {
        var dao = db.Users.Include(u => u.Objects).FirstOrDefault(u => u.Id == id);
        var model = mapper.Map<UserModel>(dao);
        return model;
    }

    //Correspondra par exemple sur postman ou dans le navigateur à la route
    // http://localhost:5160/User/48ae1f88-2019-4105-83a2-3a4267ebdf67/Objects
    //ATTENTION - changer le GUID d'après la route GetUsers
    [HttpGet("{id:guid}/Objects")]
    public ActionResult<SearchResultModel[]> ListObjects(Guid id)
    {
        var user = db.Users.Include(u => u.Objects).FirstOrDefault(u => u.Id == id);

        if (user == null) { return NotFound(); }
        var objs = user.Objects;
        var models = objs.Select(obj => new SearchResultModel()
        {
            Id = obj.Id,
            Label = obj.Label,
            Indication = obj.State.ToString(),
            ShortDescription = (obj.Description.Substring(0, 30) + "...")
        });

        return Ok(models);

    }

    [HttpPost("{id:guid}/Objects/add")]
    public async Task<object> AddObject(Guid id, [FromBody] ObjectModel obj)
    {
        if (!ModelState.IsValid)
        {
            var errMessages = ModelState.SelectMany(o => o.Value.Errors).Select(o => o.ErrorMessage).ToArray();
            return BadRequest(errMessages);
        }
        var dao = mapper.Map<ObjectDAO>(obj);
        db.Objects.Add(dao);
        dao.IdOwner = id;
        await db.SaveChangesAsync();
        return Ok(true);
    }
}