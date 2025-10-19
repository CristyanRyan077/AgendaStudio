using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaApi.Models;
using AgendaApi.Infra;

namespace AgendaApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CriancasController : ControllerBase
    {
        private readonly AgendaContext _context;

        public CriancasController(AgendaContext context)
        {
            _context = context;
        }


    }
}