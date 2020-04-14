using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Captions_Hide
{
    [Serializable]
    public class Payload
    {
        public int id { get; set; }
        public string word { get; set; }
        public string sw { get; set; }
        public string phonetic { get; set; }
        public string definition { get; set; }
        public string translation { get; set; }
        public string pos { get; set; }
        public int collins { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string oxford = null;
        //public int oxford { get; set; }
        public string tag { get; set; }
        public int bnc { get; set; }
        public int frq { get; set; }
        public string exchange { get; set; }

        [DefaultValue(null)]
        public string detail { get; set; }
        public string audio { get; set; }      

    }
}
