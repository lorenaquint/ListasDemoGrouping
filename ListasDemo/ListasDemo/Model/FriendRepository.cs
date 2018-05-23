using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation.ObjectHydrator;
using ListasDemo.Helpers;

namespace ListasDemo.Model
{
    public class FriendRepository
    {
        public IList<Friend> Friends { get; set; }

        public FriendRepository()
        {
			/*
            Hydrator<Friend> _friendHydrator
                = new Hydrator<Friend>();
            Friends = _friendHydrator.GetList(50);
            */
			Task.Run(async () => 
			         Friends = await App.Database.GetFriendsAsync()).Wait();
        }

        public IList<Friend> GetAll()
        {
            return Friends;
        }

        public IList<Friend> GetAllByFirstLetter(string letter)
        {
            var query = from q in Friends
                where q.FirstName.StartsWith(letter)
                select q;
            return query.ToList();
        }

        public 
            ObservableCollection
            <Grouping<string, Friend>> 
            GetAllGrouped()
        {
			IEnumerable<Grouping<string, Friend>> sorted = new Grouping<string, Friend>[0];

			if (Friends != null)
			{ sorted =
               from f in Friends
               orderby f.FirstName
               group f by f.FirstName[0].ToString()
                into theGroup
               select
               new Grouping<string, Friend>
               (theGroup.Key, theGroup);
			}
		   

            return new 
                ObservableCollection
                <Grouping<string, Friend>>(sorted);
        }

    }
}
