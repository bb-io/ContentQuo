using Apps.ContentQuo.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.ContentQuo.Models.Responses;

public class ListBilingualFilesResponse
{
    [Display("Bilingual files")]
    public List<BilingualFileDto> BilingualFiles { get; set; }
}