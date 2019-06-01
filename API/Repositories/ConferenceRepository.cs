using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IConferenceRepository
    {
        Task<IEnumerable<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetById(int id);
        Task<ConferenceModel> Add(ConferenceModel model);
    }
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly List<ConferenceModel> ConferenceList;

        public ConferenceRepository()
        {
            ConferenceList = new List<ConferenceModel>();
            ConferenceList.Add(
                new ConferenceModel
                {
                    Id = 1,
                    Name = "TorCon",
                    Location = "Toronto",
                    AttendeeTotal = 1000
                }
                );
            ConferenceList.Add(
                new ConferenceModel
                {
                    Id = 2,
                    Name = "OttCon",
                    Location = "Ottawa",
                    AttendeeTotal = 2000
                }
                );
            ConferenceList.Add(
                new ConferenceModel
                {
                    Id = 3,
                    Name = "CalCon",
                    Location = "Calgary",
                    AttendeeTotal = 5000
                }
                );
        }
        Task<ConferenceModel> IConferenceRepository.Add(ConferenceModel model)
        {
            ConferenceList.Add(model);
            return Task.Run(() => model);
        }
        Task<IEnumerable<ConferenceModel>> IConferenceRepository.GetAll()
        {
            return Task.Run(() => ConferenceList.AsEnumerable());
        }
        Task<ConferenceModel> IConferenceRepository.GetById(int id)
        {
            return Task.Run(() => ConferenceList.First(c => c.Id == id));
        }
       
    }
}
