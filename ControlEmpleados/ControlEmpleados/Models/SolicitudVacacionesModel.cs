using ControlEmpleados.Consults;
using ControlEmpleados.Interfaces;

namespace ControlEmpleados.Models
{
    public class SolicitudVacacionesModel : ISolicitudVacacionesModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public SolicitudVacacionesModel(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public List<ConsultarSolicitudVacaciones>? ConsultarSolicitudes()
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/SolicitudVacaciones/ConsultarSolicitudes";

                HttpResponseMessage response = client.GetAsync(urlApi).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<ConsultarSolicitudVacaciones>>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return new List<ConsultarSolicitudVacaciones>();
            }
        }
    }
}
