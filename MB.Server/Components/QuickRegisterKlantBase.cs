using MB.Server.Services;
using MB.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MB.Server.Components
{
    public class QuickRegisterKlantBase : ComponentBase
    {
        public bool ShowDialog { get; set; }

        public Klant Klant { get; set; } = new Klant { };

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Inject]
        public IKlantDataService KlantDataService { get; set; }

        

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Klant = new Klant { };
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            await KlantDataService.AddKlant(Klant);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
