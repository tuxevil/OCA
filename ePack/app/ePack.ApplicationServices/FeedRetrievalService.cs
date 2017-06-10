using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ePack.Core;
using Google.GData.Client;
using Microsoft.Practices.ServiceLocation;
using Nybble.Caching;
using ePack.Utils;

namespace ePack.ApplicationServices
{
    public class FeedRetrievalService : IFeedRetrievalService
    {
        private const string CacheFeedList = "FeedsList";

        public IList<Feed> FeedsList(int? quantity)
        {
            // Try to retrieve from cache
            string cacheKey = CacheFeedList + quantity;

            ICache cache = ServiceLocator.Current.GetInstance<ICache>();
            IList<Feed> lst = cache.Get<IList<Feed>>(cacheKey);
            if (lst != null)
                return lst;

            // TODO: Move hardcoded data to config file
            Service service = new Service("blogger", "ocaecommerce");
            service.Credentials = new GDataCredentials(Config.GoogleUser, Config.GooglePass);
            GDataGAuthRequestFactory factory = (GDataGAuthRequestFactory)service.RequestFactory;
            factory.AccountType = "GOOGLE";

            // Otherwise go get it
            lst = new List<Feed>();

            FeedQuery query = new FeedQuery();

            query.Uri = new Uri("http://www.blogger.com/feeds/default/blogs");

            AtomFeed feed = service.Query(query);
            foreach (AtomEntry entry in feed.Entries)
            {
                FeedQuery feedQuery = new FeedQuery();
                feedQuery.Uri = new Uri(entry.FeedUri);
                AtomFeed innerfeed = null;
                innerfeed = service.Query(feedQuery);

                foreach (AtomEntry innerentry in innerfeed.Entries)
                {
                   
                    Feed f = new Feed();

                    int feedStartIndex = innerentry.Id.AbsoluteUri.IndexOf("post-") + 5;
                    f.Id = innerentry.Id.AbsoluteUri.Substring(feedStartIndex);
                    f.Title = innerentry.Title.Text;
                    f.FeedData = innerentry.Content.Content;
                    f.FeedUrl = innerentry.AlternateUri.Content;
                    f.DatePublished = innerentry.Published;

                    if (quantity != null)
                    {
                        if (quantity.Value == 0)
                            break;
                        quantity--;
                    }
                    lst.Add(f);
                }
            }

            cache.Set(cacheKey, lst,new TimeSpan(0,20,0));
            return lst;
        }
    }
}
