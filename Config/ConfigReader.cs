﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaraBot.Config
{
    internal class ConfigReader
    {
        public string token {  get; set; }
        public string prefix {  get; set; }

        public async Task readJSON()
        {
            using(StreamReader sr = new StreamReader("config.json"))
            {
                string json=await sr.ReadToEndAsync();
                JSONStructure data = JsonConvert.DeserializeObject<JSONStructure>(json);

                this.token = data.token;
                this.prefix = data.prefix;
            }
        }
    }

    internal sealed class JSONStructure
    {
        public string token { get; set; }
        public string prefix { get; set; }
    }
}
