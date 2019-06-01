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
        Task<IEnumerable<ProposalModel>> GetAll(int conferenceId);
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
                    ConferenceId =1,
                    Approved = false
                }
                ) ;
            ProposalList.Add(
                new ProposalModel
                {
                    Id = 2,
                    Speaker = "Sasuke Uchiha",
                    Title = "Sharingan Mastery",
                    ConferenceId =2,
                    Approved = false
                }
                );
            ProposalList.Add(
                new ProposalModel
                {
                    Id = 3,
                    Speaker = "Shikamaru Nara",
                    Title = "Shadow Possesion Jutsu",
                    ConferenceId =3,
                    Approved = true
                }
                );
            ProposalList.Add(
                new ProposalModel
                {
                    Id = 4,
                    Speaker = "Kiba",
                    Title = "Ninja Hounds",
                    ConferenceId = 3,
                    Approved = true
                }
                );
            ProposalList.Add(
                new ProposalModel
                {
                    Id = 5,
                    Speaker = "Shino",
                    Title = "Ninja Beetles",
                    ConferenceId = 3,
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
       
        Task<IEnumerable<ProposalModel>> IProposalService.GetAll(int conferenceId)
        {
            return Task.Run(() => ProposalList.Where(p => p.ConferenceId == conferenceId).AsEnumerable());
        }
    }
}
