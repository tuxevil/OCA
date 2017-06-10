using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ePack.Core;

namespace ePack.ApplicationServices
{
    public interface IFeedRetrievalService
    {
        IList<Feed> FeedsList(int? quantity);
    }
}
