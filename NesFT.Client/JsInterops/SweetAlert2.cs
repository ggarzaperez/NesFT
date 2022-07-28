using Microsoft.JSInterop;

namespace NesFT.Client.JsInterops
{
    public class SweetAlert2
    {
        private static readonly string TOAST_FIRE = "Toast.fire";

        public IJSRuntime Javascript { get; }

        public SweetAlert2(IJSRuntime Javascript) {
            this.Javascript = Javascript;
        }

        public async Task Toast(object settings)
        {
            await Javascript.InvokeVoidAsync(TOAST_FIRE, new object[] { settings });
        }
    }
}
