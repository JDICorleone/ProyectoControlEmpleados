using ControlEmpleados.Consults;
using ControlEmpleados.Entities;
using ControlEmpleados.Interfaces;

namespace ControlEmpleados.Models
{
    public class PuestosModel : IPuestosModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public PuestosModel(IConfiguration configuration, IHttpContextAccessor contextAccessor) {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public List<Puestos>? ConsultarPuestos()
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Puestos/ConsultarPuestos";

                HttpResponseMessage response = client.GetAsync(urlApi).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<Puestos>>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return new List<Puestos>();
            }
        }

        public int AgregarPuesto(Puestos entidad)
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Puestos/AgregarPuesto";


                JsonContent body = JsonContent.Create(entidad);

                HttpResponseMessage response = client.PostAsync(urlApi, body).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return 0;
            }
        }

        public int EditarPuesto(Puestos entidad)
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Puestos/EditarPuesto";

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
