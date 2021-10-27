using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Serilog;

namespace FizzBuzzApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {

        private Clases.FizzBuzzer fizzBuzzer = new Clases.FizzBuzzer();

        // GET: api/FizzBuzz/23
        [HttpGet("{n}")]
        public ActionResult FizzBuzz(int n)
        {
            string contenidoDocumento = "";
            
            try
            {
                
                contenidoDocumento = fizzBuzzer.StartLoop(n);
                
            }
            catch(Exception e)
            {
                Log.Warning(e, e.Message);
            }

            return DownloadFile(contenidoDocumento);
        }

        

        
        public ActionResult DownloadFile(string texto)
        {

            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);

            try
            {
                tw.WriteLine(texto);
                tw.Flush();
                tw.Close();
                Log.Information("Documento creado con exito");
            }
            catch(Exception e)
            {
                Log.Warning(e, e.Message);
            }

            Log.Information("Documento listo para descargar");

            return File(memoryStream.GetBuffer(), "text/plain", "file.txt");
        }



    }
}
