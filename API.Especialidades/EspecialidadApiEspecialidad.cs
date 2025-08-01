﻿using DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Especialidades
{  
    public class EspecialidadApiEspecialidad
    {
        private static HttpClient especialidad = new HttpClient();
        static EspecialidadApiEspecialidad()
        {
            especialidad.BaseAddress = new Uri("http://localhost:5183/");
            especialidad.DefaultRequestHeaders.Accept.Clear();
            especialidad.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<EspecialidadDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await especialidad.GetAsync("especialidades/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<EspecialidadDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener especialidad con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener especialidad con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener especialidad con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<EspecialidadDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await especialidad.GetAsync("especialidades");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<EspecialidadDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de especialidades. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de especialidades: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de especialidades: {ex.Message}", ex);
            }
        }

        public async static Task AddAsync(EspecialidadDTO esp)
        {
            try
            {
                HttpResponseMessage response = await especialidad.PostAsJsonAsync("especialidades", esp);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear especialidad. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear especialidad: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear especialidad: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await especialidad.DeleteAsync("especialidades/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar especialidad con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar especialidad con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar especialidad con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(EspecialidadDTO esp)
        {
            try
            {
                HttpResponseMessage response = await especialidad.PutAsJsonAsync("especialidades", esp);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar especialidad con Id {esp.Id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar especialidad con Id {esp.Id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar especialidad con Id {esp.Id}: {ex.Message}", ex);
            }
        }
    }
}
