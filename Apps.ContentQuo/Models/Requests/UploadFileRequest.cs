﻿using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.ContentQuo.Models.Requests
{
    public class UploadFileRequest
    {
        public File File { get; set; }

        [Display("File path for uploading")]
        public string FilePath { get; set; }

        [Display("Is file reference")]
        public bool? IsRef { get; set; }
    }
}