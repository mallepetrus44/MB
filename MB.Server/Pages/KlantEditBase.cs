﻿using BlazorInputFile;
using MB.Server.Services;
using MB.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MB.Server.Pages
{
    public class KlantEditBase : ComponentBase
    {
        [Inject]
        public IKlantDataService KlantDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string KlantId { get; set; }

        public InputText LastNameInputText { get; set; }

        public Klant Klant { get; set; } = new Klant();
    

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;     

            int.TryParse(KlantId, out var KlantID);

            if (KlantID == 0) //new Klant is being created
            {
                //add some defaults
                Klant = new Klant { };
            }
            else
            {
                Klant = await KlantDataService.GetKlantDetails(int.Parse(KlantId));
            }

            //CountryId = Klant.CountryId.ToString();
            //JobCategoryId = Klant.JobCategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            //Klant.CountryId = int.Parse(CountryId);
            //Klant.JobCategoryId = int.Parse(JobCategoryId);

            if (Klant.KlantId == 0) //new
            {
                var addedKlant = await KlantDataService.AddKlant(Klant);
                if (addedKlant != null)
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
                await KlantDataService.UpdateKlant(Klant);
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

        protected async Task DeleteKlant()
        {
            await KlantDataService.DeleteKlant(Klant.KlantId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Klantoverzicht");
        }

        public IFileListEntry File { get; set; }
        public async Task HandleFileSelected(IFileListEntry[] files)
        {
            File = files.FirstOrDefault();
            if (File != null)
            {
                var ms = new MemoryStream();
                await File.Data.CopyToAsync(ms);

                var content = new MultipartFormDataContent
             {
                 { new ByteArrayContent(ms.GetBuffer()), "\"upload\"", File.Name }
             };
                await KlantDataService.UploadKlantImage(content);
            }
        }
    }
}
