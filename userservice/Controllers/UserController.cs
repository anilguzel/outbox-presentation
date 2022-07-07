using System.Text;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using userservice.Entities;

namespace userservice.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly Publisher _publisher;
    public UserController(AppDbContext dbContext, Publisher publisher)
    {
        _dbContext = dbContext;
        _publisher = publisher;
    }

    [HttpGet]
    public IActionResult Get()
    {   
        var res = _dbContext.user.ToList();
        return Ok(res);
    }

    [HttpPost]
    public IActionResult Post()
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            var user = new User
            {
                id = 1,
                firstname = "A"
            };
            _dbContext.user.Add(user);
            _dbContext.SaveChanges();

            _publisher.Publish(user.firstname);

            transaction.Commit();
        }
        

        return Ok("ok user");
    }
}
