using Microsoft.AspNetCore.Mvc;
using WebFinalMinta.F1Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFinalMinta.Controllers
{
    [Route("api/f1")]
    [ApiController]
    public class F1Controller : ControllerBase
    {
        // GET: api/<F1Controller>
        [HttpGet]
        public IActionResult Get()
        {
            Forma1Context context = new Forma1Context();
            return Ok(context.Pilota.ToList());
        }

        // GET api/<F1Controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Forma1Context context = new Forma1Context();
            var driver = (from x in context.Pilota
                          where x.PilotaId == id
                          select x).FirstOrDefault();
            return Ok(driver);
        }

        // POST api/<F1Controller>
        [HttpPost]
        public void Post([FromBody] Pilotum newdriver)
        {
            Forma1Context context = new Forma1Context();
            context.Pilota.Add(newdriver);
            context.SaveChanges();
        }

        // PUT api/<F1Controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pilotum value)
        {
            Forma1Context context = new Forma1Context();
            var modositando = (from x in context.Pilota
                               where x.PilotaId == id
                               select x).FirstOrDefault();
            if (modositando == null)
            {
                return NotFound("Nincs ilyen");
            }

            modositando.Nev = value.Nev;
            modositando.Nemzetiseg = value.Nemzetiseg;
            modositando.SzuletesiDatum = value.SzuletesiDatum;

            context.SaveChanges();
            return Ok("Sikeres modositas");
        }

        // DELETE api/<F1Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Forma1Context context = new Forma1Context();
            var deleteDriver = (from x in context.Pilota
                                where x.PilotaId == id
                                select x).FirstOrDefault();
            context.Remove(deleteDriver);
            context.SaveChanges();
        }
    }
}
