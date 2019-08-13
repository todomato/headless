using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PForm.Model
{
    public class contentViewModel 
    {
        public string Article { get; set; }
        [JsonIgnore]
        public string CommentID { get; set; }
        public List<Comment> comments { get; set; }
    }
}
