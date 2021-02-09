using MB.Server.Services;
using MB.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MB.Server.Components
{
    public class QuickRegisterFotoModelBase : ComponentBase
    {
        public bool ShowDialog { get; set; }

        public FotoModel FotoModel { get; set; } = new FotoModel { };

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Inject]
        public IFotoModelDataService FotoModelDataService { get; set; }



        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            FotoModel = new FotoModel { };
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            await FotoModelDataService.AddFotoModel(FotoModel);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
