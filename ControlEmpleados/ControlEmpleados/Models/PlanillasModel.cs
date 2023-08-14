using ControlEmpleados.Consults;
using ControlEmpleados.Entities;
using ControlEmpleados.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ControlEmpleados.Models
{
    public class PlanillasModel : IPlanillasModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public PlanillasModel(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public List<ConsultarPlanillas>? ConsultarPlanillas()
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Planillas/ConsultarPlanillas";

                HttpResponseMessage response = client.GetAsync(urlApi).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<ConsultarPlanillas>>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return new List<ConsultarPlanillas>();
            }
        }
        public List<Planilla>? ConsultarPlanillas2()
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Planillas/ConsultarPlanillas2";

                HttpResponseMessage response = client.GetAsync(urlApi).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<Planilla>>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return new List<Planilla>();
            }
        }


        public int AgregarPlanilla(Planilla entidad)
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Planillas/AgregarPlanilla";

                var datosPlanilla = new
                {
                    entidad.FECHA,
                    entidad.ID_EMPLEADO,
                    entidad.HORAS_EXTRAS,
                    entidad.DEDUCCIONES,
                    entidad.SALARIO_NETO
                };

                JsonContent body = JsonContent.Create(datosPlanilla);

                HttpResponseMessage response = client.PostAsync(urlApi, body).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return 0;
            }
        }


        public int EditarPlanilla(Planilla entidad)
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Planillas/EditarPlanilla";

                JsonContent body = JsonContent.Create(entidad);

                HttpResponseMessage response = client.PutAsync(urlApi, body).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return 0;
            }
        }

    }
}
