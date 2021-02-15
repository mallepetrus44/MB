using BlazorInputFile;
using System.Threading.Tasks;
namespace MB.Server.Services
{
    public interface IFileUpload
    {
        Task UploadAsync(IFileListEntry file);
    }
}