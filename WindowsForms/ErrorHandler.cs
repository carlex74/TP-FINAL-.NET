using System.Text.Json;

namespace WindowsForms
{
    public static class ErrorHandler
    {
        public static void HandleError(Exception ex)
        {
            if (ex is HttpRequestException httpEx)
            {
                try
                {
                    int jsonStart = httpEx.Message.IndexOf('{');
                    if (jsonStart >= 0)
                    {
                        string jsonBody = httpEx.Message.Substring(jsonStart);
                        var apiError = JsonSerializer.Deserialize<ApiError>(jsonBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        MessageBox.Show(apiError.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch
                {
                }

                MessageBox.Show("No se pudo conectar con el servidor. Verifique su conexión o si el servicio está en línea.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error inesperado en la aplicación.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}