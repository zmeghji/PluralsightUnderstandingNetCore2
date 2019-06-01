using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IStatisticsRepository
    {
        Task<StatisticsModel> GetStatistics();
    }
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly IConferenceRepository ConferenceRepository;

        public StatisticsRepository(IConferenceRepository conferenceRepository)
        {
            this.ConferenceRepository = conferenceRepository;
        }

        Task<StatisticsModel> IStatisticsRepository.GetStatistics()
        {
            var conferences = ConferenceRepository.GetAll().Result;
            return Task.Run(() =>
            new StatisticsModel
            {
                NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)
            }
            );
        }
    }
}
