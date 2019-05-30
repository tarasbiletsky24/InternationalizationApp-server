using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.BLL.Services
{
    public interface IGitHubService
    {
        void CloneProject(string gitHubLink);

        bool CheckBranch();

        bool PushChanges();
    }
}
