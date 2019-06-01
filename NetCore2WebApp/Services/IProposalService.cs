using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2WebApp.Services
{
    public interface IProposalService
    {
        Task Add(ProposalModel model);
        Task<ProposalModel> Approve(int id);
        Task<IEnumerable<ProposalModel>> GetAll();
    }
    public class ProposalMemoryService: IProposalService
    {
        private readonly List<ProposalModel> ProposalList;
        public ProposalMemoryService()
        {
            ProposalList = new List<ProposalModel>();
            ProposalList.Add(
                new ProposalModel
                {
                    Id = 1,
                    Speaker = "Naruto Uzamaki",
                    Title = "Advanced Rasengan",
                    Approved = false
                }
                ) ;
            ProposalList.Add(
                new ProposalModel
                {
                    Id = 2,
                    Speaker = "Sasuke Uchiha",
                    Title = "Sharingan Mastery",
                    Approved = false
                }
                );
            ProposalList.Add(
                new ProposalModel
                {
                    Id = 2,
                    Speaker = "Shikamaru Nara",
                    Title = "Shadow Possesion Jutsu",
                    Approved = true
                }
                );
        }

        Task<ProposalModel> IProposalService.Approve(int id)
        {
            return Task.Run(() =>
            {
                var proposal = ProposalList.First(p => p.Id == id);
                proposal.Approved = true;
                return proposal;
            });
        }
        Task IProposalService.Add(ProposalModel model)
        {
            ProposalList.Add(model);
            return Task.CompletedTask;
        }
       
        Task<IEnumerable<ProposalModel>> IProposalService.GetAll()
        {
            return Task.Run(() => ProposalList.AsEnumerable());
        }
    }
}
