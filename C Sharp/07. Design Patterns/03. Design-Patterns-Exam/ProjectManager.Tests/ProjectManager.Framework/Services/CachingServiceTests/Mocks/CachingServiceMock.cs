using ProjectManager.Framework.Services;
using System;
using System.Collections.Generic;

namespace ProjectManager.Tests.ProjectManager.Framework.Services.Mocks
{
    public class CachingServiceMock : CachingService
    {
        public CachingServiceMock(TimeSpan duration)
            : base(duration)
        {
        }

        public IDictionary<string, object> CacheStorage
        {
            get
            {
                return this.Cache;
            }
        }

        public DateTime DateTimeExpiring
        {
            get
            {
                return this.TimeExpiring;
            }
        }
    }
}
