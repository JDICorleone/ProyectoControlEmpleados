﻿using ControlEmpleados.Consults;
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

        public List<ConsultarEmpleados>? ConsultarEmpleados()
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Empleados/ConsultarEmpleados";

                HttpResponseMessage response = client.GetAsync(urlApi).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<ConsultarEmpleados>>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return new List<ConsultarEmpleados>();
            }
        }


        public int AgregarEmpleado(Empleado entidad)
        {
            using (var client = new HttpClient())
            {
                string urlApi = _configuration.GetSection("Parametros:urlApi").Value + "/Empleados/AgregarEmpleado";


                JsonContent body = JsonContent.Create(entidad);

                HttpResponseMessage response = client.PostAsync(urlApi, body).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception("Excepción Web Api: " + response.Content.ReadAsStringAsync().Result);

                return 0;
            }
        }

    }
}
