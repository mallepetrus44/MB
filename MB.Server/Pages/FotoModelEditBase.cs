using MB.Server.Services;
using MB.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;

namespace MB.Server.Pages
{
    public class FotoModelEditBase : ComponentBase
    {
        [Inject]
        public IFotoModelDataService FotoModelDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string FotoModelId { get; set; }

        public InputText LastNameInputText { get; set; }

        public FotoModel FotoModel { get; set; } = new FotoModel();

        ////needed to bind to select to value
        //protected string CountryId = string.Empty;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        //public List<Country> Countries { get; set; } = new List<Country>();

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            //Countries = (await CountryDataService.GetAllCountries()).ToList();       

            int.TryParse(FotoModelId, out var FotoModelID);

            if (FotoModelID == 0) //new Customer is being created
            {
                //add some defaults
                FotoModel = new FotoModel { };
            }
            else
            {
                FotoModel = await FotoModelDataService.GetFotoModelDetails(int.Parse(FotoModelId));
            }

            //CountryId = Customer.CountryId.ToString();
            //JobCategoryId = Customer.JobCategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            //Customer.CountryId = int.Parse(CountryId);
            //Customer.JobCategoryId = int.Parse(JobCategoryId);

            if (FotoModel.FotoModelId == 0) //new
            {
                var addedFotoModel = await FotoModelDataService.AddFotoModel(FotoModel);
                if (addedFotoModel != null)
                {
                    StatusClass = "alert-success";
                    Message = "Nieuwe klant succesvol toegevoegd.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Er is iets misgegaan tijdens het aanmaken van een nieuwe klant. Probeer het opnieuw.";
                    Saved = false;
                }
            }
            else
            {
                await FotoModelDataService.UpdateFotoModel(FotoModel);
                StatusClass = "alert-success";
                Message = "Klantgegevens zijn succesvol bijgewerkt.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteCustomer()
        {
            await FotoModelDataService.DeleteFotoModel(FotoModel.FotoModelId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/CustomerOverview");
        }
    }
}
