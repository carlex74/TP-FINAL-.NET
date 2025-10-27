using System.Net.Http;
using System.Text.Json;

namespace WindowsForms
{
    public static class ErrorHandler
    {
        public static void HandleError(Exception ex)
        {
            if (ex is HttpRequestException httpEx)
            {
                if (httpEx.StatusCode.HasValue)
                {
                    if (httpEx.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        try
                        {
                            int jsonStart = httpEx.Message.IndexOf('{');
                            if (jsonStart >= 0)
                            {
                                string jsonBody = httpEx.Message.Substring(jsonStart);
                                var apiError = JsonSerializer.Deserialize<ApiError>(jsonBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                                MessageBox.Show(apiError.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; 
                            }
                        }
                        catch
                        {
                            MessageBox.Show("La solicitud fue rechazada por el servidor. Verifique los datos ingresados.", "Solicitud Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                MessageBox.Show("No se pudo conectar con el servidor. Verifique que el servicio esté en línea y que su conexión a internet funcione.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Ha ocurrido un error inesperado en la aplicación:\n\n{ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}