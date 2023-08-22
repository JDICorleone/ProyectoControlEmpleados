using ControlEmpleados.Consults;
using ControlEmpleados.Entities;
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

        public int AgregarSolicitud(Solicitud_Vacaciones entidad)
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/SolicitudVacaciones/AgregarSolicitud";


                JsonContent body = JsonContent.Create(entidad);

                HttpResponseMessage response = client.PostAsync(urlApi, body).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return 0;
            }
        }

        public List<ConsultarSolicitudVacaciones>? ConsultarSolicitudesEmpleado(int id)
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/SolicitudVacaciones/ConsultarSolicitudesEmpleado"+"?id="+id;

                HttpResponseMessage response = client.GetAsync(urlApi).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<ConsultarSolicitudVacaciones>>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return new List<ConsultarSolicitudVacaciones>();
            }
        }


        public int cantidadVacaciones(DateTime FECHA_INICIO, DateTime FECHA_FINAL) {
            int dias = (FECHA_FINAL - FECHA_INICIO).Days + 1;
            return dias;
        }
    }
}
