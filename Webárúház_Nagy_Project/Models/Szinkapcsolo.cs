using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Szinkapcsolo
    {
        public int Id { get; set; }
        public int SzinKapcsoloId { get; set; }
        public int TermekSzinKapcsoloId { get; set; }

        [JsonIgnore]
        public virtual Szinek SzinKapcsolo { get; set; } = null!;
    }
}
