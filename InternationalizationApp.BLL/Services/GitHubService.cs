using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.BLL.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly string GitPath = "D:/MyFiles/UselessShit/dyplom/InterantionalizationApp/InternationalizationApp-server/InternationalizationApp.BLL/AppData";
        private readonly string GitBranch = "origin/InternationalizationApp";
        public void CloneProject(string gitHubLink)
        {
            Repository.Clone(gitHubLink + ".git", GitPath);
        }

        public bool CheckBranch()
        {
            using (var repo = new Repository(GitPath))
            {
                var branch = repo.Branches[GitBranch];

                if (branch == null)
                {
                    return false;
                }

                Branch currentBranch = Commands.Checkout(repo, GitBranch);

                return true;
            }
        }

        public bool PushChanges()
        {
            using (var repo = new Repository(GitPath))
            {
                Commands.Stage(repo, "*");

                Signature author = new Signature("InternationalizationApp", "InternationalizationApp@gmail.com", DateTime.Now);
                Signature committer = author;

                Commit commit = repo.Commit("Translation from InternationalizationApp", author, committer);

                var currentBranch = repo.Branches[GitBranch];

                repo.Refs.UpdateTarget(currentBranch.Reference, commit.Id);

                PushOptions options = new PushOptions();

                options.CredentialsProvider = new CredentialsHandler(
                (url, usernameFromUrl, types) =>
                {
                    return new UsernamePasswordCredentials()
                    {
                        Username = "tarasbiletsky24",
                        Password = "123bil321"
                    };
                });

                repo.Network.Push(repo.Branches[GitBranch], options);

                return true;
            }
        }
    }
}
