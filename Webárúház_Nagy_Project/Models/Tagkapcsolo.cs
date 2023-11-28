using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Tagkapcsolo
    {
        public int Id { get; set; }
        public int TagKapcsoloId { get; set; }
        public int TermekTagKapcsoloId { get; set; }

        [JsonIgnore]
        public virtual Tagek TagKapcsolo { get; set; } = null!;
    }
}
