using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ArdalisRating
{
    internal class LoadPolicy
    {
        public Policy Load_Policy() {
            // load policy - open file policy.json
            string policyJson = File.ReadAllText("policy.json");

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
            return policy;
        }
    }
}
