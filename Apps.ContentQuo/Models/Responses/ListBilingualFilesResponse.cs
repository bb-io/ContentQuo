using Apps.ContentQuo.Dtos;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.Models.Responses
{
    public class ListBilingualFilesResponse
    {
        [Display("Bilingual files")]
        public List<BilingualFileDto> BilingualFiles { get; set; }
    }
}
