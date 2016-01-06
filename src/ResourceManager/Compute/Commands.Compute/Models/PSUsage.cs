// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSUsage : PSOperation
    {
        // Gets or sets the current value of the usage.
        public int? CurrentValue { get; set; }

        // Gets or sets the limit of usage.
        public long? Limit { get; set; }

        // Gets or sets the name of the type of usage.
        public UsageName Name { get; set; }

        [JsonIgnore]
        public string NameText
        {
            get { return JsonConvert.SerializeObject(Name, Formatting.Indented); }
        }

        // Gets or sets an enum describing the unit of measurement.
        public UsageUnit? Unit { get; set; }

        [JsonIgnore]
        public string UnitText
        {
            get { return JsonConvert.SerializeObject(Unit, Formatting.Indented); }
        }
    }
}
