using DAL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("{controller}")]

public class PhotoController : ControllerBase
{
    private readonly MyDal db;
    private readonly IMapper mapper;

    public PhotoController(MyDal db, IMapper mapper)
    {
        this.db = db;
        this.mapper = mapper;
    }

    //Correspondra sur Postman ou sur le navigateur à l'url
    // http://localhost:5160/photos
    //ATTENTION - vérifier le numéro de port dans le terminal
    [HttpGet("")]
    public PhotoModel[] GetPhotos()
    {
        var daos = db.Photos;
        var models = daos.Select(dao => new PhotoModel()
        {
            Id = dao.Id,
            File = dao.File,
            Comment = dao.Comment,
            IdObject = dao.IdObject
        }).ToArray();
        return models;
    }

    // [HttpGet("{id:guid}")]
    // public ObjectModel GetOnePhoto(Guid id)
    // {

    // }

}