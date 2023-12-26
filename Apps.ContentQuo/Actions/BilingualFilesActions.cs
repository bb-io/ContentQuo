using Apps.ContentQuo.Dtos;
using Apps.ContentQuo.Models.Requests;
using Apps.ContentQuo.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using System.Net.Mime;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;

namespace Apps.ContentQuo.Actions;

[ActionList]
public class BilingualFilesActions : BaseInvocable
{
    #region Fields

    private readonly ContentQuoClient _client;

    private readonly IFileManagementClient _fileManagementClient;

    #endregion


    public BilingualFilesActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) :
        base(
            invocationContext)
    {
        _fileManagementClient = fileManagementClient;
        _client = new ContentQuoClient(invocationContext.AuthenticationCredentialsProviders);
    }

    [Action("List evaluation files", Description = "List evaluation files")]
    public async Task<ListBilingualFilesResponse> ListAllEvaluationFiles(
        [ActionParameter] GetEvaluationRequest input)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/files", Method.Get);
        var response = await _client.ExecuteAsync<List<BilingualFileDto>>(request);
        return new ListBilingualFilesResponse() { BilingualFiles = response.Data };
    }

    [Action("Upload bilingual file", Description = "Upload bilingual file")]
    public async Task<UploadFileResponse> UploadFile([ActionParameter] GetEvaluationRequest input,
        [ActionParameter] UploadFileRequest uploadFile)
    {
        var file = await _fileManagementClient.DownloadAsync(uploadFile.File);

        var request = new RestRequest($"/evaluations/{input.Id}/files", Method.Post);
        request.AddFile("file", () => file, uploadFile.File.Name);
        request.AddParameter("fileUri",
            (uploadFile.FilePath != null ? uploadFile.FilePath + "/" : "") + uploadFile.File.Name);
        request.AddParameter("ref", uploadFile.IsRef ?? false);
        var response = await _client.ExecuteAsync<UploadFileResponse>(request);
        return response.Data;
    }

    [Action("Download bilingual file", Description = "Download bilingual file")]
    public async Task<DownloadFileResponse> DownloadFile([ActionParameter] GetEvaluationRequest input,
        [ActionParameter] DownloadFileRequest uploadFile)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/files/{uploadFile.Id}", Method.Get);
        var response = await _client.ExecuteAsync(request);
        var contentDisposition =
            new ContentDisposition(response.ContentHeaders.FirstOrDefault(x => x.Name == "Content-Disposition")
                .Value.ToString());

        var file = await _fileManagementClient.UploadAsync(new MemoryStream(response.RawBytes),
            MediaTypeNames.Application.Octet, contentDisposition.FileName);
        return new()
        {
            File = file
        };
    }

    [Action("Delete bilingual file", Description = "Delete bilingual file")]
    public async Task DeleteBilingualFile([ActionParameter] GetEvaluationRequest input,
        [ActionParameter] DownloadFileRequest uploadFile)
    {
        var request = new RestRequest($"/evaluations/{input.Id}/files/{uploadFile.Id}", Method.Delete);
        await _client.ExecuteAsync(request);
    }
}