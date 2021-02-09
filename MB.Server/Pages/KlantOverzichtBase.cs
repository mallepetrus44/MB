using MB.Server.Components;
using MB.Server.Services;
using MB.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.Server.Pages
{
    public class KlantOverzichtBase : ComponentBase
    {
        [Inject]
        public IKlantDataService KlantDataService { get; set; }
        public List<Klant> Klanten { get; set; }

        protected QuickRegisterKlant QuickRegisterKlant { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Klanten = (await KlantDataService.GetAllKlanten()).ToList();

        }

        public async void QuickRegisterKlant_OnDialogClose()
        {
            Klanten = (await KlantDataService.GetAllKlanten()).ToList();
            StateHasChanged();
        }

        protected void QuickAddKlant()
        {
            QuickRegisterKlant.Show();
        }
    }
}
