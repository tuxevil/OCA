using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace ePack.Core
{
    public class Feed
    {
        public virtual String Id
        { get; set; }

        public virtual string Title
        { get; set; }

        public virtual string FeedData
        { get; set; }

        public virtual string FeedUrl
        { get; set; }

        public virtual DateTime DatePublished
        { get; set; }

        public string FormattedTitle
        {
            get {
                if(Title.Length > 74)
                    return Title.Substring(0, 74)+"...";

                return Title;
            
            }
        }
    }
}
