using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSServicio.Models;
using WSServicio.Models.Response;
using WSServicio.Models.Request;

namespace WSServicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (ServicioContext db = new ServicioContext())
                {
                    var lst = db.Clientes.OrderByDescending(d=>d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (ServicioContext db = new ServicioContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.Nombre;
                    oCliente.Telefono = oModel.Telefono;
                    oCliente.Empresa = oModel.Empresa;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)

            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        [HttpPut]
        public IActionResult Update(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (ServicioContext db = new ServicioContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.Id);
                    oCliente.Nombre = oModel.Nombre;
                    oCliente.Telefono = oModel.Telefono;
                    oCliente.Empresa = oModel.Empresa;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)

            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (ServicioContext db = new ServicioContext())
                {
                    Cliente oCliente = db.Clientes.Find(Id);
                    db.Remove(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)

            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
    }
}
