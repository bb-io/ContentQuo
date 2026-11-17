using Apps.ContentQuo.Models.Requests;
using Apps.ContentQuo.Models.Responses;
using Apps.ContentQuo.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;

namespace Apps.ContentQuo.Actions;

[ActionList("Bilingual files")]
public class BilingualFilesActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient)
    : ContentQuoInvocable(invocationContext)
{
    [Action("Upload bilingual file", Description = "Upload bilingual file")]
    public async Task<UploadFileResponse> UploadFile([ActionParameter] GetEvaluationRequest input,
        [ActionParameter] UploadFileRequest uploadFile)
    {
        var file = await fileManagementClient.DownloadAsync(uploadFile.File);

        var request = new RestRequest($"/evaluations/{input.Id}/files", Method.Post);
        request.AddFile("file", () => file, uploadFile.File.Name);
        request.AddParameter("fileUri",
            (uploadFile.FilePath != null ? uploadFile.FilePath + "/" : "") + uploadFile.File.Name);
        request.AddParameter("ref", uploadFile.IsRef ?? false);
        var response = await Client.ExecuteWithErrorHandling<UploadFileResponse>(request);
        return response;
    }

    [Action("Download bilingual file", Description = "Download bilingual file")]
    public async Task<DownloadFileResponse> DownloadFile([ActionParameter] GetEvaluationRequest input,
        [ActionParameter] DownloadFileRequest uploadFile)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/files/{uploadFile.FileId}", Method.Get);
        var response = await Client.ExecuteWithErrorHandling(request);
        var contentDisposition = response.ContentHeaders?
            .FirstOrDefault(x => string.Equals(x.Name, "Content-Disposition", StringComparison.OrdinalIgnoreCase))
            ?.Value?.ToString();
        var fileName = ContentDispositionFileNameParser.GetFileName(
            contentDisposition,
            $"{uploadFile.FileId}.xliff");

        var file = await fileManagementClient.UploadAsync(
            new MemoryStream(response.RawBytes ?? throw new PluginApplicationException(
                "ContentQuo returned an empty bilingual file response.")),
            response.ContentType ?? "application/octet-stream",
            fileName);
        return new()
        {
            File = file
        };
    }

    [Action("Delete bilingual file", Description = "Delete bilingual file")]
    public async Task DeleteBilingualFile([ActionParameter] GetEvaluationRequest input,
        [ActionParameter] DownloadFileRequest uploadFile)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/files/{uploadFile.FileId}", Method.Delete);
        await Client.ExecuteWithErrorHandling(request);
    }
}