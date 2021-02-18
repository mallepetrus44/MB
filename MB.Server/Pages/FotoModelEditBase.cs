
using BlazorInputFile;
using MB.Server.Services;
using MB.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;
using System.Linq;
using System.Net.Http;
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


        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
           

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

       
        }

        protected async Task HandleValidSubmit()
        {
           

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
            NavigationManager.NavigateTo("/fotomodeloverzicht");
        }




        // using BlazorInputFile library zorgt dat er gebruik gemaakt kan worden van de Interface IFileListEntry
        public IFileListEntry File { get; set; }


        // De InputFile tag in de html triggerd een onchange event HandleFileSelected
        // Welk bestand komt er binnen (NOG geen restricties geïmplementeerd)
        public async Task HandleFileSelected(IFileListEntry[] files)
        {
            File = files.FirstOrDefault();
            if (File != null)
            {
                // Een MemoryStream verwerkt data in het geheugen ipv op de schijf. Dit is sneller en zorgt ervoor dat het
                // bestand niet geblokkeerd wordt.

                var ms = new MemoryStream();

                // De interface IFileListEntry heeft een member Data (Een abstract class Stream)
                // De memoryStream gebruiken om de Data (Stream) in te kopiëren.
                await File.Data.CopyToAsync(ms);


                // MultipartFormDataContent aan maken (onderdeel van System.Net.Http)
                var content = new MultipartFormDataContent
             {
                    //  Bestand bufferen uit geheugen aan de hand van de MemoryStream
                 { new ByteArrayContent(ms.GetBuffer()), "\"Upload\"", File.Name }
             };

                // content (MultipartFormDataContent uit geheugen gebufferd) meegeven aan FotoModelDataService (method => UploadFotoModelImage)
                await FotoModelDataService.UploadFotoModelImage(content);
            }
        }
    }
}
