using BlazorPeliculasCurso.Shared.Entidades;
using Microsoft.JSInterop;


namespace BlazorPeliculasCurso.Client.Helpers
{
    public static class IJSSRuntimeExtensionMethods
    {
        public static async ValueTask<bool> Confirm (this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync ("console.log", "prueba de console log");
            return await js.InvokeAsync<bool>("confirm", message);
        }
    }
}
