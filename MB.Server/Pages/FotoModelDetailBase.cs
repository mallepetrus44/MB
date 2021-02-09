using MB.Server.Services;
using MB.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.Server.Pages
{
    public class FotoModelDetailBase : ComponentBase
    {
        [Inject]
        public IFotoModelDataService FotoModelDataService { get; set; }

        [Parameter]
        public string FotoModelId { get; set; }

        public FotoModel FotoModel { get; set; } = new FotoModel();

        protected override async Task OnInitializedAsync()
        {
            FotoModel = await FotoModelDataService.GetFotoModelDetails(int.Parse(FotoModelId));
        }
    }
}
