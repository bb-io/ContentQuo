using Apps.ContentQuo.Dtos;
using Apps.ContentQuo.Models.Requests;
using Apps.ContentQuo.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.ContentQuo.Actions
{
    public class BilingualFilesActions : BaseInvocable
    {
        #region Fields

        private readonly ContentQuoClient _client;

        #endregion

        public BilingualFilesActions(InvocationContext invocationContext) : base(invocationContext)
        {
            _client = new ContentQuoClient(invocationContext.AuthenticationCredentialsProviders);
        }

        [Action("List evaluations", Description = "List evaluations")]
        public async Task<ListBilingualFilesResponse> ListAllEvaluations([ActionParameter] GetEvaluationRequest input)
        {
            var request = new RestRequest($"/evaluations/{input.Id}/files", Method.Get);
            var response = await _client.ExecuteAsync<List<BilingualFileDto>>(request);
            return new ListBilingualFilesResponse() { BilingualFiles = response.Data };
        }

        [Action("Upload bilingual file", Description = "Upload bilingual file")]
        public async Task<UploadFileResponse> UploadFile([ActionParameter] GetEvaluationRequest input, [ActionParameter] UploadFileRequest uploadFile)
        {
            var request = new RestRequest($"/evaluations/{input.Id}/files", Method.Post);
            request.AddFile("file", uploadFile.File.Bytes, uploadFile.File.Name);
            request.AddParameter("fileUri", uploadFile.FilePath);
            request.AddParameter("ref", uploadFile.IsRef ?? false);
            var response = await _client.ExecuteAsync<UploadFileResponse>(request);
            return response.Data;
        }

        [Action("Download bilingual file", Description = "Download bilingual file")]
        public async Task<DownloadFileResponse> DownloadFile([ActionParameter] GetEvaluationRequest input, [ActionParameter] DownloadFileRequest uploadFile)
        {
            var request = new RestRequest($"/evaluations/{input.Id}/files/{uploadFile.Id}", Method.Get);
            var response = await _client.ExecuteAsync(request);
            var contentDisposition = 
                new ContentDisposition(response.ContentHeaders.FirstOrDefault(x => x.Name == "Content-Disposition").Value.ToString());
            return new DownloadFileResponse() 
            { 
                File = new File(response.RawBytes)
                {
                    Name = contentDisposition.FileName,
                }
            };
        }

        [Action("Delete bilingual file", Description = "Delete bilingual file")]
        public async Task DeleteBilingualFile([ActionParameter] GetEvaluationRequest input, [ActionParameter] DownloadFileRequest uploadFile)
        {
            var request = new RestRequest($"/evaluations/{input.Id}/files/{uploadFile.Id}", Method.Delete);
            await _client.ExecuteAsync(request);
        }
    }
}
