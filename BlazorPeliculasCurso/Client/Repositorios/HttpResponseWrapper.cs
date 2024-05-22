using System.Net;

namespace BlazorPeliculasCurso.Client.Repositorios
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }
        public T? Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> ObtenerMensajeError() 
        {
            if (!Error)
            {
                return null;
            }else
            {
                var codeStatus = HttpResponseMessage.StatusCode;

                if (codeStatus == HttpStatusCode.NotFound)
                {
                    return "Recurso no encontrado";
                }//se espera que el error se encuentre en el cuerpo de la respuesta http
                else if (codeStatus == HttpStatusCode.BadRequest)
                {//devolver cuerpo como string
                    return await HttpResponseMessage.Content.ReadAsStringAsync();
                }
                //el usuario debe estar autenticado para realizar una accion
                else if (codeStatus == HttpStatusCode.Unauthorized)
                {
                    return "Debes loguearte para realizar esta accion";
                }//No se cuentan con los permisos para realizar una accion especifica
                else if (codeStatus == HttpStatusCode.Forbidden)
                {
                    return "No cuentas con los permisos para hacer esta acción";
                }//cualquier otro tipo de error
                else
                {
                    return "Ha ocurrido un error inesperado";
                }
            }
        }
    }
}
