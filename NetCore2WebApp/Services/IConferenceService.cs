using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2WebApp.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetById(int id);
        Task<StatisticsModel> GetStatistics();
        Task Add(ConferenceModel model);
    }
    public class ConferenceMemoryService: IConferenceService
    {
        private readonly List<ConferenceModel> ConferenceList;

        public ConferenceMemoryService()
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
        Task IConferenceService.Add(ConferenceModel model)
        {
            ConferenceList.Add(model);
            return Task.CompletedTask;
        }
        Task<IEnumerable<ConferenceModel>> IConferenceService.GetAll()
        {
            return Task.Run(()=> ConferenceList.AsEnumerable());
        }
        Task<ConferenceModel> IConferenceService.GetById(int id)
        {
            return Task.Run(() => ConferenceList.First(c => c.Id == id));
        }
        Task<StatisticsModel> IConferenceService.GetStatistics()
        {
            return Task.Run(() =>
            new StatisticsModel
            {
                NumberOfAttendees = ConferenceList.Sum(c => c.AttendeeTotal),
                AverageConferenceAttendees = (int)ConferenceList.Average(c => c.AttendeeTotal)
            }
            );
        }
    }
}
