﻿using StarryEyes.Models;
using StarryEyes.Models.Backstages.TwitterEvents;

namespace StarryEyes.ViewModels.WindowParts.Backstages
{
    public class TwitterEventViewModel : BackstageEventViewModel
    {
        public TwitterEventViewModel(TwitterEventBase tev)
            : base(tev)
        {
        }

        public TwitterEventBase TwitterEvent
        {
            get { return this.SourceEvent as TwitterEventBase; }
        }

        public void OpenEventTargetUserProfile()
        {
            var ev = TwitterEvent;
            if (ev == null || ev.TargetUser == null) return;
            BackstageModel.RaiseCloseBackstage();
            SearchFlipModel.RequestSearch(ev.TargetUser.ScreenName, SearchMode.UserScreenName);
        }

        public void OpenEventTargetStatus()
        {
            var ev = TwitterEvent;
            if (ev == null || ev.TargetStatus == null) return;
            BackstageModel.RaiseCloseBackstage();
            SearchFlipModel.RequestSearch("?from conv:\"" + ev.TargetStatus.Id + "\"", SearchMode.Local);
        }

        public void OpenEventSourceUserProfile()
        {
            var ev = TwitterEvent;
            if (ev == null || ev.Source == null) return;
            BackstageModel.RaiseCloseBackstage();
            SearchFlipModel.RequestSearch(ev.Source.ScreenName, SearchMode.UserScreenName);
        }
    }
}