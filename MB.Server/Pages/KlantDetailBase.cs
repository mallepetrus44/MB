using MB.Server.Services;
using MB.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MB.Server.Pages
{
    public class KlantDetailBase : ComponentBase
    {
        [Inject]
        public IKlantDataService KlantDataService { get; set; }

        [Parameter]
        public string KlantId { get; set; }

        public Klant Klant { get; set; } = new Klant();

        protected override async Task OnInitializedAsync()
        {
            Klant = await KlantDataService.GetKlantDetails(int.Parse(KlantId));

        }
    }
}
