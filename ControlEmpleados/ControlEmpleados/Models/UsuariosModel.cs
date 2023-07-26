using ControlEmpleados.Entities;
using ControlEmpleados.Interfaces;

namespace ControlEmpleados.Models
{

    public class UsuariosModel : IUsuariosModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public UsuariosModel(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public Usuario? ValidarUsuario(Usuario entidad)
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Login/ValidarUsuario";

                var datosUsuario = new
                {
                    entidad.CORREO,
                    entidad.PASSWORD
                };

                JsonContent body = JsonContent.Create(datosUsuario);

                HttpResponseMessage response = client.PostAsync(urlApi, body).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<Usuario>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return null;
            }
        }

        public void RecuperarContrasenna(Usuario entidad)
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Login/RecuperarContrasenna";


                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage response = client.PostAsync(urlApi, body).Result;
            }
        }

    }
}
