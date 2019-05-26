using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.DAL.Models
{
    public class Repository
    {
        public int RepositoryId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
