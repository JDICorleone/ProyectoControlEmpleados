using ControlEmpleados.Entities;
using ControlEmpleados.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace ControlEmpleados.Models
{
    public class EmpleadosModel : IEmpleadosModel
    {

        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public EmpleadosModel(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public List<Empleado>? ConsultarEmpleados()
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Empleados/ConsultarEmpleados";

                HttpResponseMessage response = client.GetAsync(urlApi).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<Empleado>>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return new List<Empleado>();
            }
        }




    }
}
