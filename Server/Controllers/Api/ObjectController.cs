using DAL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("{controller}")]
public class ObjectController : ControllerBase
{
    private readonly MyDal db;
    private readonly IMapper mapper;

    public ObjectController(MyDal db, IMapper mapper)
    {
        this.db = db;
        this.mapper = mapper;
    }

    //Correspondra sur Postman ou sur le navigateur à l'url
    // http://localhost:5160/object
    //ATTENTION - vérifier le numéro de port dans le terminal
    [HttpGet("")]
    public SearchResultModel[] GetObjects()
    {
        var daos = db.Objects;
        var models = daos.Select(dao => new SearchResultModel()
        {
            Id = dao.Id,
            Label = dao.Label,
            Indication = dao.State.ToString(),
            ShortDescription = (dao.Description.Substring(0, 30) + "...")
        }).ToArray();
        return models;
    }

    //Correspondra sur Postman ou sur le navigateur à l'url
    // http://localhost:5160/object/3b166c08-fbf3-4528-b263-1e2eb1533f9c
    //ATTENTION - vérifier le numéro de port dans le terminal
    [HttpGet("{id:guid}")]
    public ObjectModel GetOneObject(Guid id)
    {
        var dao = db.Objects.Include(c => c.Photos).Include(c => c.Owner).FirstOrDefault(c => c.Id == id);
        var model = mapper.Map<ObjectModel>(dao);
        // var model = new ObjectModel()
        // {
        //     Id = dao.Id,
        //     Label = dao.Label,
        //     State = dao.ObjectState,
        //     Description = dao.Description,
        //     IdOwner = dao.IdOwner,
        //     Value = dao.Value,
        //     UploadDate = dao.UploadDate,
        //     Photos = mapper.Map<IEnumerable<PhotoModel>>(dao.Photos)

        // };
        return model;
    }

}