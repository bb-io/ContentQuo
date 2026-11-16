using Apps.ContentQuo.Models.Requests;
using Apps.ContentQuo.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using System.Net.Mime;
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
        var contentDisposition =
            new ContentDisposition(response.ContentHeaders.FirstOrDefault(x => x.Name == "Content-Disposition")
                .Value.ToString());

        var file = await fileManagementClient.UploadAsync(new MemoryStream(response.RawBytes), response.ContentType, contentDisposition.FileName);
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