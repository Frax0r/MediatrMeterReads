﻿using System;
using System.Linq;

namespace CSVMeterReadingsService.Features.Readings.Models
{
    public class MeterReadingDto : ValidationDto
    {
        public ulong AccountId { get; set; }

        public DateTime MeterReadingDateTime { get; set; }

        public string MeterReadValue { get; set; }

        public string UploadResult
        {
            get
            {
                return ValidationResult.IsValid 
                       ? "Uploaded successfully" 
                       : String.Join(", ", ValidationResult.Errors.Select(e => e.ErrorMessage));
            }

        }
    }
}
