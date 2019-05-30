using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.BLL.Services
{
    public interface IFileService
    {
        Task<bool> CheckAllFiles(string finalLanguage, string originalLanguage);
        void DeleteWorkingFiles();
    }
}
