using MB.Server.Components;
using MB.Server.Services;
using MB.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.Server.Pages
{
    public class FotoModelOverzichtBase : ComponentBase
    {
        [Inject]
        public IFotoModelDataService FotoModelDataService { get; set; }
        public List<FotoModel> FotoModellen { get; set; }

        protected QuickRegisterFotoModel QuickRegisterFotoModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            FotoModellen = (await FotoModelDataService.GetAllFotoModellen()).ToList();
        }

        public async void QuickRegisterFotoModel_OnDialogClose()
        {
            FotoModellen = (await FotoModelDataService.GetAllFotoModellen()).ToList();
            StateHasChanged();
        }

        protected void QuickAddFotoModel()
        {
            QuickRegisterFotoModel.Show();
        }
    }
}
